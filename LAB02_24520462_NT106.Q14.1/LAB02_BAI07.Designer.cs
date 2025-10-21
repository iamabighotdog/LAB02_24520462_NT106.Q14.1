namespace LAB02_24520462_NT106.Q14._1
{
    partial class LAB02_BAI07
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
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnLen = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lv = new System.Windows.Forms.ListView();
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDungLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTaiOC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuongDan.Location = new System.Drawing.Point(12, 12);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(641, 22);
            this.txtDuongDan.TabIndex = 0;
            // 
            // btnChon
            // 
            this.btnChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChon.Location = new System.Drawing.Point(659, 10);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(107, 26);
            this.btnChon.TabIndex = 1;
            this.btnChon.Text = "Chọn thư mục";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnLen
            // 
            this.btnLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLen.Location = new System.Drawing.Point(772, 10);
            this.btnLen.Name = "btnLen";
            this.btnLen.Size = new System.Drawing.Size(76, 26);
            this.btnLen.TabIndex = 2;
            this.btnLen.Text = "Quay Lại";
            this.btnLen.UseVisualStyleBackColor = true;
            this.btnLen.Click += new System.EventHandler(this.btnLen_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 44);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtb);
            this.splitContainer1.Panel2.Controls.Add(this.pb);
            this.splitContainer1.Size = new System.Drawing.Size(934, 497);
            this.splitContainer1.SplitterDistance = 466;
            this.splitContainer1.TabIndex = 4;
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTen,
            this.colLoai,
            this.colDungLuong,
            this.colSua});
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(466, 497);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemActivate += new System.EventHandler(this.lv_ItemActivate);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // colTen
            // 
            this.colTen.Text = "Tên";
            this.colTen.Width = 200;
            // 
            // colLoai
            // 
            this.colLoai.Text = "Loại";
            this.colLoai.Width = 80;
            // 
            // colDungLuong
            // 
            this.colDungLuong.Text = "Dung lượng";
            this.colDungLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDungLuong.Width = 90;
            // 
            // colSua
            // 
            this.colSua.Text = "Sửa lần cuối";
            this.colSua.Width = 120;
            // 
            // rtb
            // 
            this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtb.Location = new System.Drawing.Point(0, 0);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(464, 497);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            this.rtb.WordWrap = false;
            // 
            // pb
            // 
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(464, 497);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            this.pb.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTrangThai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 26);
            this.statusStrip1.TabIndex = 5;
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(77, 20);
            this.lbTrangThai.Text = "Sẵn sàng...";
            // 
            // btnTaiOC
            // 
            this.btnTaiOC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaiOC.Location = new System.Drawing.Point(854, 10);
            this.btnTaiOC.Name = "btnTaiOC";
            this.btnTaiOC.Size = new System.Drawing.Size(92, 26);
            this.btnTaiOC.TabIndex = 3;
            this.btnTaiOC.Text = "Ổ đĩa";
            this.btnTaiOC.UseVisualStyleBackColor = true;
            this.btnTaiOC.Click += new System.EventHandler(this.btnTaiOC_Click);
            // 
            // LAB02_BAI07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 570);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnTaiOC);
            this.Controls.Add(this.btnLen);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.txtDuongDan);
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "LAB02_BAI07";
            this.Text = "LAB02_BAI07";
            this.Load += new System.EventHandler(this.LAB02_BAI07_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnLen;
        private System.Windows.Forms.Button btnTaiOC;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colLoai;
        private System.Windows.Forms.ColumnHeader colDungLuong;
        private System.Windows.Forms.ColumnHeader colSua;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbTrangThai;
        private System.Windows.Forms.PictureBox pb;
    }
}