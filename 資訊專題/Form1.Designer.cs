namespace 資訊專題
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.debugtext = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 557);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(281, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "開始遊戲";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(768, 557);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(281, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "規則與控制說明";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // debugtext
            // 
            this.debugtext.AutoSize = true;
            this.debugtext.Location = new System.Drawing.Point(17, 18);
            this.debugtext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.debugtext.Name = "debugtext";
            this.debugtext.Size = new System.Drawing.Size(80, 16);
            this.debugtext.TabIndex = 3;
            this.debugtext.Text = "debugtext";
            this.debugtext.TextChanged += new System.EventHandler(this.debugtext_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 557);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "離開遊戲";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.leavegame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.debugtext);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "勇者鬥惡龍";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label debugtext;
        private System.Windows.Forms.Button button1;
    }
}

