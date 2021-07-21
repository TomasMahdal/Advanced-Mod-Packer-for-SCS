using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedETS2Packer
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize form
        /// </summary>
        /// <remarks>
        /// When is form showed, it run this function, which load version info and text into richtextbox.
        /// </remarks>
        private void About_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("AdvancedETS2Packer.about.txt"));
            string about = reader.ReadToEnd();

            txtAbout.Text = about;
        }

        /// <summary>
        /// When user click on link in richtextbox, then open it in web browser.
        /// </summary>
        private void txtAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // this is used here, because if you give link directly to Proccess.Start(), it throws error for no reason
            var ps = new ProcessStartInfo(e.LinkText)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
    }
}
