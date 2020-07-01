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
            this.components = new System.ComponentModel.Container();
            this.boss = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.debugtext = new System.Windows.Forms.Label();
            this.bossmove = new System.Windows.Forms.Label();
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.boss)).BeginInit();
            this.SuspendLayout();
            // 
            // boss
            // 
            this.boss.BackColor = System.Drawing.Color.Transparent;
            this.boss.Location = new System.Drawing.Point(681, 115);
            this.boss.Name = "boss";
            this.boss.Size = new System.Drawing.Size(364, 362);
            this.boss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boss.TabIndex = 9;
            this.boss.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer5
            // 
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // debugtext
            // 
            this.debugtext.AutoSize = true;
            this.debugtext.BackColor = System.Drawing.Color.Transparent;
            this.debugtext.Location = new System.Drawing.Point(71, 61);
            this.debugtext.Name = "debugtext";
            this.debugtext.Size = new System.Drawing.Size(33, 12);
            this.debugtext.TabIndex = 10;
            this.debugtext.Text = "label1";
            this.debugtext.TextChanged += new System.EventHandler(this.debugtext_TextChanged);
            // 
            // bossmove
            // 
            this.bossmove.AutoSize = true;
            this.bossmove.BackColor = System.Drawing.Color.Transparent;
            this.bossmove.Location = new System.Drawing.Point(71, 85);
            this.bossmove.Name = "bossmove";
            this.bossmove.Size = new System.Drawing.Size(51, 12);
            this.bossmove.TabIndex = 11;
            this.bossmove.Text = "bossmove";
            // 
            // timer7
            // 
            this.timer7.Interval = 2000;
            this.timer7.Tick += new System.EventHandler(this.timer7_Tick);
            // 
            // gameformboss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.bossmove);
            this.Controls.Add(this.debugtext);
            this.Controls.Add(this.boss);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "gameformboss";
            this.Text = "gameformbackground";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.gameformbackground_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boss;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Label debugtext;
        private System.Windows.Forms.Label bossmove;
        private System.Windows.Forms.Timer timer7;
    }
}