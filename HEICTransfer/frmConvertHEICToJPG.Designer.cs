
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
            btnSelectInputFolder = new System.Windows.Forms.Button();
            listBox1 = new System.Windows.Forms.ListBox();
            txtSelectedInputPath = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnConvert = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnSelectOutputFolder = new System.Windows.Forms.Button();
            btnOpenOutputFolder = new System.Windows.Forms.Button();
            txtSelectedOutputPath = new System.Windows.Forms.TextBox();
            btnTrim = new System.Windows.Forms.Button();
            btnTrimConvert = new System.Windows.Forms.Button();
            btnSavedValues = new System.Windows.Forms.Button();
            useDefault = new System.Windows.Forms.CheckBox();
            btnNonDefaultTrim = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectInputFolder
            // 
            btnSelectInputFolder.Location = new System.Drawing.Point(10, 29);
            btnSelectInputFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSelectInputFolder.Name = "btnOpenFolder";
            btnSelectInputFolder.Size = new System.Drawing.Size(880, 31);
            btnSelectInputFolder.TabIndex = 0;
            btnSelectInputFolder.Text = "Select Original folder";
            btnSelectInputFolder.UseVisualStyleBackColor = true;
            btnSelectInputFolder.Click += btnSelectInputFolder_Click;
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
            // txtSelectedInputPath
            // 
            txtSelectedInputPath.Location = new System.Drawing.Point(7, 68);
            txtSelectedInputPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSelectedInputPath.Name = "txtOriginalSelectedPath";
            txtSelectedInputPath.ReadOnly = true;
            txtSelectedInputPath.Size = new System.Drawing.Size(883, 27);
            txtSelectedInputPath.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSelectedInputPath);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(btnSelectInputFolder);
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
            // btnSelectOutputFolder
            // 
            btnSelectOutputFolder.Location = new System.Drawing.Point(14, 497);
            btnSelectOutputFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSelectOutputFolder.Name = "btnSelectTargetFolder";
            btnSelectOutputFolder.Size = new System.Drawing.Size(440, 31);
            btnSelectOutputFolder.TabIndex = 9;
            btnSelectOutputFolder.Text = "Select Target folder";
            btnSelectOutputFolder.UseVisualStyleBackColor = true;
            btnSelectOutputFolder.Click += btnSelectOutputFolder_Click;
            // 
            // btnOpenOutputFolder
            // 
            btnOpenOutputFolder.Location = new System.Drawing.Point(454, 497);
            btnOpenOutputFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnOpenOutputFolder.Name = "btnOpenTargetFolder";
            btnOpenOutputFolder.Size = new System.Drawing.Size(440, 31);
            btnOpenOutputFolder.TabIndex = 9;
            btnOpenOutputFolder.Text = "Open Target folder";
            btnOpenOutputFolder.UseVisualStyleBackColor = true;
            btnOpenOutputFolder.Click += btnOpenOutputFolder_Click;
            // 
            // txtSelectedOutputPath
            // 
            txtSelectedOutputPath.Location = new System.Drawing.Point(14, 536);
            txtSelectedOutputPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSelectedOutputPath.Name = "txtTargetSelectedPath";
            txtSelectedOutputPath.ReadOnly = true;
            txtSelectedOutputPath.Size = new System.Drawing.Size(876, 27);
            txtSelectedOutputPath.TabIndex = 10;
            // 
            // btnTrim
            // 
            btnTrim.BackColor = System.Drawing.Color.SkyBlue;
            btnTrim.Location = new System.Drawing.Point(10, 413);
            btnTrim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTrim.Name = "btnTrim";
            btnTrim.Size = new System.Drawing.Size(440, 33);
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
            useDefault.Checked = false;
            useDefault.CheckedChanged += useDefault_CheckedChanged;
            //
            // btnNonDefaultTrim
            //
            btnNonDefaultTrim.BackColor = System.Drawing.Color.SkyBlue;
            btnNonDefaultTrim.Location = new System.Drawing.Point(450, 413);
            btnNonDefaultTrim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnNonDefaultTrim.Name = "btnNonDefaultTrim";
            btnNonDefaultTrim.Size = new System.Drawing.Size(440, 33);
            btnNonDefaultTrim.TabIndex = 11;
            btnNonDefaultTrim.Text = "Non Default Trim";
            btnNonDefaultTrim.UseVisualStyleBackColor = false;
            btnNonDefaultTrim.Click += btnNonDefaultTrim_Click;
            // 
            // frmConvertHEICToJPG
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(914, 583);
            Controls.Add(btnTrim);
            Controls.Add(txtSelectedOutputPath);
            Controls.Add(btnSelectOutputFolder);
            Controls.Add(btnOpenOutputFolder);
            Controls.Add(progressBar);
            Controls.Add(btnConvert);
            Controls.Add(btnTrimConvert);
            Controls.Add(btnSavedValues);
            Controls.Add(useDefault);
            Controls.Add(groupBox1);
            Controls.Add(btnNonDefaultTrim);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "frmConvertHEICToJPG";
            Text = "Convert HEIC To JPG";
            Load += frmConvertHEICToJPG_Load;
            FormClosing += frmConvertHEICToJPG_Closing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSelectInputFolder;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtSelectedInputPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnSelectOutputFolder;
        private System.Windows.Forms.Button btnOpenOutputFolder;
        private System.Windows.Forms.TextBox txtSelectedOutputPath;
        private System.Windows.Forms.Button btnTrim;
        private System.Windows.Forms.Button btnTrimConvert;
        private System.Windows.Forms.Button btnSavedValues;
        private System.Windows.Forms.CheckBox useDefault;
        private System.Windows.Forms.Button btnNonDefaultTrim;
    }
}

