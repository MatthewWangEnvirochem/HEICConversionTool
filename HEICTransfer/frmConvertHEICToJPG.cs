using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using ImageProcessor;
//using ImageProcessor.Imaging.Formats;
//using SkiaSharp;
//using System.Threading.Tasks;
using ImageMagick;
using System.Diagnostics;
using System.Xml.Schema;

namespace HEICTransfer
{
    public partial class frmConvertHEICToJPG : Form
    {
        public frmConvertHEICToJPG()
        {
            InitializeComponent();
        }

        //string foldername;
        string sourceFolder = "";
        string destinationFolder = "";

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
                this.folderBrowserDialog.ShowNewFolderButton = false;
                DialogResult result = this.folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.clearListBox();

                    // retrieve the name of the selected folder
                    string foldername = this.folderBrowserDialog.SelectedPath;

                    // print the folder name on a label
                    this.txtOriginalSelectedPath.Text = foldername;


                    // iterate over all files in the selected folder and add them to 
                    // the listbox.
                    foreach (string filename in Directory.GetFiles(foldername))
                        this.listBox1.Items.Add(filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "btnOpenFolder_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void clearListBox()
        {
            this.listBox1.Items.Clear();
        }

        private void btnSelectTargetFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // this.clearListBox();

                // retrieve the name of the selected folder
                string foldername = this.folderBrowserDialog1.SelectedPath;

                // print the folder name on a label
                this.txtTargetSelectedPath.Text = foldername;


                // iterate over all files in the selected folder and add them to 
                // the listbox.
                //foreach (string filename in Directory.GetFiles(foldername))
                //	this.listBox1.Items.Add(filename);
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            await convertFiles();
        }

        //private void ConvertHEICToJPG(string sourceFolder, string destinationFolder)
        //{
        //    var heicFiles = Directory.GetFiles(sourceFolder, "*.heic");

        //    foreach (var heicFile in heicFiles)
        //    {
        //        string jpgFileName = Path.ChangeExtension(Path.GetFileName(heicFile), ".jpg");
        //        string jpgFilePath = Path.Combine(destinationFolder, jpgFileName);

        //        try
        //        {
        //            using (var image = new MagickImage(heicFile))
        //            {
        //                image.Write(jpgFilePath);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log or handle the exception
        //            Console.WriteLine($"Error processing {heicFile}: {ex.Message}");
        //            // You can choose to skip this file or take other appropriate actions.
        //        }
        //    }
        //}

        private async Task ConvertHEICToJPGAsync(string sourceFolder, string destinationFolder)
        {
            var heicFiles = Directory.GetFiles(sourceFolder, "*.heic");

            progressBar.Maximum = heicFiles.Length;
            progressBar.Value = 0;

            foreach (var heicFile in heicFiles)
            {
                string jpgFileName = Path.ChangeExtension(Path.GetFileName(heicFile), ".jpg");
                string jpgFilePath = Path.Combine(destinationFolder, jpgFileName);

                try
                {
                    await Task.Run(() =>
                    {
                        using (var image = new MagickImage(heicFile))
                        {
                            image.Write(jpgFilePath);
                        }
                    });
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    Console.WriteLine($"Error processing {heicFile}: {ex.Message}");
                    // You can choose to skip this file or take other appropriate actions.
                }
                finally
                {
                    progressBar.Value++;
                }
            }
        }

