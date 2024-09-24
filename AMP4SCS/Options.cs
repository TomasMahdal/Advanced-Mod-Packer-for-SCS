using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedETS2Packer
{
    public partial class Options : Form
    {
        /// <summary>
        /// It loads languages and loads settings into form.
        /// </summary>
        public Options()
        {
            InitializeComponent();

            // load settings
            txtArchiver.Text = Properties.Settings.Default.SCSArchiverPath;

            if (Properties.Settings.Default.Language < 0)
            {
                // default is english
                cmbBoxLang.SelectedIndex = 0;
            }
            else
            {
                // select selected language
                cmbBoxLang.SelectedIndex = Properties.Settings.Default.Language;
            }

            // load translations
            ResourceManager LocRM = new ResourceManager("AdvancedETS2Packer.Languages.Options", typeof(Options).Assembly);
            groupBox1.Text = LocRM.GetString("language");
            lblJazykAplikace.Text = LocRM.GetString("languageOfApp");

            label1.Text = LocRM.GetString("PathToArchiver");
            btnClose.Text = LocRM.GetString("Close");
            btnSave.Text = LocRM.GetString("Save");
        }

        /// <summary>
        /// This method save settings.
        /// </summary>
        /// <remarks>Save user settings, set selected language as current language and close form.</remarks>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // save settings
            Properties.Settings.Default.SCSArchiverPath = txtArchiver.Text;
            Properties.Settings.Default.Language = cmbBoxLang.SelectedIndex;
            Properties.Settings.Default.Save();

            // set language
            Languages.CultureGenerator.SetCultureFromProperties();

            // close this form
            this.Close();
        }

        /// <summary>
        /// This method only close form. It does not save anything.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This method is for selecting Archiver executable by OpenFileDialog.
        /// </summary>
        private void btnSelectArchiver_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtArchiver.Text = openFileDialog1.FileName;
            }
        }
    }
}
