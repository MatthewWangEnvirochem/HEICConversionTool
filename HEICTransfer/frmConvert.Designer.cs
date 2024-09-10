
namespace HEICConverter
{
    partial class frmConvert
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
            txtOriginalSelectedPath = new System.Windows.Forms.TextBox();
            listBox1 = new System.Windows.Forms.ListBox();
            btnOpenFolder = new System.Windows.Forms.Button();
            txtTargetSelectedPath = new System.Windows.Forms.TextBox();
            btnOpenTargetFolder = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnConvert = new System.Windows.Forms.Button();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtOriginalSelectedPath);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(btnOpenFolder);
            groupBox1.Location = new System.Drawing.Point(14, 16);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(897, 348);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Original Folder";
            // 
            // txtOriginalSelectedPath
            // 
            txtOriginalSelectedPath.Location = new System.Drawing.Point(7, 77);
            txtOriginalSelectedPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtOriginalSelectedPath.Name = "txtOriginalSelectedPath";
            txtOriginalSelectedPath.Size = new System.Drawing.Size(883, 27);
            txtOriginalSelectedPath.TabIndex = 4;
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
            // txtTargetSelectedPath
            // 
            txtTargetSelectedPath.Location = new System.Drawing.Point(17, 521);
            txtTargetSelectedPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTargetSelectedPath.Name = "txtTargetSelectedPath";
            txtTargetSelectedPath.Size = new System.Drawing.Size(876, 27);
            txtTargetSelectedPath.TabIndex = 14;
            // 
            // btnOpenTargetFolder
            // 
            btnOpenTargetFolder.Location = new System.Drawing.Point(17, 483);
            btnOpenTargetFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnOpenTargetFolder.Name = "btnOpenTargetFolder";
            btnOpenTargetFolder.Size = new System.Drawing.Size(880, 31);
            btnOpenTargetFolder.TabIndex = 13;
            btnOpenTargetFolder.Text = "Open Target folder";
            btnOpenTargetFolder.UseVisualStyleBackColor = true;
            btnOpenTargetFolder.Click += btnOpenTargetFolder_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(17, 444);
            progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(877, 31);
            progressBar.TabIndex = 12;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = System.Drawing.Color.SkyBlue;
            btnConvert.Location = new System.Drawing.Point(13, 356);
            btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(880, 81);
            btnConvert.TabIndex = 11;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // frmConvert
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(919, 571);
            Controls.Add(txtTargetSelectedPath);
            Controls.Add(btnOpenTargetFolder);
            Controls.Add(progressBar);
            Controls.Add(btnConvert);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "frmConvert";
            Text = "frmConvert";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOriginalSelectedPath;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtTargetSelectedPath;
        private System.Windows.Forms.Button btnOpenTargetFolder;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}