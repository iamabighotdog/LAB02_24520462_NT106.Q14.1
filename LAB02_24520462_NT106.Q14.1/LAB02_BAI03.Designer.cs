namespace LAB02_24520462_NT106.Q14._1
{
    partial class LAB02_BAI03
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
            this.btnRead = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnRead.Location = new System.Drawing.Point(24, 20);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(180, 48);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Chọn input3.txt";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnProcess.Location = new System.Drawing.Point(484, 20);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(240, 48);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Tính và ghi output3.txt";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // rtbInput
            // 
            this.rtbInput.Location = new System.Drawing.Point(24, 104);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(436, 360);
            this.rtbInput.TabIndex = 2;
            this.rtbInput.Text = "";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(484, 104);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(436, 360);
            this.rtbOutput.TabIndex = 3;
            this.rtbOutput.Text = "";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(21, 84);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(92, 16);
            this.lblInput.TabIndex = 4;
            this.lblInput.Text = "Nội dung input";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(481, 84);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(110, 16);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "Kết quả (preview)";
            // 
            // LAB02_BAI03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 491);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.rtbInput);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnRead);
            this.Name = "LAB02_BAI03";
            this.Text = "LAB02_BAI03";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
    }
}
