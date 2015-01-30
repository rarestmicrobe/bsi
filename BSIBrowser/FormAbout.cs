using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace BSIBrowser
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            lblAppName.Text = Assembly.GetExecutingAssembly().GetName().Name;


            lblVersion.Text = String.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version);


            lblCopyright.Text = String.Format("Copyright © {0} Tyler Chambers", SetCopyrightText());
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
        }

        private static string SetCopyrightText()
        {
            const int firstYear = 2015;
            var currentYear = DateTime.Now.Year;
            string copyrightYear;

            if (currentYear == firstYear)
            {
                copyrightYear = firstYear.ToString(); // display year software was written only
                return copyrightYear;
            }
            copyrightYear = firstYear + " - " + currentYear; // display date range (written - current)
            return copyrightYear;
        }

        private void lnkGnu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:tyler@bsimail.com");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}