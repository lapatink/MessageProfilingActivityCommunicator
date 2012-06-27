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
               this.tmrClockRefresh = new System.Windows.Forms.Timer(this.components);
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
               this.btnAddMessage = new System.Windows.Forms.Button();
               this.btnAddCompanyMessage = new System.Windows.Forms.Button();
               this.txtMessageOne = new System.Windows.Forms.TextBox();
               this.txtMessageTwo = new System.Windows.Forms.TextBox();
               this.txtMessageThree = new System.Windows.Forms.TextBox();
               this.btnSendMessageOne = new System.Windows.Forms.Button();
               this.btnSendMessageTwo = new System.Windows.Forms.Button();
               this.btnSendMessageThree = new System.Windows.Forms.Button();
               this.menuStrip1 = new System.Windows.Forms.MenuStrip();
               this.File = new System.Windows.Forms.ToolStripMenuItem();
               this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
               this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.btnOpenAndClose = new System.Windows.Forms.Button();
               this.menuStrip1.SuspendLayout();
               this.SuspendLayout();
               // 
               // lblCurrentTime
               // 
               this.lblCurrentTime.AutoSize = true;
               this.lblCurrentTime.Font = new System.Drawing.Font("Quartz MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lblCurrentTime.Location = new System.Drawing.Point(779, 25);
               this.lblCurrentTime.Name = "lblCurrentTime";
               this.lblCurrentTime.Size = new System.Drawing.Size(308, 25);
               this.lblCurrentTime.TabIndex = 0;
               this.lblCurrentTime.Text = "MM/DD/YY   HH:MM:SS XM";
               // 
               // tmrClockRefresh
               // 
               this.tmrClockRefresh.Enabled = true;
               this.tmrClockRefresh.Tick += new System.EventHandler(this.tmrClockRefresh_Tick);
               // 
               // btnConfiureComPort
               // 
               this.btnConfiureComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnConfiureComPort.Location = new System.Drawing.Point(273, 27);
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
               this.lblPortName.Location = new System.Drawing.Point(354, 27);
               this.lblPortName.Name = "lblPortName";
               this.lblPortName.Size = new System.Drawing.Size(60, 13);
               this.lblPortName.TabIndex = 4;
               this.lblPortName.Text = "Port Name:";
               // 
               // lblParity
               // 
               this.lblParity.AutoSize = true;
               this.lblParity.Location = new System.Drawing.Point(354, 53);
               this.lblParity.Name = "lblParity";
               this.lblParity.Size = new System.Drawing.Size(36, 13);
               this.lblParity.TabIndex = 5;
               this.lblParity.Text = "Parity:";
               // 
               // lblStopBits
               // 
               this.lblStopBits.AutoSize = true;
               this.lblStopBits.Location = new System.Drawing.Point(354, 79);
               this.lblStopBits.Name = "lblStopBits";
               this.lblStopBits.Size = new System.Drawing.Size(52, 13);
               this.lblStopBits.TabIndex = 6;
               this.lblStopBits.Text = "Stop Bits:";
               // 
               // lblDataBits
               // 
               this.lblDataBits.AutoSize = true;
               this.lblDataBits.Location = new System.Drawing.Point(354, 66);
               this.lblDataBits.Name = "lblDataBits";
               this.lblDataBits.Size = new System.Drawing.Size(53, 13);
               this.lblDataBits.TabIndex = 7;
               this.lblDataBits.Text = "Data Bits:";
               // 
               // lblBaudRate
               // 
               this.lblBaudRate.AutoSize = true;
               this.lblBaudRate.Location = new System.Drawing.Point(354, 40);
               this.lblBaudRate.Name = "lblBaudRate";
               this.lblBaudRate.Size = new System.Drawing.Size(61, 13);
               this.lblBaudRate.TabIndex = 8;
               this.lblBaudRate.Text = "Baud Rate:";
               // 
               // lblvPortName
               // 
               this.lblvPortName.AutoSize = true;
               this.lblvPortName.Location = new System.Drawing.Point(420, 27);
               this.lblvPortName.Name = "lblvPortName";
               this.lblvPortName.Size = new System.Drawing.Size(67, 13);
               this.lblvPortName.TabIndex = 9;
               this.lblvPortName.Text = "0000000000";
               // 
               // lblvParity
               // 
               this.lblvParity.AutoSize = true;
               this.lblvParity.Location = new System.Drawing.Point(420, 53);
               this.lblvParity.Name = "lblvParity";
               this.lblvParity.Size = new System.Drawing.Size(67, 13);
               this.lblvParity.TabIndex = 10;
               this.lblvParity.Text = "0000000000";
               // 
               // lblvStopBits
               // 
               this.lblvStopBits.AutoSize = true;
               this.lblvStopBits.Location = new System.Drawing.Point(420, 79);
               this.lblvStopBits.Name = "lblvStopBits";
               this.lblvStopBits.Size = new System.Drawing.Size(67, 13);
               this.lblvStopBits.TabIndex = 11;
               this.lblvStopBits.Text = "0000000000";
               // 
               // lblvDataBits
               // 
               this.lblvDataBits.AutoSize = true;
               this.lblvDataBits.Location = new System.Drawing.Point(420, 66);
               this.lblvDataBits.Name = "lblvDataBits";
               this.lblvDataBits.Size = new System.Drawing.Size(67, 13);
               this.lblvDataBits.TabIndex = 12;
               this.lblvDataBits.Text = "0000000000";
               // 
               // lblvBaudRate
               // 
               this.lblvBaudRate.AutoSize = true;
               this.lblvBaudRate.Location = new System.Drawing.Point(420, 40);
               this.lblvBaudRate.Name = "lblvBaudRate";
               this.lblvBaudRate.Size = new System.Drawing.Size(67, 13);
               this.lblvBaudRate.TabIndex = 13;
               this.lblvBaudRate.Text = "0000000000";
               // 
               // lstDisplayWindow
               // 
               this.lstDisplayWindow.FormattingEnabled = true;
               this.lstDisplayWindow.Location = new System.Drawing.Point(12, 192);
               this.lstDisplayWindow.Name = "lstDisplayWindow";
               this.lstDisplayWindow.Size = new System.Drawing.Size(1082, 277);
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
               // btnAddMessage
               // 
               this.btnAddMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnAddMessage.Location = new System.Drawing.Point(507, 27);
               this.btnAddMessage.Name = "btnAddMessage";
               this.btnAddMessage.Size = new System.Drawing.Size(75, 68);
               this.btnAddMessage.TabIndex = 15;
               this.btnAddMessage.Text = "Add Local Message";
               this.btnAddMessage.UseVisualStyleBackColor = true;
               this.btnAddMessage.Click += new System.EventHandler(this.btnAddMessage_Click);
               // 
               // btnAddCompanyMessage
               // 
               this.btnAddCompanyMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnAddCompanyMessage.Location = new System.Drawing.Point(588, 27);
               this.btnAddCompanyMessage.Name = "btnAddCompanyMessage";
               this.btnAddCompanyMessage.Size = new System.Drawing.Size(75, 68);
               this.btnAddCompanyMessage.TabIndex = 16;
               this.btnAddCompanyMessage.Text = "Add Company Message";
               this.btnAddCompanyMessage.UseVisualStyleBackColor = true;
               this.btnAddCompanyMessage.Click += new System.EventHandler(this.btnAddCompanyMessage_Click);
               // 
               // txtMessageOne
               // 
               this.txtMessageOne.Location = new System.Drawing.Point(174, 110);
               this.txtMessageOne.Name = "txtMessageOne";
               this.txtMessageOne.Size = new System.Drawing.Size(653, 20);
               this.txtMessageOne.TabIndex = 17;
               // 
               // txtMessageTwo
               // 
               this.txtMessageTwo.Location = new System.Drawing.Point(174, 137);
               this.txtMessageTwo.Name = "txtMessageTwo";
               this.txtMessageTwo.Size = new System.Drawing.Size(653, 20);
               this.txtMessageTwo.TabIndex = 18;
               // 
               // txtMessageThree
               // 
               this.txtMessageThree.Location = new System.Drawing.Point(174, 164);
               this.txtMessageThree.Name = "txtMessageThree";
               this.txtMessageThree.Size = new System.Drawing.Size(653, 20);
               this.txtMessageThree.TabIndex = 19;
               // 
               // btnSendMessageOne
               // 
               this.btnSendMessageOne.Location = new System.Drawing.Point(833, 107);
               this.btnSendMessageOne.Name = "btnSendMessageOne";
               this.btnSendMessageOne.Size = new System.Drawing.Size(75, 23);
               this.btnSendMessageOne.TabIndex = 20;
               this.btnSendMessageOne.Text = "Send";
               this.btnSendMessageOne.UseVisualStyleBackColor = true;
               this.btnSendMessageOne.Click += new System.EventHandler(this.btnSendMessageOne_Click);
               // 
               // btnSendMessageTwo
               // 
               this.btnSendMessageTwo.Location = new System.Drawing.Point(833, 134);
               this.btnSendMessageTwo.Name = "btnSendMessageTwo";
               this.btnSendMessageTwo.Size = new System.Drawing.Size(75, 23);
               this.btnSendMessageTwo.TabIndex = 21;
               this.btnSendMessageTwo.Text = "Send";
               this.btnSendMessageTwo.UseVisualStyleBackColor = true;
               this.btnSendMessageTwo.Click += new System.EventHandler(this.btnSendMessageTwo_Click);
               // 
               // btnSendMessageThree
               // 
               this.btnSendMessageThree.Location = new System.Drawing.Point(833, 161);
               this.btnSendMessageThree.Name = "btnSendMessageThree";
               this.btnSendMessageThree.Size = new System.Drawing.Size(75, 23);
               this.btnSendMessageThree.TabIndex = 22;
               this.btnSendMessageThree.Text = "Send";
               this.btnSendMessageThree.UseVisualStyleBackColor = true;
               this.btnSendMessageThree.Click += new System.EventHandler(this.btnSendMessageThree_Click);
               // 
               // menuStrip1
               // 
               this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File});
               this.menuStrip1.Location = new System.Drawing.Point(0, 0);
               this.menuStrip1.Name = "menuStrip1";
               this.menuStrip1.Size = new System.Drawing.Size(1106, 24);
               this.menuStrip1.TabIndex = 23;
               this.menuStrip1.Text = "menuStrip1";
               // 
               // File
               // 
               this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
               this.File.Name = "File";
               this.File.Size = new System.Drawing.Size(37, 20);
               this.File.Text = "File";
               // 
               // importToolStripMenuItem
               // 
               this.importToolStripMenuItem.Name = "importToolStripMenuItem";
               this.importToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
               this.importToolStripMenuItem.Text = "Import...";
               this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
               // 
               // exportToolStripMenuItem
               // 
               this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
               this.exportToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
               this.exportToolStripMenuItem.Text = "Export...";
               this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
               // 
               // toolStripSeparator1
               // 
               this.toolStripSeparator1.Name = "toolStripSeparator1";
               this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
               // 
               // exitToolStripMenuItem
               // 
               this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
               this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
               this.exitToolStripMenuItem.Text = "Exit";
               this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
               // 
               // btnOpenAndClose
               // 
               this.btnOpenAndClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnOpenAndClose.Location = new System.Drawing.Point(192, 27);
               this.btnOpenAndClose.Name = "btnOpenAndClose";
               this.btnOpenAndClose.Size = new System.Drawing.Size(75, 68);
               this.btnOpenAndClose.TabIndex = 24;
               this.btnOpenAndClose.Text = "Toggle";
               this.btnOpenAndClose.UseVisualStyleBackColor = true;
               this.btnOpenAndClose.Click += new System.EventHandler(this.btnOpenAndClose_Click);
               // 
               // MainForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1106, 482);
               this.Controls.Add(this.btnOpenAndClose);
               this.Controls.Add(this.btnSendMessageThree);
               this.Controls.Add(this.btnSendMessageTwo);
               this.Controls.Add(this.btnSendMessageOne);
               this.Controls.Add(this.txtMessageThree);
               this.Controls.Add(this.txtMessageTwo);
               this.Controls.Add(this.txtMessageOne);
               this.Controls.Add(this.btnAddCompanyMessage);
               this.Controls.Add(this.btnAddMessage);
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
               this.Controls.Add(this.lblCurrentTime);
               this.Controls.Add(this.menuStrip1);
               this.MainMenuStrip = this.menuStrip1;
               this.Name = "MainForm";
               this.Text = "Message-Profiling Activity Communicator";
               this.menuStrip1.ResumeLayout(false);
               this.menuStrip1.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Label lblCurrentTime;
          private System.Windows.Forms.Timer tmrClockRefresh;
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
          private System.Windows.Forms.Button btnAddMessage;
          private System.Windows.Forms.Button btnAddCompanyMessage;
          private System.Windows.Forms.TextBox txtMessageOne;
          private System.Windows.Forms.TextBox txtMessageTwo;
          private System.Windows.Forms.TextBox txtMessageThree;
          private System.Windows.Forms.Button btnSendMessageOne;
          private System.Windows.Forms.Button btnSendMessageTwo;
          private System.Windows.Forms.Button btnSendMessageThree;
          private System.Windows.Forms.MenuStrip menuStrip1;
          private System.Windows.Forms.ToolStripMenuItem File;
          private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
          private System.Windows.Forms.Button btnOpenAndClose;
     }
}

