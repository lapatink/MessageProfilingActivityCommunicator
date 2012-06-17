namespace MPacApplication
{
     partial class MainForm
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
               this.components = new System.ComponentModel.Container();
               this.lblCurrentTime = new System.Windows.Forms.Label();
               this.ClockRefresh = new System.Windows.Forms.Timer(this.components);
               this.btnOpenComPort = new System.Windows.Forms.Button();
               this.btnCloseComPort = new System.Windows.Forms.Button();
               this.btnConfiureComPort = new System.Windows.Forms.Button();
               this.lblPortName = new System.Windows.Forms.Label();
               this.lblParity = new System.Windows.Forms.Label();
               this.lblStopBits = new System.Windows.Forms.Label();
               this.lblDataBits = new System.Windows.Forms.Label();
               this.lblBaudRate = new System.Windows.Forms.Label();
               this.lblvPortName = new System.Windows.Forms.Label();
               this.lblvParity = new System.Windows.Forms.Label();
               this.lblvStopBits = new System.Windows.Forms.Label();
               this.lblvDataBits = new System.Windows.Forms.Label();
               this.lblvBaudRate = new System.Windows.Forms.Label();
               this.lstDisplayWindow = new System.Windows.Forms.ListBox();
               this.tmrCloseComPortCheck = new System.Windows.Forms.Timer(this.components);
               this.tmrCheckForData = new System.Windows.Forms.Timer(this.components);
               this.SuspendLayout();
               // 
               // lblCurrentTime
               // 
               this.lblCurrentTime.AutoSize = true;
               this.lblCurrentTime.Font = new System.Drawing.Font("Quartz MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lblCurrentTime.Location = new System.Drawing.Point(779, 9);
               this.lblCurrentTime.Name = "lblCurrentTime";
               this.lblCurrentTime.Size = new System.Drawing.Size(308, 25);
               this.lblCurrentTime.TabIndex = 0;
               this.lblCurrentTime.Text = "MM/DD/YY   HH:MM:SS XM";
               // 
               // ClockRefresh
               // 
               this.ClockRefresh.Enabled = true;
               this.ClockRefresh.Tick += new System.EventHandler(this.ClockRefresh_Tick);
               // 
               // btnOpenComPort
               // 
               this.btnOpenComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnOpenComPort.Location = new System.Drawing.Point(93, 10);
               this.btnOpenComPort.Name = "btnOpenComPort";
               this.btnOpenComPort.Size = new System.Drawing.Size(75, 68);
               this.btnOpenComPort.TabIndex = 1;
               this.btnOpenComPort.Text = "Open";
               this.btnOpenComPort.UseVisualStyleBackColor = true;
               this.btnOpenComPort.Click += new System.EventHandler(this.btnOpenComPort_Click);
               // 
               // btnCloseComPort
               // 
               this.btnCloseComPort.Enabled = false;
               this.btnCloseComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnCloseComPort.Location = new System.Drawing.Point(12, 10);
               this.btnCloseComPort.Name = "btnCloseComPort";
               this.btnCloseComPort.Size = new System.Drawing.Size(75, 69);
               this.btnCloseComPort.TabIndex = 2;
               this.btnCloseComPort.Text = "Close";
               this.btnCloseComPort.UseVisualStyleBackColor = true;
               this.btnCloseComPort.Click += new System.EventHandler(this.btnCloseComPort_Click);
               // 
               // btnConfiureComPort
               // 
               this.btnConfiureComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnConfiureComPort.Location = new System.Drawing.Point(174, 10);
               this.btnConfiureComPort.Name = "btnConfiureComPort";
               this.btnConfiureComPort.Size = new System.Drawing.Size(75, 68);
               this.btnConfiureComPort.TabIndex = 3;
               this.btnConfiureComPort.Text = "Configure";
               this.btnConfiureComPort.UseVisualStyleBackColor = true;
               this.btnConfiureComPort.Click += new System.EventHandler(this.btnConfiureComPort_Click);
               // 
               // lblPortName
               // 
               this.lblPortName.AutoSize = true;
               this.lblPortName.Location = new System.Drawing.Point(255, 10);
               this.lblPortName.Name = "lblPortName";
               this.lblPortName.Size = new System.Drawing.Size(60, 13);
               this.lblPortName.TabIndex = 4;
               this.lblPortName.Text = "Port Name:";
               // 
               // lblParity
               // 
               this.lblParity.AutoSize = true;
               this.lblParity.Location = new System.Drawing.Point(255, 36);
               this.lblParity.Name = "lblParity";
               this.lblParity.Size = new System.Drawing.Size(36, 13);
               this.lblParity.TabIndex = 5;
               this.lblParity.Text = "Parity:";
               // 
               // lblStopBits
               // 
               this.lblStopBits.AutoSize = true;
               this.lblStopBits.Location = new System.Drawing.Point(255, 62);
               this.lblStopBits.Name = "lblStopBits";
               this.lblStopBits.Size = new System.Drawing.Size(52, 13);
               this.lblStopBits.TabIndex = 6;
               this.lblStopBits.Text = "Stop Bits:";
               // 
               // lblDataBits
               // 
               this.lblDataBits.AutoSize = true;
               this.lblDataBits.Location = new System.Drawing.Point(255, 49);
               this.lblDataBits.Name = "lblDataBits";
               this.lblDataBits.Size = new System.Drawing.Size(53, 13);
               this.lblDataBits.TabIndex = 7;
               this.lblDataBits.Text = "Data Bits:";
               // 
               // lblBaudRate
               // 
               this.lblBaudRate.AutoSize = true;
               this.lblBaudRate.Location = new System.Drawing.Point(255, 23);
               this.lblBaudRate.Name = "lblBaudRate";
               this.lblBaudRate.Size = new System.Drawing.Size(61, 13);
               this.lblBaudRate.TabIndex = 8;
               this.lblBaudRate.Text = "Baud Rate:";
               // 
               // lblvPortName
               // 
               this.lblvPortName.AutoSize = true;
               this.lblvPortName.Location = new System.Drawing.Point(321, 10);
               this.lblvPortName.Name = "lblvPortName";
               this.lblvPortName.Size = new System.Drawing.Size(67, 13);
               this.lblvPortName.TabIndex = 9;
               this.lblvPortName.Text = "0000000000";
               // 
               // lblvParity
               // 
               this.lblvParity.AutoSize = true;
               this.lblvParity.Location = new System.Drawing.Point(321, 36);
               this.lblvParity.Name = "lblvParity";
               this.lblvParity.Size = new System.Drawing.Size(67, 13);
               this.lblvParity.TabIndex = 10;
               this.lblvParity.Text = "0000000000";
               // 
               // lblvStopBits
               // 
               this.lblvStopBits.AutoSize = true;
               this.lblvStopBits.Location = new System.Drawing.Point(321, 62);
               this.lblvStopBits.Name = "lblvStopBits";
               this.lblvStopBits.Size = new System.Drawing.Size(67, 13);
               this.lblvStopBits.TabIndex = 11;
               this.lblvStopBits.Text = "0000000000";
               // 
               // lblvDataBits
               // 
               this.lblvDataBits.AutoSize = true;
               this.lblvDataBits.Location = new System.Drawing.Point(321, 49);
               this.lblvDataBits.Name = "lblvDataBits";
               this.lblvDataBits.Size = new System.Drawing.Size(67, 13);
               this.lblvDataBits.TabIndex = 12;
               this.lblvDataBits.Text = "0000000000";
               // 
               // lblvBaudRate
               // 
               this.lblvBaudRate.AutoSize = true;
               this.lblvBaudRate.Location = new System.Drawing.Point(321, 23);
               this.lblvBaudRate.Name = "lblvBaudRate";
               this.lblvBaudRate.Size = new System.Drawing.Size(67, 13);
               this.lblvBaudRate.TabIndex = 13;
               this.lblvBaudRate.Text = "0000000000";
               // 
               // lstDisplayWindow
               // 
               this.lstDisplayWindow.FormattingEnabled = true;
               this.lstDisplayWindow.Location = new System.Drawing.Point(12, 98);
               this.lstDisplayWindow.Name = "lstDisplayWindow";
               this.lstDisplayWindow.Size = new System.Drawing.Size(1082, 355);
               this.lstDisplayWindow.TabIndex = 14;
               // 
               // tmrCloseComPortCheck
               // 
               this.tmrCloseComPortCheck.Enabled = true;
               this.tmrCloseComPortCheck.Tick += new System.EventHandler(this.tmrCloseComPortCheck_Tick);
               // 
               // tmrCheckForData
               // 
               this.tmrCheckForData.Enabled = true;
               this.tmrCheckForData.Interval = 50;
               this.tmrCheckForData.Tick += new System.EventHandler(this.tmrCheckForData_Tick);
               // 
               // MainForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1106, 468);
               this.Controls.Add(this.lstDisplayWindow);
               this.Controls.Add(this.lblvBaudRate);
               this.Controls.Add(this.lblvDataBits);
               this.Controls.Add(this.lblvStopBits);
               this.Controls.Add(this.lblvParity);
               this.Controls.Add(this.lblvPortName);
               this.Controls.Add(this.lblBaudRate);
               this.Controls.Add(this.lblDataBits);
               this.Controls.Add(this.lblStopBits);
               this.Controls.Add(this.lblParity);
               this.Controls.Add(this.lblPortName);
               this.Controls.Add(this.btnConfiureComPort);
               this.Controls.Add(this.btnCloseComPort);
               this.Controls.Add(this.btnOpenComPort);
               this.Controls.Add(this.lblCurrentTime);
               this.Name = "MainForm";
               this.Text = "Message-Profiling Activity Communicator";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Label lblCurrentTime;
          private System.Windows.Forms.Timer ClockRefresh;
          private System.Windows.Forms.Button btnOpenComPort;
          private System.Windows.Forms.Button btnCloseComPort;
          private System.Windows.Forms.Button btnConfiureComPort;
          private System.Windows.Forms.Label lblPortName;
          private System.Windows.Forms.Label lblParity;
          private System.Windows.Forms.Label lblStopBits;
          private System.Windows.Forms.Label lblDataBits;
          private System.Windows.Forms.Label lblBaudRate;
          private System.Windows.Forms.Label lblvPortName;
          private System.Windows.Forms.Label lblvParity;
          private System.Windows.Forms.Label lblvStopBits;
          private System.Windows.Forms.Label lblvDataBits;
          private System.Windows.Forms.Label lblvBaudRate;
          private System.Windows.Forms.ListBox lstDisplayWindow;
          private System.Windows.Forms.Timer tmrCloseComPortCheck;
          private System.Windows.Forms.Timer tmrCheckForData;
     }
}

