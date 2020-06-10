namespace 資訊專題
{
    partial class infoform
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
            this.rulechange = new System.Windows.Forms.TabControl();
            this.rulepage = new System.Windows.Forms.TabPage();
            this.controlpage = new System.Windows.Forms.TabPage();
            this.back = new System.Windows.Forms.Button();
            this.ruletitle = new System.Windows.Forms.Label();
            this.controltitle = new System.Windows.Forms.Label();
            this.controlinfo = new System.Windows.Forms.Label();
            this.ruleinfo = new System.Windows.Forms.Label();
            this.rulechange.SuspendLayout();
            this.rulepage.SuspendLayout();
            this.controlpage.SuspendLayout();
            this.SuspendLayout();
            // 
            // rulechange
            // 
            this.rulechange.Controls.Add(this.rulepage);
            this.rulechange.Controls.Add(this.controlpage);
            this.rulechange.Location = new System.Drawing.Point(16, 16);
            this.rulechange.Margin = new System.Windows.Forms.Padding(4);
            this.rulechange.Name = "rulechange";
            this.rulechange.SelectedIndex = 0;
            this.rulechange.Size = new System.Drawing.Size(1035, 527);
            this.rulechange.TabIndex = 0;
            // 
            // rulepage
            // 
            this.rulepage.Controls.Add(this.ruleinfo);
            this.rulepage.Controls.Add(this.ruletitle);
            this.rulepage.Font = new System.Drawing.Font("華康兒風體W4", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rulepage.Location = new System.Drawing.Point(4, 26);
            this.rulepage.Margin = new System.Windows.Forms.Padding(4);
            this.rulepage.Name = "rulepage";
            this.rulepage.Padding = new System.Windows.Forms.Padding(4);
            this.rulepage.Size = new System.Drawing.Size(1027, 497);
            this.rulepage.TabIndex = 0;
            this.rulepage.Text = "劇情概要";
            this.rulepage.UseVisualStyleBackColor = true;
            // 
            // controlpage
            // 
            this.controlpage.Controls.Add(this.controlinfo);
            this.controlpage.Controls.Add(this.controltitle);
            this.controlpage.Font = new System.Drawing.Font("華康兒風體W4", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.controlpage.Location = new System.Drawing.Point(4, 26);
            this.controlpage.Margin = new System.Windows.Forms.Padding(4);
            this.controlpage.Name = "controlpage";
            this.controlpage.Padding = new System.Windows.Forms.Padding(4);
            this.controlpage.Size = new System.Drawing.Size(1027, 497);
            this.controlpage.TabIndex = 1;
            this.controlpage.Text = "控制說明";
            this.controlpage.UseVisualStyleBackColor = true;
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(16, 553);
            this.back.Margin = new System.Windows.Forms.Padding(4);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(1035, 31);
            this.back.TabIndex = 1;
            this.back.Text = "回首頁";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // ruletitle
            // 
            this.ruletitle.AutoSize = true;
            this.ruletitle.Font = new System.Drawing.Font("標楷體", 24F);
            this.ruletitle.Location = new System.Drawing.Point(25, 26);
            this.ruletitle.Name = "ruletitle";
            this.ruletitle.Size = new System.Drawing.Size(143, 32);
            this.ruletitle.TabIndex = 0;
            this.ruletitle.Text = "劇情概要";
            // 
            // controltitle
            // 
            this.controltitle.AutoSize = true;
            this.controltitle.Font = new System.Drawing.Font("標楷體", 24F);
            this.controltitle.Location = new System.Drawing.Point(25, 26);
            this.controltitle.Name = "controltitle";
            this.controltitle.Size = new System.Drawing.Size(143, 32);
            this.controltitle.TabIndex = 1;
            this.controltitle.Text = "控制說明";
            // 
            // controlinfo
            // 
            this.controlinfo.AutoSize = true;
            this.controlinfo.Font = new System.Drawing.Font("標楷體", 20F);
            this.controlinfo.Location = new System.Drawing.Point(25, 68);
            this.controlinfo.Name = "controlinfo";
            this.controlinfo.Size = new System.Drawing.Size(124, 27);
            this.controlinfo.TabIndex = 2;
            this.controlinfo.Text = "控制說明";
            // 
            // ruleinfo
            // 
            this.ruleinfo.AutoSize = true;
            this.ruleinfo.Font = new System.Drawing.Font("標楷體", 20F);
            this.ruleinfo.Location = new System.Drawing.Point(25, 68);
            this.ruleinfo.Name = "ruleinfo";
            this.ruleinfo.Size = new System.Drawing.Size(124, 27);
            this.ruleinfo.TabIndex = 1;
            this.ruleinfo.Text = "劇情概要";
            // 
            // infoform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.back);
            this.Controls.Add(this.rulechange);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "infoform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "規則與控制";
            this.rulechange.ResumeLayout(false);
            this.rulepage.ResumeLayout(false);
            this.rulepage.PerformLayout();
            this.controlpage.ResumeLayout(false);
            this.controlpage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl rulechange;
        private System.Windows.Forms.TabPage rulepage;
        private System.Windows.Forms.TabPage controlpage;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label ruletitle;
        private System.Windows.Forms.Label ruleinfo;
        private System.Windows.Forms.Label controlinfo;
        private System.Windows.Forms.Label controltitle;
    }
}