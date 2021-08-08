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

        /// <summary>
        /// This method loads transaltions for this form.
        /// </summary>
        public PackingDialog()
        {
            InitializeComponent();

            // load translations
            LocRM = new ResourceManager("AdvancedETS2Packer.Languages.Export", typeof(Exporter).Assembly);
            lblPackaging.Text = LocRM.GetString("Packaging...");
        }

        /// <summary>
        /// This method is updating status on label on form.
        /// </summary>
        /// <remarks>It using Invoke, so this method can be called from another thread.</remarks>
        /// <param name="status">Status string, that will be displayed on form.</param>
        public void UpdateStatus(string status)
        {
            if (this.IsHandleCreated) {
                Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = LocRM.GetString(status);
                });
            }
        }
    }
}
