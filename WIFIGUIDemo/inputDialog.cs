using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WIFIGUIDemo
{
    public partial class inputDialog : Form
    {
        public string IP
        {
            get;
            protected set;
        }

        public inputDialog()
        {
            InitializeComponent();
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            IP = txtIP.Text;
            this.Close();
        }

    }
}
