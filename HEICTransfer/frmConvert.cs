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

using ImageMagick;
using System.Diagnostics;

namespace HEICConverter
{
    public partial class frmConvert : Form
    {
        public frmConvert()
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

        private void btnOpenTargetFolder_Click(object sender, EventArgs e)
        {
            
            string folderPath = destinationFolder;
            System.Diagnostics.Process.Start("explorer.exe", folderPath);
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtOriginalSelectedPath.Text.Length != 0)
                {
                    sourceFolder = folderBrowserDialog.SelectedPath;
                    destinationFolder = Path.Combine(sourceFolder, "Converted");
                    txtTargetSelectedPath.Text = destinationFolder;

                    if (!Directory.Exists(destinationFolder))
                        Directory.CreateDirectory(destinationFolder);

                    //ConvertHEICToJPG(sourceFolder, destinationFolder);
                    await ConvertHEICToJPGAsync(sourceFolder, destinationFolder);

                    MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        sourceFolder = folderBrowserDialog.SelectedPath;
                        destinationFolder = Path.Combine(sourceFolder, "Converted");
                        txtTargetSelectedPath.Text = destinationFolder;

                        if (!Directory.Exists(destinationFolder))
                            Directory.CreateDirectory(destinationFolder);

                        //ConvertHEICToJPG(sourceFolder, destinationFolder);
                        await ConvertHEICToJPGAsync(sourceFolder, destinationFolder);

                        MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "btnConvert_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

  
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
                  
                }
                finally
                {
                    progressBar.Value++;
                }
            }
        }

        private void btnOpenTargetFolder_Click_1(object sender, EventArgs e)
        {

            if (Directory.Exists(destinationFolder))
            {
                Process.Start("explorer.exe", destinationFolder);
            }
            else
            {
                MessageBox.Show("Destination folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}