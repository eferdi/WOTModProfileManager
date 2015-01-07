using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoTModProfileManager
{
    class modDB
    {
        private Form1 mainForm = new Form1();
        private List<TreeNode> nodes = new List<TreeNode>();

        public TreeNode[] loadAll(String WoTPath)
        {
            
            /*/
            //get a list of the drives
            string[] drives = Environment.GetLogicalDrives();
                       
            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    //set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                //Form1.modListAll.Nodes.Add(node);

                //mainForm.modListAll = node;
                /*/
                WoTPath += "res_mods_repo\\";
                DirectoryInfo dir = new DirectoryInfo(WoTPath);
                foreach (DirectoryInfo modCat in dir.GetDirectories()) //TODO catch exception
                {
                    TreeNode node = new TreeNode(modCat.Name);
                    node.Tag = modCat;
                    
                    nodes.Add(node);
                }   

            return nodes.ToArray(); ;
        }
    }
}
