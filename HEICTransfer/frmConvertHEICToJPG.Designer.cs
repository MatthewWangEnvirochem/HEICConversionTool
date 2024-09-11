
using System.Windows.Forms;

namespace HEICTransfer
{
    partial class frmConvertHEICToJPG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertHEICToJPG));
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            btnOpenFolder = new System.Windows.Forms.Button();
            listBox1 = new System.Windows.Forms.ListBox();
            txtOriginalSelectedPath = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnConvert = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnSelectTargetFolder = new System.Windows.Forms.Button();
            btnOpenTargetFolder = new System.Windows.Forms.Button();
            txtTargetSelectedPath = new System.Windows.Forms.TextBox();
            btnTrim = new System.Windows.Forms.Button();
            btnTrimConvert = new System.Windows.Forms.Button();
            btnSavedValues = new System.Windows.Forms.Button();
            useDefault = new System.Windows.Forms.CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new System.Drawing.Point(10, 29);
            btnOpenFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new System.Drawing.Size(880, 31);
            btnOpenFolder.TabIndex = 0;
            btnOpenFolder.Text = "Select Original folder";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new System.Drawing.Point(7, 128);
            listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(883, 204);
            listBox1.TabIndex = 2;
            // 
            // txtOriginalSelectedPath
            // 
            txtOriginalSelectedPath.Location = new System.Drawing.Point(7, 68);
            txtOriginalSelectedPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtOriginalSelectedPath.Name = "txtOriginalSelectedPath";
            txtOriginalSelectedPath.ReadOnly = true;
            txtOriginalSelectedPath.Size = new System.Drawing.Size(883, 27);
            txtOriginalSelectedPath.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtOriginalSelectedPath);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(btnOpenFolder);
            groupBox1.Location = new System.Drawing.Point(3, 16);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(897, 348);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Original Folder";
            // 
            // btnConvert
            // 
            btnConvert.BackColor = System.Drawing.Color.SkyBlue;
            btnConvert.Location = new System.Drawing.Point(10, 372);
            btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(440, 33);
            btnConvert.TabIndex = 7;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(14, 459);
            progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(877, 31);
            progressBar.TabIndex = 8;
            // 
            // btnSelectTargetFolder
            // 
            btnSelectTargetFolder.Location = new System.Drawing.Point(14, 497);
            btnSelectTargetFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSelectTargetFolder.Name = "btnSelectTargetFolder";
            btnSelectTargetFolder.Size = new System.Drawing.Size(440, 31);
            btnSelectTargetFolder.TabIndex = 9;
            btnSelectTargetFolder.Text = "Select Target folder";
            btnSelectTargetFolder.UseVisualStyleBackColor = true;
            btnSelectTargetFolder.Click += btnSelectTargetFolder_Click;
            // 
            // btnOpenTargetFolder
            // 
            btnOpenTargetFolder.Location = new System.Drawing.Point(454, 497);
            btnOpenTargetFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnOpenTargetFolder.Name = "btnOpenTargetFolder";
            btnOpenTargetFolder.Size = new System.Drawing.Size(440, 31);
            btnOpenTargetFolder.TabIndex = 9;
            btnOpenTargetFolder.Text = "Open Target folder";
            btnOpenTargetFolder.UseVisualStyleBackColor = true;
            btnOpenTargetFolder.Click += btnOpenTargetFolder_Click;
            // 
            // txtTargetSelectedPath
            // 
            txtTargetSelectedPath.Location = new System.Drawing.Point(14, 536);
            txtTargetSelectedPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTargetSelectedPath.Name = "txtTargetSelectedPath";
            txtTargetSelectedPath.ReadOnly = true;
            txtTargetSelectedPath.Size = new System.Drawing.Size(876, 27);
            txtTargetSelectedPath.TabIndex = 10;
            // 
            // btnTrim
            // 
            btnTrim.BackColor = System.Drawing.Color.SkyBlue;
            btnTrim.Location = new System.Drawing.Point(10, 413);
            btnTrim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTrim.Name = "btnTrim";
            btnTrim.Size = new System.Drawing.Size(880, 33);
            btnTrim.TabIndex = 11;
            btnTrim.Text = "Trim Target Folder";
            btnTrim.UseVisualStyleBackColor = false;
            btnTrim.Click += btnTrim_Click;
            // 
            // btnTrimConvert
            // 
            btnTrimConvert.BackColor = System.Drawing.Color.SkyBlue;
            btnTrimConvert.Location = new System.Drawing.Point(450, 372);
            btnTrimConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTrimConvert.Name = "btnTrimConvert";
            btnTrimConvert.Size = new System.Drawing.Size(440, 33);
            btnTrimConvert.TabIndex = 12;
            btnTrimConvert.Text = "Convert and Trim";
            btnTrimConvert.UseVisualStyleBackColor = false;
            btnTrimConvert.Click += btnTrimConvert_Click;
            // 
            // btnSavedValues
            // 
            btnSavedValues.BackColor = System.Drawing.Color.SkyBlue;
            btnSavedValues.Location = new System.Drawing.Point(823, 13);
            btnSavedValues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSavedValues.Name = "btnSavedValues";
            btnSavedValues.Size = new System.Drawing.Size(80, 27);
            btnSavedValues.TabIndex = 12;
            btnSavedValues.Text = "Defaults";
            btnSavedValues.UseVisualStyleBackColor = false;
            btnSavedValues.Click += btnSavedValues_Click;
            //
            // useDefault
            //
            useDefault.Location = new System.Drawing.Point(701, 13);
            useDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            useDefault.Name = "useDefault";
            useDefault.Text = "Toggle Defaults";
            useDefault.TabIndex = 12;
            useDefault.Size = new System.Drawing.Size(122, 27);
            useDefault.Appearance = Appearance.Button;
            useDefault.ThreeState = false;
            useDefault.Checked = true;
            useDefault.CheckedChanged += useDefault_CheckedChanged;
            // 
            // frmConvertHEICToJPG
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(914, 583);
            Controls.Add(btnTrim);
            Controls.Add(txtTargetSelectedPath);
            Controls.Add(btnSelectTargetFolder);
            Controls.Add(btnOpenTargetFolder);
            Controls.Add(progressBar);
            Controls.Add(btnConvert);
            Controls.Add(btnTrimConvert);
            Controls.Add(btnSavedValues);
            Controls.Add(useDefault);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "frmConvertHEICToJPG";
            Text = "Convert HEIC To JPG";
            Load += frmConvertHEICToJPG_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtOriginalSelectedPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnSelectTargetFolder;
        private System.Windows.Forms.Button btnOpenTargetFolder;
        private System.Windows.Forms.TextBox txtTargetSelectedPath;
        private System.Windows.Forms.Button btnTrim;
        private System.Windows.Forms.Button btnTrimConvert;
        private System.Windows.Forms.Button btnSavedValues;
        private System.Windows.Forms.CheckBox useDefault;
    }
}

