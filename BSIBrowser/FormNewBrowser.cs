using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace BSIBrowser
{
    public partial class FormNewBrowser : Form
    {
        public FormNewBrowser()
        {
            InitializeComponent();
        }

        public WebBrowser NewBrowser
        {
            get {  return newBrowser; }
        }

        private void FormNewBrowser_Load(object sender, EventArgs e)
        {
            lblAppName.Text = Assembly.GetExecutingAssembly().GetName().Name;
            lblVersion.Text = String.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void emailSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:tyler@bsimail.com");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:tyler@bsimail.com");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new FormAbout();
            frmAbout.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}