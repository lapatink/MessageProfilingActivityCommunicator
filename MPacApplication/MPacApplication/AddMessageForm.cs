using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPacApplication
{
    public partial class AddMessageForm : Form
    {
        private MainForm parentForm;

        public enum messageType { local, company };

        public AddMessageForm(MainForm sourceForm)
          {
               InitializeComponent();
            //this causes problems with other windows. Do not use yet.
               //new Focus(this);
               parentForm = sourceForm;

               //move all the panels to the correct location
               //note: some of these panels are off the edge of the window on the designer.
               pnlCustomFormat.Location = new Point(271, 135);
               pnlExternalProgram.Location = new Point(271, 135);
               pnlUniformGroup.Location = new Point(271, 135);
            
                //won't let me do this in the designer for some reason
                //default selections
               cmbDefaultFormat.SelectedIndex = 3;
               cmbDefaultType.SelectedIndex = 0;
               cmbGroup.SelectedIndex = 0;
               cmbCount.SelectedIndex = 0;
               cmbType.SelectedIndex = 0;
               cmbFormat.SelectedIndex = 3;
               cmbUniformFormat.SelectedIndex = 3;
               cmbUniformGroup.SelectedIndex = 1;
            
               reset();
          }
        public AddMessageForm(MainForm sourceForm, messageType type)
        {
            InitializeComponent();

            //move all the panels to the correct location
            //note: some of these panels are off the edge of the window on the designer.
            pnlCustomFormat.Location = new Point(271, 135);
            pnlExternalProgram.Location = new Point(271, 135);
            pnlUniformGroup.Location = new Point(271, 135);

            //won't let me do this in the designer for some reason
            //default selections
            cmbDefaultFormat.SelectedIndex = 3;
            cmbDefaultType.SelectedIndex = 0;
            cmbGroup.SelectedIndex = 0;
            cmbCount.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbFormat.SelectedIndex = 3;
            cmbUniformFormat.SelectedIndex = 3;
            cmbUniformGroup.SelectedIndex = 1;
            parentForm = sourceForm;
            reset();
        }

        private void txtVersion1_LostFocus(object sender, EventArgs e)
        {
            if (txtVersion1.Text != "")
            {
                try
                {
                    int n = int.Parse(txtVersion1.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtVersion1.Text = "00";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtVersion1.Text = "00";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtVersion2_LostFocus(object sender, EventArgs e)
        {
            if (txtVersion2.Text != "")
            {
                try
                {
                    int n = int.Parse(txtVersion2.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtVersion2.Text = "00";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtVersion2.Text = "00";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtID1_LostFocus(object sender, EventArgs e)
        {
            if (txtID1.Text != "")
            {
                try
                {
                    int n = int.Parse(txtID1.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtID1.Text = "00";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtID1.Text = "00";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtID2_LostFocus(object sender, EventArgs e)
        {
            if (txtID2.Text != "")
            {
                try
                {
                    int n = int.Parse(txtID2.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtID2.Text = "00";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtID2.Text = "00";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtLength_LostFocus(object sender, EventArgs e)
        {
            if (txtLength.Text != "")
            {
                try
                {
                    int n = int.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtLength.Text = "00";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtLength.Text = "00";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.getMessagesCount(); i++)
            {
                if ((Byte.Parse(txtID1.Text, System.Globalization.NumberStyles.HexNumber) == MainForm.getMessageHigh(i)) && (Byte.Parse(txtID2.Text, System.Globalization.NumberStyles.HexNumber) == MainForm.getMessageLow(i)))
                {
                    MessageBox.Show("Message ID already exists", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Visible = false;
                    reset();
                    return;
                }
				if (txtName.Text == MainForm.getMessageName(i))
                {
                    MessageBox.Show("Message name already exists", "Duplicate name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Visible = false;
                    reset();
                    return;
                }
            }

            if (cmbFormatType.SelectedIndex == 0)
            {
                txtFormat.Text = "df " + Format.getTokenString(cmbDefaultFormat.Text) + " " + Format.getTokenString(cmbDefaultType.Text) + " ";
                txtFormat.Text += "dl " + txtDelim.Text.Replace(" ", @"\s").Replace(",", @"\c") + " ";
                txtFormat.Text += "g " + cmbUniformGroup.Text + " 255 " + Format.getTokenString(cmbUniformFormat.Text) + " b";
            }
            else if (cmbFormatType.SelectedIndex == 1)
            {
                txtFormat.Text = "df " + Format.getTokenString(cmbDefaultFormat.Text) + " " + Format.getTokenString(cmbDefaultType.Text) + " ";
                txtFormat.Text += "dl " + txtDelim.Text.Replace(" ", @"\s").Replace(",", @"\c") + " ";
                foreach (FormatLine f in lstFormats.Items)
                    txtFormat.Text += f.ToFormatString();
            }
            else if (cmbFormatType.SelectedIndex == 2)
            {
                txtFormat.Text = "call " + txtExternalFile.Text;
            }

            parentForm.PrintStatusMessage("Format string: " + txtFormat.Text);
            MessageFormat message = new MessageFormat(
                Byte.Parse(txtVersion1.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtVersion2.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtID1.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtID2.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber),
                txtName.Text,
                txtFormat.Text);

            MainForm.createMessageFormat(message);
            this.Visible = false;
            reset();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            reset();
        }

        private void reset()
        {
            txtVersion1.Text = "00";
            txtVersion2.Text = "00";
            txtID1.Text = "00";
            txtID2.Text = "00";
            txtLength.Text = "00";
            txtName.Text = "";
            txtFormat.Text = "";
            cmbDefaultFormat.SelectedIndex = 3;
            cmbDefaultType.SelectedIndex = 0;
            cmbGroup.SelectedIndex = 0;
            cmbCount.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbFormat.SelectedIndex = 3;
            cmbUniformFormat.SelectedIndex = 3;
            cmbUniformGroup.SelectedIndex = 1;
            cmbFormatType.SelectedIndex = -1;

            pnlCustomFormat.Hide();
            pnlExternalProgram.Hide();
            pnlUniformGroup.Hide();

            lstFormats.Items.Clear();
            txtExternalFile.Text = "";
        }

        private void cmbFormatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormatType.SelectedIndex == 0)
            {
                pnlDefault.Enabled = true; 
                pnlUniformGroup.Show();
                pnlExternalProgram.Hide();
                pnlCustomFormat.Hide();
                
            }
            else if (cmbFormatType.SelectedIndex == 1)
            {
                pnlDefault.Enabled = true;
                pnlCustomFormat.Show();
                pnlExternalProgram.Hide();
                pnlUniformGroup.Hide();
            }
            else if (cmbFormatType.SelectedIndex == 2)
            {
                pnlDefault.Enabled = false;
                pnlExternalProgram.Show();
                pnlCustomFormat.Hide();
                pnlUniformGroup.Hide();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Files|*.*";
            fileDialog.InitialDirectory = "%USERPROFILE%";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtExternalFile.Text = fileDialog.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormatLine f = new FormatLine();

            f.count = cmbCount.Text;
            f.type = cmbType.Text;
            f.group = cmbGroup.Text;
            f.display = cmbFormat.Text;

            lstFormats.Items.Add(f);
        }


        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstFormats.SelectedIndex >= 1 && lstFormats.SelectedIndex < lstFormats.Items.Count)
            {
                var sel = lstFormats.Items[lstFormats.SelectedIndex];
                var above = lstFormats.Items[lstFormats.SelectedIndex - 1];
                lstFormats.Items[lstFormats.SelectedIndex] = above;
                lstFormats.Items[lstFormats.SelectedIndex - 1] = sel;
                lstFormats.SelectedIndex--;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstFormats.SelectedIndex >= 0 && lstFormats.SelectedIndex < lstFormats.Items.Count - 1)
            {
                var sel = lstFormats.Items[lstFormats.SelectedIndex];
                var below = lstFormats.Items[lstFormats.SelectedIndex + 1];
                lstFormats.Items[lstFormats.SelectedIndex] = below;
                lstFormats.Items[lstFormats.SelectedIndex + 1] = sel;
                lstFormats.SelectedIndex++;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstFormats.SelectedIndex >= 0 && lstFormats.SelectedIndex < lstFormats.Items.Count)
                lstFormats.Items.RemoveAt(lstFormats.SelectedIndex);
        }

        #region  Class FormatLine

        private class FormatLine
        {
            public string group = "";
            public string count = "";
            public string type = "";
            public string display = "";

            public override string ToString()
            {

                bool plural = false;
                int g = 0;
                g = int.Parse(group);
                if (count == "*")
                    plural = true;
                else
                {
                    try { if (int.Parse(count) > 1) plural = true; }
                    catch { }
                }

                return "Display " + count + ((g > 1) ? " group" + (plural ? "s" : "") + " of " + group : "") + " " + type +
                    (plural ? "s" : "") + " as " + (plural ? "" : "a ") + display +
                    " value" + (plural ? "s" : "") + ".";
            }
            public string ToFormatString()
            {
                int g = int.Parse(group);
                if (g > 1)
                {
                    return "g " + group + " " + count + " " + Format.getTokenString(display) + " " + Format.getTokenString(type) + " ";
                }
                else
                {
                    return count + " " + Format.getTokenString(display) + " " + Format.getTokenString(type) + " ";
                }
            }
        }
        #endregion
    }
}
