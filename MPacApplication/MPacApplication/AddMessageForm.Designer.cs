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
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtHex1 = new System.Windows.Forms.TextBox();
            this.txtHex2 = new System.Windows.Forms.TextBox();
            this.lblHex1 = new System.Windows.Forms.Label();
            this.lblHex2 = new System.Windows.Forms.Label();
            this.lblHex4 = new System.Windows.Forms.Label();
            this.lblHex3 = new System.Windows.Forms.Label();
            this.txtHex4 = new System.Windows.Forms.TextBox();
            this.txtHex3 = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblHex5 = new System.Windows.Forms.Label();
            this.txtHex5 = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtString1 = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtString2 = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 22);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 20);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version";
            // 
            // txtHex1
            // 
            this.txtHex1.Location = new System.Drawing.Point(117, 22);
            this.txtHex1.Name = "txtHex1";
            this.txtHex1.Size = new System.Drawing.Size(46, 20);
            this.txtHex1.TabIndex = 1;
            this.txtHex1.TextChanged += new System.EventHandler(this.txtHex1_TextChanged);
            // 
            // txtHex2
            // 
            this.txtHex2.Location = new System.Drawing.Point(201, 22);
            this.txtHex2.Name = "txtHex2";
            this.txtHex2.Size = new System.Drawing.Size(46, 20);
            this.txtHex2.TabIndex = 2;
            this.txtHex2.TextChanged += new System.EventHandler(this.txtHex2_TextChanged);
            // 
            // lblHex1
            // 
            this.lblHex1.AutoSize = true;
            this.lblHex1.Location = new System.Drawing.Point(117, 49);
            this.lblHex1.Name = "lblHex1";
            this.lblHex1.Size = new System.Drawing.Size(34, 13);
            this.lblHex1.TabIndex = 3;
            this.lblHex1.Text = "00-FF";
            // 
            // lblHex2
            // 
            this.lblHex2.AutoSize = true;
            this.lblHex2.Location = new System.Drawing.Point(198, 49);
            this.lblHex2.Name = "lblHex2";
            this.lblHex2.Size = new System.Drawing.Size(34, 13);
            this.lblHex2.TabIndex = 4;
            this.lblHex2.Text = "00-FF";
            // 
            // lblHex4
            // 
            this.lblHex4.AutoSize = true;
            this.lblHex4.Location = new System.Drawing.Point(198, 107);
            this.lblHex4.Name = "lblHex4";
            this.lblHex4.Size = new System.Drawing.Size(34, 13);
            this.lblHex4.TabIndex = 9;
            this.lblHex4.Text = "00-FF";
            // 
            // lblHex3
            // 
            this.lblHex3.AutoSize = true;
            this.lblHex3.Location = new System.Drawing.Point(117, 107);
            this.lblHex3.Name = "lblHex3";
            this.lblHex3.Size = new System.Drawing.Size(34, 13);
            this.lblHex3.TabIndex = 8;
            this.lblHex3.Text = "00-FF";
            // 
            // txtHex4
            // 
            this.txtHex4.Location = new System.Drawing.Point(201, 80);
            this.txtHex4.Name = "txtHex4";
            this.txtHex4.Size = new System.Drawing.Size(46, 20);
            this.txtHex4.TabIndex = 7;
            this.txtHex4.TextChanged += new System.EventHandler(this.txtHex4_TextChanged);
            // 
            // txtHex3
            // 
            this.txtHex3.Location = new System.Drawing.Point(117, 80);
            this.txtHex3.Name = "txtHex3";
            this.txtHex3.Size = new System.Drawing.Size(46, 20);
            this.txtHex3.TabIndex = 6;
            this.txtHex3.TextChanged += new System.EventHandler(this.txtHex3_TextChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(12, 80);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 20);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "ID";
            // 
            // lblHex5
            // 
            this.lblHex5.AutoSize = true;
            this.lblHex5.Location = new System.Drawing.Point(117, 168);
            this.lblHex5.Name = "lblHex5";
            this.lblHex5.Size = new System.Drawing.Size(34, 13);
            this.lblHex5.TabIndex = 13;
            this.lblHex5.Text = "00-FF";
            // 
            // txtHex5
            // 
            this.txtHex5.Location = new System.Drawing.Point(117, 141);
            this.txtHex5.Name = "txtHex5";
            this.txtHex5.Size = new System.Drawing.Size(46, 20);
            this.txtHex5.TabIndex = 11;
            this.txtHex5.TextChanged += new System.EventHandler(this.txtHex5_TextChanged);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(12, 141);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(59, 20);
            this.lblLength.TabIndex = 10;
            this.lblLength.Text = "Length";
            // 
            // txtString1
            // 
            this.txtString1.Location = new System.Drawing.Point(117, 210);
            this.txtString1.Name = "txtString1";
            this.txtString1.Size = new System.Drawing.Size(130, 20);
            this.txtString1.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 210);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name";
            // 
            // txtString2
            // 
            this.txtString2.Location = new System.Drawing.Point(117, 272);
            this.txtString2.Name = "txtString2";
            this.txtString2.Size = new System.Drawing.Size(130, 20);
            this.txtString2.TabIndex = 18;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat.Location = new System.Drawing.Point(12, 272);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(60, 20);
            this.lblFormat.TabIndex = 17;
            this.lblFormat.Text = "Format";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(36, 326);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // AddMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 372);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtString2);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.txtString1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblHex5);
            this.Controls.Add(this.txtHex5);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblHex4);
            this.Controls.Add(this.lblHex3);
            this.Controls.Add(this.txtHex4);
            this.Controls.Add(this.txtHex3);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblHex2);
            this.Controls.Add(this.lblHex1);
            this.Controls.Add(this.txtHex2);
            this.Controls.Add(this.txtHex1);
            this.Controls.Add(this.lblVersion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMessageForm";
            this.Text = "AddMessageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtHex1;
        private System.Windows.Forms.TextBox txtHex2;
        private System.Windows.Forms.Label lblHex1;
        private System.Windows.Forms.Label lblHex2;
        private System.Windows.Forms.Label lblHex4;
        private System.Windows.Forms.Label lblHex3;
        private System.Windows.Forms.TextBox txtHex4;
        private System.Windows.Forms.TextBox txtHex3;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblHex5;
        private System.Windows.Forms.TextBox txtHex5;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtString1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtString2;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;


    }
}