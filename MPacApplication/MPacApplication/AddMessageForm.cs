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

        private void btnLocalMessage_Click(object sender, EventArgs e)
        {
            btnLocalMessage.Enabled = false;
            btnCompanyMessage.Enabled = true;
        }

        private void btnCompanyMessage_Click(object sender, EventArgs e)
        {
            btnLocalMessage.Enabled = true;
            btnCompanyMessage.Enabled = false;
        }

        private void btnByte_Click(object sender, EventArgs e)
        {
            btnByte.Enabled = false;
            btnWord.Enabled = true;
            btnAll.Enabled = true;
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            btnByte.Enabled = true;
            btnWord.Enabled = false;
            btnAll.Enabled = true;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnByte.Enabled = true;
            btnWord.Enabled = true;
            btnAll.Enabled = false;

        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            btnDec.Enabled = false;
            btnBin.Enabled = true;
            btnHex.Enabled = true;
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            btnDec.Enabled = true;
            btnBin.Enabled = false;
            btnHex.Enabled = true;
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            btnDec.Enabled = true;
            btnBin.Enabled = true;
            btnHex.Enabled = false;
        }
    }
}
