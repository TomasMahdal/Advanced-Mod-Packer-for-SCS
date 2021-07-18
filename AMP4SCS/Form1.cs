using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedETS2Packer
{
    public partial class Form1 : Form
    {
        private Exporter exporter = new Exporter();

        public Form1()
        {
            // set language
            Languages.CultureGenerator.SetCultureFromProperties();

            // verify, if exists settings
            if (Properties.Settings.Default.SevenZip_path == "" || File.Exists(Properties.Settings.Default.SevenZip_path) == false)
            {
                Options options = new Options();
                options.ShowDialog();

                // Was set? No? Then exit application!
                if (Properties.Settings.Default.SevenZip_path == "")
                {
                    MessageBox.Show("7z not selected, app will close.", "7z not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }

            // set language
            Languages.CultureGenerator.SetCultureFromProperties();

            InitializeComponent();
            UpdateFormLanguage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // load mods and groups
            foreach(Template template in exporter.Templates)
            {
                // load mods
                listbox_mods.Items.Add(template.Name);

                // verify, if there is not group with this name
                // if isn't, then add this group as new
                bool IsThere = false;
                foreach(string item in listbox_mods_groups.Items)
                {
                    if (item == template.Group)
                    {
                        IsThere = true;
                    }
                }

                if (IsThere == false)
                {
                    listbox_mods_groups.Items.Add(template.Group);
                }
            }
        }

        private void btnMods_Click(object sender, EventArgs e)
        {
            if (listbox_mods.SelectedItem != null)
            {
                exporter.ExportMod(listbox_mods.SelectedItem.ToString());
            }
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            if (listbox_mods_groups.SelectedItem != null)
            {
                exporter.ExportGroup(listbox_mods_groups.SelectedItem.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Options options = new Options();
            options.ShowDialog();
            UpdateFormLanguage();
        }

        private void UpdateFormLanguage()
        {
            // load translations
            ResourceManager LocRM = new ResourceManager("AdvancedETS2Packer.Languages.Form1", typeof(Form1).Assembly);
            groupBox1.Text = LocRM.GetString("exportMod");
            groupBox2.Text = LocRM.GetString("exportOfGroupsOfMods");
            btnMods.Text = LocRM.GetString("exportMod2");
            btnGroups.Text = LocRM.GetString("exportGroup2");
            lblNastaveni.Text = LocRM.GetString("Settings");
            lblAbout.Text = LocRM.GetString("About");
        }

        private void lblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
