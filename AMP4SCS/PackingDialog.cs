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
    public partial class PackingDialog : Form
    {
        ResourceManager LocRM { get; set; }

        public PackingDialog()
        {
            InitializeComponent();

            // load translations
            LocRM = new ResourceManager("AdvancedETS2Packer.Languages.Export", typeof(Exporter).Assembly);
            lblPackaging.Text = LocRM.GetString("Packaging...");
        }

        public void UpdateStatus(string status)
        {
            Invoke((MethodInvoker)delegate
            {
                lblStatus.Text = LocRM.GetString(status);
            });
        }
    }
}
