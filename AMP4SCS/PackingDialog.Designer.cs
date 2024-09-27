
namespace AdvancedETS2Packer
{
    partial class PackingDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPackaging = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lblPackaging
            // 
            lblPackaging.AutoSize = true;
            lblPackaging.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            lblPackaging.Location = new System.Drawing.Point(110, 12);
            lblPackaging.Name = "lblPackaging";
            lblPackaging.Size = new System.Drawing.Size(170, 37);
            lblPackaging.TabIndex = 0;
            lblPackaging.Text = "Packaging...";
            lblPackaging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblStatus.Location = new System.Drawing.Point(0, 83);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(182, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Now packaging mod \"{0}\"";
            // 
            // PackingDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(378, 103);
            ControlBox = false;
            Controls.Add(lblStatus);
            Controls.Add(lblPackaging);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "PackingDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = " ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPackaging;
        private System.Windows.Forms.Label lblStatus;
    }
}