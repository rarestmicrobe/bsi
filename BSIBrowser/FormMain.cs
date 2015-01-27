using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using WebBrowser = SHDocVw.WebBrowser;

namespace BSIBrowser
{
    public partial class FormMain : Form
    {
        private WebBrowser _nativeBrowser;

        public FormMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblAppName.Text = Assembly.GetExecutingAssembly().GetName().Name;
            lblVersion.Text = String.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _nativeBrowser = (WebBrowser) webBrowser.ActiveXInstance;
            _nativeBrowser.NewWindow2 += nativeBrowser_NewWindow2;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _nativeBrowser.NewWindow2 -= nativeBrowser_NewWindow2;
            base.OnFormClosing(e);

            // Exit confirmation message
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            }
        }

        private void nativeBrowser_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            var popup = new FormNewBrowser();
            popup.Show(this);
            ppDisp = popup.NewBrowser.ActiveXInstance;
        }

        public static bool CloseCancel()
        {
            const string message = "Exit the BSI Browser?";
            const string caption = "EXIT?";

            var result = MessageBox.Show(message, caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
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
    }
}