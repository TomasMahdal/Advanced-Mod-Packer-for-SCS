
namespace AdvancedETS2Packer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMods = new System.Windows.Forms.Button();
            this.listbox_mods = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGroups = new System.Windows.Forms.Button();
            this.listbox_mods_groups = new System.Windows.Forms.ListBox();
            this.lblNastaveni = new System.Windows.Forms.LinkLabel();
            this.lblAbout = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMods);
            this.groupBox1.Controls.Add(this.listbox_mods);
            this.groupBox1.Location = new System.Drawing.Point(11, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(284, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export módů";
            // 
            // btnMods
            // 
            this.btnMods.Location = new System.Drawing.Point(5, 237);
            this.btnMods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMods.Name = "btnMods";
            this.btnMods.Size = new System.Drawing.Size(274, 22);
            this.btnMods.TabIndex = 1;
            this.btnMods.Text = "Exportovat módy";
            this.btnMods.UseVisualStyleBackColor = true;
            this.btnMods.Click += new System.EventHandler(this.btnMods_Click);
            // 
            // listbox_mods
            // 
            this.listbox_mods.FormattingEnabled = true;
            this.listbox_mods.ItemHeight = 15;
            this.listbox_mods.Location = new System.Drawing.Point(5, 20);
            this.listbox_mods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listbox_mods.Name = "listbox_mods";
            this.listbox_mods.Size = new System.Drawing.Size(274, 214);
            this.listbox_mods.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGroups);
            this.groupBox2.Controls.Add(this.listbox_mods_groups);
            this.groupBox2.Location = new System.Drawing.Point(301, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(326, 270);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export skupin módů";
            // 
            // btnGroups
            // 
            this.btnGroups.Location = new System.Drawing.Point(6, 237);
            this.btnGroups.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(314, 22);
            this.btnGroups.TabIndex = 1;
            this.btnGroups.Text = "Exportovat skupiny módů";
            this.btnGroups.UseVisualStyleBackColor = true;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // listbox_mods_groups
            // 
            this.listbox_mods_groups.FormattingEnabled = true;
            this.listbox_mods_groups.ItemHeight = 15;
            this.listbox_mods_groups.Location = new System.Drawing.Point(6, 20);
            this.listbox_mods_groups.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listbox_mods_groups.Name = "listbox_mods_groups";
            this.listbox_mods_groups.Size = new System.Drawing.Size(315, 214);
            this.listbox_mods_groups.TabIndex = 0;
            // 
            // lblNastaveni
            // 
            this.lblNastaveni.AutoSize = true;
            this.lblNastaveni.Location = new System.Drawing.Point(568, 9);
            this.lblNastaveni.Name = "lblNastaveni";
            this.lblNastaveni.Size = new System.Drawing.Size(59, 15);
            this.lblNastaveni.TabIndex = 2;
            this.lblNastaveni.TabStop = true;
            this.lblNastaveni.Text = "Nastavení";
            this.lblNastaveni.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(503, 9);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(59, 15);
            this.lblAbout.TabIndex = 3;
            this.lblAbout.TabStop = true;
            this.lblAbout.Text = "O aplikaci";
            this.lblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAbout_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 304);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.lblNastaveni);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Advanced ETS2 Mod Packer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMods;
        private System.Windows.Forms.ListBox listbox_mods;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGroups;
        private System.Windows.Forms.ListBox listbox_mods_groups;
        private System.Windows.Forms.LinkLabel lblNastaveni;
        private System.Windows.Forms.LinkLabel lblAbout;
    }
}

