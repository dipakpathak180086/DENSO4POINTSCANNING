namespace DENSO_PRINTING_APP
{
    partial class frmLaserScaning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaserScaning));
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPrintingParameter = new System.Windows.Forms.GroupBox();
            this.lblReflectLabel = new System.Windows.Forms.Label();
            this.lblPartCarryLocation = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDesiccatorLoaction = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPCBPartNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkSecondStaus = new System.Windows.Forms.CheckBox();
            this.chkFirstStaus = new System.Windows.Forms.CheckBox();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKanbanModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPacketQR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChangeOverSheet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gbPrintingParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.btnMinimize.Location = new System.Drawing.Point(1174, -65);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 32);
            this.btnMinimize.TabIndex = 207;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1226, 43);
            this.lblHeader.TabIndex = 208;
            this.lblHeader.Text = "LASER LOADING SCANNING";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.gbPrintingParameter);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.panel1.Location = new System.Drawing.Point(6, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1214, 739);
            this.panel1.TabIndex = 209;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 525);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1212, 139);
            this.panel3.TabIndex = 196;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column8,
            this.Column10,
            this.Column11});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.AliceBlue;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 42;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.RowTemplate.Height = 45;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1212, 139);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 194;
            this.dgv.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "Line";
            this.Column1.HeaderText = "LINE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 101;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "ChangeOverSheet";
            this.Column2.HeaderText = "CHANGE OVER SHEET";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.DataPropertyName = "Kanban";
            this.Column4.HeaderText = "KANBAN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "PacketQrCode";
            this.Column3.HeaderText = "PACKET QR";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.DataPropertyName = "PCBPartNo";
            this.Column5.HeaderText = "PCB PART NO";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 180;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column8.DataPropertyName = "TMName";
            this.Column8.HeaderText = "TM NAME";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 130;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column10.DataPropertyName = "Date";
            this.Column10.HeaderText = "DATE";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 130;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.DataPropertyName = "Time";
            this.Column11.HeaderText = "TIME";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // gbPrintingParameter
            // 
            this.gbPrintingParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrintingParameter.Controls.Add(this.lblReflectLabel);
            this.gbPrintingParameter.Controls.Add(this.lblPartCarryLocation);
            this.gbPrintingParameter.Controls.Add(this.label7);
            this.gbPrintingParameter.Controls.Add(this.lblDesiccatorLoaction);
            this.gbPrintingParameter.Controls.Add(this.label5);
            this.gbPrintingParameter.Controls.Add(this.txtPCBPartNo);
            this.gbPrintingParameter.Controls.Add(this.label10);
            this.gbPrintingParameter.Controls.Add(this.chkSecondStaus);
            this.gbPrintingParameter.Controls.Add(this.chkFirstStaus);
            this.gbPrintingParameter.Controls.Add(this.txtTMName);
            this.gbPrintingParameter.Controls.Add(this.label3);
            this.gbPrintingParameter.Controls.Add(this.txtKanbanModel);
            this.gbPrintingParameter.Controls.Add(this.label2);
            this.gbPrintingParameter.Controls.Add(this.txtPacketQR);
            this.gbPrintingParameter.Controls.Add(this.label1);
            this.gbPrintingParameter.Controls.Add(this.txtChangeOverSheet);
            this.gbPrintingParameter.Controls.Add(this.label4);
            this.gbPrintingParameter.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbPrintingParameter.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbPrintingParameter.Location = new System.Drawing.Point(3, 3);
            this.gbPrintingParameter.Name = "gbPrintingParameter";
            this.gbPrintingParameter.Size = new System.Drawing.Size(1202, 519);
            this.gbPrintingParameter.TabIndex = 0;
            this.gbPrintingParameter.TabStop = false;
            // 
            // lblReflectLabel
            // 
            this.lblReflectLabel.BackColor = System.Drawing.Color.Yellow;
            this.lblReflectLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReflectLabel.ForeColor = System.Drawing.Color.Yellow;
            this.lblReflectLabel.Location = new System.Drawing.Point(584, 161);
            this.lblReflectLabel.Name = "lblReflectLabel";
            this.lblReflectLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReflectLabel.Size = new System.Drawing.Size(10, 28);
            this.lblReflectLabel.TabIndex = 228;
            this.lblReflectLabel.Text = "Full Tray *:";
            // 
            // lblPartCarryLocation
            // 
            this.lblPartCarryLocation.AutoSize = true;
            this.lblPartCarryLocation.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblPartCarryLocation.Font = new System.Drawing.Font("Calibri", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPartCarryLocation.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblPartCarryLocation.Location = new System.Drawing.Point(936, 124);
            this.lblPartCarryLocation.Name = "lblPartCarryLocation";
            this.lblPartCarryLocation.Size = new System.Drawing.Size(223, 36);
            this.lblPartCarryLocation.TabIndex = 227;
            this.lblPartCarryLocation.Text = "XXXXXXXXXXXXX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Font = new System.Drawing.Font("Calibri", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Location = new System.Drawing.Point(628, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 36);
            this.label7.TabIndex = 226;
            this.label7.Text = "PART CARRY LOCATION:";
            // 
            // lblDesiccatorLoaction
            // 
            this.lblDesiccatorLoaction.AutoSize = true;
            this.lblDesiccatorLoaction.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblDesiccatorLoaction.Font = new System.Drawing.Font("Calibri", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblDesiccatorLoaction.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblDesiccatorLoaction.Location = new System.Drawing.Point(936, 65);
            this.lblDesiccatorLoaction.Name = "lblDesiccatorLoaction";
            this.lblDesiccatorLoaction.Size = new System.Drawing.Size(223, 36);
            this.lblDesiccatorLoaction.TabIndex = 225;
            this.lblDesiccatorLoaction.Text = "XXXXXXXXXXXXX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Font = new System.Drawing.Font("Calibri", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.AliceBlue;
            this.label5.Location = new System.Drawing.Point(628, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 36);
            this.label5.TabIndex = 224;
            this.label5.Text = "DESICCATOR LOCATION:";
            // 
            // txtPCBPartNo
            // 
            this.txtPCBPartNo.BackColor = System.Drawing.Color.Yellow;
            this.txtPCBPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCBPartNo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCBPartNo.ForeColor = System.Drawing.Color.Yellow;
            this.txtPCBPartNo.Location = new System.Drawing.Point(201, 159);
            this.txtPCBPartNo.Name = "txtPCBPartNo";
            this.txtPCBPartNo.Size = new System.Drawing.Size(394, 33);
            this.txtPCBPartNo.TabIndex = 3;
            this.txtPCBPartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPCBPartNo_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(58, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 26);
            this.label10.TabIndex = 223;
            this.label10.Text = "PCB Part No. *:";
            // 
            // chkSecondStaus
            // 
            this.chkSecondStaus.BackColor = System.Drawing.Color.Yellow;
            this.chkSecondStaus.Enabled = false;
            this.chkSecondStaus.Font = new System.Drawing.Font("Calibri", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSecondStaus.Location = new System.Drawing.Point(20, 361);
            this.chkSecondStaus.Name = "chkSecondStaus";
            this.chkSecondStaus.Size = new System.Drawing.Size(1159, 121);
            this.chkSecondStaus.TabIndex = 217;
            this.chkSecondStaus.Text = "STATUS-2";
            this.chkSecondStaus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSecondStaus.UseVisualStyleBackColor = false;
            this.chkSecondStaus.CheckedChanged += new System.EventHandler(this.chkSecondTrayStaus_CheckedChanged);
            // 
            // chkFirstStaus
            // 
            this.chkFirstStaus.BackColor = System.Drawing.Color.Yellow;
            this.chkFirstStaus.Enabled = false;
            this.chkFirstStaus.Font = new System.Drawing.Font("Calibri", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFirstStaus.Location = new System.Drawing.Point(20, 214);
            this.chkFirstStaus.Name = "chkFirstStaus";
            this.chkFirstStaus.Size = new System.Drawing.Size(1159, 121);
            this.chkFirstStaus.TabIndex = 216;
            this.chkFirstStaus.Text = "STATUS-1";
            this.chkFirstStaus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFirstStaus.UseVisualStyleBackColor = false;
            this.chkFirstStaus.CheckedChanged += new System.EventHandler(this.chkFirstTrayStaus_CheckedChanged);
            // 
            // txtTMName
            // 
            this.txtTMName.BackColor = System.Drawing.Color.White;
            this.txtTMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTMName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTMName.Location = new System.Drawing.Point(738, 19);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.Size = new System.Drawing.Size(421, 33);
            this.txtTMName.TabIndex = 4;
            this.txtTMName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTMName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(614, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 26);
            this.label3.TabIndex = 208;
            this.label3.Text = "TM Name *:";
            // 
            // txtKanbanModel
            // 
            this.txtKanbanModel.BackColor = System.Drawing.Color.White;
            this.txtKanbanModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKanbanModel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKanbanModel.Location = new System.Drawing.Point(201, 65);
            this.txtKanbanModel.Name = "txtKanbanModel";
            this.txtKanbanModel.Size = new System.Drawing.Size(394, 33);
            this.txtKanbanModel.TabIndex = 1;
            this.txtKanbanModel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKanbanModel_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 206;
            this.label2.Text = "Kanban *:";
            // 
            // txtPacketQR
            // 
            this.txtPacketQR.BackColor = System.Drawing.Color.White;
            this.txtPacketQR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPacketQR.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacketQR.Location = new System.Drawing.Point(201, 111);
            this.txtPacketQR.Name = "txtPacketQR";
            this.txtPacketQR.Size = new System.Drawing.Size(394, 33);
            this.txtPacketQR.TabIndex = 2;
            this.txtPacketQR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPacketQR_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 204;
            this.label1.Text = "Packet QR  *:";
            // 
            // txtChangeOverSheet
            // 
            this.txtChangeOverSheet.BackColor = System.Drawing.Color.White;
            this.txtChangeOverSheet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChangeOverSheet.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangeOverSheet.Location = new System.Drawing.Point(201, 19);
            this.txtChangeOverSheet.Name = "txtChangeOverSheet";
            this.txtChangeOverSheet.Size = new System.Drawing.Size(394, 33);
            this.txtChangeOverSheet.TabIndex = 0;
            this.txtChangeOverSheet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChangeOverSheet_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 26);
            this.label4.TabIndex = 187;
            this.label4.Text = "Change Over Sheet *:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Font = new System.Drawing.Font("Calibri", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 664);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1212, 73);
            this.lblMessage.TabIndex = 195;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1168, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Minimize";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(977, 3);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 43);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "&Next Loading";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 212;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DENSO_PRINTING_APP.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(1105, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 46);
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
            this.btnMini.Location = new System.Drawing.Point(1180, 5);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(33, 24);
            this.btnMini.TabIndex = 0;
            this.btnMini.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // frmLaserScaning
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1226, 788);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLaserScaning";
            this.Text = "Laser Scanning";
            this.Load += new System.EventHandler(this.frmModelMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gbPrintingParameter.ResumeLayout(false);
            this.gbPrintingParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMini;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbPrintingParameter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtChangeOverSheet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKanbanModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPacketQR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFirstStaus;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkSecondStaus;
        private System.Windows.Forms.TextBox txtPCBPartNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDesiccatorLoaction;
        private System.Windows.Forms.Label lblPartCarryLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblReflectLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}