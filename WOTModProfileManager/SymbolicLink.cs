using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.InteropServices;

// Code in this file courtesy of Troy Parsons
// http://troyparsons.com/blog/2012/03/symbolic-links-in-c-sharp/
// https://gist.github.com/Artfunkel/c5a642b90a3e7a65eb7d

namespace WoTModProfileManager
{
    /// <remarks>
    /// Refer to http://msdn.microsoft.com/en-us/library/windows/hardware/ff552012%28v=vs.85%29.aspx
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct SymbolicLinkReparseData
    {
        // Not certain about this!
        private const int maxUnicodePathLength = 260 * 2;

        public uint ReparseTag;
        public ushort ReparseDataLength;
        public ushort Reserved;
        public ushort SubstituteNameOffset;
        public ushort SubstituteNameLength;
        public ushort PrintNameOffset;
        public ushort PrintNameLength;
        public uint Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = maxUnicodePathLength)]
        public byte[] PathBuffer;
    }

    public static class SymbolicLink
    {
        private const uint genericReadAccess = 0x80000000;
        private const uint fileFlagsForOpenReparsePointAndBackupSemantics = 0x02200000;
        private const int ioctlCommandGetReparsePoint = 0x000900A8;
        private const uint openExisting = 0x3;
        private const uint pathNotAReparsePointError = 0x80071126;
        private const uint shareModeAll = 0x7; // Read, Write, Delete
        private const uint symLinkTag = 0xA000000C;
        private const int targetIsAFile = 0;
        private const int targetIsADirectory = 1;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern SafeFileHandle CreateFile(
            String lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CreateSymbolicLink(String lpSymlinkFileName, String lpTargetFileName, int dwFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            int nInBufferSize,
            IntPtr lpOutBuffer,
            int nOutBufferSize,
            out int lpBytesReturned,
            IntPtr lpOverlapped);

        public static void CreateDirectoryLink(String linkPath, String targetPath)
        {
            if (!CreateSymbolicLink(linkPath, targetPath, targetIsADirectory) || Marshal.GetLastWin32Error() != 0)
            {
                try
                {
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
                catch (COMException exception)
                {
                    throw new IOException(exception.Message, exception);
                }
            }
        }

        public static void CreateFileLink(String linkPath, String targetPath)
        {
            if (!CreateSymbolicLink(linkPath, targetPath, targetIsAFile))
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }

        public static bool Exists(String path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                return false;
            }
            string target = GetTarget(path);
            return target != null;
        }

        private static SafeFileHandle getFileHandle(String path)
        {
            return CreateFile(path, genericReadAccess, shareModeAll, IntPtr.Zero, openExisting,
                fileFlagsForOpenReparsePointAndBackupSemantics, IntPtr.Zero);
        }

        public static String GetTarget(String path)
        {
            if (String.IsNullOrEmpty(path))
                return null;

            SymbolicLinkReparseData reparseDataBuffer;

            using (SafeFileHandle fileHandle = getFileHandle(path))
            {
                if (fileHandle.IsInvalid)
                {
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }

                int outBufferSize = Marshal.SizeOf(typeof(SymbolicLinkReparseData));
                IntPtr outBuffer = IntPtr.Zero;
                try
                {
                    outBuffer = Marshal.AllocHGlobal(outBufferSize);
                    int bytesReturned;
                    bool success = DeviceIoControl(
                        fileHandle.DangerousGetHandle(), ioctlCommandGetReparsePoint, IntPtr.Zero, 0,
                        outBuffer, outBufferSize, out bytesReturned, IntPtr.Zero);

                    fileHandle.Close();

                    if (!success)
                    {
                        if (((uint)Marshal.GetHRForLastWin32Error()) == pathNotAReparsePointError)
                        {
                            return null;
                        }
                        Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }

                    reparseDataBuffer = (SymbolicLinkReparseData)Marshal.PtrToStructure(
                        outBuffer, typeof(SymbolicLinkReparseData));
                }
                finally
                {
                    Marshal.FreeHGlobal(outBuffer);
                }
            }
            if (reparseDataBuffer.ReparseTag != symLinkTag)
            {
                return null;
            }

            String target = Encoding.Unicode.GetString(reparseDataBuffer.PathBuffer,
                reparseDataBuffer.PrintNameOffset, reparseDataBuffer.PrintNameLength);

            return target;
        }

        public static String ConvertToHardPath(String path)
        {
            if (String.IsNullOrEmpty(path)) return path;

            var dir_info = new FileInfo(GetTarget(path) ?? path).Directory;
            var final_path = new List<String>();
            final_path.Add(Path.GetFileName(path));
            while (dir_info != null)
            {
                var symlink_target = GetTarget(dir_info.FullName);
                if (symlink_target != null)
                    dir_info = new DirectoryInfo(symlink_target);

                final_path.Add(dir_info.Name);
                dir_info = dir_info.Parent;
            }
            final_path.Reverse();
            return Path.Combine(final_path.ToArray());
        }
    }
}