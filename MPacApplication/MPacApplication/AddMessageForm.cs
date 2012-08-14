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
        private int editIndex = -1;
        private int loadFile = 0;
        private ushort ID;
        private const ushort CONTROLX = 15;
        private const ushort CONTROLY = 128; 

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
        }

        public AddMessageForm(MainForm sourceForm, MessageType type, int index)
        {
            InitializeComponent();
            parentForm = sourceForm;
            msgType = type;
            editIndex = index;
            

            if (type == MessageType.Company)
                this.Text = "Add Company Message";
            else
                this.Text = "Add Local Message";
        }
        private void txtID_check(object sender, EventArgs e)
        {
                try
                {
                    int n = int.Parse(txtID.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 65535)
                    {
                        if (msgType == MessageType.Company)
                            lblIdError2.Visible = true;
                        else
                            lblIdError1.Visible = true;
                        error = true;
                    }
                    else if (msgType == MessageType.Company && n <= 32767)
                    {
                        lblIdError2.Visible = true;
                        error = true;
                    }
                    else if (msgType == MessageType.Local && n > 32767)
                    {
                        lblIdError1.Visible = true;
                        error = true;
                    }
                    else
                    {
                        lblIdError1.Visible = false;
                        lblIdError2.Visible = false;
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

        private void txtLength_check(object sender, EventArgs e)
        {
                try
                {
                    int n = int.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber);
                    bytes = n;
                    if (n < 0 || n > 255)
                    {
                        lblLengthError.Visible = true;
                        error = true;
                    }
                    else
                        lblLengthError.Visible = false;
                }
                catch
                {
                    lblLengthError.Visible = true;
                    error = true;
                }
        }

        private void txtName_check(object sender, EventArgs e)
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
            lblNameError2.Visible = false;
            lblIdError3.Visible = false;
            error = false;
            txtName_check(sender, e);
            txtID_check(sender, e);
            txtLength_check(sender, e);
            if (error == true)
                return;
            ID = ushort.Parse(txtID.Text, System.Globalization.NumberStyles.HexNumber);
            byte[] versionBytes = BitConverter.GetBytes(MainForm.SOFTWARE_VERSION);
            byte[] IdBytes = BitConverter.GetBytes(ID);

            for (int i = 0; i < parentForm.GetMessagesCount(msgType); i++)
            {
                if (i == editIndex)
                    continue;

                if ((IdBytes[1] == parentForm.GetMessageHighByte(i, msgType)) && (IdBytes[0] == parentForm.GetMessageLowByte(i, msgType)))
                {
                    lblIdError3.Visible = true;
                    error = true;
                }
                if (txtName.Text.Trim() == parentForm.GetMessageName(i, msgType))
                {
                    lblNameError2.Visible = true;
                    error = true;
                }
            }
            if (error == true)
                return;

            if (cmbFormatType.SelectedIndex == 0)
            {
                txtFormat.Text = "* " + cmbUniformGroup.Text + " " + Format.getTokenString(cmbUniformFormat.Text);
                if (cmbUniformFormat.Text == "decimal")
                    if (cmbUniformSigned.Text == "unsigned")
                        txtFormat.Text = "* " + cmbUniformGroup.Text + " " + Format.getTokenString("unsigned");
                

                if (txtFormat.Text == "* 1 h")
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
            
            MessageFormat message = new MessageFormat(
                versionBytes[1],
                versionBytes[0],
                IdBytes[1],
                IdBytes[0],
                Byte.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber),
                txtName.Text.Trim(),
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
            if (editIndex > -1)
                parentForm.RemoveMessageFormat(editIndex);
            parentForm.AddMessageFormat(message, msgType);
            this.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            editIndex = -1;
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
            cmbSigned.SelectedIndex = 0;
            cmbUniformSigned.SelectedIndex = 0;
            cmbUniformFormat.SelectedIndex = 2;
            cmbUniformGroup.SelectedIndex = 0;
            cmbFormatType.SelectedIndex = 0;

            cmbUniformSigned.Hide();
            lblUniformSigned.Hide();
            cmbSigned.Hide();
            lblUniformSigned.Hide();

            lblIdError1.Visible = false;
            lblIdError2.Visible = false;
            lblIdError3.Visible = false;
            lblNameError1.Visible = false;
            lblNameError2.Visible = false;
            lblLengthError.Visible = false;
            lblCompanyError1.Visible = false;
            lblCompanyError2.Visible = false;
            lblCustomError.Visible = false;

            Point controlPoint = new Point(CONTROLX, CONTROLY);
            pnlCustomFormat.Location = controlPoint;
            pnlExternalProgram.Location = controlPoint;
            pnlUniformGroup.Location = controlPoint;

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

            UpdateControls();

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

            editIndex = -1;
        }

        private void UpdateControls()
        {
            bytes = 0;
            int group = 0;
            int count = 0;

            try { bytes = int.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber); }
            catch { }

            if (bytes == 0)
            {
                pnlCustomFormat.Hide();
                pnlExternalProgram.Hide();
                pnlUniformGroup.Hide();
                cmbFormatType.Hide();
                lblFormat.Hide();
            }
            else
            {
                cmbFormatType.Show();
                lblFormat.Show();

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

            try { group = int.Parse(cmbGroup.Text); }
            catch { cmbGroup.Text = "1"; group = 1; }

            try { count = int.Parse(cmbCount.Text); }
            catch { cmbCount.Text = "1"; count = 1; }

               int size = group * count;

               if (cmbFormat.Text == "decimal")
               {
                   cmbSigned.Show();
                   lblSigned.Show();
               }
               else
               {
                   cmbSigned.Hide();
                   lblSigned.Hide();

               }

            if (size > (bytes - bytes_used))
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;


        }

        private void Edit(int index)
        {
            MessageFormat m = null;

            if (index < 0)
                return;
            m = parentForm.GetMessageFormat(index);

            txtLength.Text = m.Length.ToString("X");
            txtName.Text = m.Name;
            byte[] id = { m.IdHigh, m.IdLow };
            try { txtID.Text = ushort.Parse(Format.AsUnsignedDecimal(id)).ToString("X"); }
            catch { }
            if (m.FormatString == "%" || m.FormatString == "")
                return;
            
            string[] tokens = m.FormatString.Split(' ');

            if (tokens.Length < 2)
                return;

            if (tokens[0] == "call")
            {
                cmbFormatType.SelectedIndex = 2;
                txtExternalFile.Text = tokens[1];
            }
            else if (tokens[0] == "*")
            {
                cmbFormatType.SelectedIndex = 0;
                try { int.Parse(tokens[1]); cmbUniformGroup.Text = tokens[1]; }
                catch { }
                switch (tokens[2])
                {
                    case "b":
                        cmbUniformFormat.Text = "binary";
                        break;
                    case "h":
                        cmbUniformFormat.Text = "hex";
                        break;
                    case "d":
                        cmbUniformFormat.Text = "decimal";
                        cmbUniformSigned.Text = "signed";
                        break;
                    case "u":
                        cmbUniformFormat.Text = "decimal";
                        cmbUniformSigned.Text = "unsigned";
                        break;
                }
            }
            else
            {
                cmbFormatType.SelectedIndex = 1;

                string formatline = "";
                for (int i = 0; i < tokens.Length; i++)
                {
                    formatline += tokens[i] + " ";
                    if (i % 3 == 2)
                    {
                        formatline = formatline.Trim();
                        FormatLine f = new FormatLine(formatline);
                        bytes_used += f.getSize();
                        lstFormats.Items.Add(f);
                        formatline = "";
                    }
                }
            }
            UpdateControls();

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
            loadFile = 1;
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


            f.display = cmbFormat.Text;
            if (cmbFormat.Text == "decimal")
                if (cmbSigned.Text == "unsigned")
                    f.display = "unsigned";

            f.count = cmbCount.Text;
            f.group = cmbGroup.Text;

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

            public FormatLine()
            { }
            public FormatLine(string tokens)
            {
                string[] token = tokens.Split(' ');
                group = token[1];
                count = token[0];
                switch (token[2])
                {
                    case "b":
                        display = "binary";
                        break;
                    case "h":
                        display = "hex";
                        break;
                    case "d":
                        display = "decimal";
                        break;
                    case "u":
                        display = "unsigned";
                        break;
                }

            }
            public override string ToString()
            {

                bool plural1 = false;
                bool plural2 = false;
                int g = 0;
                try { g = int.Parse(group); }
                catch { }
                if (g > 1)
                    plural2 = true;
                if (count == "*")
                    plural1 = true;
                else
                {
                    try { if (int.Parse(count) > 1) plural1 = true; }
                    catch { }
                }

                return "Display " + count + (plural2 ? " group" + (plural1 ? "s" : "") + " of " + group : "") + " byte" +
                    (plural2 || plural1 ? "s" : "") + " as " + (plural1 ? "" : (display[0] == 'u' ? "an " :"a ")) + display +
                    " value" + (plural1 ? "s" : "") + ".";
            }
            public string ToFormatString()
            {
                    return count + " " + group + " " + Format.getTokenString(display) + " ";
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

        private void cmbUniformFormat_TextChanged(object sender, EventArgs e)
        {
            if (cmbUniformFormat.Text == "decimal")
            {
                cmbUniformSigned.Show();
                lblUniformSigned.Show();
            }
            else
            {
                cmbUniformSigned.Hide();
                lblUniformSigned.Hide();
            }
        }

        private void AddMessageForm_activated(object sender, EventArgs e)
        {
            if (editIndex != -1)
            {
                int index = editIndex;
                reset();
                editIndex = index;
                Edit(index);
            }
            else if (loadFile == 1)
                {
                    loadFile = 0;
                }
            else
                reset();
            txtName.Focus();
        }
    }
}
