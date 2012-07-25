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
        private ushort ID;

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
        private void txtID_LostFocus(object sender, EventArgs e)
        {
                try
                {
                    int n = int.Parse(txtID.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 65535)
                    {
                        if (msgType == MessageType.Company)
                        {
                            txtID.Text = "8000";
                            lblIdError2.Visible = true;
                        }
                        else
                        {
                            txtID.Text = "0000";
                            lblIdError1.Visible = true;
                        }
                        error = true;
                    }
                    else if (msgType == MessageType.Company && n <= 32767)
                    {
                        txtID.Text = "8000";
                        lblIdError2.Visible = true;
                        error = true;
                    }
                    else if (msgType == MessageType.Local && n > 32767)
                    {
                        txtID.Text = "0000";
                        lblIdError1.Visible = true;
                        error = true;
                    }
                    else
                    {
                        lblIdError1.Visible = false;
                        lblIdError2.Visible = false;
                        ID = ushort.Parse(txtID.Text, System.Globalization.NumberStyles.HexNumber);
                    }
                }
                catch
                {
                    if (msgType == MessageType.Company)
                    {
                        txtID.Text = "8000";
                        lblIdError2.Visible = true;
                    }
                    else
                    {
                        txtID.Text = "0000";
                        lblIdError1.Visible = true;
                    }
                    error = true;
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
                        lblLengthError.Visible = true;
                    }
                    else
                        lblLengthError.Visible = false;
                }
                catch
                {
                    txtLength.Text = "00";
                    lblLengthError.Visible = true;
                }
        }
        private void txtName_LostFocus(object sender, EventArgs e)
        {
                try
                {
                    if (txtName.Text.Trim() == "")
                    {
                        lblNameError1.Visible = true;
                        error = true;
                    }
                    else
                        lblNameError1.Visible = false;
                }
                catch
                {
                    lblNameError1.Visible = true;
                    error = true;
                }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            byte[] versionBytes = BitConverter.GetBytes(MainForm.SOFTWARE_VERSION);
            byte[] IdBytes = BitConverter.GetBytes(ID);
            error = false;
            txtID_LostFocus(sender, e);
            txtName_LostFocus(sender, e);
            if (error == true)
                return;

            for (int i = 0; i < parentForm.GetMessagesCount(msgType); i++)
            {
                if (IdBytes[0] == parentForm.GetMessageHighByte(i, msgType) && IdBytes[1] == parentForm.GetMessageLowByte(i, msgType))
                {
                    lblIdError3.Visible = true;
                    return;
                }
                else
                    lblIdError3.Visible = false;
			 if (txtName.Text == parentForm.GetMessageName(i, msgType))
                {
                    lblNameError2.Visible = true;
                    return;
                }
             else
                 lblNameError2.Visible = false;
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
                    lblCustomError.Visible = true;
                    return;
                }
                else
                    lblCustomError.Visible = false;
                foreach (FormatLine f in lstFormats.Items)
                    txtFormat.Text += f.ToFormatString();
            }
            else if (cmbFormatType.SelectedIndex == 2)
            {
                txtFormat.Text = "call " + txtExternalFile.Text;
            }
            parentForm.PrintStatusMessage("Format string: " + txtFormat.Text);
            MessageFormat message = new MessageFormat(
                versionBytes[1],
                versionBytes[0],
                IdBytes[1],
                IdBytes[0],
                Byte.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber),
                txtName.Text,
                txtFormat.Text);

            if (msgType == MessageType.Company)
            {
                if (cmbConnections.SelectedIndex < 0)
                {
                    lblCompanyError1.Visible = true;
                    return;
                }
                else
                    lblCompanyError1.Visible = false;
                Connection c = (Connection)cmbConnections.Items[cmbConnections.SelectedIndex];
                SqlMessageConnection sql = new SqlMessageConnection(c.connection);
                if (sql.Write(message) == false)
                {
                    lblCompanyError2.Visible = true;
                    return;
                }
                else
                    lblCompanyError2.Visible = false;
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
            if (msgType == MessageType.Company)
                txtID.Text = "8000";
            else
                txtID.Text = "0000";
            txtLength.Text = "00";
            txtName.Text = "";
            txtFormat.Text = "";
            cmbGroup.SelectedIndex = 0;
            cmbCount.SelectedIndex = 0;
            cmbFormat.SelectedIndex = 2;
            cmbUniformFormat.SelectedIndex = 1;
            cmbUniformGroup.SelectedIndex = 0;
            cmbFormatType.SelectedIndex = 0;

            pnlCustomFormat.Location = new Point(15, 128);
            pnlExternalProgram.Location = new Point(15, 128);
            pnlUniformGroup.Location = new Point(15, 128);

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

        private void UpdateControls()
        {
            bytes = 0;
            int group = 0;
            int count = 0;

            try { bytes = int.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber); }
            catch { }

            try { group = int.Parse(cmbGroup.Text); }
            catch { }

            try { count = int.Parse(cmbCount.Text); }
            catch { }

               int size = group * count;



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

                return "Display " + count + ((g > 1) ? " group" + (plural ? "s" : "") + " of " + group : "") + " byte" +
                    (plural ? "s" : "") + " as " + (plural ? "" : "a ") + display +
                    " value" + (plural ? "s" : "") + ".";
            }
            public string ToFormatString()
            {
                    return group + " " + count + " " + Format.getTokenString(display) + " ";
            }
            public int getSize()
            {

                int g = 0;
                int c = 0;

                try { c = int.Parse(count); }
                catch { }
                try { g = int.Parse(group); }
                catch { }

                return g * c;
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
    }
}
