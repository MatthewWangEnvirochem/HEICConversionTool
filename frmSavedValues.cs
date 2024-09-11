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


namespace HEICTransfer
{
    public class frmSavedValues
    {
        public Form menu { get; }
        public TextBox savedXValue { get; }
        public TextBox savedYValue { get; }
        public TextBox savedOrigin { get; }
        public TextBox savedTarget { get; }
        public TextBox savedTarget { get; }
        public Label xCrossValue { get; }
        public Label scalingValue { get; }
        public Label savedOriginLabel { get; }
        public Label savedTargetLabel { get; }
        public Label title { get; }
        public Button save { get; }
        public Button cancel { get; }
        public Button btnSelectTarget { get; }
        public Button btnSelectOrigin { get; }

        public frmSavedValues(int x, int y, string origin, string target)
        {
            menu = new Form();
            menu.Text = "Default Values";

            savedXValue = new TextBox();
            savedYValue = new TextBox();
            savedOrigin = new TextBox();
            savedOrigin.Text = origin;
            savedTarget = new TextBox();
            savedTarget.Text = target;

            xCrossValue = new Label();

            scalingValue = new Label();


            savedOriginLabel = new Label();
            savedOriginLabel.Text = "Default Origin:";
            savedTargetLabel = new Label();
            savedTargetLabel.Text = "Default Target:";

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
            savedOrigin.SetBounds(130, 110, 600, 20);
            savedOrigin.ReadOnly = true;
            savedOriginLabel.SetBounds(20, 110, 120, 20);
            savedTarget.SetBounds(130, 170, 600, 20);
            savedTarget.ReadOnly = true;
            savedTargetLabel.SetBounds(20, 170, 120, 20);


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
            menu.Controls.Add(btnSelectTarget);
            menu.Controls.Add(btnSelectOrigin);
            menu.AcceptButton = save;
            menu.CancelButton = cancel;
        }
    }
}




