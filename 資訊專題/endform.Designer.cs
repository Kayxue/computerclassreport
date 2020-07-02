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
            this.winorlose = new System.Windows.Forms.Label();
            this.restart = new System.Windows.Forms.PictureBox();
            this.backtomenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.restart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backtomenu)).BeginInit();
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
            this.debugtext.Visible = false;
            this.debugtext.TextChanged += new System.EventHandler(this.debugtext_TextChanged);
            // 
            // winorlose
            // 
            this.winorlose.AutoSize = true;
            this.winorlose.Location = new System.Drawing.Point(793, 156);
            this.winorlose.Name = "winorlose";
            this.winorlose.Size = new System.Drawing.Size(56, 16);
            this.winorlose.TabIndex = 4;
            this.winorlose.Text = "label1";
            this.winorlose.Visible = false;
            // 
            // restart
            // 
            this.restart.BackColor = System.Drawing.Color.Transparent;
            this.restart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.restart.Image = global::資訊專題.Properties.Resources._10;
            this.restart.Location = new System.Drawing.Point(92, 491);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(281, 55);
            this.restart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.restart.TabIndex = 5;
            this.restart.TabStop = false;
            this.restart.Click += new System.EventHandler(this.again_Click);
            // 
            // backtomenu
            // 
            this.backtomenu.BackColor = System.Drawing.Color.Transparent;
            this.backtomenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backtomenu.Image = global::資訊專題.Properties.Resources._13;
            this.backtomenu.Location = new System.Drawing.Point(664, 491);
            this.backtomenu.Name = "backtomenu";
            this.backtomenu.Size = new System.Drawing.Size(281, 55);
            this.backtomenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backtomenu.TabIndex = 6;
            this.backtomenu.TabStop = false;
            this.backtomenu.Click += new System.EventHandler(this.backtomenu_Click);
            // 
            // endform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::資訊專題.Properties.Resources.開始畫面;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.backtomenu);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.winorlose);
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
            ((System.ComponentModel.ISupportInitialize)(this.restart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backtomenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label debugtext;
        private System.Windows.Forms.Label winorlose;
        private System.Windows.Forms.PictureBox restart;
        private System.Windows.Forms.PictureBox backtomenu;
    }
}