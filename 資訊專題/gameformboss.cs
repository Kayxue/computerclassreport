using System;
using System.Drawing;
using System.Windows.Forms;

namespace 資訊專題
{
    public partial class gameformboss : Form
    {
        /*變數*/
        private Point x;
        private Size gameformsize;
        private Image[,] bossimages;
        private int bossmoveint, nowbossimage, bossimagecount = 6;
        private bool iffreeze;
        private string bossattackmovement = "attack";

        /*初始化*/

        public gameformboss()
        {
            InitializeComponent();
            bossimages = new Image[,] {
                { Image.FromFile("左一.png"), Image.FromFile("左二.png"), Image.FromFile("左三.png"),Image.FromFile("左二.png"), Image.FromFile("左五.png"), Image.FromFile("左六.png") },
                { Image.FromFile("有一.png"), Image.FromFile("有二.png"), Image.FromFile("又三.png"),Image.FromFile("有二.png"), Image.FromFile("又五.png"), Image.FromFile("又六.png") }
            };
            bossmove.Text = "left";
            nowbossimage = 0;
            boss.Size = new Size(boss.Size.Width * 2, boss.Size.Height * 2);
        }

        private void gameformbackground_Load(object sender, EventArgs e)
        {
            GameData.gameformbackground = this;
            this.TopMost = true;
            this.Location = x;
            this.Size = gameformsize;
            this.TransparencyKey = Color.White;
            boss.Image = bossimages[0, 0];
            boss.Top = this.Height - boss.Height - 50;
            boss.Left = this.Width - 20 - boss.Width;
            bossmoveint = 0;
            GameData.bossleft = boss.Left;
            GameData.bosswidth = boss.Width;
        }

        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            GameData.sendstatustomain(debugtext.Text);
            if (debugtext.Text == "startgame")
            {
                timer1.Enabled = true;
                timer3.Enabled = true;
            }
            else if (debugtext.Text == "endgame")
            {
                GameData.sendstatustomain("endgame");
                timer1.Enabled = false;
                timer3.Enabled = false;
            }
            else if (debugtext.Text == "again")
            {
                this.Close();
                this.Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                GameData.bossleft = boss.Left;
                boss.Image = bossimages[bossmoveint, 0];
                if (bossmove.Text == "left")
                {
                    if (boss.Left - 10 >= 0)
                    {
                        bossmoveint = 0;
                        boss.Left -= 10;

                        if (boss.Left < GameData.meleft + GameData.mewidth)
                        {
                            bossattackmovement = "up";
                            timer5.Enabled = true;
                            timer3.Enabled = false;
                            timer1.Enabled = false;
                        }
                    }
                }
                else if (bossmove.Text == "right")
                {
                    if (boss.Left + 10 <= this.Width - 20 - boss.Width)
                    {
                        bossmoveint = 1;
                        boss.Left += 10;

                        if (boss.Left + boss.Width > GameData.meleft)
                        {
                            bossattackmovement = "up";
                            timer5.Enabled = true;
                            timer3.Enabled = false;
                            timer1.Enabled = false;
                        }
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (GameData.meleft + GameData.mewidth < boss.Left)
            {
                bossmove.Text = "left";
            }
            else if (GameData.meleft > boss.Left + boss.Width)
            {
                bossmove.Text = "right";
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (bossattackmovement == "up")
            {
                if(nowbossimage < 3)
                {
                    nowbossimage += 1;
                    boss.Image = bossimages[bossmoveint, nowbossimage];
                    boss.Top -= 50;
                    if(boss.Left < GameData.meleft + GameData.mewidth && boss.Left > GameData.meleft)
                    {
                        if (!GameData.block)
                        {
                            GameData.minusmeheart();
                            GameData.setmeheart();
                        }
                        else
                        {
                            iffreeze = true;
                            GameData.addmeheart();
                        }
                    }
                    
                }
                else
                {
                    bossattackmovement = "down";
                    timer5.Interval = 50;
                }
            }
            else if (bossattackmovement == "down")
            {
                if (nowbossimage < bossimagecount-1)
                {
                    
                    nowbossimage += 1;
                    boss.Image = bossimages[bossmoveint, nowbossimage];
                    boss.Top += 50;
                    if (boss.Left < GameData.meleft + GameData.mewidth && boss.Left > GameData.meleft)
                    {
                        if (!GameData.block)
                        {
                            GameData.minusmeheart();
                            GameData.setmeheart();
                        }
                        else
                        {
                            iffreeze = true;
                            GameData.addmeheart();
                        }
                        
                    }
                }
                else
                {
                    boss.Top += 50;
                    nowbossimage = 0;
                    boss.Image = bossimages[bossmoveint, nowbossimage];
                    if (iffreeze)
                    {
                        timer5.Enabled = false;
                        timer7.Enabled = true;
                        nowbossimage = 0;
                    }
                    else
                    {
                        timer1.Enabled = true;
                        timer3.Enabled = true;
                        timer5.Enabled = false;
                        nowbossimage = 0;
                    }
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (iffreeze)
            {
                iffreeze = false;
            }
            else
            {
                timer1.Enabled = true;
                timer3.Enabled = true;
                timer7.Enabled = false;
            }
        }

        /*傳值*/

        public Point getformposition
        {
            set
            {
                x = value;
            }
        }

        public Size getgameformsize
        {
            set
            {
                gameformsize = value;
            }
        }

        public string setgamestatus
        {
            set
            {
                debugtext.Text = value;
            }
        }
    }
}