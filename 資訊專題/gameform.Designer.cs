namespace 資訊專題
{
    partial class gameform
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
            this.debugtext = new System.Windows.Forms.Label();
            this.myheart = new System.Windows.Forms.ProgressBar();
            this.bossheart = new System.Windows.Forms.ProgressBar();
            this.bosshearttext = new System.Windows.Forms.Label();
            this.myhearttext = new System.Windows.Forms.Label();
            this.me = new System.Windows.Forms.PictureBox();
            this.boss = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bossmove = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.me)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boss)).BeginInit();
            this.SuspendLayout();
            // 
            // debugtext
            // 
            this.debugtext.AutoSize = true;
            this.debugtext.Location = new System.Drawing.Point(61, 44);
            this.debugtext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.debugtext.Name = "debugtext";
            this.debugtext.Size = new System.Drawing.Size(80, 16);
            this.debugtext.TabIndex = 2;
            this.debugtext.Text = "debugtext";
            this.debugtext.Visible = false;
            this.debugtext.TextChanged += new System.EventHandler(this.debugtext_TextChanged);
            // 
            // myheart
            // 
            this.myheart.Location = new System.Drawing.Point(0, 570);
            this.myheart.Margin = new System.Windows.Forms.Padding(4);
            this.myheart.Name = "myheart";
            this.myheart.Size = new System.Drawing.Size(933, 31);
            this.myheart.TabIndex = 3;
            this.myheart.Value = 100;
            // 
            // bossheart
            // 
            this.bossheart.Location = new System.Drawing.Point(0, -1);
            this.bossheart.Margin = new System.Windows.Forms.Padding(4);
            this.bossheart.Name = "bossheart";
            this.bossheart.Size = new System.Drawing.Size(933, 31);
            this.bossheart.TabIndex = 4;
            this.bossheart.Value = 100;
            // 
            // bosshearttext
            // 
            this.bosshearttext.AutoSize = true;
            this.bosshearttext.BackColor = System.Drawing.Color.Transparent;
            this.bosshearttext.Location = new System.Drawing.Point(1006, 44);
            this.bosshearttext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bosshearttext.Name = "bosshearttext";
            this.bosshearttext.Size = new System.Drawing.Size(56, 16);
            this.bosshearttext.TabIndex = 5;
            this.bosshearttext.Text = "label1";
            // 
            // myhearttext
            // 
            this.myhearttext.AutoSize = true;
            this.myhearttext.BackColor = System.Drawing.Color.Transparent;
            this.myhearttext.Location = new System.Drawing.Point(1006, 539);
            this.myhearttext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myhearttext.Name = "myhearttext";
            this.myhearttext.Size = new System.Drawing.Size(56, 16);
            this.myhearttext.TabIndex = 6;
            this.myhearttext.Text = "label2";
            // 
            // me
            // 
            this.me.BackColor = System.Drawing.Color.White;
            this.me.Location = new System.Drawing.Point(64, 266);
            this.me.Name = "me";
            this.me.Size = new System.Drawing.Size(119, 211);
            this.me.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.me.TabIndex = 9;
            this.me.TabStop = false;
            // 
            // boss
            // 
            this.boss.BackColor = System.Drawing.Color.Transparent;
            this.boss.Location = new System.Drawing.Point(753, 178);
            this.boss.Name = "boss";
            this.boss.Size = new System.Drawing.Size(292, 299);
            this.boss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boss.TabIndex = 8;
            this.boss.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bossmove
            // 
            this.bossmove.AutoSize = true;
            this.bossmove.BackColor = System.Drawing.Color.Transparent;
            this.bossmove.Location = new System.Drawing.Point(61, 86);
            this.bossmove.Name = "bossmove";
            this.bossmove.Size = new System.Drawing.Size(72, 16);
            this.bossmove.TabIndex = 10;
            this.bossmove.Text = "bossmove";
            // 
            // timer4
            // 
            this.timer4.Interval = 30;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // gameform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.bossmove);
            this.Controls.Add(this.me);
            this.Controls.Add(this.boss);
            this.Controls.Add(this.myhearttext);
            this.Controls.Add(this.bosshearttext);
            this.Controls.Add(this.bossheart);
            this.Controls.Add(this.myheart);
            this.Controls.Add(this.debugtext);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "gameform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "勇者鬥惡龍";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gameform_FormClosed);
            this.Load += new System.EventHandler(this.gameform_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameform_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameform_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.me)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label debugtext;
        private System.Windows.Forms.ProgressBar myheart;
        private System.Windows.Forms.ProgressBar bossheart;
        private System.Windows.Forms.Label bosshearttext;
        private System.Windows.Forms.Label myhearttext;
        private System.Windows.Forms.PictureBox boss;
        private System.Windows.Forms.PictureBox me;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label bossmove;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer3;
    }
}