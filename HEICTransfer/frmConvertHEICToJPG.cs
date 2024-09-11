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

namespace HEICTransfer
{
    public partial class frmConvertHEICToJPG : Form
    {
        public frmConvertHEICToJPG()
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, "defaults.json")))
            {
                using (FileStream fs = File.Create(Path.Combine(Application.StartupPath, "defaults.json")))
                {

                }

            }
            InitializeComponent();
            loadSettings();
        }

        //string foldername;
        string sourceFolder = "";
        string destinationFolder = "";
        string defaultSource = "";
        string defaultDestination = "";
        int defaultX = 800;
        int defaultY = 600;
        Boolean useDefaults = true;
        string savePath = Path.Combine(Application.StartupPath, "defaults.json");

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (!useDefaults)
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
        }
        private void clearListBox()
        {
            this.listBox1.Items.Clear();
        }

        private void btnSelectTargetFolder_Click(object sender, EventArgs e)
        {
            if (!useDefaults)
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
            if (useDefaults)
            {
                tempOrigin = txtOriginalSelectedPath.Text;
                tempTarget = txtTargetSelectedPath.Text;
                txtOriginalSelectedPath.Text = tempTarget;
                txtTargetSelectedPath.Text = "";
                TrimFiles(txtOriginalSelectedPath.Text, txtTargetSelectedPath.Text, defaultX, defaultY);
                txtOriginalSelectedPath.Text = tempOrigin;
                txtTargetSelectedPath.Text = tempTarget;
            } else
            {
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
            
        }

        private async void btnTrimConvert_Click(object sender, EventArgs e)
        {

            int x = -1;
            int y = -1;
            string tempOrigin;
            string tempTarget;
            await convertFiles();
            if (useDefaults)
            {
                tempOrigin = txtOriginalSelectedPath.Text;
                tempTarget = txtTargetSelectedPath.Text;
                txtOriginalSelectedPath.Text = tempTarget;
                txtTargetSelectedPath.Text = "";
                TrimFiles(txtOriginalSelectedPath.Text, txtTargetSelectedPath.Text, defaultX, defaultY);
                txtOriginalSelectedPath.Text = tempOrigin;
                txtTargetSelectedPath.Text = tempTarget;
            }
            else
            {
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

        private void btnSavedValues_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 1;
            string origin = "";
            string target = "";
            
            string data = File.ReadAllText(savePath);

            if (data != "" && data != "{}")
            {
                SaveData loadedData = JsonConvert.DeserializeObject<SaveData>(data);
                origin = loadedData.inputFolder;
                target = loadedData.outputFolder;
                x = loadedData.x;
                y = loadedData.y;

                defaultSource = loadedData.inputFolder;
                defaultDestination = loadedData.outputFolder;
                defaultX = loadedData.x;
                defaultY = loadedData.y;
            }

            if (savedValues(ref x, ref y, ref origin, ref target) == DialogResult.OK)
            {
                SaveData saveData = new SaveData(origin, target, x, y);
                defaultSource = saveData.inputFolder;
                defaultDestination = saveData.outputFolder;
                defaultX = saveData.x;
                defaultY = saveData.y;
                string toWrite = JsonConvert.SerializeObject(saveData);
                Debug.WriteLine(toWrite);
                File.WriteAllText(savePath, toWrite);
            }
        }
        public static DialogResult savedValues(ref int x, ref int y, ref string origin, ref string target)
        {
            Form menu = new Form();
            menu.Text = "Default Values";

            TextBox savedXValue = new TextBox();
            TextBox savedYValue = new TextBox();
            TextBox savedOrigin = new TextBox();
            savedOrigin.Text = origin;
            TextBox savedTarget = new TextBox();
            savedTarget.Text = target;

            Label xCrossValue = new Label();

            Label scalingValue = new Label();


            Label savedOriginLabel = new Label();
            savedOriginLabel.Text = "Default Origin Folder:";
            Label savedTargetLabel = new Label();
            savedTargetLabel.Text = "Default Target Folder:";

            Label title = new Label();
            title.Text = "Default Values";

            menu.SetBounds(20, 20, 400, 700);
            menu.ClientSize = new System.Drawing.Size(800, 400);
            menu.FormBorderStyle = FormBorderStyle.FixedDialog;
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.MinimizeBox = false;
            menu.MaximizeBox = false;


            title.SetBounds(20, 20, 160, 20);
            scalingValue.Text = "Default Trim:";
            scalingValue.SetBounds(20, 50, 160, 20);
            savedXValue.Text = x.ToString();
            savedXValue.SetBounds(115, 50, 100, 20);
            xCrossValue.Text = "X";
            xCrossValue.SetBounds(215, 50, 20, 20);
            savedYValue.Text = y.ToString();
            savedYValue.SetBounds(235, 50, 100, 20);
            savedOrigin.SetBounds(200, 80, 600, 20);
            savedOriginLabel.SetBounds(20, 80, 175, 20);
            savedTarget.SetBounds(200, 110, 600, 20);
            savedTargetLabel.SetBounds(20, 110, 175, 20);


            Button save = new Button();
            save.Text = "Save";
            Button cancel = new Button();
            cancel.Text = "Cancel";
            save.DialogResult = DialogResult.OK;
            cancel.DialogResult = DialogResult.Cancel;

            save.SetBounds(250, 300, 160, 60);
            cancel.SetBounds(410, 300, 160, 60);

            menu.Controls.Add(savedXValue);
            menu.Controls.Add(savedYValue);
            menu.Controls.Add(savedOrigin);
            menu.Controls.Add(savedTarget);
            menu.Controls.Add(xCrossValue);
            menu.Controls.Add(scalingValue);
            menu.Controls.Add(title);
            menu.Controls.Add(savedOriginLabel);
            menu.Controls.Add(savedTargetLabel);
            menu.Controls.Add(save);
            menu.Controls.Add(cancel);
            menu.AcceptButton = save;
            menu.CancelButton = cancel;
            DialogResult dialogResult = menu.ShowDialog();
            try
            {
                x = int.Parse(savedXValue.Text);
                y = int.Parse(savedYValue.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error: Wrong value entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            origin = savedOrigin.Text;
            target = savedTarget.Text;
            return dialogResult;
        }
        private void loadSettings()
        {
            string data = File.ReadAllText(savePath);

            if (data != "" && data != "{}")
            {
                SaveData loadedData = JsonConvert.DeserializeObject<SaveData>(data);
                txtOriginalSelectedPath.Text = loadedData.inputFolder;
                txtTargetSelectedPath.Text = loadedData.outputFolder;
                defaultX = loadedData.x;
                defaultY = loadedData.y;
                this.clearListBox();



                // iterate over all files in the selected folder and add them to 
                // the listbox.
                foreach (string filename in Directory.GetFiles(loadedData.inputFolder))
                    this.listBox1.Items.Add(filename);
            }

        }

        private void useDefault_CheckedChanged(object sender, EventArgs e)
        {
            if(useDefault.Checked == true)
            {
                useDefaults = true;
            } else
            {
                useDefaults = false;
            }
        }

        public sealed class SaveData
        {
            public string outputFolder { get; set; }
            public string inputFolder { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public SaveData(string outputFolder, string inputFolder, int x, int y)
            {
                this.outputFolder = outputFolder;
                this.inputFolder = inputFolder;
                this.x = x;
                this.y = y;

            }
        }

        private void frmConvertHEICToJPG_Load(object sender, EventArgs e)
        {

        }
    }
}