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
            this.txtVersion1 = new System.Windows.Forms.TextBox();
            this.txtVersion2 = new System.Windows.Forms.TextBox();
            this.lblHex1 = new System.Windows.Forms.Label();
            this.lblHex2 = new System.Windows.Forms.Label();
            this.lblHex4 = new System.Windows.Forms.Label();
            this.lblHex3 = new System.Windows.Forms.Label();
            this.txtID2 = new System.Windows.Forms.TextBox();
            this.txtID1 = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblHex5 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbFormatType = new System.Windows.Forms.ComboBox();
            this.pnlUniformGroup = new System.Windows.Forms.Panel();
            this.lblUniformGroup2 = new System.Windows.Forms.Label();
            this.cmbUniformFormat = new System.Windows.Forms.ComboBox();
            this.lblUniformFormat = new System.Windows.Forms.Label();
            this.lblUniformGroup = new System.Windows.Forms.Label();
            this.cmbUniformGroup = new System.Windows.Forms.ComboBox();
            this.pnlExternalProgram = new System.Windows.Forms.Panel();
            this.lblExternal = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtExternalFile = new System.Windows.Forms.TextBox();
            this.pnlCustomFormat = new System.Windows.Forms.Panel();
            this.lblType = new System.Windows.Forms.Label();
            this.lblFormat2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lstFormats = new System.Windows.Forms.ListBox();
            this.pnlUniformGroup.SuspendLayout();
            this.pnlExternalProgram.SuspendLayout();
            this.pnlCustomFormat.SuspendLayout();
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
            // txtVersion1
            // 
            this.txtVersion1.Location = new System.Drawing.Point(117, 22);
            this.txtVersion1.Name = "txtVersion1";
            this.txtVersion1.Size = new System.Drawing.Size(46, 20);
            this.txtVersion1.TabIndex = 1;
            this.txtVersion1.LostFocus += new System.EventHandler(this.txtVersion1_LostFocus);
            // 
            // txtVersion2
            // 
            this.txtVersion2.Location = new System.Drawing.Point(201, 22);
            this.txtVersion2.Name = "txtVersion2";
            this.txtVersion2.Size = new System.Drawing.Size(46, 20);
            this.txtVersion2.TabIndex = 2;
            this.txtVersion2.LostFocus += new System.EventHandler(this.txtVersion2_LostFocus);
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
            this.lblHex4.Location = new System.Drawing.Point(198, 92);
            this.lblHex4.Name = "lblHex4";
            this.lblHex4.Size = new System.Drawing.Size(34, 13);
            this.lblHex4.TabIndex = 9;
            this.lblHex4.Text = "00-FF";
            // 
            // lblHex3
            // 
            this.lblHex3.AutoSize = true;
            this.lblHex3.Location = new System.Drawing.Point(117, 92);
            this.lblHex3.Name = "lblHex3";
            this.lblHex3.Size = new System.Drawing.Size(34, 13);
            this.lblHex3.TabIndex = 8;
            this.lblHex3.Text = "00-FF";
            // 
            // txtID2
            // 
            this.txtID2.Location = new System.Drawing.Point(201, 65);
            this.txtID2.Name = "txtID2";
            this.txtID2.Size = new System.Drawing.Size(46, 20);
            this.txtID2.TabIndex = 7;
            this.txtID2.LostFocus += new System.EventHandler(this.txtID2_LostFocus);
            // 
            // txtID1
            // 
            this.txtID1.Location = new System.Drawing.Point(117, 65);
            this.txtID1.Name = "txtID1";
            this.txtID1.Size = new System.Drawing.Size(46, 20);
            this.txtID1.TabIndex = 6;
            this.txtID1.LostFocus += new System.EventHandler(this.txtID1_LostFocus);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(12, 65);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 20);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "ID";
            // 
            // lblHex5
            // 
            this.lblHex5.AutoSize = true;
            this.lblHex5.Location = new System.Drawing.Point(117, 135);
            this.lblHex5.Name = "lblHex5";
            this.lblHex5.Size = new System.Drawing.Size(34, 13);
            this.lblHex5.TabIndex = 13;
            this.lblHex5.Text = "00-FF";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(117, 108);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(46, 20);
            this.txtLength.TabIndex = 11;
            this.txtLength.LostFocus += new System.EventHandler(this.txtLength_LostFocus);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(12, 108);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(59, 20);
            this.lblLength.TabIndex = 10;
            this.lblLength.Text = "Length";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(117, 151);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(130, 20);
            this.txtName.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 151);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name";
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(16, 192);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.ReadOnly = true;
            this.txtFormat.Size = new System.Drawing.Size(231, 20);
            this.txtFormat.TabIndex = 18;
            this.txtFormat.Visible = false;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat.Location = new System.Drawing.Point(267, 20);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(60, 20);
            this.lblFormat.TabIndex = 17;
            this.lblFormat.Text = "Format";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(36, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbFormatType
            // 
            this.cmbFormatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormatType.FormattingEnabled = true;
            this.cmbFormatType.Items.AddRange(new object[] {
            "Uniform Grouping",
            "Custom Format",
            "External Program"});
            this.cmbFormatType.Location = new System.Drawing.Point(372, 22);
            this.cmbFormatType.Name = "cmbFormatType";
            this.cmbFormatType.Size = new System.Drawing.Size(213, 21);
            this.cmbFormatType.TabIndex = 21;
            this.cmbFormatType.SelectedIndexChanged += new System.EventHandler(this.cmbFormatType_SelectedIndexChanged);
            // 
            // pnlUniformGroup
            // 
            this.pnlUniformGroup.Controls.Add(this.lblUniformGroup2);
            this.pnlUniformGroup.Controls.Add(this.cmbUniformFormat);
            this.pnlUniformGroup.Controls.Add(this.lblUniformFormat);
            this.pnlUniformGroup.Controls.Add(this.lblUniformGroup);
            this.pnlUniformGroup.Controls.Add(this.cmbUniformGroup);
            this.pnlUniformGroup.Location = new System.Drawing.Point(716, 126);
            this.pnlUniformGroup.Name = "pnlUniformGroup";
            this.pnlUniformGroup.Size = new System.Drawing.Size(251, 97);
            this.pnlUniformGroup.TabIndex = 22;
            this.pnlUniformGroup.Visible = false;
            // 
            // lblUniformGroup2
            // 
            this.lblUniformGroup2.AutoSize = true;
            this.lblUniformGroup2.Location = new System.Drawing.Point(186, 18);
            this.lblUniformGroup2.Name = "lblUniformGroup2";
            this.lblUniformGroup2.Size = new System.Drawing.Size(35, 13);
            this.lblUniformGroup2.TabIndex = 7;
            this.lblUniformGroup2.Text = "bytes.";
            // 
            // cmbUniformFormat
            // 
            this.cmbUniformFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUniformFormat.FormattingEnabled = true;
            this.cmbUniformFormat.Items.AddRange(new object[] {
            "Binary",
            "Hex"});
            this.cmbUniformFormat.Location = new System.Drawing.Point(99, 49);
            this.cmbUniformFormat.Name = "cmbUniformFormat";
            this.cmbUniformFormat.Size = new System.Drawing.Size(81, 21);
            this.cmbUniformFormat.TabIndex = 6;
            // 
            // lblUniformFormat
            // 
            this.lblUniformFormat.AutoSize = true;
            this.lblUniformFormat.Location = new System.Drawing.Point(3, 52);
            this.lblUniformFormat.Name = "lblUniformFormat";
            this.lblUniformFormat.Size = new System.Drawing.Size(86, 13);
            this.lblUniformFormat.TabIndex = 5;
            this.lblUniformFormat.Text = "Format output as";
            // 
            // lblUniformGroup
            // 
            this.lblUniformGroup.AutoSize = true;
            this.lblUniformGroup.Location = new System.Drawing.Point(5, 18);
            this.lblUniformGroup.Name = "lblUniformGroup";
            this.lblUniformGroup.Size = new System.Drawing.Size(84, 13);
            this.lblUniformGroup.TabIndex = 4;
            this.lblUniformGroup.Text = "Group by sets of";
            // 
            // cmbUniformGroup
            // 
            this.cmbUniformGroup.FormattingEnabled = true;
            this.cmbUniformGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "16",
            "32"});
            this.cmbUniformGroup.Location = new System.Drawing.Point(99, 15);
            this.cmbUniformGroup.Name = "cmbUniformGroup";
            this.cmbUniformGroup.Size = new System.Drawing.Size(81, 21);
            this.cmbUniformGroup.TabIndex = 3;
            // 
            // pnlExternalProgram
            // 
            this.pnlExternalProgram.Controls.Add(this.lblExternal);
            this.pnlExternalProgram.Controls.Add(this.btnOpenFile);
            this.pnlExternalProgram.Controls.Add(this.txtExternalFile);
            this.pnlExternalProgram.Location = new System.Drawing.Point(716, 49);
            this.pnlExternalProgram.Name = "pnlExternalProgram";
            this.pnlExternalProgram.Size = new System.Drawing.Size(352, 66);
            this.pnlExternalProgram.TabIndex = 29;
            this.pnlExternalProgram.Visible = false;
            // 
            // lblExternal
            // 
            this.lblExternal.AutoSize = true;
            this.lblExternal.Location = new System.Drawing.Point(9, 12);
            this.lblExternal.Name = "lblExternal";
            this.lblExternal.Size = new System.Drawing.Size(210, 13);
            this.lblExternal.TabIndex = 2;
            this.lblExternal.Text = "Format the data via an external application:";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(257, 26);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtExternalFile
            // 
            this.txtExternalFile.Location = new System.Drawing.Point(10, 28);
            this.txtExternalFile.Name = "txtExternalFile";
            this.txtExternalFile.Size = new System.Drawing.Size(241, 20);
            this.txtExternalFile.TabIndex = 0;
            // 
            // pnlCustomFormat
            // 
            this.pnlCustomFormat.Controls.Add(this.lblType);
            this.pnlCustomFormat.Controls.Add(this.lblFormat2);
            this.pnlCustomFormat.Controls.Add(this.lblCount);
            this.pnlCustomFormat.Controls.Add(this.lblGroup);
            this.pnlCustomFormat.Controls.Add(this.btnRemove);
            this.pnlCustomFormat.Controls.Add(this.btnMoveDown);
            this.pnlCustomFormat.Controls.Add(this.btnMoveUp);
            this.pnlCustomFormat.Controls.Add(this.btnAdd);
            this.pnlCustomFormat.Controls.Add(this.cmbType);
            this.pnlCustomFormat.Controls.Add(this.cmbFormat);
            this.pnlCustomFormat.Controls.Add(this.cmbCount);
            this.pnlCustomFormat.Controls.Add(this.cmbGroup);
            this.pnlCustomFormat.Controls.Add(this.lstFormats);
            this.pnlCustomFormat.Location = new System.Drawing.Point(271, 134);
            this.pnlCustomFormat.Name = "pnlCustomFormat";
            this.pnlCustomFormat.Size = new System.Drawing.Size(404, 144);
            this.pnlCustomFormat.TabIndex = 31;
            this.pnlCustomFormat.Visible = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(243, 11);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "Type:";
            // 
            // lblFormat2
            // 
            this.lblFormat2.AutoSize = true;
            this.lblFormat2.Location = new System.Drawing.Point(165, 11);
            this.lblFormat2.Name = "lblFormat2";
            this.lblFormat2.Size = new System.Drawing.Size(42, 13);
            this.lblFormat2.TabIndex = 11;
            this.lblFormat2.Text = "Format:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(93, 11);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 13);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "Count:";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(9, 11);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(39, 13);
            this.lblGroup.TabIndex = 9;
            this.lblGroup.Text = "Group:";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(325, 114);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(325, 85);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(325, 56);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(325, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Byte",
            "Short",
            "Int",
            "Long"});
            this.cmbType.Location = new System.Drawing.Point(246, 27);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(71, 21);
            this.cmbType.TabIndex = 4;
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Items.AddRange(new object[] {
            "Binary",
            "Octal",
            "Decimal",
            "Hex"});
            this.cmbFormat.Location = new System.Drawing.Point(168, 27);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(72, 21);
            this.cmbFormat.TabIndex = 3;
            // 
            // cmbCount
            // 
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "16",
            "32"});
            this.cmbCount.Location = new System.Drawing.Point(90, 27);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(72, 21);
            this.cmbCount.TabIndex = 2;
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "16",
            "32"});
            this.cmbGroup.Location = new System.Drawing.Point(12, 27);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(72, 21);
            this.cmbGroup.TabIndex = 1;
            // 
            // lstFormats
            // 
            this.lstFormats.FormattingEnabled = true;
            this.lstFormats.Location = new System.Drawing.Point(12, 54);
            this.lstFormats.Name = "lstFormats";
            this.lstFormats.Size = new System.Drawing.Size(305, 82);
            this.lstFormats.TabIndex = 0;
            // 
            // AddMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 282);
            this.Controls.Add(this.pnlCustomFormat);
            this.Controls.Add(this.pnlExternalProgram);
            this.Controls.Add(this.pnlUniformGroup);
            this.Controls.Add(this.cmbFormatType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblHex5);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblHex4);
            this.Controls.Add(this.lblHex3);
            this.Controls.Add(this.txtID2);
            this.Controls.Add(this.txtID1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblHex2);
            this.Controls.Add(this.lblHex1);
            this.Controls.Add(this.txtVersion2);
            this.Controls.Add(this.txtVersion1);
            this.Controls.Add(this.lblVersion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddMessageForm";
            this.pnlUniformGroup.ResumeLayout(false);
            this.pnlUniformGroup.PerformLayout();
            this.pnlExternalProgram.ResumeLayout(false);
            this.pnlExternalProgram.PerformLayout();
            this.pnlCustomFormat.ResumeLayout(false);
            this.pnlCustomFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtVersion1;
        private System.Windows.Forms.TextBox txtVersion2;
        private System.Windows.Forms.Label lblHex1;
        private System.Windows.Forms.Label lblHex2;
        private System.Windows.Forms.Label lblHex4;
        private System.Windows.Forms.Label lblHex3;
        private System.Windows.Forms.TextBox txtID2;
        private System.Windows.Forms.TextBox txtID1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblHex5;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbFormatType;
        private System.Windows.Forms.Panel pnlUniformGroup;
        private System.Windows.Forms.ComboBox cmbUniformGroup;
        private System.Windows.Forms.ComboBox cmbUniformFormat;
        private System.Windows.Forms.Label lblUniformFormat;
        private System.Windows.Forms.Label lblUniformGroup;
        private System.Windows.Forms.Label lblUniformGroup2;
        private System.Windows.Forms.Panel pnlExternalProgram;
        private System.Windows.Forms.Label lblExternal;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtExternalFile;
        private System.Windows.Forms.Panel pnlCustomFormat;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblFormat2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ListBox lstFormats;


    }
}