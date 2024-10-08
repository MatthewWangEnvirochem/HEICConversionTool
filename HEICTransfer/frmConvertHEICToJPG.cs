﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
//using ImageProcessor;
//using ImageProcessor.Imaging.Formats;
//using SkiaSharp;
//using System.Threading.Tasks;
using ImageMagick;
using System.Diagnostics;
using System.Xml.Schema;
using System.Reflection;
using static HEICTransfer.frmConvertHEICToJPG;
using System.Diagnostics.Eventing.Reader;

namespace HEICTransfer
{
    public partial class frmConvertHEICToJPG : Form
    {
        public frmConvertHEICToJPG()
        {
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataFolder = Path.Combine(userFolder, "HEICImageConverter");
            savePath = Path.Combine(appDataFolder, "defaults.json");
            InitializeComponent();
            AppDataSetup();
        }
        string appDataFolder;
        string inputFolder = "";
        string outputFolder = "";
        string savePath;
        SaveData saveData;

        private void btnSelectInputFolder_Click(object sender, EventArgs e)
        {
            if (saveData.useDefaults == false)
            {
                try
                {
                    DialogResult result = this.folderBrowserDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        this.clearListBox();

                        // retrieve the name of the selected folder
                        string foldername = this.folderBrowserDialog.SelectedPath;

                        // print the folder name on a label
                        this.txtSelectedInputPath.Text = foldername;


                        // iterate over all files in the selected folder and add them to 
                        // the listbox.
                        this.listFiles(foldername);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "btnOpenFolder_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void clearListBox()
        {
            this.listBox1.Items.Clear();
        }

        private void btnSelectOutputFolder_Click(object sender, EventArgs e)
        {
            if (saveData.useDefaults == false)
            {
                DialogResult result = this.folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // retrieve the name of the selected folder
                    string foldername = this.folderBrowserDialog.SelectedPath;

                    // print the folder name on a label
                    this.txtSelectedOutputPath.Text = foldername;
                }
            }
            
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            await convertFiles();
        }

        private async Task ConvertHEICToJPGAsync(string inputFolder, string outputFolder)
        {
            var heicFiles = Directory.GetFiles(inputFolder, "*.heic");

            progressBar.Maximum = heicFiles.Length;
            progressBar.Value = 0;

            foreach (var heicFile in heicFiles)
            {
                string jpgFileName = Path.ChangeExtension(Path.GetFileName(heicFile), ".jpg");
                string jpgFilePath = Path.Combine(outputFolder, jpgFileName);

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

        private void btnOpenOutputFolder_Click(object sender, EventArgs e)
        {
            outputFolder = txtSelectedOutputPath.Text;
            if (Directory.Exists(outputFolder))
            {
                Process.Start("explorer.exe", outputFolder);
            }
            else
            {
                MessageBox.Show("Destination folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            trim();
        }

        private async void btnTrimConvert_Click(object sender, EventArgs e)
        {
            await convertFiles();
            trim();
        }

        private void btnNonDefaultTrim_Click(object sender, EventArgs e)
        {
            if (txtSelectedInputPath.Text.Length != 0 && txtSelectedOutputPath.Text.Length != 0)
            {
                if (saveData.useDefaults)
                {
                    saveData.useDefaults = false;
                    trim();
                    saveData.useDefaults = true;
                } else
                {
                    trim();
                }
            } else
            {
                MessageBox.Show("Please select defaults or disable the use defaults toggle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TrimFiles(string inputFolder, string outputFolder, int x, int y)
        {
            try
            {
                if (txtSelectedInputPath.Text.Length != 0)
                {
                    outputFolder = Path.Combine(inputFolder, "Trimmed");
                    txtSelectedOutputPath.Text = outputFolder;

                    if (!Directory.Exists(outputFolder))
                    {
                        Directory.CreateDirectory(outputFolder);
                    }

                    // Get all jpg files in the source folder
                    string[] files = Directory.GetFiles(inputFolder, "*.jpg");
                    foreach (string file in files)
                    {
                        string filename = x.ToString() + "x" + y.ToString() + Path.GetFileName(file);
                        string destPath = Path.Combine(outputFolder, filename);

                        // Resize each image and save it to the destination folder
                        ResizeImage(file, destPath, x, y);
                    }

                    MessageBox.Show("Trim complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else if(saveData.useDefaults == false) 
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        inputFolder = folderBrowserDialog.SelectedPath;
                        outputFolder = Path.Combine(inputFolder, "Trimmed");
                        txtSelectedOutputPath.Text = outputFolder;

                        if (!Directory.Exists(outputFolder))
                            Directory.CreateDirectory(outputFolder);

                        // Get all jpg files in the source folder
                        string[] files = Directory.GetFiles(inputFolder, "*.jpg");
                        foreach (string file in files)
                        {
                            string filename = x.ToString() + "x" + y.ToString() + Path.GetFileName(file);
                            string destPath = Path.Combine(outputFolder, filename);

                            // Resize each image and save it to the destination folder
                            ResizeImage(file, destPath, x, y);
                        }

                        MessageBox.Show("Trim complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else {
                    MessageBox.Show("Please select defaults or disable the use defaults toggle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtSelectedInputPath.Text.Length != 0)
                {
                    inputFolder = txtSelectedInputPath.Text;
                    outputFolder = txtSelectedOutputPath.Text;
                    if (!Directory.Exists(outputFolder))
                    {
                        outputFolder = Path.Combine(txtSelectedInputPath.Text, "Converted");
                        txtSelectedOutputPath.Text = outputFolder;
                        Directory.CreateDirectory(outputFolder);
                    }

                    //ConvertHEICToJPG(sourceFolder, destinationFolder);
                    await ConvertHEICToJPGAsync(inputFolder, outputFolder);

                    MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if(saveData.useDefaults == false)
                {

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        inputFolder = folderBrowserDialog.SelectedPath;
                        txtSelectedInputPath.Text = folderBrowserDialog.SelectedPath;
                        outputFolder = txtSelectedOutputPath.Text;
                        if (!Directory.Exists(outputFolder))
                        {
                            outputFolder = Path.Combine(inputFolder, "Converted");
                            txtSelectedOutputPath.Text = outputFolder;
                            Directory.CreateDirectory(outputFolder);
                        }

                        //ConvertHEICToJPG(sourceFolder, destinationFolder);
                        await ConvertHEICToJPGAsync(inputFolder, outputFolder);

                        MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else
                {
                    MessageBox.Show("Please select defaults or disable the use defaults toggle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSavedValues_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 1;
            string input = "";
            string output = "";
            
            string data = File.ReadAllText(savePath);

            if (data != "" && data != "{}")
            {
                SaveData loadedData = JsonConvert.DeserializeObject<SaveData>(data);
                input = loadedData.inputFolder;
                output = loadedData.outputFolder;
                x = loadedData.x;
                y = loadedData.y;
            }

            if (savedValues(ref x, ref y, ref input, ref output) == DialogResult.OK)
            {
                saveData.inputFolder = input;
                saveData.outputFolder = output;
                saveData.x = x;
                saveData.y = y;

                string toWrite = JsonConvert.SerializeObject(saveData);
                File.WriteAllText(savePath, toWrite);
                if (saveData.useDefaults)
                {
                    loadSettings();
                }
            }
        }
        public static DialogResult savedValues(ref int x, ref int y, ref string input, ref string output)
        {
            frmSavedValues request = new frmSavedValues(x,y,input,output);
            DialogResult dialogResult = request.savedValues(ref x, ref y, ref input, ref output);
            return dialogResult;
        }

        private void loadSettings()
        {
            string data = File.ReadAllText(savePath);
            if (data != "" && data != "{}")
            {
                SaveData loadedData = JsonConvert.DeserializeObject<SaveData>(data);
                saveData.copyData(loadedData);
                txtSelectedInputPath.Text = saveData.inputFolder;
                txtSelectedOutputPath.Text = saveData.outputFolder;
                this.clearListBox();



                // iterate over all files in the selected folder and add them to 
                // the listbox.
                if(inputFolder != "")
                {
                    listFiles(saveData.inputFolder);
                }
            } 
        }

        private void useDefault_CheckedChanged(object sender, EventArgs e)
        {
            if(useDefault.Checked)
            {
                saveData.useDefaults = useDefault.Checked;
                btnSelectInputFolder.Text = "Selecting a folder is disabled while using defaults";
                btnSelectOutputFolder.Text = "Selecting a folder is disabled while using defaults";
                loadSettings();
                
            } else
            {
                saveData.useDefaults = useDefault.Checked;
                btnSelectInputFolder.Text = "Select Original folder";
                btnSelectOutputFolder.Text = "Select Target folder";
            }
        }

        public sealed class SaveData
        {
            public string outputFolder { get; set; }
            public string inputFolder { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public Boolean useDefaults { get; set; }
            public SaveData(string inputFolder, string outputFolder, int x, int y, Boolean defaultsOn)
            {
                this.outputFolder = outputFolder;
                this.inputFolder = inputFolder;
                this.x = x;
                this.y = y;
                this.useDefaults = defaultsOn;
            }

            public void copyData(SaveData loadedData)
            {
                this.outputFolder = loadedData.outputFolder;
                this.inputFolder= loadedData.inputFolder;
                this.x = loadedData.x;
                this.y = loadedData.y;
            }
        }

        private void frmConvertHEICToJPG_Load(object sender, EventArgs e)
        {
            if (saveData.useDefaults)
            {
                loadSettings();
            }
            loadFileLoader();
            useDefault.Checked = saveData.useDefaults;
        }

        private void frmConvertHEICToJPG_Closing(object sender, CancelEventArgs e)
        {
            string toWrite = JsonConvert.SerializeObject(saveData);
            System.Diagnostics.Debug.WriteLine(toWrite);
            File.WriteAllText(savePath, toWrite);
        }
        private void listFiles(string filePath)
        {
            foreach (string filename in Directory.GetFiles(filePath))
                this.listBox1.Items.Add(filename);
        }

        private void loadFileLoader()
        {
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
        }

        private void trim()
        {
            int x = -1;
            int y = -1;
            string tempInput;
            string tempOutput;
            if (saveData.useDefaults)
            {
                tempInput = txtSelectedInputPath.Text;
                tempOutput = txtSelectedOutputPath.Text;
                txtSelectedInputPath.Text = tempOutput;
                txtSelectedOutputPath.Text = "";
                TrimFiles(txtSelectedInputPath.Text, txtSelectedOutputPath.Text, saveData.x, saveData.y);
                txtSelectedInputPath.Text = tempInput;
                txtSelectedOutputPath.Text = tempOutput;
            }
            else
            {
                if (TrimBox("Trim", "Enter desired size", ref x, ref y) == DialogResult.OK)
                {
                    tempInput = txtSelectedInputPath.Text;
                    tempOutput = txtSelectedOutputPath.Text;
                    txtSelectedInputPath.Text = tempOutput;
                    txtSelectedOutputPath.Text = "";
                    TrimFiles(txtSelectedInputPath.Text, txtSelectedOutputPath.Text, x, y);
                    txtSelectedInputPath.Text = tempInput;
                    txtSelectedOutputPath.Text = tempOutput;
                }
            }
        }
        private void AppDataSetup()
        {
            if(!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }
            if (!File.Exists(savePath))
            {
                saveData = new SaveData("", "", 800, 600, useDefault.Checked);
                string toWrite = JsonConvert.SerializeObject(saveData);
                File.WriteAllText(savePath, toWrite);
            } else
            {
                string data = File.ReadAllText(savePath);
                saveData = JsonConvert.DeserializeObject<SaveData>(data);
            }
        }
    }
}