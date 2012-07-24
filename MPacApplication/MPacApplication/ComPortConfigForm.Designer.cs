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
               this.lblHandshake = new System.Windows.Forms.Label();
               this.cmbHandshake = new System.Windows.Forms.ComboBox();
               this.lblRequestToSend = new System.Windows.Forms.Label();
               this.cmbRequestToSend = new System.Windows.Forms.ComboBox();
               this.lblDataTerminalReady = new System.Windows.Forms.Label();
               this.cmbDataTerminalReady = new System.Windows.Forms.ComboBox();
               this.SuspendLayout();
               // 
               // cmbComPortName
               // 
               this.cmbComPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbComPortName.FormattingEnabled = true;
               this.cmbComPortName.Location = new System.Drawing.Point(125, 15);
               this.cmbComPortName.Name = "cmbComPortName";
               this.cmbComPortName.Size = new System.Drawing.Size(121, 21);
               this.cmbComPortName.TabIndex = 0;
               // 
               // lblComPortName
               // 
               this.lblComPortName.AutoSize = true;
               this.lblComPortName.Location = new System.Drawing.Point(12, 18);
               this.lblComPortName.Name = "lblComPortName";
               this.lblComPortName.Size = new System.Drawing.Size(81, 13);
               this.lblComPortName.TabIndex = 1;
               this.lblComPortName.Text = "Com Port Name";
               // 
               // lblStopBits
               // 
               this.lblStopBits.AutoSize = true;
               this.lblStopBits.Location = new System.Drawing.Point(12, 126);
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
               this.cmbStopBits.Location = new System.Drawing.Point(125, 123);
               this.cmbStopBits.Name = "cmbStopBits";
               this.cmbStopBits.Size = new System.Drawing.Size(121, 21);
               this.cmbStopBits.TabIndex = 2;
               // 
               // lblDataBits
               // 
               this.lblDataBits.AutoSize = true;
               this.lblDataBits.Location = new System.Drawing.Point(12, 99);
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
               this.cmbDataBits.Location = new System.Drawing.Point(125, 96);
               this.cmbDataBits.Name = "cmbDataBits";
               this.cmbDataBits.Size = new System.Drawing.Size(121, 21);
               this.cmbDataBits.TabIndex = 4;
               // 
               // lblParity
               // 
               this.lblParity.AutoSize = true;
               this.lblParity.Location = new System.Drawing.Point(12, 72);
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
               this.cmbParity.Location = new System.Drawing.Point(125, 69);
               this.cmbParity.Name = "cmbParity";
               this.cmbParity.Size = new System.Drawing.Size(121, 21);
               this.cmbParity.TabIndex = 6;
               // 
               // lblBaudRate
               // 
               this.lblBaudRate.AutoSize = true;
               this.lblBaudRate.Location = new System.Drawing.Point(12, 45);
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
               this.cmbBaudRate.Location = new System.Drawing.Point(125, 42);
               this.cmbBaudRate.Name = "cmbBaudRate";
               this.cmbBaudRate.Size = new System.Drawing.Size(121, 21);
               this.cmbBaudRate.TabIndex = 8;
               // 
               // btnOK
               // 
               this.btnOK.Location = new System.Drawing.Point(33, 240);
               this.btnOK.Name = "btnOK";
               this.btnOK.Size = new System.Drawing.Size(75, 23);
               this.btnOK.TabIndex = 10;
               this.btnOK.Text = "OK";
               this.btnOK.UseVisualStyleBackColor = true;
               this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
               // 
               // btnCancel
               // 
               this.btnCancel.Location = new System.Drawing.Point(149, 240);
               this.btnCancel.Name = "btnCancel";
               this.btnCancel.Size = new System.Drawing.Size(75, 23);
               this.btnCancel.TabIndex = 11;
               this.btnCancel.Text = "Cancel";
               this.btnCancel.UseVisualStyleBackColor = true;
               this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
               // 
               // lblHandshake
               // 
               this.lblHandshake.AutoSize = true;
               this.lblHandshake.Location = new System.Drawing.Point(12, 153);
               this.lblHandshake.Name = "lblHandshake";
               this.lblHandshake.Size = new System.Drawing.Size(62, 13);
               this.lblHandshake.TabIndex = 15;
               this.lblHandshake.Text = "Handshake";
               // 
               // cmbHandshake
               // 
               this.cmbHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbHandshake.FormattingEnabled = true;
               this.cmbHandshake.Items.AddRange(new object[] {
            "None",
            "RequestToSend",
            "XOnXOff",
            "Both"});
               this.cmbHandshake.Location = new System.Drawing.Point(125, 150);
               this.cmbHandshake.Name = "cmbHandshake";
               this.cmbHandshake.Size = new System.Drawing.Size(121, 21);
               this.cmbHandshake.TabIndex = 14;
               // 
               // lblRequestToSend
               // 
               this.lblRequestToSend.AutoSize = true;
               this.lblRequestToSend.Location = new System.Drawing.Point(12, 180);
               this.lblRequestToSend.Name = "lblRequestToSend";
               this.lblRequestToSend.Size = new System.Drawing.Size(87, 13);
               this.lblRequestToSend.TabIndex = 13;
               this.lblRequestToSend.Text = "Request to Send";
               // 
               // cmbRequestToSend
               // 
               this.cmbRequestToSend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbRequestToSend.FormattingEnabled = true;
               this.cmbRequestToSend.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
               this.cmbRequestToSend.Location = new System.Drawing.Point(125, 177);
               this.cmbRequestToSend.Name = "cmbRequestToSend";
               this.cmbRequestToSend.Size = new System.Drawing.Size(121, 21);
               this.cmbRequestToSend.TabIndex = 12;
               // 
               // lblDataTerminalReady
               // 
               this.lblDataTerminalReady.AutoSize = true;
               this.lblDataTerminalReady.Location = new System.Drawing.Point(12, 207);
               this.lblDataTerminalReady.Name = "lblDataTerminalReady";
               this.lblDataTerminalReady.Size = new System.Drawing.Size(107, 13);
               this.lblDataTerminalReady.TabIndex = 17;
               this.lblDataTerminalReady.Text = "Data Terminal Ready";
               // 
               // cmbDataTerminalReady
               // 
               this.cmbDataTerminalReady.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbDataTerminalReady.FormattingEnabled = true;
               this.cmbDataTerminalReady.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
               this.cmbDataTerminalReady.Location = new System.Drawing.Point(125, 204);
               this.cmbDataTerminalReady.Name = "cmbDataTerminalReady";
               this.cmbDataTerminalReady.Size = new System.Drawing.Size(121, 21);
               this.cmbDataTerminalReady.TabIndex = 16;
               // 
               // ComPortConfigForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(259, 275);
               this.Controls.Add(this.lblDataTerminalReady);
               this.Controls.Add(this.cmbDataTerminalReady);
               this.Controls.Add(this.lblHandshake);
               this.Controls.Add(this.cmbHandshake);
               this.Controls.Add(this.lblRequestToSend);
               this.Controls.Add(this.cmbRequestToSend);
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
               this.MaximumSize = new System.Drawing.Size(280, 320);
               this.MinimizeBox = false;
               this.MinimumSize = new System.Drawing.Size(255, 292);
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
          private System.Windows.Forms.Label lblHandshake;
          private System.Windows.Forms.ComboBox cmbHandshake;
          private System.Windows.Forms.Label lblRequestToSend;
          private System.Windows.Forms.ComboBox cmbRequestToSend;
          private System.Windows.Forms.Label lblDataTerminalReady;
          private System.Windows.Forms.ComboBox cmbDataTerminalReady;
     }
}