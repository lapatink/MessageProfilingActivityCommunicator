namespace MPacApplication
{
    partial class AddMessageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLocalMessage = new System.Windows.Forms.Button();
            this.btnCompanyMessage = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.btnByte = new System.Windows.Forms.Button();
            this.btnBin = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.btnHex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLocalMessage
            // 
            this.btnLocalMessage.Enabled = false;
            this.btnLocalMessage.Location = new System.Drawing.Point(62, 12);
            this.btnLocalMessage.Name = "btnLocalMessage";
            this.btnLocalMessage.Size = new System.Drawing.Size(97, 64);
            this.btnLocalMessage.TabIndex = 0;
            this.btnLocalMessage.Text = "Add Local Message";
            this.btnLocalMessage.UseVisualStyleBackColor = true;
            this.btnLocalMessage.Click += new System.EventHandler(this.btnLocalMessage_Click);
            // 
            // btnCompanyMessage
            // 
            this.btnCompanyMessage.Location = new System.Drawing.Point(165, 12);
            this.btnCompanyMessage.Name = "btnCompanyMessage";
            this.btnCompanyMessage.Size = new System.Drawing.Size(97, 64);
            this.btnCompanyMessage.TabIndex = 1;
            this.btnCompanyMessage.Text = "Add Company Message";
            this.btnCompanyMessage.UseVisualStyleBackColor = true;
            this.btnCompanyMessage.Click += new System.EventHandler(this.btnCompanyMessage_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(69, 191);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(90, 30);
            this.btnAll.TabIndex = 19;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnWord
            // 
            this.btnWord.Location = new System.Drawing.Point(69, 155);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(90, 30);
            this.btnWord.TabIndex = 18;
            this.btnWord.Text = "Word";
            this.btnWord.UseVisualStyleBackColor = true;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // btnByte
            // 
            this.btnByte.Enabled = false;
            this.btnByte.Location = new System.Drawing.Point(69, 119);
            this.btnByte.Name = "btnByte";
            this.btnByte.Size = new System.Drawing.Size(90, 30);
            this.btnByte.TabIndex = 17;
            this.btnByte.Text = "Byte";
            this.btnByte.UseVisualStyleBackColor = true;
            this.btnByte.Click += new System.EventHandler(this.btnByte_Click);
            // 
            // btnBin
            // 
            this.btnBin.Location = new System.Drawing.Point(165, 155);
            this.btnBin.Name = "btnBin";
            this.btnBin.Size = new System.Drawing.Size(90, 30);
            this.btnBin.TabIndex = 16;
            this.btnBin.Text = "Binary";
            this.btnBin.UseVisualStyleBackColor = true;
            this.btnBin.Click += new System.EventHandler(this.btnBin_Click);
            // 
            // btnDec
            // 
            this.btnDec.Enabled = false;
            this.btnDec.Location = new System.Drawing.Point(165, 119);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(90, 30);
            this.btnDec.TabIndex = 15;
            this.btnDec.Text = "Decimal";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // btnHex
            // 
            this.btnHex.Location = new System.Drawing.Point(165, 191);
            this.btnHex.Name = "btnHex";
            this.btnHex.Size = new System.Drawing.Size(90, 30);
            this.btnHex.TabIndex = 14;
            this.btnHex.Text = "Hexadecimal";
            this.btnHex.UseVisualStyleBackColor = true;
            this.btnHex.Click += new System.EventHandler(this.btnHex_Click);
            // 
            // AddMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 341);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.btnByte);
            this.Controls.Add(this.btnBin);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.btnHex);
            this.Controls.Add(this.btnCompanyMessage);
            this.Controls.Add(this.btnLocalMessage);
            this.Name = "AddMessageForm";
            this.Text = "AddMessageForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLocalMessage;
        private System.Windows.Forms.Button btnCompanyMessage;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Button btnByte;
        private System.Windows.Forms.Button btnBin;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Button btnHex;
    }
}