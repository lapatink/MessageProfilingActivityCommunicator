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
               this.btnConfigureComPort = new System.Windows.Forms.Button();
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
               this.lstDisplayWindowOne = new System.Windows.Forms.ListBox();
               this.tmrCheckForData = new System.Windows.Forms.Timer(this.components);
               this.btnAddMessage = new System.Windows.Forms.Button();
               this.btnAddCompanyMessage = new System.Windows.Forms.Button();
               this.menuStrip1 = new System.Windows.Forms.MenuStrip();
               this.File = new System.Windows.Forms.ToolStripMenuItem();
               this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
               this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.btnOpenAndClose = new System.Windows.Forms.Button();
               this.lstMessageSummary = new System.Windows.Forms.ListBox();
               this.btnRefresh = new System.Windows.Forms.Button();
               this.btnRemove = new System.Windows.Forms.Button();
               this.cmbViews = new System.Windows.Forms.ComboBox();
               this.lblvHandshake = new System.Windows.Forms.Label();
               this.lblHandshake = new System.Windows.Forms.Label();
               this.lblvRTSEnable = new System.Windows.Forms.Label();
               this.lblRTSEnable = new System.Windows.Forms.Label();
               this.lblvDTREnable = new System.Windows.Forms.Label();
               this.lblDTREnable = new System.Windows.Forms.Label();
               this.btnEdit = new System.Windows.Forms.Button();
               this.btnClear = new System.Windows.Forms.Button();
               this.lstDisplayWindowTwo = new System.Windows.Forms.ListBox();
               this.menuStrip1.SuspendLayout();
               this.SuspendLayout();
               // 
               // lblCurrentTime
               // 
               this.lblCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.lblCurrentTime.AutoSize = true;
               this.lblCurrentTime.Font = new System.Drawing.Font("Quartz MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lblCurrentTime.Location = new System.Drawing.Point(454, 29);
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
               // btnConfigureComPort
               // 
               this.btnConfigureComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnConfigureComPort.Location = new System.Drawing.Point(93, 27);
               this.btnConfigureComPort.Name = "btnConfigureComPort";
               this.btnConfigureComPort.Size = new System.Drawing.Size(75, 68);
               this.btnConfigureComPort.TabIndex = 3;
               this.btnConfigureComPort.Text = "Configure";
               this.btnConfigureComPort.UseVisualStyleBackColor = true;
               this.btnConfigureComPort.Click += new System.EventHandler(this.btnConfigureComPort_Click);
               // 
               // lblPortName
               // 
               this.lblPortName.AutoSize = true;
               this.lblPortName.Location = new System.Drawing.Point(174, 27);
               this.lblPortName.Name = "lblPortName";
               this.lblPortName.Size = new System.Drawing.Size(60, 13);
               this.lblPortName.TabIndex = 4;
               this.lblPortName.Text = "Port Name:";
               // 
               // lblParity
               // 
               this.lblParity.AutoSize = true;
               this.lblParity.Location = new System.Drawing.Point(174, 92);
               this.lblParity.Name = "lblParity";
               this.lblParity.Size = new System.Drawing.Size(36, 13);
               this.lblParity.TabIndex = 5;
               this.lblParity.Text = "Parity:";
               // 
               // lblStopBits
               // 
               this.lblStopBits.AutoSize = true;
               this.lblStopBits.Location = new System.Drawing.Point(174, 118);
               this.lblStopBits.Name = "lblStopBits";
               this.lblStopBits.Size = new System.Drawing.Size(52, 13);
               this.lblStopBits.TabIndex = 6;
               this.lblStopBits.Text = "Stop Bits:";
               // 
               // lblDataBits
               // 
               this.lblDataBits.AutoSize = true;
               this.lblDataBits.Location = new System.Drawing.Point(174, 105);
               this.lblDataBits.Name = "lblDataBits";
               this.lblDataBits.Size = new System.Drawing.Size(53, 13);
               this.lblDataBits.TabIndex = 7;
               this.lblDataBits.Text = "Data Bits:";
               // 
               // lblBaudRate
               // 
               this.lblBaudRate.AutoSize = true;
               this.lblBaudRate.Location = new System.Drawing.Point(174, 40);
               this.lblBaudRate.Name = "lblBaudRate";
               this.lblBaudRate.Size = new System.Drawing.Size(61, 13);
               this.lblBaudRate.TabIndex = 8;
               this.lblBaudRate.Text = "Baud Rate:";
               // 
               // lblvPortName
               // 
               this.lblvPortName.AutoSize = true;
               this.lblvPortName.Location = new System.Drawing.Point(240, 27);
               this.lblvPortName.Name = "lblvPortName";
               this.lblvPortName.Size = new System.Drawing.Size(49, 13);
               this.lblvPortName.TabIndex = 9;
               this.lblvPortName.Text = "0000000";
               // 
               // lblvParity
               // 
               this.lblvParity.AutoSize = true;
               this.lblvParity.Location = new System.Drawing.Point(240, 92);
               this.lblvParity.Name = "lblvParity";
               this.lblvParity.Size = new System.Drawing.Size(49, 13);
               this.lblvParity.TabIndex = 10;
               this.lblvParity.Text = "0000000";
               // 
               // lblvStopBits
               // 
               this.lblvStopBits.AutoSize = true;
               this.lblvStopBits.Location = new System.Drawing.Point(240, 118);
               this.lblvStopBits.Name = "lblvStopBits";
               this.lblvStopBits.Size = new System.Drawing.Size(49, 13);
               this.lblvStopBits.TabIndex = 11;
               this.lblvStopBits.Text = "0000000";
               // 
               // lblvDataBits
               // 
               this.lblvDataBits.AutoSize = true;
               this.lblvDataBits.Location = new System.Drawing.Point(240, 105);
               this.lblvDataBits.Name = "lblvDataBits";
               this.lblvDataBits.Size = new System.Drawing.Size(49, 13);
               this.lblvDataBits.TabIndex = 12;
               this.lblvDataBits.Text = "0000000";
               // 
               // lblvBaudRate
               // 
               this.lblvBaudRate.AutoSize = true;
               this.lblvBaudRate.Location = new System.Drawing.Point(240, 40);
               this.lblvBaudRate.Name = "lblvBaudRate";
               this.lblvBaudRate.Size = new System.Drawing.Size(49, 13);
               this.lblvBaudRate.TabIndex = 13;
               this.lblvBaudRate.Text = "0000000";
               // 
               // lstDisplayWindowOne
               // 
               this.lstDisplayWindowOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.lstDisplayWindowOne.Font = new System.Drawing.Font("Moire", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lstDisplayWindowOne.FormattingEnabled = true;
               this.lstDisplayWindowOne.HorizontalScrollbar = true;
               this.lstDisplayWindowOne.ItemHeight = 18;
               this.lstDisplayWindowOne.Location = new System.Drawing.Point(12, 164);
               this.lstDisplayWindowOne.Name = "lstDisplayWindowOne";
               this.lstDisplayWindowOne.Size = new System.Drawing.Size(436, 256);
               this.lstDisplayWindowOne.TabIndex = 14;
               // 
               // tmrCheckForData
               // 
               this.tmrCheckForData.Enabled = true;
               this.tmrCheckForData.Interval = 1;
               this.tmrCheckForData.Tick += new System.EventHandler(this.tmrCheckForData_Tick);
               // 
               // btnAddMessage
               // 
               this.btnAddMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnAddMessage.Location = new System.Drawing.Point(292, 27);
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
               this.btnAddCompanyMessage.Location = new System.Drawing.Point(373, 26);
               this.btnAddCompanyMessage.Name = "btnAddCompanyMessage";
               this.btnAddCompanyMessage.Size = new System.Drawing.Size(75, 68);
               this.btnAddCompanyMessage.TabIndex = 16;
               this.btnAddCompanyMessage.Text = "Add Company Message";
               this.btnAddCompanyMessage.UseVisualStyleBackColor = true;
               this.btnAddCompanyMessage.Click += new System.EventHandler(this.btnAddCompanyMessage_Click);
               // 
               // menuStrip1
               // 
               this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File});
               this.menuStrip1.Location = new System.Drawing.Point(0, 0);
               this.menuStrip1.Name = "menuStrip1";
               this.menuStrip1.Size = new System.Drawing.Size(774, 24);
               this.menuStrip1.TabIndex = 23;
               this.menuStrip1.Text = "menuStrip1";
               // 
               // File
               // 
               this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.saveLogToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
               this.File.Name = "File";
               this.File.Size = new System.Drawing.Size(37, 20);
               this.File.Text = "File";
               // 
               // importToolStripMenuItem
               // 
               this.importToolStripMenuItem.Name = "importToolStripMenuItem";
               this.importToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
               this.importToolStripMenuItem.Text = "Import...";
               this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
               // 
               // exportToolStripMenuItem
               // 
               this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
               this.exportToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
               this.exportToolStripMenuItem.Text = "Export...";
               this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
               // 
               // saveLogToolStripMenuItem
               // 
               this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
               this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
               this.saveLogToolStripMenuItem.Text = "Save Log...";
               this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
               // 
               // toolStripSeparator1
               // 
               this.toolStripSeparator1.Name = "toolStripSeparator1";
               this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
               // 
               // exitToolStripMenuItem
               // 
               this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
               this.exitToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
               this.exitToolStripMenuItem.Text = "Exit";
               this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
               // 
               // btnOpenAndClose
               // 
               this.btnOpenAndClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnOpenAndClose.Location = new System.Drawing.Point(12, 27);
               this.btnOpenAndClose.Name = "btnOpenAndClose";
               this.btnOpenAndClose.Size = new System.Drawing.Size(75, 68);
               this.btnOpenAndClose.TabIndex = 24;
               this.btnOpenAndClose.Text = "Toggle";
               this.btnOpenAndClose.UseVisualStyleBackColor = true;
               this.btnOpenAndClose.Click += new System.EventHandler(this.btnOpenAndClose_Click);
               // 
               // lstMessageSummary
               // 
               this.lstMessageSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.lstMessageSummary.Font = new System.Drawing.Font("Moire", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lstMessageSummary.FormattingEnabled = true;
               this.lstMessageSummary.HorizontalScrollbar = true;
               this.lstMessageSummary.ItemHeight = 18;
               this.lstMessageSummary.Location = new System.Drawing.Point(459, 74);
               this.lstMessageSummary.Name = "lstMessageSummary";
               this.lstMessageSummary.Size = new System.Drawing.Size(303, 346);
               this.lstMessageSummary.TabIndex = 30;
               // 
               // btnRefresh
               // 
               this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnRefresh.Location = new System.Drawing.Point(373, 100);
               this.btnRefresh.Name = "btnRefresh";
               this.btnRefresh.Size = new System.Drawing.Size(75, 24);
               this.btnRefresh.TabIndex = 31;
               this.btnRefresh.Text = "Refresh";
               this.btnRefresh.UseVisualStyleBackColor = true;
               this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
               // 
               // btnRemove
               // 
               this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.btnRemove.Location = new System.Drawing.Point(687, 433);
               this.btnRemove.Name = "btnRemove";
               this.btnRemove.Size = new System.Drawing.Size(75, 23);
               this.btnRemove.TabIndex = 32;
               this.btnRemove.Text = "Remove";
               this.btnRemove.UseVisualStyleBackColor = true;
               this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
               // 
               // cmbViews
               // 
               this.cmbViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbViews.FormattingEnabled = true;
               this.cmbViews.Location = new System.Drawing.Point(12, 137);
               this.cmbViews.Name = "cmbViews";
               this.cmbViews.Size = new System.Drawing.Size(121, 21);
               this.cmbViews.TabIndex = 31;
               this.cmbViews.SelectedIndexChanged += new System.EventHandler(this.cmbViews_SelectedIndexChanged);
               // 
               // lblvHandshake
               // 
               this.lblvHandshake.AutoSize = true;
               this.lblvHandshake.Location = new System.Drawing.Point(240, 79);
               this.lblvHandshake.Name = "lblvHandshake";
               this.lblvHandshake.Size = new System.Drawing.Size(49, 13);
               this.lblvHandshake.TabIndex = 34;
               this.lblvHandshake.Text = "0000000";
               // 
               // lblHandshake
               // 
               this.lblHandshake.AutoSize = true;
               this.lblHandshake.Location = new System.Drawing.Point(174, 79);
               this.lblHandshake.Name = "lblHandshake";
               this.lblHandshake.Size = new System.Drawing.Size(65, 13);
               this.lblHandshake.TabIndex = 33;
               this.lblHandshake.Text = "Handshake:";
               // 
               // lblvRTSEnable
               // 
               this.lblvRTSEnable.AutoSize = true;
               this.lblvRTSEnable.Location = new System.Drawing.Point(240, 53);
               this.lblvRTSEnable.Name = "lblvRTSEnable";
               this.lblvRTSEnable.Size = new System.Drawing.Size(49, 13);
               this.lblvRTSEnable.TabIndex = 36;
               this.lblvRTSEnable.Text = "0000000";
               // 
               // lblRTSEnable
               // 
               this.lblRTSEnable.AutoSize = true;
               this.lblRTSEnable.Location = new System.Drawing.Point(174, 53);
               this.lblRTSEnable.Name = "lblRTSEnable";
               this.lblRTSEnable.Size = new System.Drawing.Size(32, 13);
               this.lblRTSEnable.TabIndex = 35;
               this.lblRTSEnable.Text = "RTS:";
               // 
               // lblvDTREnable
               // 
               this.lblvDTREnable.AutoSize = true;
               this.lblvDTREnable.Location = new System.Drawing.Point(240, 66);
               this.lblvDTREnable.Name = "lblvDTREnable";
               this.lblvDTREnable.Size = new System.Drawing.Size(49, 13);
               this.lblvDTREnable.TabIndex = 38;
               this.lblvDTREnable.Text = "0000000";
               // 
               // lblDTREnable
               // 
               this.lblDTREnable.AutoSize = true;
               this.lblDTREnable.Location = new System.Drawing.Point(174, 66);
               this.lblDTREnable.Name = "lblDTREnable";
               this.lblDTREnable.Size = new System.Drawing.Size(33, 13);
               this.lblDTREnable.TabIndex = 37;
               this.lblDTREnable.Text = "DTR:";
               // 
               // btnEdit
               // 
               this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.btnEdit.Location = new System.Drawing.Point(606, 433);
               this.btnEdit.Name = "btnEdit";
               this.btnEdit.Size = new System.Drawing.Size(75, 23);
               this.btnEdit.TabIndex = 40;
               this.btnEdit.Text = "Edit";
               this.btnEdit.UseVisualStyleBackColor = true;
               this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
               // 
               // btnClear
               // 
               this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
               this.btnClear.Location = new System.Drawing.Point(12, 433);
               this.btnClear.Name = "btnClear";
               this.btnClear.Size = new System.Drawing.Size(75, 23);
               this.btnClear.TabIndex = 41;
               this.btnClear.Text = "Clear";
               this.btnClear.UseVisualStyleBackColor = true;
               this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
               // 
               // lstDisplayWindowTwo
               // 
               this.lstDisplayWindowTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.lstDisplayWindowTwo.Font = new System.Drawing.Font("Moire", 11.25F);
               this.lstDisplayWindowTwo.FormattingEnabled = true;
               this.lstDisplayWindowTwo.HorizontalScrollbar = true;
               this.lstDisplayWindowTwo.ItemHeight = 18;
               this.lstDisplayWindowTwo.Location = new System.Drawing.Point(12, 164);
               this.lstDisplayWindowTwo.Name = "lstDisplayWindowTwo";
               this.lstDisplayWindowTwo.Size = new System.Drawing.Size(436, 256);
               this.lstDisplayWindowTwo.TabIndex = 42;
               // 
               // MainForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(774, 462);
               this.Controls.Add(this.lstDisplayWindowOne);
               this.Controls.Add(this.lstDisplayWindowTwo);
               this.Controls.Add(this.btnClear);
               this.Controls.Add(this.btnEdit);
               this.Controls.Add(this.lblvDTREnable);
               this.Controls.Add(this.lblDTREnable);
               this.Controls.Add(this.lblvRTSEnable);
               this.Controls.Add(this.lblRTSEnable);
               this.Controls.Add(this.lblvHandshake);
               this.Controls.Add(this.lblHandshake);
               this.Controls.Add(this.btnRemove);
               this.Controls.Add(this.btnRefresh);
               this.Controls.Add(this.cmbViews);
               this.Controls.Add(this.lstMessageSummary);
               this.Controls.Add(this.btnOpenAndClose);
               this.Controls.Add(this.btnAddCompanyMessage);
               this.Controls.Add(this.btnAddMessage);
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
               this.Controls.Add(this.btnConfigureComPort);
               this.Controls.Add(this.lblCurrentTime);
               this.Controls.Add(this.menuStrip1);
               this.MainMenuStrip = this.menuStrip1;
               this.MinimumSize = new System.Drawing.Size(790, 500);
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
          private System.Windows.Forms.Button btnConfigureComPort;
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
          private System.Windows.Forms.ListBox lstDisplayWindowOne;
          private System.Windows.Forms.Timer tmrCheckForData;
          private System.Windows.Forms.Button btnAddMessage;
          private System.Windows.Forms.Button btnAddCompanyMessage;
          private System.Windows.Forms.MenuStrip menuStrip1;
          private System.Windows.Forms.ToolStripMenuItem File;
          private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
          private System.Windows.Forms.Button btnOpenAndClose;
          private System.Windows.Forms.ListBox lstMessageSummary;

          private System.Windows.Forms.Button btnRefresh;
          private System.Windows.Forms.Button btnRemove;

          private System.Windows.Forms.ComboBox cmbViews;
          private System.Windows.Forms.Label lblvHandshake;
          private System.Windows.Forms.Label lblHandshake;
          private System.Windows.Forms.Label lblvRTSEnable;
          private System.Windows.Forms.Label lblRTSEnable;
          private System.Windows.Forms.Label lblvDTREnable;
          private System.Windows.Forms.Label lblDTREnable;
          private System.Windows.Forms.Button btnEdit;
          private System.Windows.Forms.Button btnClear;
          private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
          private System.Windows.Forms.ListBox lstDisplayWindowTwo;

     }
}

