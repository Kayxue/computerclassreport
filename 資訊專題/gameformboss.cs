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
        private int bossmoveint, nowbossimage, bossimagecount = 3;
        private bool iffreeze;
        private string bossattackmovement = "attack";

        /*初始化*/

        public gameformboss()
        {
            InitializeComponent();
            bossimages = new Image[,] {
                { Image.FromFile("魔王 初始.png"), Image.FromFile("魔王 攻擊1.png"), Image.FromFile("魔王 攻擊2.png") },
                { Image.FromFile("魔王 初始(1).png"), Image.FromFile("魔王 攻擊1(1).png"), Image.FromFile("魔王 攻擊2(1).png") }
            };
            bossmove.Text = "left";
            nowbossimage = 0;
        }

        private void gameformbackground_Load(object sender, EventArgs e)
        {
            GameData.gameformbackground = this;
            this.Location = x;
            this.Size = gameformsize;
            this.TransparencyKey = Color.White;
            boss.Image = bossimages[0, 0];
            boss.Top = this.Height - boss.Height - 100;
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
                            bossattackmovement = "attack";
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
                            bossattackmovement = "attack";
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
            if (bossattackmovement == "attack")
            {
                if (nowbossimage == bossimagecount - 1)
                {
                    boss.Image = bossimages[bossmoveint, nowbossimage];
                    bossattackmovement = "reset";
                    if (!GameData.block)
                    {
                        GameData.minusmeheart();
                        GameData.setmeheart();
                    }
                    else
                    {
                        iffreeze = true;
                    }

                    if (GameData.meheart == 0)
                    {
                        GameData.ifwin = false;
                        debugtext.Text = "endgame";
                    }
                }
                else
                {
                    boss.Image = bossimages[bossmoveint, nowbossimage];
                    nowbossimage += 1;
                }
            }
            else if (bossattackmovement == "reset")
            {
                if (nowbossimage == bossimagecount)
                {
                    nowbossimage = (bossimagecount - 1);
                }
                if (nowbossimage == 0)
                {
                    boss.Image = bossimages[bossmoveint, nowbossimage];
                    timer5.Enabled = false;
                    if (iffreeze)
                    {
                        timer7.Enabled = true;
                    }
                    else
                    {
                        timer1.Enabled = true;
                        timer3.Enabled = true;
                    }
                }
                else
                {
                    boss.Image = bossimages[bossmoveint, nowbossimage];
                    nowbossimage -= 1;
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