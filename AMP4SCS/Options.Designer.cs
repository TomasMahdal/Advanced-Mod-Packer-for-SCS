
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBoxLang = new System.Windows.Forms.ComboBox();
            this.lblJazykAplikace = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelect7zip = new System.Windows.Forms.Button();
            this.txt7Zip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBoxLang);
            this.groupBox1.Controls.Add(this.lblJazykAplikace);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(366, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jazyk";
            // 
            // cmbBoxLang
            // 
            this.cmbBoxLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxLang.FormattingEnabled = true;
            this.cmbBoxLang.Items.AddRange(new object[] {
            "Čeština",
            "English"});
            this.cmbBoxLang.Location = new System.Drawing.Point(6, 34);
            this.cmbBoxLang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBoxLang.Name = "cmbBoxLang";
            this.cmbBoxLang.Size = new System.Drawing.Size(133, 23);
            this.cmbBoxLang.TabIndex = 2;
            // 
            // lblJazykAplikace
            // 
            this.lblJazykAplikace.AutoSize = true;
            this.lblJazykAplikace.Location = new System.Drawing.Point(6, 17);
            this.lblJazykAplikace.Name = "lblJazykAplikace";
            this.lblJazykAplikace.Size = new System.Drawing.Size(80, 15);
            this.lblJazykAplikace.TabIndex = 0;
            this.lblJazykAplikace.Text = "Jazyk aplikace";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelect7zip);
            this.groupBox2.Controls.Add(this.txt7Zip);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(10, 80);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(366, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "7zip";
            // 
            // btnSelect7zip
            // 
            this.btnSelect7zip.Location = new System.Drawing.Point(253, 33);
            this.btnSelect7zip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect7zip.Name = "btnSelect7zip";
            this.btnSelect7zip.Size = new System.Drawing.Size(32, 22);
            this.btnSelect7zip.TabIndex = 2;
            this.btnSelect7zip.Text = "...";
            this.btnSelect7zip.UseVisualStyleBackColor = true;
            this.btnSelect7zip.Click += new System.EventHandler(this.btnSelect7zip_Click);
            // 
            // txt7Zip
            // 
            this.txt7Zip.Location = new System.Drawing.Point(6, 35);
            this.txt7Zip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt7Zip.Name = "txt7Zip";
            this.txt7Zip.ReadOnly = true;
            this.txt7Zip.Size = new System.Drawing.Size(241, 23);
            this.txt7Zip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cesta ke konzolové aplikaci 7zip:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(294, 158);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 22);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Zavřít";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(206, 158);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 22);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Uložit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "7zip console app|7zG.exe";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 189);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Nastavení";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbBoxLang;
        private System.Windows.Forms.Label lblJazykAplikace;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelect7zip;
        private System.Windows.Forms.TextBox txt7Zip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}