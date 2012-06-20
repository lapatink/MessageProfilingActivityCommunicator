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

        public AddMessageForm(MainForm sourceForm)
          {
               InitializeComponent();
               parentForm = sourceForm;
          }

        private void txtHex1_TextChanged(object sender, EventArgs e)
        {
            if (txtHex1.Text != "")
            {
                try
                {
                    int n = int.Parse(txtHex1.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtHex1.Text = "";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtHex1.Text = "";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtHex2_TextChanged(object sender, EventArgs e)
        {
            if (txtHex2.Text != "")
            {
                try
                {
                    int n = int.Parse(txtHex2.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtHex2.Text = "";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtHex2.Text = "";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtHex3_TextChanged(object sender, EventArgs e)
        {
            if (txtHex3.Text != "")
            {
                try
                {
                    int n = int.Parse(txtHex3.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtHex3.Text = "";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtHex3.Text = "";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtHex4_TextChanged(object sender, EventArgs e)
        {
            if (txtHex4.Text != "")
            {
                try
                {
                    int n = int.Parse(txtHex4.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtHex4.Text = "";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtHex4.Text = "";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtHex5_TextChanged(object sender, EventArgs e)
        {
            if (txtHex5.Text != "")
            {
                try
                {
                    int n = int.Parse(txtHex5.Text, System.Globalization.NumberStyles.HexNumber);
                    if (n < 0 || n > 255)
                    {
                        txtHex5.Text = "";
                        MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch
                {
                    txtHex5.Text = "";
                    MessageBox.Show("Enter a Hex number between 00 and FF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
       
    }
}
