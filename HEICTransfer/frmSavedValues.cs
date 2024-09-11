using System;
using System.Windows.Forms;
using System.IO;
namespace HEICTransfer
{
    public class frmSavedValues
    {
        public Form menu { get; }
        public TextBox savedXValue { get; }
        public TextBox savedYValue { get; }
        public TextBox savedInput { get; }
        public TextBox savedOutput { get; }
        public Label xCrossValue { get; }
        public Label scalingValue { get; }
        public Label savedInputLabel { get; }
        public Label savedOutputLabel { get; }
        public Label title { get; }
        public Button save { get; }
        public Button cancel { get; }
        public Button btnSelectTarget { get; }
        public Button btnSelectOrigin { get; }
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;


        public frmSavedValues(int x, int y, string input, string output)
        {
            menu = new Form();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            menu.Text = "Default Values";

            savedXValue = new TextBox();
            savedYValue = new TextBox();
            savedInput = new TextBox();
            savedInput.Text = input;
            savedOutput = new TextBox();
            savedOutput.Text = output;

            xCrossValue = new Label();

            scalingValue = new Label();


            savedInputLabel = new Label();
            savedInputLabel.Text = "Default Origin:";
            savedOutputLabel = new Label();
            savedOutputLabel.Text = "Default Target:";

            title = new Label();
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
            savedInput.SetBounds(130, 110, 600, 20);
            savedInput.ReadOnly = true;
            savedInputLabel.SetBounds(20, 110, 120, 20);
            savedOutput.SetBounds(130, 170, 600, 20);
            savedOutput.ReadOnly = true;
            savedOutputLabel.SetBounds(20, 170, 120, 20);


            save = new Button();
            save.Text = "Save";
            cancel = new Button();
            cancel.Text = "Cancel";
            save.DialogResult = DialogResult.OK;
            cancel.DialogResult = DialogResult.Cancel;

            save.SetBounds(250, 300, 160, 60);
            cancel.SetBounds(410, 300, 160, 60);

            btnSelectTarget = new Button();
            btnSelectOrigin = new Button();

            btnSelectOrigin.Text = "Select New Default Origin";
            btnSelectTarget.Text = "Select New Default Target";
            btnSelectOrigin.SetBounds(130, 80, 320, 30);
            btnSelectTarget.SetBounds(130, 140, 320, 30);
            btnSelectOrigin.Click += BtnSelectOrigin_Click;
            btnSelectTarget.Click += BtnSelectTarget_Click;

            menu.Controls.Add(savedXValue);
            menu.Controls.Add(savedYValue);
            menu.Controls.Add(savedInput);
            menu.Controls.Add(savedOutput);
            menu.Controls.Add(xCrossValue);
            menu.Controls.Add(scalingValue);
            menu.Controls.Add(title);
            menu.Controls.Add(savedInputLabel);
            menu.Controls.Add(savedOutputLabel);
            menu.Controls.Add(save);
            menu.Controls.Add(cancel);
            menu.Controls.Add(btnSelectTarget);
            menu.Controls.Add(btnSelectOrigin);
            menu.AcceptButton = save;
            menu.CancelButton = cancel;
        }

        private void BtnSelectOrigin_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // retrieve the name of the selected folder
                string foldername = this.folderBrowserDialog.SelectedPath;

                // print the folder name on a label
                savedInput.Text = foldername;
            }
        }

        private void BtnSelectTarget_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // retrieve the name of the selected folder
                string foldername = this.folderBrowserDialog.SelectedPath;

                // print the folder name on a label
                savedOutput.Text = foldername;
            }
        }

        public DialogResult savedValues(ref int x, ref int y, ref string input, ref string output)
        {
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

            input = savedInput.Text;
            output = savedOutput.Text;
            return dialogResult;
        }


    }
}

