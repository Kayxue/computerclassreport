namespace 資訊專題
{
    partial class pauseform
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
            this.label1 = new System.Windows.Forms.Label();
            this.backtomenu = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.continuegame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(60, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "遊戲暫停";
            // 
            // backtomenu
            // 
            this.backtomenu.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.backtomenu.Location = new System.Drawing.Point(47, 172);
            this.backtomenu.Name = "backtomenu";
            this.backtomenu.Size = new System.Drawing.Size(132, 37);
            this.backtomenu.TabIndex = 2;
            this.backtomenu.Text = "回主畫面";
            this.backtomenu.UseVisualStyleBackColor = true;
            this.backtomenu.Click += new System.EventHandler(this.backtomenu_Click);
            // 
            // restart
            // 
            this.restart.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.restart.Location = new System.Drawing.Point(47, 129);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(132, 37);
            this.restart.TabIndex = 1;
            this.restart.Text = "重新開始";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // continuegame
            // 
            this.continuegame.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.continuegame.Location = new System.Drawing.Point(47, 86);
            this.continuegame.Name = "continuegame";
            this.continuegame.Size = new System.Drawing.Size(132, 37);
            this.continuegame.TabIndex = 0;
            this.continuegame.Text = "繼續遊戲";
            this.continuegame.UseVisualStyleBackColor = true;
            this.continuegame.Click += new System.EventHandler(this.continuegame_Click);
            // 
            // pauseform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 221);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backtomenu);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.continuegame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "pauseform";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "遊戲暫停中......";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pauseform_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backtomenu;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button continuegame;
    }
}