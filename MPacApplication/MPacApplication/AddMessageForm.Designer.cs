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
               this.lblIdError1 = new System.Windows.Forms.Label();
               this.txtID = new System.Windows.Forms.TextBox();
               this.lblID = new System.Windows.Forms.Label();
               this.lblLengthError = new System.Windows.Forms.Label();
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
               this.lblUniformSigned = new System.Windows.Forms.Label();
               this.cmbUniformSigned = new System.Windows.Forms.ComboBox();
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
               this.lblSigned = new System.Windows.Forms.Label();
               this.cmbSigned = new System.Windows.Forms.ComboBox();
               this.lblCustomError = new System.Windows.Forms.Label();
               this.lblvBytes = new System.Windows.Forms.Label();
               this.lblRemaining = new System.Windows.Forms.Label();
               this.lblFormat2 = new System.Windows.Forms.Label();
               this.lblCount = new System.Windows.Forms.Label();
               this.lblGroup = new System.Windows.Forms.Label();
               this.btnRemove = new System.Windows.Forms.Button();
               this.btnMoveDown = new System.Windows.Forms.Button();
               this.btnMoveUp = new System.Windows.Forms.Button();
               this.btnAdd = new System.Windows.Forms.Button();
               this.cmbFormat = new System.Windows.Forms.ComboBox();
               this.cmbCount = new System.Windows.Forms.ComboBox();
               this.cmbGroup = new System.Windows.Forms.ComboBox();
               this.lstFormats = new System.Windows.Forms.ListBox();
               this.cmbConnections = new System.Windows.Forms.ComboBox();
               this.lblConnection = new System.Windows.Forms.Label();
               this.lblNameError1 = new System.Windows.Forms.Label();
               this.lblIdError3 = new System.Windows.Forms.Label();
               this.lblNameError2 = new System.Windows.Forms.Label();
               this.lblIdError2 = new System.Windows.Forms.Label();
               this.lblCompanyError1 = new System.Windows.Forms.Label();
               this.lblCompanyError2 = new System.Windows.Forms.Label();
               this.pnlUniformGroup.SuspendLayout();
               this.pnlExternalProgram.SuspendLayout();
               this.pnlCustomFormat.SuspendLayout();
               this.SuspendLayout();
               // 
               // lblIdError1
               // 
               this.lblIdError1.AutoSize = true;
               this.lblIdError1.ForeColor = System.Drawing.Color.Red;
               this.lblIdError1.Location = new System.Drawing.Point(12, 70);
               this.lblIdError1.Name = "lblIdError1";
               this.lblIdError1.Size = new System.Drawing.Size(99, 13);
               this.lblIdError1.TabIndex = 8;
               this.lblIdError1.Text = "Must be 0000-7FFF";
               this.lblIdError1.Visible = false;
               // 
               // txtID
               // 
               this.txtID.Location = new System.Drawing.Point(36, 47);
               this.txtID.Name = "txtID";
               this.txtID.Size = new System.Drawing.Size(47, 20);
               this.txtID.TabIndex = 6;
               // 
               // lblID
               // 
               this.lblID.AutoSize = true;
               this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
               this.lblID.Location = new System.Drawing.Point(12, 50);
               this.lblID.Name = "lblID";
               this.lblID.Size = new System.Drawing.Size(18, 13);
               this.lblID.TabIndex = 5;
               this.lblID.Text = "ID";
               // 
               // lblLengthError
               // 
               this.lblLengthError.AutoSize = true;
               this.lblLengthError.ForeColor = System.Drawing.Color.Red;
               this.lblLengthError.Location = new System.Drawing.Point(117, 70);
               this.lblLengthError.Name = "lblLengthError";
               this.lblLengthError.Size = new System.Drawing.Size(75, 13);
               this.lblLengthError.TabIndex = 13;
               this.lblLengthError.Text = "Must be 00-FF";
               this.lblLengthError.Visible = false;
               // 
               // txtLength
               // 
               this.txtLength.Location = new System.Drawing.Point(163, 46);
               this.txtLength.Name = "txtLength";
               this.txtLength.Size = new System.Drawing.Size(32, 20);
               this.txtLength.TabIndex = 11;
               this.txtLength.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
               // 
               // lblLength
               // 
               this.lblLength.AutoSize = true;
               this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
               this.lblLength.Location = new System.Drawing.Point(117, 50);
               this.lblLength.Name = "lblLength";
               this.lblLength.Size = new System.Drawing.Size(40, 13);
               this.lblLength.TabIndex = 10;
               this.lblLength.Text = "Length";
               // 
               // txtName
               // 
               this.txtName.Location = new System.Drawing.Point(53, 6);
               this.txtName.Name = "txtName";
               this.txtName.Size = new System.Drawing.Size(130, 20);
               this.txtName.TabIndex = 16;
               // 
               // lblName
               // 
               this.lblName.AutoSize = true;
               this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
               this.lblName.Location = new System.Drawing.Point(12, 9);
               this.lblName.Name = "lblName";
               this.lblName.Size = new System.Drawing.Size(35, 13);
               this.lblName.TabIndex = 15;
               this.lblName.Text = "Name";
               // 
               // txtFormat
               // 
               this.txtFormat.Location = new System.Drawing.Point(502, 222);
               this.txtFormat.Name = "txtFormat";
               this.txtFormat.ReadOnly = true;
               this.txtFormat.Size = new System.Drawing.Size(231, 20);
               this.txtFormat.TabIndex = 18;
               this.txtFormat.Visible = false;
               // 
               // lblFormat
               // 
               this.lblFormat.AutoSize = true;
               this.lblFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
               this.lblFormat.Location = new System.Drawing.Point(12, 98);
               this.lblFormat.Name = "lblFormat";
               this.lblFormat.Size = new System.Drawing.Size(39, 13);
               this.lblFormat.TabIndex = 17;
               this.lblFormat.Text = "Format";
               // 
               // btnCancel
               // 
               this.btnCancel.Location = new System.Drawing.Point(209, 311);
               this.btnCancel.Name = "btnCancel";
               this.btnCancel.Size = new System.Drawing.Size(75, 23);
               this.btnCancel.TabIndex = 20;
               this.btnCancel.Text = "Cancel";
               this.btnCancel.UseVisualStyleBackColor = true;
               this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
               // 
               // btnOK
               // 
               this.btnOK.Location = new System.Drawing.Point(128, 311);
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
               this.cmbFormatType.Location = new System.Drawing.Point(57, 95);
               this.cmbFormatType.Name = "cmbFormatType";
               this.cmbFormatType.Size = new System.Drawing.Size(213, 21);
               this.cmbFormatType.TabIndex = 21;
               this.cmbFormatType.SelectedIndexChanged += new System.EventHandler(this.cmbFormatType_SelectedIndexChanged);
               // 
               // pnlUniformGroup
               // 
               this.pnlUniformGroup.Controls.Add(this.lblUniformSigned);
               this.pnlUniformGroup.Controls.Add(this.cmbUniformSigned);
               this.pnlUniformGroup.Controls.Add(this.lblUniformGroup2);
               this.pnlUniformGroup.Controls.Add(this.cmbUniformFormat);
               this.pnlUniformGroup.Controls.Add(this.lblUniformFormat);
               this.pnlUniformGroup.Controls.Add(this.lblUniformGroup);
               this.pnlUniformGroup.Controls.Add(this.cmbUniformGroup);
               this.pnlUniformGroup.Location = new System.Drawing.Point(502, 14);
               this.pnlUniformGroup.Name = "pnlUniformGroup";
               this.pnlUniformGroup.Size = new System.Drawing.Size(251, 121);
               this.pnlUniformGroup.TabIndex = 22;
               this.pnlUniformGroup.Visible = false;
               // 
               // lblUniformSigned
               // 
               this.lblUniformSigned.AutoSize = true;
               this.lblUniformSigned.Location = new System.Drawing.Point(46, 87);
               this.lblUniformSigned.Name = "lblUniformSigned";
               this.lblUniformSigned.Size = new System.Drawing.Size(43, 13);
               this.lblUniformSigned.TabIndex = 9;
               this.lblUniformSigned.Text = "Signed:";
               // 
               // cmbUniformSigned
               // 
               this.cmbUniformSigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbUniformSigned.FormattingEnabled = true;
               this.cmbUniformSigned.Items.AddRange(new object[] {
            "signed",
            "unsigned"});
               this.cmbUniformSigned.Location = new System.Drawing.Point(98, 84);
               this.cmbUniformSigned.Name = "cmbUniformSigned";
               this.cmbUniformSigned.Size = new System.Drawing.Size(82, 21);
               this.cmbUniformSigned.TabIndex = 8;
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
            "binary",
            "decimal",
            "hex"});
               this.cmbUniformFormat.Location = new System.Drawing.Point(99, 49);
               this.cmbUniformFormat.Name = "cmbUniformFormat";
               this.cmbUniformFormat.Size = new System.Drawing.Size(81, 21);
               this.cmbUniformFormat.TabIndex = 6;
               this.cmbUniformFormat.TextChanged += new System.EventHandler(this.cmbUniformFormat_TextChanged);
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
               this.cmbUniformGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbUniformGroup.FormattingEnabled = true;
               this.cmbUniformGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
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
               this.pnlExternalProgram.Location = new System.Drawing.Point(502, 150);
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
               this.pnlCustomFormat.Controls.Add(this.lblSigned);
               this.pnlCustomFormat.Controls.Add(this.cmbSigned);
               this.pnlCustomFormat.Controls.Add(this.lblCustomError);
               this.pnlCustomFormat.Controls.Add(this.lblvBytes);
               this.pnlCustomFormat.Controls.Add(this.lblRemaining);
               this.pnlCustomFormat.Controls.Add(this.lblFormat2);
               this.pnlCustomFormat.Controls.Add(this.lblCount);
               this.pnlCustomFormat.Controls.Add(this.lblGroup);
               this.pnlCustomFormat.Controls.Add(this.btnRemove);
               this.pnlCustomFormat.Controls.Add(this.btnMoveDown);
               this.pnlCustomFormat.Controls.Add(this.btnMoveUp);
               this.pnlCustomFormat.Controls.Add(this.btnAdd);
               this.pnlCustomFormat.Controls.Add(this.cmbFormat);
               this.pnlCustomFormat.Controls.Add(this.cmbCount);
               this.pnlCustomFormat.Controls.Add(this.cmbGroup);
               this.pnlCustomFormat.Controls.Add(this.lstFormats);
               this.pnlCustomFormat.Location = new System.Drawing.Point(15, 122);
               this.pnlCustomFormat.Name = "pnlCustomFormat";
               this.pnlCustomFormat.Size = new System.Drawing.Size(404, 173);
               this.pnlCustomFormat.TabIndex = 31;
               this.pnlCustomFormat.Visible = false;
               // 
               // lblSigned
               // 
               this.lblSigned.AutoSize = true;
               this.lblSigned.Location = new System.Drawing.Point(244, 11);
               this.lblSigned.Name = "lblSigned";
               this.lblSigned.Size = new System.Drawing.Size(43, 13);
               this.lblSigned.TabIndex = 40;
               this.lblSigned.Text = "Signed:";
               // 
               // cmbSigned
               // 
               this.cmbSigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbSigned.FormattingEnabled = true;
               this.cmbSigned.Items.AddRange(new object[] {
            "signed",
            "unsigned"});
               this.cmbSigned.Location = new System.Drawing.Point(244, 27);
               this.cmbSigned.Name = "cmbSigned";
               this.cmbSigned.Size = new System.Drawing.Size(73, 21);
               this.cmbSigned.TabIndex = 41;
               // 
               // lblCustomError
               // 
               this.lblCustomError.AutoSize = true;
               this.lblCustomError.ForeColor = System.Drawing.Color.Red;
               this.lblCustomError.Location = new System.Drawing.Point(175, 152);
               this.lblCustomError.Name = "lblCustomError";
               this.lblCustomError.Size = new System.Drawing.Size(128, 13);
               this.lblCustomError.TabIndex = 40;
               this.lblCustomError.Text = "Custom Format is too long";
               this.lblCustomError.Visible = false;
               // 
               // lblvBytes
               // 
               this.lblvBytes.AutoSize = true;
               this.lblvBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lblvBytes.Location = new System.Drawing.Point(144, 150);
               this.lblvBytes.Name = "lblvBytes";
               this.lblvBytes.Size = new System.Drawing.Size(16, 16);
               this.lblvBytes.TabIndex = 14;
               this.lblvBytes.Text = "0";
               // 
               // lblRemaining
               // 
               this.lblRemaining.AutoSize = true;
               this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lblRemaining.Location = new System.Drawing.Point(9, 150);
               this.lblRemaining.Name = "lblRemaining";
               this.lblRemaining.Size = new System.Drawing.Size(129, 16);
               this.lblRemaining.TabIndex = 13;
               this.lblRemaining.Text = "Remaining Bytes:";
               // 
               // lblFormat2
               // 
               this.lblFormat2.AutoSize = true;
               this.lblFormat2.Location = new System.Drawing.Point(163, 10);
               this.lblFormat2.Name = "lblFormat2";
               this.lblFormat2.Size = new System.Drawing.Size(42, 13);
               this.lblFormat2.TabIndex = 11;
               this.lblFormat2.Text = "Format:";
               // 
               // lblCount
               // 
               this.lblCount.AutoSize = true;
               this.lblCount.Location = new System.Drawing.Point(87, 10);
               this.lblCount.Name = "lblCount";
               this.lblCount.Size = new System.Drawing.Size(64, 13);
               this.lblCount.TabIndex = 10;
               this.lblCount.Text = "# of groups:";
               // 
               // lblGroup
               // 
               this.lblGroup.AutoSize = true;
               this.lblGroup.Location = new System.Drawing.Point(9, 11);
               this.lblGroup.Name = "lblGroup";
               this.lblGroup.Size = new System.Drawing.Size(53, 13);
               this.lblGroup.TabIndex = 9;
               this.lblGroup.Text = "Group by:";
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
               this.btnAdd.Location = new System.Drawing.Point(325, 28);
               this.btnAdd.Name = "btnAdd";
               this.btnAdd.Size = new System.Drawing.Size(75, 23);
               this.btnAdd.TabIndex = 5;
               this.btnAdd.Text = "Add";
               this.btnAdd.UseVisualStyleBackColor = true;
               this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
               // 
               // cmbFormat
               // 
               this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbFormat.FormattingEnabled = true;
               this.cmbFormat.Items.AddRange(new object[] {
            "binary",
            "decimal",
            "hex"});
               this.cmbFormat.Location = new System.Drawing.Point(166, 27);
               this.cmbFormat.Name = "cmbFormat";
               this.cmbFormat.Size = new System.Drawing.Size(72, 21);
               this.cmbFormat.TabIndex = 3;
               this.cmbFormat.TextChanged += new System.EventHandler(this.cmbFormat_TextChanged);
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
               this.cmbCount.Location = new System.Drawing.Point(88, 27);
               this.cmbCount.Name = "cmbCount";
               this.cmbCount.Size = new System.Drawing.Size(72, 21);
               this.cmbCount.TabIndex = 2;
               this.cmbCount.TextChanged += new System.EventHandler(this.cmbCount_TextChanged);
               // 
               // cmbGroup
               // 
               this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbGroup.FormattingEnabled = true;
               this.cmbGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
               this.cmbGroup.Location = new System.Drawing.Point(12, 27);
               this.cmbGroup.Name = "cmbGroup";
               this.cmbGroup.Size = new System.Drawing.Size(72, 21);
               this.cmbGroup.TabIndex = 1;
               this.cmbGroup.TextChanged += new System.EventHandler(this.cmbGroup_TextChanged);
               // 
               // lstFormats
               // 
               this.lstFormats.FormattingEnabled = true;
               this.lstFormats.Location = new System.Drawing.Point(12, 54);
               this.lstFormats.Name = "lstFormats";
               this.lstFormats.Size = new System.Drawing.Size(305, 82);
               this.lstFormats.TabIndex = 0;
               // 
               // cmbConnections
               // 
               this.cmbConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbConnections.FormattingEnabled = true;
               this.cmbConnections.Location = new System.Drawing.Point(209, 28);
               this.cmbConnections.Name = "cmbConnections";
               this.cmbConnections.Size = new System.Drawing.Size(210, 21);
               this.cmbConnections.TabIndex = 32;
               this.cmbConnections.Visible = false;
               // 
               // lblConnection
               // 
               this.lblConnection.AutoSize = true;
               this.lblConnection.Location = new System.Drawing.Point(206, 9);
               this.lblConnection.Name = "lblConnection";
               this.lblConnection.Size = new System.Drawing.Size(88, 13);
               this.lblConnection.TabIndex = 33;
               this.lblConnection.Text = "SQL Connection:";
               this.lblConnection.Visible = false;
               // 
               // lblNameError1
               // 
               this.lblNameError1.AutoSize = true;
               this.lblNameError1.ForeColor = System.Drawing.Color.Red;
               this.lblNameError1.Location = new System.Drawing.Point(65, 29);
               this.lblNameError1.Name = "lblNameError1";
               this.lblNameError1.Size = new System.Drawing.Size(92, 13);
               this.lblNameError1.TabIndex = 34;
               this.lblNameError1.Text = "Must not be blank";
               this.lblNameError1.Visible = false;
               // 
               // lblIdError3
               // 
               this.lblIdError3.AutoSize = true;
               this.lblIdError3.ForeColor = System.Drawing.Color.Red;
               this.lblIdError3.Location = new System.Drawing.Point(12, 70);
               this.lblIdError3.Name = "lblIdError3";
               this.lblIdError3.Size = new System.Drawing.Size(84, 13);
               this.lblIdError3.TabIndex = 35;
               this.lblIdError3.Text = "ID already exists";
               this.lblIdError3.Visible = false;
               // 
               // lblNameError2
               // 
               this.lblNameError2.AutoSize = true;
               this.lblNameError2.ForeColor = System.Drawing.Color.Red;
               this.lblNameError2.Location = new System.Drawing.Point(50, 29);
               this.lblNameError2.Name = "lblNameError2";
               this.lblNameError2.Size = new System.Drawing.Size(145, 13);
               this.lblNameError2.TabIndex = 36;
               this.lblNameError2.Text = "Message name already exists";
               this.lblNameError2.Visible = false;
               // 
               // lblIdError2
               // 
               this.lblIdError2.AutoSize = true;
               this.lblIdError2.ForeColor = System.Drawing.Color.Red;
               this.lblIdError2.Location = new System.Drawing.Point(12, 70);
               this.lblIdError2.Name = "lblIdError2";
               this.lblIdError2.Size = new System.Drawing.Size(99, 13);
               this.lblIdError2.TabIndex = 37;
               this.lblIdError2.Text = "Must be 8000-FFFF";
               this.lblIdError2.Visible = false;
               // 
               // lblCompanyError1
               // 
               this.lblCompanyError1.AutoSize = true;
               this.lblCompanyError1.ForeColor = System.Drawing.Color.Red;
               this.lblCompanyError1.Location = new System.Drawing.Point(111, 340);
               this.lblCompanyError1.Name = "lblCompanyError1";
               this.lblCompanyError1.Size = new System.Drawing.Size(182, 13);
               this.lblCompanyError1.TabIndex = 38;
               this.lblCompanyError1.Text = "Please select a database connection";
               this.lblCompanyError1.Visible = false;
               // 
               // lblCompanyError2
               // 
               this.lblCompanyError2.AutoSize = true;
               this.lblCompanyError2.ForeColor = System.Drawing.Color.Red;
               this.lblCompanyError2.Location = new System.Drawing.Point(142, 340);
               this.lblCompanyError2.Name = "lblCompanyError2";
               this.lblCompanyError2.Size = new System.Drawing.Size(128, 13);
               this.lblCompanyError2.TabIndex = 39;
               this.lblCompanyError2.Text = "Company Message Failed";
               this.lblCompanyError2.Visible = false;
               // 
               // AddMessageForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(433, 364);
               this.Controls.Add(this.lblCompanyError2);
               this.Controls.Add(this.lblCompanyError1);
               this.Controls.Add(this.lblIdError2);
               this.Controls.Add(this.lblNameError2);
               this.Controls.Add(this.lblIdError3);
               this.Controls.Add(this.lblNameError1);
               this.Controls.Add(this.lblConnection);
               this.Controls.Add(this.cmbConnections);
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
               this.Controls.Add(this.lblLengthError);
               this.Controls.Add(this.txtLength);
               this.Controls.Add(this.lblLength);
               this.Controls.Add(this.lblIdError1);
               this.Controls.Add(this.txtID);
               this.Controls.Add(this.lblID);
               this.MaximizeBox = false;
               this.MaximumSize = new System.Drawing.Size(449, 402);
               this.MinimizeBox = false;
               this.MinimumSize = new System.Drawing.Size(449, 402);
               this.Name = "AddMessageForm";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
               this.Text = "AddMessageForm";
               this.Activated += new System.EventHandler(this.AddMessageForm_activated);
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

        private System.Windows.Forms.Label lblIdError1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblLengthError;
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
        private System.Windows.Forms.Label lblFormat2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ListBox lstFormats;
        private System.Windows.Forms.ComboBox cmbConnections;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Label lblvBytes;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblNameError1;
        private System.Windows.Forms.Label lblIdError3;
        private System.Windows.Forms.Label lblNameError2;
        private System.Windows.Forms.Label lblIdError2;
        private System.Windows.Forms.Label lblCompanyError1;
        private System.Windows.Forms.Label lblCompanyError2;
        private System.Windows.Forms.Label lblCustomError;
        private System.Windows.Forms.Label lblSigned;
        private System.Windows.Forms.ComboBox cmbSigned;
        private System.Windows.Forms.Label lblUniformSigned;
        private System.Windows.Forms.ComboBox cmbUniformSigned;


    }
}