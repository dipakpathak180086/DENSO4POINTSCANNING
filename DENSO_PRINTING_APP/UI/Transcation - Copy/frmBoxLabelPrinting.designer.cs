namespace ASTI_PRINTING_APP
{
    partial class frmBoxLabelPrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoxLabelPrinting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gbPrintingParameter = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBinCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ScannedBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrinterBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gbPrintingParameter.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.btnMinimize.Location = new System.Drawing.Point(933, -65);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 32);
            this.btnMinimize.TabIndex = 207;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
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
            this.btnMini.Location = new System.Drawing.Point(939, 5);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(33, 24);
            this.btnMini.TabIndex = 0;
            this.btnMini.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(985, 43);
            this.lblHeader.TabIndex = 208;
            this.lblHeader.Text = "BOX LABEL PRINTING";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel1.Location = new System.Drawing.Point(6, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 459);
            this.panel1.TabIndex = 209;
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
            this.ScannedBarcode,
            this.BoxBarcode,
            this.PrinterBy});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.AliceBlue;
            this.dgv.Location = new System.Drawing.Point(5, 160);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(959, 288);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 194;
            this.dgv.TabStop = false;
            // 
            // gbPrintingParameter
            // 
            this.gbPrintingParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrintingParameter.Controls.Add(this.lblMessage);
            this.gbPrintingParameter.Controls.Add(this.panel2);
            this.gbPrintingParameter.Controls.Add(this.label1);
            this.gbPrintingParameter.Controls.Add(this.txtBarcode);
            this.gbPrintingParameter.Controls.Add(this.label4);
            this.gbPrintingParameter.Controls.Add(this.lblBinCount);
            this.gbPrintingParameter.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbPrintingParameter.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbPrintingParameter.Location = new System.Drawing.Point(3, 3);
            this.gbPrintingParameter.Name = "gbPrintingParameter";
            this.gbPrintingParameter.Size = new System.Drawing.Size(961, 151);
            this.gbPrintingParameter.TabIndex = 193;
            this.gbPrintingParameter.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Yellow;
            this.lblMessage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(6, 119);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 19);
            this.lblMessage.TabIndex = 202;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(768, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 63);
            this.panel2.TabIndex = 195;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnReset.Location = new System.Drawing.Point(11, 6);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(66, 51);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnClose.Image = global::ASTI_PRINTING_APP.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(87, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 51);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(104, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 201;
            this.label1.Text = "Bin Count :";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtBarcode.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtBarcode.Location = new System.Drawing.Point(217, 15);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(709, 27);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 19);
            this.label4.TabIndex = 187;
            this.label4.Text = "Internal Bin Lable QR Code *:";
            // 
            // lblBinCount
            // 
            this.lblBinCount.BackColor = System.Drawing.Color.Black;
            this.lblBinCount.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinCount.ForeColor = System.Drawing.Color.Gold;
            this.lblBinCount.Location = new System.Drawing.Point(217, 56);
            this.lblBinCount.Name = "lblBinCount";
            this.lblBinCount.Size = new System.Drawing.Size(172, 42);
            this.lblBinCount.TabIndex = 200;
            this.lblBinCount.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(927, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Minimize";
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
            // ScannedBarcode
            // 
            this.ScannedBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ScannedBarcode.DataPropertyName = "BinBarcode";
            this.ScannedBarcode.HeaderText = "Scanned Barcode";
            this.ScannedBarcode.Name = "ScannedBarcode";
            this.ScannedBarcode.ReadOnly = true;
            this.ScannedBarcode.Width = 600;
            // 
            // BoxBarcode
            // 
            this.BoxBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BoxBarcode.DataPropertyName = "BoxBarcode";
            this.BoxBarcode.HeaderText = "Printed Barcode";
            this.BoxBarcode.Name = "BoxBarcode";
            this.BoxBarcode.ReadOnly = true;
            this.BoxBarcode.Width = 600;
            // 
            // PrinterBy
            // 
            this.PrinterBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PrinterBy.DataPropertyName = "PrintedBy";
            this.PrinterBy.HeaderText = "User";
            this.PrinterBy.Name = "PrinterBy";
            this.PrinterBy.ReadOnly = true;
            // 
            // frmBoxLabelPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(985, 508);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBoxLabelPrinting";
            this.Text = "Label Printing";
            this.Load += new System.EventHandler(this.frmModelMaster_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gbPrintingParameter.ResumeLayout(false);
            this.gbPrintingParameter.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblBinCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScannedBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrinterBy;
    }
}