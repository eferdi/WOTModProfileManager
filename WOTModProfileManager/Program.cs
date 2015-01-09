using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WOTMPMNewProfileDialog;
using WOTModProfiles;
using System.IO;

namespace WoTModProfileManager
{
    static class Program
    {
        private static Form1 mainForm;
        //private static String WOTPath = "";
        private static WoTInfo wot;
        private static Random rnd = new Random();
        //private static int lastParentID = 0;
        private static List<WOTProfile> profiles = new List<WOTProfile>();
        private static String linkedModFolder = "#-NO profile active, using default-#";
        private static String linkedModProfile = "#-NO profile active, using default-#";
        private static String modFolderPrefix = "wotmpm_";
        private static int modFolderPrefixLength = 0;
        private static String profileNotesTxt = "profile_notes.txt";
        private static String emptyModFolder;
        private static String originalModFolder;
        private static String emptyModProfile;
        private static String originalModProfile;
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

            modFolderPrefixLength = (modFolderPrefix + wot.getGameVersion()).Length + 1;

            emptyModProfile = wot.getGameVersion() + "_empty";
            emptyModFolder = wot.getResModsFolderPath() + emptyModProfile;
            originalModProfile = modFolderPrefix + wot.getGameVersion() + "_ORIGINAL";
            originalModFolder = wot.getResModsFolderPath() + originalModProfile;

            if (wot.getWOTPath() != "no WoT installation found")
            {
                mainForm.log = "World of Tanks found in " + wot.getWOTPath();
            }
            else
            {
                mainForm.log = "WorldOfTanks.exe not found, this is bad, there is no way to path manualy!";
            }

            mainForm.log = "WOTLauncher.exe version: " + wot.getLauncherVersion();
            mainForm.gameVersion = wot.getGameVersion();
            mainForm.log = "WorldOfTanks.exe version: " + wot.getGameVersion();
            mainForm.launcherVersion = wot.getLauncherVersion();

            runSomeTests();

            loadProfilesList();
            loadProfile();                        

            Application.Run(mainForm);
        }

        private static void loadProfilesList()
        {
            profiles.Clear();
            string[] directoryArray = Directory.GetDirectories(wot.getResModsFolderPath());
            mainForm.log = "loading Profiles ...";

            profiles.Add(new WOTProfile() { Name = "<select a profile>", Value = "" });
            foreach (String directory in directoryArray)
            {
                if(directory.Contains("wotmpm_"))// && File.Exists(directory + "profile_notes.txt"))
                {
                    String substrDirectory = directory.Substring( directory.LastIndexOf('\\') + 1, directory.Length - directory.LastIndexOf('\\') - 1);

                    String substrProfileName = getProfileNameFromProfileFolder(substrDirectory);
                    if (linkedModFolder == substrDirectory)
                    {
                        mainForm.log = "... profile '" + substrProfileName + "' is active ...";
                        substrProfileName = substrProfileName + " #-ACTIVE-#";
                    }
                    profiles.Add(new WOTProfile() { Name = substrProfileName, Value = substrDirectory });
                }
            }
            mainForm.log = "... loading Profiles DONE.";
        }

