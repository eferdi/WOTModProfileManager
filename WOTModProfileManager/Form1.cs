using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using WOTModProfiles;
using WoTModProfileManager;
using WOTMPMNewProfileDialog;

namespace WoTModProfileManager
{
    public partial class Form1 : Form
    {
       public TreeNode profileFolder
        { 
            set 
            {
                treeViewProfileFolder.Nodes.Add(value); 
            } 
        }

        public String log
        {
            set
            {
                String dateTime = DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss");
                String dT = "[" + dateTime.ToString() + "] ";
                richTextBoxLog.AppendText(dT + value + "\n");
            }
        }

        public String gameVersion
        {
            set
            {
                labelGameVersionNumber.Text = value;
            }
        }

        public String launcherVersion
        {
            set
            {
                labelLauncherVersionNumber.Text = value;
            }
        }

        public String profileNotes
        {
            set
            {
                richTextBoxProfileNotes.Text = value;
            }
            get
            {
                return richTextBoxProfileNotes.Text.ToString();
            }
        }

        public Form1()
        {
            InitializeComponent();
            comboBoxProfiles.SelectionChangeCommitted += new EventHandler(comboBoxProfiles_SelectionChangeCommitted);
            buttonStartWOTWMods.Click += new EventHandler(buttonStartWOTWMods_Click);
            buttonStartWOTWOMods.Click += new EventHandler(buttonStartWOTWOMods_Click);
            //richTextBoxProfileNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(richTextBoxProfileNotes_KeyPress);
        }

        /*public void addProfileFolderItem(String key, String text, int image)
        {
            treeViewProfileFolder.Nodes.Add(key,text,image);
        }*/

        public void populateTreeView(String path, String linkedProfile)
        {
            log = "Loading profile Folder '" + path + linkedProfile + "'";
            treeViewProfileFolder.Nodes.Clear();
            treeViewProfileFolder.Nodes.Add(linkedProfile);
            populateTreeView(path, treeViewProfileFolder.Nodes[0]);
            treeViewProfileFolder.Nodes[0].Expand();
        }

        private void populateTreeView(string directoryValue, TreeNode parentNode)
        {
            string[] directoryArray = Directory.GetDirectories(directoryValue);
            string[] fileArray = Directory.GetFiles(directoryValue);
            String substringDirectory; 
            String substringFile;

            try
            {
                if (directoryArray.Length != 0)
                {
                    foreach (string directory in directoryArray)
                    {
                        substringDirectory = directory.Substring( directory.LastIndexOf('\\') + 1, directory.Length - directory.LastIndexOf('\\') - 1);

                        TreeNode myNode = new TreeNode(substringDirectory);
                        parentNode.Nodes.Add(myNode);

                        populateTreeView(directory, myNode);
                    }
                }

                if (fileArray.Length != 0)
                {
                    foreach (string file in fileArray)
                    {
                        substringFile = file.Substring(file.LastIndexOf('\\') + 1, file.Length - file.LastIndexOf('\\') - 1);
                        TreeNode myNode = new TreeNode(substringFile);
                        parentNode.Nodes.Add(myNode);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                parentNode.Nodes.Add("#-Access denied-#");
            }
        }

        public void populateDropDown(List<WOTProfile> profilesList)
        {
            comboBoxProfiles.DataSource = null;
            comboBoxProfiles.DataSource = profilesList;
            comboBoxProfiles.DisplayMember = "Name";
            comboBoxProfiles.ValueMember = "Value";
            comboBoxProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
        } 
        
        private void comboBoxProfiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Program.loadProfile(comboBoxProfiles.SelectedValue.ToString());
        }

        private void richTextBoxProfileNotes_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs ex)
        {
            Program.saveProfileNote(comboBoxProfiles.SelectedValue.ToString(), richTextBoxProfileNotes.Text.ToString());
        }

        public void selectLinkedProfile(String profile)
        {
            int selin = comboBoxProfiles.Items.IndexOf(profile);
            comboBoxProfiles.SelectedIndex = comboBoxProfiles.FindString(profile);//.IndexOf(profile);
        }

        private void buttonStartWOTWMods_Click(object sender, EventArgs e)
        {
            Program.startWOTWithSelectedProfile(comboBoxProfiles.SelectedValue.ToString());
        }

        private void buttonStartWOTWOMods_Click(object sender, EventArgs e)
        {
            Program.startWOTWithoutMods();
        }

        private void buttonProfileNew_Click(object sender, EventArgs e)
        {
            newProfileDialog  nPD = new newProfileDialog();
            nPD.ShowDialog(this);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://klonk-clan.de");
        }

        private void buttonProfileDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you realy want to delete the profile '" + Program.getProfileNameFromProfileFolder(comboBoxProfiles.SelectedValue.ToString()) + "'?", "Realy?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Program.deleteProfile(comboBoxProfiles.SelectedValue.ToString());
            }
        }
    }   
}
