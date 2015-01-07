using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WOTModProfiles;
using System.IO;

namespace WoTModProfileManager
{
    static class Program
    {
        private static Form1 mainForm;
        private static String WOTPath = "";
        private static WoTInfo wot;
        private static Random rnd = new Random();
        //private static int lastParentID = 0;
        private static List<WOTProfile> profiles = new List<WOTProfile>();
        private static String linkedModFolder = "#-NO profile active, using default-#";
        private static String linkedModProfile = "#-NO profile active, using default-#";
        private static String modFolderPrefix = "wotmpm_";
        private static int modFolderPrefixLength = 0;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            mainForm = new Form1();
            wot = new WoTInfo();
            modFolderPrefixLength = (modFolderPrefix + wot.getGameVersion()).Length;

            if (wot.getWOTPath() != "no WoT installation found")
            {
                mainForm.log = "World of Tanks found in " + wot.getWOTPath();
            }
            else
            {
                mainForm.log = "World of Tanks not found, pleas set path manualy.";
            }

            mainForm.log = "WOTLauncher.exe version: " + wot.getLauncherVersion();
            mainForm.gameVersion = wot.getGameVersion();
            mainForm.log = "WorldOfTanks.exe version: " + wot.getGameVersion();
            mainForm.launcherVersion = wot.getLauncherVersion();
            String bla = SymbolicLink.GetTarget(wot.getModFolderPath());
            //modDB mods = new modDB();
            //mainForm.modListAll = mods.loadAll(WOTPath);

            String tmpLinkedModFolder = SymbolicLink.GetTarget(wot.getModFolderPath());
            if (tmpLinkedModFolder != null)
            {
                linkedModFolder = tmpLinkedModFolder;
            }
            
            loadProfiles();
            mainForm.populateDropDown(profiles);
            mainForm.populateTreeView(wot.getModFolderPath(), linkedModFolder);
            linkedModProfile = getProfileNameFromProfileFolder(linkedModFolder);
            mainForm.selectLinkedProfile(linkedModProfile);
            
            Application.Run(mainForm);
        }

        private static void loadProfiles()
        {
            string[] directoryArray = Directory.GetDirectories(wot.getResModsFolderPath());
            

            profiles.Add(new WOTProfile() { Name = "<select a profile>", Value = "" });
            foreach (String directory in directoryArray)
            {
                if(directory.Contains("wotmpm_"))// && File.Exists(directory + "profile_notes.txt"))
                {
                    String substrDirectory = directory.Substring( directory.LastIndexOf('\\') + 1, directory.Length - directory.LastIndexOf('\\') - 1);

                    String substrProfileName = getProfileNameFromProfileFolder(substrDirectory);
                    if (linkedModFolder == substrDirectory)
                    {
                        substrProfileName = substrProfileName + " #-ACTIVE-#";
                    }
                    profiles.Add(new WOTProfile() { Name = substrProfileName, Value = substrDirectory });
                }
            }
        }

        public static void loadProfileInfo(String profile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(wot.getResModsFolderPath() + profile + "\\profile_notes.txt"))
                {
                    String line = sr.ReadToEnd();
                    mainForm.profileNotes = line;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            mainForm.populateTreeView(wot.getModFolderPath(), profile);
        }

        public static void saveProfileNote(String profile, String note)
        {
            using (StreamWriter outfile = new StreamWriter(wot.getResModsFolderPath() + profile + "\\profile_notes.txt"))
            {
                outfile.Write(note);
            }
        }

        public static String getProfileNameFromProfileFolder(String folder)
        {
            return folder.Substring(modFolderPrefixLength + 1);
        }

        public static void startWOTWithSelectedProfile(String profile)
        {
            if (profile != SymbolicLink.GetTarget(wot.getModFolderPath()))
            {
                File.Delete(wot.getModFolderPath());
                SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), wot.getResModsFolderPath() + profile);
            }
            //start wot!
        }

        public static void startWOTWithoutMods()
        {
            if (wot.getGameVersion() + "_original" != SymbolicLink.GetTarget(wot.getModFolderPath()))
            {
                File.Delete(wot.getModFolderPath());
                SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), wot.getResModsFolderPath() + wot.getGameVersion() + "_original");
            }
            //start wot!
        }
    }
}
