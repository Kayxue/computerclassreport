namespace 資訊專題
{
    partial class gameformboss
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
            this.boss = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.boss)).BeginInit();
            this.SuspendLayout();
            // 
            // boss
            // 
            this.boss.BackColor = System.Drawing.Color.Transparent;
            this.boss.Location = new System.Drawing.Point(254, 76);
            this.boss.Name = "boss";
            this.boss.Size = new System.Drawing.Size(292, 299);
            this.boss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boss.TabIndex = 9;
            this.boss.TabStop = false;
            // 
            // gameformboss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.boss);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "gameformboss";
            this.Text = "gameformboss";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.gameformboss_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boss)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boss;
    }
}