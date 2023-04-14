namespace DENSO_PRINTING_APP
{
    partial class frmSpoolingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpoolingReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.gbPrintingParameter = new System.Windows.Forms.GroupBox();
            this.cbSpoolType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTMUser = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLotNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFeeder = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPartNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLine = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPartBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewPartBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Feeder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpoolerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbPrintingParameter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(192, 18);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(76, 47);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "R&eset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnClose.Image = global::DENSO_PRINTING_APP.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(282, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.BackColor = System.Drawing.Color.Transparent;
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMini.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnMini.Image = ((System.Drawing.Image)(resources.GetObject("btnMini.Image")));
            this.btnMini.Location = new System.Drawing.Point(1157, 3);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(29, 22);
            this.btnMini.TabIndex = 210;
            this.btnMini.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // gbPrintingParameter
            // 
            this.gbPrintingParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrintingParameter.Controls.Add(this.cbSpoolType);
            this.gbPrintingParameter.Controls.Add(this.label8);
            this.gbPrintingParameter.Controls.Add(this.cbTMUser);
            this.gbPrintingParameter.Controls.Add(this.label7);
            this.gbPrintingParameter.Controls.Add(this.cbLotNo);
            this.gbPrintingParameter.Controls.Add(this.label6);
            this.gbPrintingParameter.Controls.Add(this.cbFeeder);
            this.gbPrintingParameter.Controls.Add(this.label4);
            this.gbPrintingParameter.Controls.Add(this.cbPartNo);
            this.gbPrintingParameter.Controls.Add(this.label2);
            this.gbPrintingParameter.Controls.Add(this.cbLine);
            this.gbPrintingParameter.Controls.Add(this.label9);
            this.gbPrintingParameter.Controls.Add(this.dpToDate);
            this.gbPrintingParameter.Controls.Add(this.dpFromDate);
            this.gbPrintingParameter.Controls.Add(this.label1);
            this.gbPrintingParameter.Controls.Add(this.label3);
            this.gbPrintingParameter.Controls.Add(this.panel2);
            this.gbPrintingParameter.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbPrintingParameter.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbPrintingParameter.Location = new System.Drawing.Point(3, 3);
            this.gbPrintingParameter.Name = "gbPrintingParameter";
            this.gbPrintingParameter.Size = new System.Drawing.Size(1184, 198);
            this.gbPrintingParameter.TabIndex = 193;
            this.gbPrintingParameter.TabStop = false;
            this.gbPrintingParameter.Text = "Report";
            // 
            // cbSpoolType
            // 
            this.cbSpoolType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSpoolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpoolType.Font = new System.Drawing.Font("Calibri", 12F);
            this.cbSpoolType.FormattingEnabled = true;
            this.cbSpoolType.Items.AddRange(new object[] {
            "--Select--",
            "FRONT",
            "BACK"});
            this.cbSpoolType.Location = new System.Drawing.Point(470, 156);
            this.cbSpoolType.Name = "cbSpoolType";
            this.cbSpoolType.Size = new System.Drawing.Size(243, 27);
            this.cbSpoolType.TabIndex = 216;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(361, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 19);
            this.label8.TabIndex = 217;
            this.label8.Text = "Spooler Type:";
            // 
            // cbTMUser
            // 
            this.cbTMUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTMUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTMUser.Font = new System.Drawing.Font("Calibri", 12F);
            this.cbTMUser.FormattingEnabled = true;
            this.cbTMUser.Location = new System.Drawing.Point(115, 156);
            this.cbTMUser.Name = "cbTMUser";
            this.cbTMUser.Size = new System.Drawing.Size(243, 27);
            this.cbTMUser.TabIndex = 214;
            this.cbTMUser.SelectedIndexChanged += new System.EventHandler(this.cbTMUser_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(37, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 19);
            this.label7.TabIndex = 215;
            this.label7.Text = "TM User :";
            // 
            // cbLotNo
            // 
            this.cbLotNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLotNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLotNo.Font = new System.Drawing.Font("Calibri", 12F);
            this.cbLotNo.FormattingEnabled = true;
            this.cbLotNo.Location = new System.Drawing.Point(470, 114);
            this.cbLotNo.Name = "cbLotNo";
            this.cbLotNo.Size = new System.Drawing.Size(243, 27);
            this.cbLotNo.TabIndex = 212;
            this.cbLotNo.SelectedIndexChanged += new System.EventHandler(this.cbLotNo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(397, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 213;
            this.label6.Text = "Lot No. :";
            // 
            // cbFeeder
            // 
            this.cbFeeder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbFeeder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFeeder.Font = new System.Drawing.Font("Calibri", 12F);
            this.cbFeeder.FormattingEnabled = true;
            this.cbFeeder.Location = new System.Drawing.Point(115, 114);
            this.cbFeeder.Name = "cbFeeder";
            this.cbFeeder.Size = new System.Drawing.Size(243, 27);
            this.cbFeeder.TabIndex = 210;
            this.cbFeeder.SelectedIndexChanged += new System.EventHandler(this.cbFeeder_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(47, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 211;
            this.label4.Text = "Feeder :";
            // 
            // cbPartNo
            // 
            this.cbPartNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPartNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartNo.Font = new System.Drawing.Font("Calibri", 12F);
            this.cbPartNo.FormattingEnabled = true;
            this.cbPartNo.Location = new System.Drawing.Point(470, 70);
            this.cbPartNo.Name = "cbPartNo";
            this.cbPartNo.Size = new System.Drawing.Size(243, 27);
            this.cbPartNo.TabIndex = 208;
            this.cbPartNo.SelectedIndexChanged += new System.EventHandler(this.cbPartNo_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(390, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 209;
            this.label2.Text = "Part No. :";
            // 
            // cbLine
            // 
            this.cbLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLine.Font = new System.Drawing.Font("Calibri", 12F);
            this.cbLine.FormattingEnabled = true;
            this.cbLine.Location = new System.Drawing.Point(115, 70);
            this.cbLine.Name = "cbLine";
            this.cbLine.Size = new System.Drawing.Size(243, 27);
            this.cbLine.TabIndex = 206;
            this.cbLine.SelectedIndexChanged += new System.EventHandler(this.cbLine_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(65, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 19);
            this.label9.TabIndex = 207;
            this.label9.Text = "Line :";
            // 
            // dpToDate
            // 
            this.dpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dpToDate.CustomFormat = "dd-MM-yyyy";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpToDate.Location = new System.Drawing.Point(470, 26);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(243, 27);
            this.dpToDate.TabIndex = 204;
            this.dpToDate.CloseUp += new System.EventHandler(this.dpToDate_CloseUp);
            this.dpToDate.ValueChanged += new System.EventHandler(this.dpToDate_ValueChanged);
            this.dpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dpToDate_KeyPress);
            // 
            // dpFromDate
            // 
            this.dpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(115, 26);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(243, 27);
            this.dpFromDate.TabIndex = 204;
            this.dpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dpFromDate_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(387, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 205;
            this.label1.Text = "To Date *:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 205;
            this.label3.Text = "From Date *:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(781, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 80);
            this.panel2.TabIndex = 195;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(102, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(76, 47);
            this.btnExport.TabIndex = 207;
            this.btnExport.Text = "&Download";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(12, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 47);
            this.btnSearch.TabIndex = 206;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1204, 35);
            this.lblHeader.TabIndex = 212;
            this.lblHeader.Text = "REPORT";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnMinimize.Location = new System.Drawing.Point(1166, -72);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 32);
            this.btnMinimize.TabIndex = 211;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.gbPrintingParameter);
            this.panel1.Location = new System.Drawing.Point(4, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 514);
            this.panel1.TabIndex = 213;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Garamond", 12.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line,
            this.OldPartBarcode,
            this.NewPartBarcode,
            this.PartNo,
            this.Feeder,
            this.Lot,
            this.TMUser,
            this.Date,
            this.Time,
            this.SpoolerType});
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.AliceBlue;
            this.dgv.Location = new System.Drawing.Point(5, 200);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1194, 305);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 194;
            this.dgv.TabStop = false;
            // 
            // Line
            // 
            this.Line.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Line.DataPropertyName = "Line";
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            this.Line.Width = 149;
            // 
            // OldPartBarcode
            // 
            this.OldPartBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OldPartBarcode.DataPropertyName = "OldPartNo";
            this.OldPartBarcode.HeaderText = "Old Part Barcode";
            this.OldPartBarcode.Name = "OldPartBarcode";
            this.OldPartBarcode.Width = 200;
            // 
            // NewPartBarcode
            // 
            this.NewPartBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NewPartBarcode.DataPropertyName = "NewPartNo";
            this.NewPartBarcode.HeaderText = "New Part Barcode";
            this.NewPartBarcode.Name = "NewPartBarcode";
            this.NewPartBarcode.Width = 200;
            // 
            // PartNo
            // 
            this.PartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PartNo.DataPropertyName = "PartNo";
            this.PartNo.HeaderText = "Part No.";
            this.PartNo.Name = "PartNo";
            this.PartNo.Width = 149;
            // 
            // Feeder
            // 
            this.Feeder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Feeder.DataPropertyName = "FeederPartNo";
            this.Feeder.HeaderText = "Feeder Part No.";
            this.Feeder.Name = "Feeder";
            this.Feeder.Width = 149;
            // 
            // Lot
            // 
            this.Lot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Lot.DataPropertyName = "LotNo";
            this.Lot.HeaderText = "Lot No.";
            this.Lot.Name = "Lot";
            this.Lot.Width = 149;
            // 
            // TMUser
            // 
            this.TMUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TMUser.DataPropertyName = "TMName";
            this.TMUser.HeaderText = "TM User Name";
            this.TMUser.Name = "TMUser";
            this.TMUser.Width = 170;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 180;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Width = 180;
            // 
            // SpoolerType
            // 
            this.SpoolerType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SpoolerType.DataPropertyName = "SpoolType";
            this.SpoolerType.HeaderText = "Spooler Type";
            this.SpoolerType.Name = "SpoolerType";
            this.SpoolerType.Width = 180;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1146, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 214;
            this.label5.Text = "Minimize";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 262;
            this.pictureBox1.TabStop = false;
            // 
            // frmSpoolingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1204, 560);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSpoolingReport";
            this.Text = "Spooling Report";
            this.Load += new System.EventHandler(this.frmReprinting_Load);
            this.gbPrintingParameter.ResumeLayout(false);
            this.gbPrintingParameter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.GroupBox gbPrintingParameter;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cbLotNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFeeder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPartNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTMUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSpoolType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldPartBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewPartBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feeder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpoolerType;
    }
}