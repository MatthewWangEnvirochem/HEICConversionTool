
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
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new System.Drawing.Point(9, 22);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new System.Drawing.Size(770, 23);
            btnOpenFolder.TabIndex = 0;
            btnOpenFolder.Text = "Select Original folder";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new System.Drawing.Point(6, 96);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(773, 154);
            listBox1.TabIndex = 2;
            // 
            // txtOriginalSelectedPath
            // 
            txtOriginalSelectedPath.Location = new System.Drawing.Point(6, 58);
            txtOriginalSelectedPath.Name = "txtOriginalSelectedPath";
            txtOriginalSelectedPath.Size = new System.Drawing.Size(773, 23);
            txtOriginalSelectedPath.TabIndex = 4;
            txtOriginalSelectedPath.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtOriginalSelectedPath);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(btnOpenFolder);
            groupBox1.Location = new System.Drawing.Point(3, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(785, 261);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Original Folder";
            // 
            // btnConvert
            // 
            btnConvert.BackColor = System.Drawing.Color.SkyBlue;
            btnConvert.Location = new System.Drawing.Point(9, 279);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(385, 25);
            btnConvert.TabIndex = 7;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(12, 344);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(767, 23);
            progressBar.TabIndex = 8;
            // 
            // btnSelectTargetFolder
            // 
            btnSelectTargetFolder.Location = new System.Drawing.Point(12, 373);
            btnSelectTargetFolder.Name = "btnSelectTargetFolder";
            btnSelectTargetFolder.Size = new System.Drawing.Size(385, 23);
            btnSelectTargetFolder.TabIndex = 9;
            btnSelectTargetFolder.Text = "Select Target folder";
            btnSelectTargetFolder.UseVisualStyleBackColor = true;
            btnSelectTargetFolder.Click += btnSelectTargetFolder_Click;
            // 
            // btnOpenTargetFolder
            // 
            btnOpenTargetFolder.Location = new System.Drawing.Point(397, 373);
            btnOpenTargetFolder.Name = "btnOpenTargetFolder";
            btnOpenTargetFolder.Size = new System.Drawing.Size(385, 23);
            btnOpenTargetFolder.TabIndex = 9;
            btnOpenTargetFolder.Text = "Open Target folder";
            btnOpenTargetFolder.UseVisualStyleBackColor = true;
            btnOpenTargetFolder.Click += btnOpenTargetFolder_Click;
            // 
            // txtTargetSelectedPath
            // 
            txtTargetSelectedPath.Location = new System.Drawing.Point(12, 402);
            txtTargetSelectedPath.Name = "txtTargetSelectedPath";
            txtTargetSelectedPath.ReadOnly = true;
            txtTargetSelectedPath.Size = new System.Drawing.Size(767, 23);
            txtTargetSelectedPath.TabIndex = 10;
            // 
            // btnTrim
            // 
            btnTrim.BackColor = System.Drawing.Color.SkyBlue;
            btnTrim.Location = new System.Drawing.Point(9, 310);
            btnTrim.Name = "btnTrim";
            btnTrim.Size = new System.Drawing.Size(770, 25);
            btnTrim.TabIndex = 11;
            btnTrim.Text = "Trim Target Folder";
            btnTrim.UseVisualStyleBackColor = false;
            btnTrim.Click += btnTrim_Click;
            //
            // btnTrimConvert
            //
            btnTrimConvert.BackColor = System.Drawing.Color.SkyBlue;
            btnTrimConvert.Location = new System.Drawing.Point(394, 279);
            btnTrimConvert.Name = "btnTrimConvert";
            btnTrimConvert.Size = new System.Drawing.Size(385, 25);
            btnTrimConvert.TabIndex = 12;
            btnTrimConvert.Text = "Convert and Trim";
            btnTrimConvert.UseVisualStyleBackColor = false;
            btnTrimConvert.Click += btnTrimConvert_Click;
            // 
            // frmConvertHEICToJPG
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 437);
            Controls.Add(btnTrim);
            Controls.Add(txtTargetSelectedPath);
            Controls.Add(btnSelectTargetFolder);
            Controls.Add(btnOpenTargetFolder);
            Controls.Add(progressBar);
            Controls.Add(btnConvert);
            Controls.Add(btnTrimConvert);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "frmConvertHEICToJPG";
            Text = "Convert HEIC To JPG";
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
    }
}

