namespace MPacApplication
{
     partial class ComPortConfigForm
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
               this.cmbComPortName = new System.Windows.Forms.ComboBox();
               this.lblComPortName = new System.Windows.Forms.Label();
               this.lblStopBits = new System.Windows.Forms.Label();
               this.cmbStopBits = new System.Windows.Forms.ComboBox();
               this.lblDataBits = new System.Windows.Forms.Label();
               this.cmbDataBits = new System.Windows.Forms.ComboBox();
               this.lblParity = new System.Windows.Forms.Label();
               this.cmbParity = new System.Windows.Forms.ComboBox();
               this.lblBaudRate = new System.Windows.Forms.Label();
               this.cmbBaudRate = new System.Windows.Forms.ComboBox();
               this.btnOK = new System.Windows.Forms.Button();
               this.btnCancel = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // cmbComPortName
               // 
               this.cmbComPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbComPortName.FormattingEnabled = true;
               this.cmbComPortName.Location = new System.Drawing.Point(99, 15);
               this.cmbComPortName.Name = "cmbComPortName";
               this.cmbComPortName.Size = new System.Drawing.Size(121, 21);
               this.cmbComPortName.TabIndex = 0;
               // 
               // lblComPortName
               // 
               this.lblComPortName.AutoSize = true;
               this.lblComPortName.Location = new System.Drawing.Point(12, 20);
               this.lblComPortName.Name = "lblComPortName";
               this.lblComPortName.Size = new System.Drawing.Size(81, 13);
               this.lblComPortName.TabIndex = 1;
               this.lblComPortName.Text = "Com Port Name";
               // 
               // lblStopBits
               // 
               this.lblStopBits.AutoSize = true;
               this.lblStopBits.Location = new System.Drawing.Point(12, 140);
               this.lblStopBits.Name = "lblStopBits";
               this.lblStopBits.Size = new System.Drawing.Size(49, 13);
               this.lblStopBits.TabIndex = 3;
               this.lblStopBits.Text = "Stop Bits";
               // 
               // cmbStopBits
               // 
               this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbStopBits.FormattingEnabled = true;
               this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
               this.cmbStopBits.Location = new System.Drawing.Point(99, 135);
               this.cmbStopBits.Name = "cmbStopBits";
               this.cmbStopBits.Size = new System.Drawing.Size(121, 21);
               this.cmbStopBits.TabIndex = 2;
               // 
               // lblDataBits
               // 
               this.lblDataBits.AutoSize = true;
               this.lblDataBits.Location = new System.Drawing.Point(12, 110);
               this.lblDataBits.Name = "lblDataBits";
               this.lblDataBits.Size = new System.Drawing.Size(50, 13);
               this.lblDataBits.TabIndex = 5;
               this.lblDataBits.Text = "Data Bits";
               // 
               // cmbDataBits
               // 
               this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbDataBits.FormattingEnabled = true;
               this.cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
               this.cmbDataBits.Location = new System.Drawing.Point(99, 105);
               this.cmbDataBits.Name = "cmbDataBits";
               this.cmbDataBits.Size = new System.Drawing.Size(121, 21);
               this.cmbDataBits.TabIndex = 4;
               // 
               // lblParity
               // 
               this.lblParity.AutoSize = true;
               this.lblParity.Location = new System.Drawing.Point(12, 80);
               this.lblParity.Name = "lblParity";
               this.lblParity.Size = new System.Drawing.Size(33, 13);
               this.lblParity.TabIndex = 7;
               this.lblParity.Text = "Parity";
               // 
               // cmbParity
               // 
               this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbParity.FormattingEnabled = true;
               this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
               this.cmbParity.Location = new System.Drawing.Point(99, 75);
               this.cmbParity.Name = "cmbParity";
               this.cmbParity.Size = new System.Drawing.Size(121, 21);
               this.cmbParity.TabIndex = 6;
               // 
               // lblBaudRate
               // 
               this.lblBaudRate.AutoSize = true;
               this.lblBaudRate.Location = new System.Drawing.Point(12, 50);
               this.lblBaudRate.Name = "lblBaudRate";
               this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
               this.lblBaudRate.TabIndex = 9;
               this.lblBaudRate.Text = "Baud Rate";
               // 
               // cmbBaudRate
               // 
               this.cmbBaudRate.FormattingEnabled = true;
               this.cmbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
               this.cmbBaudRate.Location = new System.Drawing.Point(99, 45);
               this.cmbBaudRate.Name = "cmbBaudRate";
               this.cmbBaudRate.Size = new System.Drawing.Size(121, 21);
               this.cmbBaudRate.TabIndex = 8;
               // 
               // btnOK
               // 
               this.btnOK.Location = new System.Drawing.Point(18, 176);
               this.btnOK.Name = "btnOK";
               this.btnOK.Size = new System.Drawing.Size(75, 23);
               this.btnOK.TabIndex = 10;
               this.btnOK.Text = "OK";
               this.btnOK.UseVisualStyleBackColor = true;
               this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
               // 
               // btnCancel
               // 
               this.btnCancel.Location = new System.Drawing.Point(136, 176);
               this.btnCancel.Name = "btnCancel";
               this.btnCancel.Size = new System.Drawing.Size(75, 23);
               this.btnCancel.TabIndex = 11;
               this.btnCancel.Text = "Cancel";
               this.btnCancel.UseVisualStyleBackColor = true;
               this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
               // 
               // ComPortConfigForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(239, 211);
               this.Controls.Add(this.btnCancel);
               this.Controls.Add(this.btnOK);
               this.Controls.Add(this.lblBaudRate);
               this.Controls.Add(this.cmbBaudRate);
               this.Controls.Add(this.lblParity);
               this.Controls.Add(this.cmbParity);
               this.Controls.Add(this.lblDataBits);
               this.Controls.Add(this.cmbDataBits);
               this.Controls.Add(this.lblStopBits);
               this.Controls.Add(this.cmbStopBits);
               this.Controls.Add(this.lblComPortName);
               this.Controls.Add(this.cmbComPortName);
               this.MaximizeBox = false;
               this.MaximumSize = new System.Drawing.Size(255, 249);
               this.MinimizeBox = false;
               this.MinimumSize = new System.Drawing.Size(255, 249);
               this.Name = "ComPortConfigForm";
               this.Text = "ComPortConfigForm";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.ComboBox cmbComPortName;
          private System.Windows.Forms.Label lblComPortName;
          private System.Windows.Forms.Label lblStopBits;
          private System.Windows.Forms.ComboBox cmbStopBits;
          private System.Windows.Forms.Label lblDataBits;
          private System.Windows.Forms.ComboBox cmbDataBits;
          private System.Windows.Forms.Label lblParity;
          private System.Windows.Forms.ComboBox cmbParity;
          private System.Windows.Forms.Label lblBaudRate;
          private System.Windows.Forms.ComboBox cmbBaudRate;
          private System.Windows.Forms.Button btnOK;
          private System.Windows.Forms.Button btnCancel;
     }
}