        public static void loadProfileNote(String profile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(wot.getResModsFolderPath() + profile + "\\profile_notes.txt"))
                {
                    String line = sr.ReadToEnd();
                    mainForm.profileNotes = line;
                }
            }
            catch (Exception e)
            {
                mainForm.log = "Exception occured!";
                mainForm.log = "The file could not be read: " + e.Message;
            }
        }

        public static void saveProfileNote(String profile, String note)
        {
            try
            {
                using (StreamWriter outfile = new StreamWriter(wot.getResModsFolderPath() + profile + "\\" + profileNotesTxt))
                {
                    outfile.Write(note);
                }
            }
            catch (Exception e)
            {
                mainForm.log = "Exception occured!";
                mainForm.log = "The file could not be written: " + e.Message;
            }
        }

        public static String getProfileNameFromProfileFolder(String folder)
        {
            return folder.Substring(modFolderPrefixLength);
        }

        public static void startWOTWithSelectedProfile(String profile)
        {
            if (profile != SymbolicLink.GetTarget(wot.getModFolderPath()))
            {
                try 
                {	        
		            Directory.Delete(wot.getModFolderPath());
                    SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), wot.getResModsFolderPath() + profile);
                    mainForm.log = "Link to new mod folder '" + profile + "' created. Starting WoT ...";
                    loadProfilesList(); //reload profile list to mark new selected profile
                    startWot();
                    return;
                }
                catch (Exception ex)
                {
                    mainForm.log = "Exception occured!";
                    mainForm.log = ex.Message;
                    MessageBox.Show("Could not link the selected Profile, Sorry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }              
            }
            startWot();
           
        }

        public static void startWOTWithoutMods()
        {
            if (wot.getGameVersion() + "_empty" != SymbolicLink.GetTarget(wot.getModFolderPath()))
            {
                try
                {	 
                    Directory.Delete(wot.getModFolderPath());
                    SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), emptyModFolder);
                    mainForm.log = "Link to original mod folder '" + wot.getGameVersion() + "_original' created. Starting WoT ...";
                    loadProfilesList(); //reload profile list to mark new selected profile
                    startWot();
                    return;
                }
                catch (Exception ex)
                {
                    mainForm.log = "Exception occured!";
                    mainForm.log = ex.Message;
                    MessageBox.Show("Could not link the selected Profile, Sorry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                startWot();
            }
        }

        private static void loadProfile()
        {
            String tmpLinkedModFolder = SymbolicLink.GetTarget(wot.getModFolderPath());
            if (tmpLinkedModFolder != null)
            {

                linkedModFolder = tmpLinkedModFolder.Substring(tmpLinkedModFolder.LastIndexOf('\\') + 1);
            }
            else
            {
                DialogResult result = MessageBox.Show("This seems to be the first time you start WotModProfileManager or WoT was updated. So the MOD folder '" + wot.getGameVersion() + "' is not managed by WoTModProfileManager! Klick [YES] if you want to use this folder as the original folder (already installed MODs won't be deleted) or [NO] and we delete it and create a new one (already installed MODs will be lost!).", "This is new, isn't it?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    Environment.Exit(1);
                }

                if (!Directory.Exists(emptyModFolder))
                {
                    Directory.CreateDirectory(emptyModFolder);
                    StreamWriter sw = File.CreateText(emptyModFolder + "\\" + profileNotesTxt);
                    sw.Write("Empty profile, no MODs will be loaded");
                    sw.Close();
                }

                if (result == DialogResult.Yes)
                {
                    if (!Directory.Exists(originalModFolder))
                    {
                        Directory.Move(wot.getModFolderPath(), originalModFolder);
                        StreamWriter sw = File.CreateText(originalModFolder + "\\" + profileNotesTxt);
                        sw.Write("ORIGINAL MOD folder which existed as WoTModProfileManager was started the first time.");
                        sw.Close();
                        SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), originalModFolder);
                        loadProfile();
                    }
                    else
                    {
                        String rndBackupFolder = originalModProfile + "_backup_" + (new Random().Next(100, 999).ToString());
                        Directory.Move(wot.getModFolderPath(), (wot.getResModsFolderPath() + rndBackupFolder));
                        StreamWriter sw = File.CreateText(originalModFolder + "\\" + profileNotesTxt);
                        sw.Write("ORIGINAL MOD folder (COPY! because there was already one) which existed as WoTModProfileManager was started the first time.");
                        sw.Close();
                        MessageBox.Show("ORIGINAL profile Folder already existet, I created a nother copy and named it '" + rndBackupFolder + "'", "Magic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mainForm.log = "ORIGINAL profile Folder already existet, I created a nother copy and named it '" + rndBackupFolder + "'";
                        SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), rndBackupFolder);
                        loadProfile();
                    }
                }
                else if (result == DialogResult.No)
                {
                    try
                    {
                        Directory.Delete(wot.getModFolderPath(), true);
                        SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), emptyModFolder);
                        loadProfile();
                    }
                    catch (Exception ex)
                    {
                        mainForm.log = "Exception occured!";
                        mainForm.log = ex.Message;
                        MessageBox.Show("Exception occured! See log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            loadProfile(linkedModFolder);
        }
        //private static void loadProfile(String profileName)

        public static void loadProfile(String profile)
        {
            //loadProfilesList();
            mainForm.populateDropDown(profiles);
            mainForm.populateTreeView(wot.getModFolderPath(), profile);
            loadProfileNote(profile);
            if (profile == emptyModProfile)
            {
                linkedModFolder = emptyModProfile;
            }
            else
            {
                linkedModProfile = getProfileNameFromProfileFolder(profile);
            }
            if (profile != emptyModProfile)
            {
                mainForm.selectLinkedProfile(profile.Substring(modFolderPrefixLength));
            }
        }

        public static void createNewProfile(String newProfileName)
        {
            try
            {
                String newProfile = modFolderPrefix + wot.getGameVersion() + "_" + newProfileName;
                String newProflePath = wot.getResModsFolderPath() + newProfile;
                
                String dt = DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss");
                Directory.CreateDirectory(newProflePath);
                StreamWriter sw = File.CreateText(newProflePath + "\\" + profileNotesTxt);
                sw.Write("Profile '" + newProfileName + "' created on " + dt);
                sw.Close();
                mainForm.log = "New Profile '" + newProfileName + "' created.";
                loadProfile(newProfile);
            }
            catch (Exception ex)
            {
                mainForm.log = "Exception occured!";
                mainForm.log = ex.Message;
                MessageBox.Show("Could not create the new Profiel, for details have a look at the log", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void deleteProfile(String profile)
        {
            try
            {
                String folderForDelete = wot.getResModsFolderPath() + profile;
                String accLinkedFolder = SymbolicLink.GetTarget(wot.getModFolderPath());
                if (folderForDelete == accLinkedFolder)
                {
                    Directory.Delete(wot.getModFolderPath());
                    while(Directory.Exists(wot.getModFolderPath()))
                    {
                        //do nothing, wait till delet is done
                    }
                    SymbolicLink.CreateDirectoryLink(wot.getModFolderPath(), emptyModFolder);
                }
                Directory.Delete(wot.getResModsFolderPath() + profile, true);
                mainForm.log = "Profile '" + profile + "' deleted!";
                loadProfile();
            }
            catch (Exception ex)
            {
                mainForm.log = "Exception occured!";
                mainForm.log = ex.Message;
                MessageBox.Show("Something went wrong, see log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void startWot()
        {
            System.Diagnostics.Process.Start(wot.getGameExeFullPath());
        }

        private static void runSomeTests()
        {
            //TODO Check if mod folder realy exists
            //TODO check if user is allowed to performe soft link actions
            //TODO buy me a coke
        }
    }
}
