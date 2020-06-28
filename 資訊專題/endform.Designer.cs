namespace 資訊專題
{
    partial class endform
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
            this.debugtext = new System.Windows.Forms.Label();
            this.again = new System.Windows.Forms.Button();
            this.backtomenu = new System.Windows.Forms.Button();
            this.winorlose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // debugtext
            // 
            this.debugtext.AutoSize = true;
            this.debugtext.Location = new System.Drawing.Point(13, 9);
            this.debugtext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.debugtext.Name = "debugtext";
            this.debugtext.Size = new System.Drawing.Size(80, 16);
            this.debugtext.TabIndex = 0;
            this.debugtext.Text = "debugtext";
            this.debugtext.TextChanged += new System.EventHandler(this.debugtext_TextChanged);
            // 
            // again
            // 
            this.again.Location = new System.Drawing.Point(389, 351);
            this.again.Margin = new System.Windows.Forms.Padding(4);
            this.again.Name = "again";
            this.again.Size = new System.Drawing.Size(100, 31);
            this.again.TabIndex = 2;
            this.again.Text = "再一次";
            this.again.UseVisualStyleBackColor = true;
            this.again.Click += new System.EventHandler(this.again_Click);
            // 
            // backtomenu
            // 
            this.backtomenu.Location = new System.Drawing.Point(537, 351);
            this.backtomenu.Margin = new System.Windows.Forms.Padding(4);
            this.backtomenu.Name = "backtomenu";
            this.backtomenu.Size = new System.Drawing.Size(100, 31);
            this.backtomenu.TabIndex = 3;
            this.backtomenu.Text = "回到主畫面";
            this.backtomenu.UseVisualStyleBackColor = true;
            this.backtomenu.Click += new System.EventHandler(this.backtomenu_Click);
            // 
            // winorlose
            // 
            this.winorlose.AutoSize = true;
            this.winorlose.Location = new System.Drawing.Point(477, 256);
            this.winorlose.Name = "winorlose";
            this.winorlose.Size = new System.Drawing.Size(56, 16);
            this.winorlose.TabIndex = 4;
            this.winorlose.Text = "label1";
            // 
            // endform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.winorlose);
            this.Controls.Add(this.backtomenu);
            this.Controls.Add(this.again);
            this.Controls.Add(this.debugtext);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "endform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "遊戲結束";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.endform_FormClosed);
            this.Load += new System.EventHandler(this.endform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label debugtext;
        private System.Windows.Forms.Button again;
        private System.Windows.Forms.Button backtomenu;
        private System.Windows.Forms.Label winorlose;
    }
}