        private void btnOpenTargetFolder_Click(object sender, EventArgs e)
        {
            destinationFolder = txtTargetSelectedPath.Text;
            if (Directory.Exists(destinationFolder))
            {
                Process.Start("explorer.exe", destinationFolder);
            }
            else
            {
                MessageBox.Show("Destination folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            int x = -1;
            int y = -1;
            string tempOrigin;
            string tempTarget;
            if (TrimBox("Trim", "Enter desired size", ref x, ref y) == DialogResult.OK)
            {
                tempOrigin = txtOriginalSelectedPath.Text;
                tempTarget = txtTargetSelectedPath.Text;
                txtOriginalSelectedPath.Text = tempTarget;
                txtTargetSelectedPath.Text = "";
                TrimFiles(txtOriginalSelectedPath.Text, txtTargetSelectedPath.Text, x, y);
                txtOriginalSelectedPath.Text = tempOrigin;
                txtTargetSelectedPath.Text = tempTarget;
            }
        }

        private async void btnTrimConvert_Click(object sender, EventArgs e)
        {
            int x = -1;
            int y = -1;
            string tempOrigin;
            string tempTarget;
            await convertFiles();
            if (TrimBox("Convert and Trim", "Enter desired size", ref x, ref y) == DialogResult.OK)
            {
                tempOrigin = txtOriginalSelectedPath.Text;
                tempTarget = txtTargetSelectedPath.Text;
                txtOriginalSelectedPath.Text = tempTarget;
                txtTargetSelectedPath.Text = "";
                TrimFiles(txtOriginalSelectedPath.Text, txtTargetSelectedPath.Text, x, y);
                txtOriginalSelectedPath.Text = tempOrigin;
                txtTargetSelectedPath.Text = tempTarget;
            }
        }

        private void TrimFiles(string sourceFolder, string destinationFolder, int x, int y)
        {
            try
            {
                if (txtOriginalSelectedPath.Text.Length != 0)
                {
                    destinationFolder = Path.Combine(sourceFolder, "Trimmed");
                    txtTargetSelectedPath.Text = destinationFolder;

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    // Get all jpg files in the source folder
                    string[] files = Directory.GetFiles(sourceFolder, "*.jpg");
                    foreach (string file in files)
                    {
                        string filename = x.ToString() + "x" + y.ToString() + Path.GetFileName(file);
                        string destPath = Path.Combine(destinationFolder, filename);

                        // Resize each image and save it to the destination folder
                        ResizeImage(file, destPath, x, y);
                    }

                    MessageBox.Show("Trim complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else
                {

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        sourceFolder = folderBrowserDialog.SelectedPath;
                        destinationFolder = Path.Combine(sourceFolder, "Trimmed");
                        txtTargetSelectedPath.Text = destinationFolder;

                        if (!Directory.Exists(destinationFolder))
                            Directory.CreateDirectory(destinationFolder);

                        // Get all jpg files in the source folder
                        string[] files = Directory.GetFiles(sourceFolder, "*.jpg");
                        foreach (string file in files)
                        {
                            string filename = x.ToString() + "x" + y.ToString() + Path.GetFileName(file);
                            string destPath = Path.Combine(destinationFolder, filename);

                            // Resize each image and save it to the destination folder
                            ResizeImage(file, destPath, x, y);
                        }

                        MessageBox.Show("Trim complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "btnConvert_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task convertFiles()
        {
            try
            {
                if (txtOriginalSelectedPath.Text.Length != 0)
                {
                    sourceFolder = txtOriginalSelectedPath.Text;
                    destinationFolder = txtTargetSelectedPath.Text;
                    if (!Directory.Exists(destinationFolder))
                    {
                        destinationFolder = Path.Combine(txtOriginalSelectedPath.Text, "Converted");
                        txtTargetSelectedPath.Text = destinationFolder;
                        Directory.CreateDirectory(destinationFolder);
                    }


                    //ConvertHEICToJPG(sourceFolder, destinationFolder);
                    await ConvertHEICToJPGAsync(sourceFolder, destinationFolder);

                    MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        sourceFolder = folderBrowserDialog.SelectedPath;
                        txtOriginalSelectedPath.Text = folderBrowserDialog.SelectedPath;
                        destinationFolder = txtTargetSelectedPath.Text;
                        if (!Directory.Exists(destinationFolder))
                        {
                            destinationFolder = Path.Combine(sourceFolder, "Converted");
                            txtTargetSelectedPath.Text = destinationFolder;
                            Directory.CreateDirectory(destinationFolder);
                        }

                        //ConvertHEICToJPG(sourceFolder, destinationFolder);
                        await ConvertHEICToJPGAsync(sourceFolder, destinationFolder);

                        MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static DialogResult TrimBox(string title, string promptText, ref int x, ref int y)
        {
            Form trimBox = new Form();
            Label trimQ = new Label();
            Label xCross = new Label();
            TextBox xInput = new TextBox();
            TextBox yInput = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            trimBox.Text = title;
            trimQ.Text = promptText;

            buttonOk.Text = "Trim";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            trimBox.SetBounds(36, 36, 372, 13);
            xCross.Text = "X";
            xCross.SetBounds(386, 86, 20, 20);
            xInput.SetBounds(36, 86, 350, 20); 
            yInput.SetBounds(406, 86, 350, 20);

            buttonOk.SetBounds(228, 170, 160, 60);
            buttonCancel.SetBounds(400, 170, 160, 60);

            trimQ.AutoSize = true;
            trimBox.ClientSize = new System.Drawing.Size(796, 307);
            trimBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            trimBox.StartPosition = FormStartPosition.CenterScreen;
            trimBox.MinimizeBox = false;
            trimBox.MaximizeBox = false;

            trimBox.Controls.Add(trimQ);
            trimBox.Controls.Add(buttonCancel);
            trimBox.Controls.Add(buttonOk);
            trimBox.Controls.Add(xCross);
            trimBox.Controls.Add(xInput);
            trimBox.Controls.Add(yInput);
            trimBox.AcceptButton = buttonOk;
            trimBox.CancelButton = buttonCancel;    

            DialogResult dialogResult = trimBox.ShowDialog();
            
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    x = int.Parse(xInput.Text);
                    y = int.Parse(yInput.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error: Failed to Trim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    x = -1;
                    y = -1;
                }
            }


            return dialogResult;
        }
        public void ResizeImage(string originalPath, string outputPath, int newWidth, int newHeight)
        {
            using (var image = Image.FromFile(originalPath))
            {
                var newImage = new Bitmap(newWidth, newHeight);
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                }
                newImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}