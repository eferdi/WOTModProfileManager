using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WOTMPMNewProfileDialog
{
    public partial class gameIsRunning : Form
    {
        public gameIsRunning()
        {
            InitializeComponent();

            this.CenterToParent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = String.Empty;
        }
    }
}
