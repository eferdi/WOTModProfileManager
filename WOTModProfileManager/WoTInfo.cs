using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Resources;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Diagnostics;
using System.IO;

namespace WoTModProfileManager
{
    class WoTInfo
    {
        private String gameEXE = "WorldOfTanks.exe";
        private String launcherEXE = "WOTLauncher.exe";
        private String modFolder = "res_mods";

        private String WOTPath = "no WoT installation found";
        private String gameVersion = "no version info";
        private String launcherVersion = "no version info";
        private String resModsFolderPath = "no res_mods folder";
        private String modFolderPath = "no mod folder";

        public WoTInfo()
        {
            // Save user prefs to reg.
            RegistryKey regKey = Registry.ClassesRoot;//.LocalMachine;
            //regKey = regKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{1EAC1D02-C6AC-4FA6-9A44-96258C37C812EU}_is1", RegistryKeyPermissionCheck.Default, rs);
            //regKey = regKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{1EAC1D02-C6AC-4FA6-9A44-96258C37C812EU}_is1");
            //regKey = regKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{1EAC1D02-C6AC-4FA6-9A44-96258C37C812}_is1"); //Wargaming removed the EU TODO: catch exception
            regKey = regKey.OpenSubKey(".wotreplay\\shell\\open\\command");
            string[] valueNames = regKey.GetValueNames();
            //WOTPath = (String) regKey.GetValue("InstallLocation", "ERROR");
            WOTPath = (String) regKey.GetValue(null, "ERROR");
            WOTPath = WOTPath.Substring(1, WOTPath.Length - 23);

            setGameVersion();
            setLauncherVersion();
            setResModsFolderPath();
            setModFolderPath();
        }

        public String getGameVersion()
        {
            return gameVersion;
        }

        public String getLauncherVersion()
        {
            
            return launcherVersion;
        }

        public String getWOTPath()
        {
            return WOTPath;
        }

        public String getResModsFolderPath()
        {
            return resModsFolderPath;
        }

        public String getModFolderPath()
        {
            return modFolderPath;
        }

        private void setGameVersion()
        {
            if (File.Exists(getGameExeFullPath()))
            {
                FileVersionInfo gameExeFileVersionInfo = FileVersionInfo.GetVersionInfo(getGameExeFullPath());
                gameVersion = gameExeFileVersionInfo.ProductVersion;
                gameVersion = gameVersion.Replace(", ", ".");
                int lastDot = gameVersion.LastIndexOf('.');
                gameVersion = gameVersion.Substring(0, (lastDot));
            }
            else
            {
                //TODO write log, inform user 
            }
        }

        private void setLauncherVersion()
        {
            if (File.Exists(getGameLauncherExeFullPath()))
            {
                FileVersionInfo launcherEXEFileVersionInfo = FileVersionInfo.GetVersionInfo(getGameLauncherExeFullPath());
                launcherVersion = launcherEXEFileVersionInfo.ProductVersion;
            }
            else
            {
                //TODO write log, inform user 
            }
        }

        private void setModFolderPath()
        {
            modFolderPath = resModsFolderPath + gameVersion + "\\";
        }

        private void setResModsFolderPath()
        {
            resModsFolderPath = WOTPath + modFolder + "\\";
        }

        public string getGameExeFullPath()
        {
            return WOTPath + gameEXE;
        }

        public string getGameLauncherExeFullPath()
        {
            return WOTPath + launcherEXE;
        }
    }
}
