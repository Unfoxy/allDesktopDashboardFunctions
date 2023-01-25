namespace desktopDashboard___Y_Lee.Forms
{
    partial class pingPc
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
            this.pnPingPcMain = new System.Windows.Forms.Panel();
            this.lbPingPcMain = new System.Windows.Forms.Label();
            this.btnPingPcOK = new System.Windows.Forms.Button();
            this.txtPingPc = new System.Windows.Forms.TextBox();
            this.pnPingPcTop = new System.Windows.Forms.Panel();
            this.lbPingPcTop = new System.Windows.Forms.Label();
            this.rtxtPingPc = new System.Windows.Forms.RichTextBox();
            this.pnPingPcMain.SuspendLayout();
            this.pnPingPcTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPingPcMain
            // 
            this.pnPingPcMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnPingPcMain.Controls.Add(this.lbPingPcMain);
            this.pnPingPcMain.Controls.Add(this.btnPingPcOK);
            this.pnPingPcMain.Controls.Add(this.txtPingPc);
            this.pnPingPcMain.Controls.Add(this.pnPingPcTop);
            this.pnPingPcMain.Controls.Add(this.rtxtPingPc);
            this.pnPingPcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPingPcMain.Location = new System.Drawing.Point(0, 0);
            this.pnPingPcMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnPingPcMain.Name = "pnPingPcMain";
            this.pnPingPcMain.Size = new System.Drawing.Size(901, 680);
            this.pnPingPcMain.TabIndex = 3;
            // 
            // lbPingPcMain
            // 
            this.lbPingPcMain.AutoSize = true;
            this.lbPingPcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPingPcMain.ForeColor = System.Drawing.SystemColors.Window;
            this.lbPingPcMain.Location = new System.Drawing.Point(29, 40);
            this.lbPingPcMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPingPcMain.Name = "lbPingPcMain";
            this.lbPingPcMain.Size = new System.Drawing.Size(75, 16);
            this.lbPingPcMain.TabIndex = 6;
            this.lbPingPcMain.Text = "Host name:";
            // 
            // btnPingPcOK
            // 
            this.btnPingPcOK.Location = new System.Drawing.Point(167, 60);
            this.btnPingPcOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnPingPcOK.Name = "btnPingPcOK";
            this.btnPingPcOK.Size = new System.Drawing.Size(56, 21);
            this.btnPingPcOK.TabIndex = 5;
            this.btnPingPcOK.Text = "OK";
            this.btnPingPcOK.UseVisualStyleBackColor = true;
            this.btnPingPcOK.Click += new System.EventHandler(this.btnPingPcOK_Click);
            // 
            // txtPingPc
            // 
            this.txtPingPc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.txtPingPc.ForeColor = System.Drawing.Color.White;
            this.txtPingPc.Location = new System.Drawing.Point(31, 60);
            this.txtPingPc.Margin = new System.Windows.Forms.Padding(2);
            this.txtPingPc.Name = "txtPingPc";
            this.txtPingPc.Size = new System.Drawing.Size(129, 20);
            this.txtPingPc.TabIndex = 4;
            // 
            // pnPingPcTop
            // 
            this.pnPingPcTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(100)))));
            this.pnPingPcTop.Controls.Add(this.lbPingPcTop);
            this.pnPingPcTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnPingPcTop.Location = new System.Drawing.Point(0, 0);
            this.pnPingPcTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnPingPcTop.Name = "pnPingPcTop";
            this.pnPingPcTop.Size = new System.Drawing.Size(901, 34);
            this.pnPingPcTop.TabIndex = 2;
            // 
            // lbPingPcTop
            // 
            this.lbPingPcTop.AutoSize = true;
            this.lbPingPcTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPingPcTop.ForeColor = System.Drawing.Color.White;
            this.lbPingPcTop.Location = new System.Drawing.Point(357, 9);
            this.lbPingPcTop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPingPcTop.Name = "lbPingPcTop";
            this.lbPingPcTop.Size = new System.Drawing.Size(72, 20);
            this.lbPingPcTop.TabIndex = 7;
            this.lbPingPcTop.Text = "Ping PC";
            // 
            // rtxtPingPc
            // 
            this.rtxtPingPc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.rtxtPingPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtPingPc.ForeColor = System.Drawing.Color.White;
            this.rtxtPingPc.Location = new System.Drawing.Point(22, 88);
            this.rtxtPingPc.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtPingPc.Name = "rtxtPingPc";
            this.rtxtPingPc.Size = new System.Drawing.Size(856, 524);
            this.rtxtPingPc.TabIndex = 1;
            this.rtxtPingPc.Text = "";
            // 
            // pingPc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 680);
            this.Controls.Add(this.pnPingPcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pingPc";
            this.Text = "pingPc";
            this.pnPingPcMain.ResumeLayout(false);
            this.pnPingPcMain.PerformLayout();
            this.pnPingPcTop.ResumeLayout(false);
            this.pnPingPcTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnPingPcMain;
        private System.Windows.Forms.Label lbPingPcMain;
        private System.Windows.Forms.Button btnPingPcOK;
        private System.Windows.Forms.TextBox txtPingPc;
        private System.Windows.Forms.Panel pnPingPcTop;
        private System.Windows.Forms.Label lbPingPcTop;
        private System.Windows.Forms.RichTextBox rtxtPingPc;
    }
}