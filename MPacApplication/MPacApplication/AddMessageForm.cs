﻿using System;
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
               parentForm = sourceForm;
               reset();
          }
        public AddMessageForm(MainForm sourceForm, messageType type)
        {
            InitializeComponent();
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
            }
            MessageFormat message = new MessageFormat(
                Byte.Parse(txtVersion1.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtVersion2.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtID1.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtID2.Text, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(txtLength.Text, System.Globalization.NumberStyles.HexNumber),
                txtFormat.Text,
                txtName.Text);

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
        }
       
    }
}
