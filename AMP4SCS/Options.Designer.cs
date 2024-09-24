
namespace AdvancedETS2Packer
{
    partial class Options
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            cmbBoxLang = new System.Windows.Forms.ComboBox();
            lblJazykAplikace = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnSelectArchiver = new System.Windows.Forms.Button();
            txtArchiver = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbBoxLang);
            groupBox1.Controls.Add(lblJazykAplikace);
            groupBox1.Location = new System.Drawing.Point(13, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(418, 87);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Jazyk";
            // 
            // cmbBoxLang
            // 
            cmbBoxLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBoxLang.FormattingEnabled = true;
            cmbBoxLang.Items.AddRange(new object[] { "English", "Čeština" });
            cmbBoxLang.Location = new System.Drawing.Point(7, 45);
            cmbBoxLang.Name = "cmbBoxLang";
            cmbBoxLang.Size = new System.Drawing.Size(151, 28);
            cmbBoxLang.TabIndex = 2;
            // 
            // lblJazykAplikace
            // 
            lblJazykAplikace.AutoSize = true;
            lblJazykAplikace.Location = new System.Drawing.Point(7, 23);
            lblJazykAplikace.Name = "lblJazykAplikace";
            lblJazykAplikace.Size = new System.Drawing.Size(102, 20);
            lblJazykAplikace.TabIndex = 0;
            lblJazykAplikace.Text = "Jazyk aplikace";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSelectArchiver);
            groupBox2.Controls.Add(txtArchiver);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new System.Drawing.Point(11, 107);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(418, 99);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "SCS Packer";
            // 
            // btnSelectArchiver
            // 
            btnSelectArchiver.Location = new System.Drawing.Point(289, 44);
            btnSelectArchiver.Name = "btnSelectArchiver";
            btnSelectArchiver.Size = new System.Drawing.Size(37, 29);
            btnSelectArchiver.TabIndex = 2;
            btnSelectArchiver.Text = "...";
            btnSelectArchiver.UseVisualStyleBackColor = true;
            btnSelectArchiver.Click += btnSelectArchiver_Click;
            // 
            // txtArchiver
            // 
            txtArchiver.Location = new System.Drawing.Point(7, 47);
            txtArchiver.Name = "txtArchiver";
            txtArchiver.ReadOnly = true;
            txtArchiver.Size = new System.Drawing.Size(275, 27);
            txtArchiver.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(226, 20);
            label1.TabIndex = 0;
            label1.Text = "Cesta ke konzolové aplikaci 7zip:";
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(336, 211);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(94, 29);
            btnClose.TabIndex = 2;
            btnClose.Text = "Zavřít";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(235, 211);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(94, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Uložit";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "SCS Archiver|*.exe";
            // 
            // Options
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(443, 252);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Options";
            Text = "Nastavení";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbBoxLang;
        private System.Windows.Forms.Label lblJazykAplikace;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectArchiver;
        private System.Windows.Forms.TextBox txtArchiver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}