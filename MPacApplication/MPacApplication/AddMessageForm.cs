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
    public enum MessageType { Local, Company };

    public partial class AddMessageForm : Form
    {
        private MainForm parentForm;
        private MessageType msgType;
        private bool error;

        private int _bytes = 0;
        private int _bytes_used = 0;

        private int bytes
        {
            get { return _bytes; }
            set
            {
                _bytes = value;
                lblvBytes.Text = (_bytes - _bytes_used).ToString();
            }
        }
        private int bytes_used
        {
            get { return _bytes_used; }
            set
            {
                _bytes_used = value;
                lblvBytes.Text = (_bytes - _bytes_used).ToString();
            }

        }  

        public AddMessageForm(MainForm sourceForm)
          {
               InitializeComponent();
               parentForm = sourceForm;
               reset();
          }
        public AddMessageForm(MainForm sourceForm, MessageType type)
        {
            InitializeComponent();
            parentForm = sourceForm;
            msgType = type;

            if (type == MessageType.Company)
                this.Text = "Add Company Message";
            else
                this.Text = "Add Local Message";

            reset();
        }

        private void txtVersion1_LostFocus(object sender, EventArgs e)
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

        private void txtVersion2_LostFocus(object sender, EventArgs e)
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

        private void txtID1_LostFocus(object sender, EventArgs e)
        {
                try
                {
                    int n = int.Parse(txtID1.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtID1.Text = "00";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        error = true;
                    }
                    else if (msgType == MessageType.Company && n <= 127)
                    {
                        txtID1.Text = "00";
                        MessageBox.Show("Company message ID must be 0x8000 and above", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        error = true;
                    }
                    else if (msgType == MessageType.Local && n > 127)
                    {
                        txtID1.Text = "00";
                        MessageBox.Show("Local message ID must be below 0x8000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        error = true;
                    }
                }
                catch
                {
                    txtID1.Text = "00";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    error = true;
                }
        }

        private void txtID2_LostFocus(object sender, EventArgs e)
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

        private void txtLength_LostFocus(object sender, EventArgs e)
        {
                try
                {
                    int n = int.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber);
                    bytes = n;
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
        private void txtName_LostFocus(object sender, EventArgs e)
        {
                try
                {
                    if (txtName.Text.Trim() == "")
                    {
                        MessageBox.Show("Name must not be left blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        error = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Name must not be left blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    error = true;
                }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            error = false;
            txtID1_LostFocus(sender, e);
            txtName_LostFocus(sender, e);
            if (error == true)
                return;

            for (int i = 0; i < parentForm.GetMessagesCount(msgType); i++)
            {
                if ((Byte.Parse(txtID1.Text, System.Globalization.NumberStyles.HexNumber) == parentForm.GetMessageHighByte(i, msgType)) && (Byte.Parse(txtID2.Text, System.Globalization.NumberStyles.HexNumber) == parentForm.GetMessageLowByte(i, msgType)))
                {
                    MessageBox.Show("Message ID already exists", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
			 if (txtName.Text == parentForm.GetMessageName(i, msgType))
                {
                    MessageBox.Show("Message name already exists", "Duplicate name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }

            if (cmbFormatType.SelectedIndex == 0)
            {
                txtFormat.Text += "g * " + cmbUniformGroup.Text + " " + Format.getTokenString(cmbUniformFormat.Text);

                if (txtFormat.Text == "g * 1 h")
                    txtFormat.Text = "%"; //slight optimization, the parser will skip some extra work
            }
            else if (cmbFormatType.SelectedIndex == 1)
            {
                if ((bytes - bytes_used) < 0)
                {
                    MessageBox.Show("The custom format specified is too long.", "Invalid Custom Format", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
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

            if (msgType == MessageType.Company)
            {
                if (cmbConnections.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a database connection.", "Company message failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                Connection c = (Connection)cmbConnections.Items[cmbConnections.SelectedIndex];
                SqlMessageConnection sql = new SqlMessageConnection(c.connection);
                if (sql.Write(message) == false)
                {
                    MessageBox.Show("Company message failed", "Company message failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                MessageBox.Show("Company message created", "Company message created", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Local message created", "Local message created", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            parentForm.AddMessageFormat(message, msgType);
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
            txtVersion1.Text = "01";
            txtVersion2.Text = "00";
            if (msgType == MessageType.Company)
                txtID1.Text = "80";
            else
                txtID1.Text = "00";
            txtID2.Text = "00";
            txtLength.Text = "00";
            txtName.Text = "";
            txtFormat.Text = "";
            cmbGroup.SelectedIndex = 0;
            cmbCount.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbFormat.SelectedIndex = 2;
            cmbUniformFormat.SelectedIndex = 1;
            cmbUniformGroup.SelectedIndex = 0;
            cmbFormatType.SelectedIndex = 0;

            pnlCustomFormat.Location = new Point(271, 110);
            pnlExternalProgram.Location = new Point(271, 110);
            pnlUniformGroup.Location = new Point(271, 110);

            bytes = 0;
            bytes_used = 0;

            pnlCustomFormat.Hide();
            pnlExternalProgram.Hide();
            pnlUniformGroup.Show();

            lstFormats.Items.Clear();
            txtExternalFile.Text = "";

            cmbConnections.Items.Clear();
            cmbConnections.Hide();
            lblConnection.Hide();

            if (parentForm.IsAdministrator && msgType == MessageType.Company)
            {
                Configuration config = new Configuration();

                string[] connections = config.Read();

                foreach (string connection in connections)
                    cmbConnections.Items.Add(new Connection(connection));

                if (cmbConnections.Items.Count == 1)
                    cmbConnections.SelectedIndex = 0;

                lblConnection.Show();
                cmbConnections.Show();
            }


        }

        private void UpdateControls(bool typefield = false)
        {
            bytes = 0;
            int group = 0;
            int count = 0;
            int type = 0;

            try { bytes = int.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber); }
            catch { }

            try { group = int.Parse(cmbGroup.Text); }
            catch { }

            try { count = int.Parse(cmbCount.Text); }
            catch { }

            type = FormatParser.sizeOf(cmbType.Text);

            int size = 0;

            string old_type = "";
            if (cmbType.SelectedIndex > -1)
                old_type = (string)cmbType.Items[cmbType.SelectedIndex];

            if (cmbFormat.Text == "decimal" && !typefield)
            {
                cmbType.Items.Clear();
                cmbType.Items.Add("byte");
                cmbType.Items.Add("ushort");
                cmbType.Items.Add("short");
                cmbType.Items.Add("uint");
                cmbType.Items.Add("int");
                cmbType.Items.Add("ulong");
                cmbType.Items.Add("long");

            }
            else if (!typefield)
            {
                cmbType.Items.Clear();
                cmbType.Items.Add("byte");
                cmbType.Items.Add("short");
                cmbType.Items.Add("int");
                cmbType.Items.Add("long");
            }

            if (old_type.Length > 0)
            {
                if (old_type[0] == 'u')
                    old_type = old_type.Substring(1);
                if (!typefield)
                    cmbType.Text = old_type;
            }


            if (group > 1)
            {
                if (!typefield)
                {
                    cmbType.Text = "byte";
                    cmbType.Enabled = false;
                }

                size = group * count;
            }
            else
            {
                cmbType.Enabled = true;
                size = type * count;
            }

            if (size > (bytes - bytes_used))
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;


        }

        private void cmbFormatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormatType.SelectedIndex == 0)
            {
                pnlUniformGroup.Show();
                pnlExternalProgram.Hide();
                pnlCustomFormat.Hide();
                
            }
            else if (cmbFormatType.SelectedIndex == 1)
            {
                pnlCustomFormat.Show();
                pnlExternalProgram.Hide();
                pnlUniformGroup.Hide();
            }
            else if (cmbFormatType.SelectedIndex == 2)
            {
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

            bytes_used += f.getSize();
            UpdateControls();

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
            {
                FormatLine f = (FormatLine)lstFormats.Items[lstFormats.SelectedIndex];
                bytes_used -= f.getSize();
                UpdateControls();
                lstFormats.Items.RemoveAt(lstFormats.SelectedIndex);
            }
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
            public int getSize()
            {

                int t = FormatParser.sizeOf(type);
                int g = 0;
                int c = 0;

                try { c = int.Parse(count); }
                catch { }
                try { g = int.Parse(group); }
                catch { }

                if (g < 2)
                {
                    return t * c;
                }
                else
                {
                    return g * c * t;
                }

            }
        }
        #endregion
        
        #region Class Connection
        private class Connection
        {
            public string connection;
            public Connection(string connection)
            {
                this.connection = connection;
            }
            public override string ToString()
            {
                return connection.Split(';')[1] + " Table=" + connection.Split(';')[4];
            }
        }
        #endregion

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void cmbGroup_TextChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void cmbCount_TextChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void cmbFormat_TextChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void cmbType_TextChanged(object sender, EventArgs e)
        {
            UpdateControls(true);
        }

    }
}
