using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Resources;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Diagnostics;

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
            RegistryKey regKey = Registry.LocalMachine;
            //regKey = regKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{1EAC1D02-C6AC-4FA6-9A44-96258C37C812EU}_is1", RegistryKeyPermissionCheck.Default, rs);
            //regKey = regKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{1EAC1D02-C6AC-4FA6-9A44-96258C37C812EU}_is1");
            regKey = regKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{1EAC1D02-C6AC-4FA6-9A44-96258C37C812}_is1"); //Wargaming removed the EU TODO: catch exception
            string[] valueNames = regKey.GetValueNames();
            WOTPath = (String) regKey.GetValue("InstallLocation", "ERROR");

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
            FileVersionInfo gameExeFileVersionInfo = FileVersionInfo.GetVersionInfo(WOTPath + gameEXE);
            gameVersion = gameExeFileVersionInfo.ProductVersion;
            gameVersion = gameVersion.Replace(", ", ".");
            int lastDot = gameVersion.LastIndexOf('.');
            gameVersion = gameVersion.Substring(0, (lastDot));
        }

        private void setLauncherVersion()
        {
            FileVersionInfo launcherEXEFileVersionInfo = FileVersionInfo.GetVersionInfo(WOTPath + launcherEXE);
            launcherVersion = launcherEXEFileVersionInfo.ProductVersion;
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
    }
}
