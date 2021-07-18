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
        public Options()
        {
            InitializeComponent();

            // load settings
            txt7Zip.Text = Properties.Settings.Default.SevenZip_path;
            
            if (Properties.Settings.Default.Language < 0)
            {
                // default is english
                cmbBoxLang.SelectedIndex = 1;
            } else
            {
                // select selected language
                cmbBoxLang.SelectedIndex = Properties.Settings.Default.Language;
            }

            // load translations
            ResourceManager LocRM = new ResourceManager("AdvancedETS2Packer.Languages.Options", typeof(Options).Assembly);
            groupBox1.Text = LocRM.GetString("language");
            lblJazykAplikace.Text = LocRM.GetString("languageOfApp");

            label1.Text = LocRM.GetString("PathToConsole7zip");
            btnClose.Text = LocRM.GetString("Close");
            btnSave.Text = LocRM.GetString("Save");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // save settings
            Properties.Settings.Default.SevenZip_path = txt7Zip.Text;
            Properties.Settings.Default.Language = cmbBoxLang.SelectedIndex;
            Properties.Settings.Default.Save();

            // set language
            string language = "en-US";
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    language = "cs-CZ";
                    break;

                case 2:
                    language = "de-DE";
                    break;
            }

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            // close this form
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect7zip_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt7Zip.Text = openFileDialog1.FileName;
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }
    }
}
