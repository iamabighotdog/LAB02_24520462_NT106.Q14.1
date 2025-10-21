namespace LAB02_24520462_NT106.Q14._1
{
    partial class LAB02_BAI04
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMssv = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtD1 = new System.Windows.Forms.TextBox();
            this.txtD2 = new System.Windows.Forms.TextBox();
            this.txtD3 = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhiInput = new System.Windows.Forms.Button();
            this.btnDocTinh = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbTrang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Location = new System.Drawing.Point(20, 200);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(760, 300);
            this.dgv.TabIndex = 0;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(90, 18);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(220, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtMssv
            // 
            this.txtMssv.Location = new System.Drawing.Point(385, 18);
            this.txtMssv.Name = "txtMssv";
            this.txtMssv.Size = new System.Drawing.Size(120, 22);
            this.txtMssv.TabIndex = 2;
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(566, 18);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(214, 22);
            this.txtSdt.TabIndex = 3;
            // 
            // txtD1
            // 
            this.txtD1.Location = new System.Drawing.Point(90, 58);
            this.txtD1.Name = "txtD1";
            this.txtD1.Size = new System.Drawing.Size(70, 22);
            this.txtD1.TabIndex = 4;
            // 
            // txtD2
            // 
            this.txtD2.Location = new System.Drawing.Point(240, 58);
            this.txtD2.Name = "txtD2";
            this.txtD2.Size = new System.Drawing.Size(70, 22);
            this.txtD2.TabIndex = 5;
            // 
            // txtD3
            // 
            this.txtD3.Location = new System.Drawing.Point(390, 58);
            this.txtD3.Name = "txtD3";
            this.txtD3.Size = new System.Drawing.Size(70, 22);
            this.txtD3.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(480, 55);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 28);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(570, 55);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 28);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa dòng";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhiInput
            // 
            this.btnGhiInput.Location = new System.Drawing.Point(20, 110);
            this.btnGhiInput.Name = "btnGhiInput";
            this.btnGhiInput.Size = new System.Drawing.Size(180, 36);
            this.btnGhiInput.TabIndex = 9;
            this.btnGhiInput.Text = "Ghi input4.txt";
            this.btnGhiInput.Click += new System.EventHandler(this.btnGhiInput_Click);
            // 
            // btnDocTinh
            // 
            this.btnDocTinh.Location = new System.Drawing.Point(220, 110);
            this.btnDocTinh.Name = "btnDocTinh";
            this.btnDocTinh.Size = new System.Drawing.Size(340, 36);
            this.btnDocTinh.TabIndex = 10;
            this.btnDocTinh.Text = "Đọc input4.txt + tính → output4.txt";
            this.btnDocTinh.Click += new System.EventHandler(this.btnDocTinh_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(566, 110);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(107, 36);
            this.btnPrev.TabIndex = 11;
            this.btnPrev.Text = "◀ Trang trước";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(679, 110);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 36);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Trang sau ▶";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbTrang
            // 
            this.lbTrang.AutoSize = true;
            this.lbTrang.Location = new System.Drawing.Point(20, 170);
            this.lbTrang.Name = "lbTrang";
            this.lbTrang.Size = new System.Drawing.Size(64, 16);
            this.lbTrang.TabIndex = 13;
            this.lbTrang.Text = "Trang 0/0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "MSSV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "SĐT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Điểm 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Điểm 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Điểm 3";
            // 
            // LAB02_BAI04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 520);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMssv);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.txtD1);
            this.Controls.Add(this.txtD2);
            this.Controls.Add(this.txtD3);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnGhiInput);
            this.Controls.Add(this.btnDocTinh);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lbTrang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Name = "LAB02_BAI04";
            this.Text = "LAB02_BAI04";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMssv;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtD1;
        private System.Windows.Forms.TextBox txtD2;
        private System.Windows.Forms.TextBox txtD3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhiInput;
        private System.Windows.Forms.Button btnDocTinh;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbTrang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}