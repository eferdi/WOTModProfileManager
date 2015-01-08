using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoTModProfileManager;

namespace WOTMPMNewProfileDialog
{
    public partial class newProfileDialog : Form
    {
        public newProfileDialog()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z0-9_]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Program.createNewProfile(textBox1.Text.ToString());
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
