<<<<<<< HEAD:資訊專題/gameformmain.cs
﻿using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace 資訊專題
{
    public partial class gameformmain : Form
    {
        /*宣告變數*/
        int memove, bossmoveint, nowmeimage, meimagecount = 3, nowbossimage, bossimagecount = 3;
        bool needagain, block, attack, resume;
        string meblockpicturemovement = "block";
        Form1 form1 = new Form1();
        gameformbackground gameformbackground = new gameformbackground();
        Point x;
        Image[,] meimages;
        Image[,] bossimages;
        WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();
        SoundPlayer meattacksound = new SoundPlayer();
        PrivateFontCollection fontcollection = new PrivateFontCollection();
        Random random = new Random();

        /*初始化與視窗關閉*/
        public gameformmain()
        {
            InitializeComponent();
            meattacksound.SoundLocation = Application.StartupPath + "\\";
            this.KeyPreview = true;
            myhearttext.Text = myheart.Maximum.ToString();
            bosshearttext.Text = bossheart.Maximum.ToString();
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            this.Font = font;
            block = false;
            bossmove.Text = "left";
            meimages = new Image[,] {
                { Image.FromFile("主角 站立.png"), Image.FromFile("主角 格擋1.png"), Image.FromFile("主角 格擋2.png") },
                { Image.FromFile("主角 站立1.png"), Image.FromFile("主角 格擋1(1).png"), Image.FromFile("主角 格擋2(1).png") } 
            };
            bossimages = new Image[,] { 
                { Image.FromFile("魔王 初始.png"), Image.FromFile("魔王 攻擊1.png"), Image.FromFile("魔王 攻擊2.png") }, 
                { Image.FromFile("魔王 初始(1).png"), Image.FromFile("魔王 攻擊1(1).png"), Image.FromFile("魔王 攻擊2(1).png") } 
            };
            nowmeimage = 0;
            resume = false;
        }

        private void gameform_Load(object sender, EventArgs e)
        {
            this.Location = x;
            this.BackColor = Color.White;
            this.TransparencyKey = this.BackColor;
            me.Image = meimages[0,0];
            boss.Image = bossimages[0, 0];
            myheart.Size = new Size(this.Width, myheart.Height);
            bossheart.Size = new Size(this.Width, myheart.Height);
            myheart.Top = this.Height - myheart.Height;
            myhearttext.Left = this.Width - myhearttext.Width - 20;
            myhearttext.Top = this.Height - 110 - myhearttext.Height;
            bosshearttext.Left = this.Width - bosshearttext.Width - 20;
            me.Top = this.Height - me.Height - 150;
            boss.Top = this.Height - boss.Height - 100;
            debugtext.Text = "startgame";
            bossmoveint = 0;
        }

        private void gameform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needagain == false)
            {
                form1.Visible = true;
                gameformbackground.Close();
                wmplayer.close();
            }
        }

        /*遊戲監聽器*/
        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                if(resume == false)
                {
                    wmplayer.URL = Application.StartupPath + "\\遊戲中背景音樂.wav";
                    wmplayer.settings.setMode("loop", true);
                }
                else
                {
                    wmplayer.controls.play();
                }
                this.TopMost = true;
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
            else if (debugtext.Text == "gamepause")
            {
                pauseform pauseform = new pauseform(this);
                wmplayer.controls.pause();
                pauseform.TopMost = true;
                pauseform.ShowDialog();
            }
            else if(debugtext.Text == "again")
            {
                form1.getinfofromgame = "again";
                debugtext.Text = "again";
                needagain = true;
                wmplayer.close();
                gameformbackground.Close();
                this.Close();
                this.Dispose();
            }
            else if(debugtext.Text == "backtomenu")
            {
                debugtext.Text = "backtomenu";
                gameformbackground.Close();
                this.Close();
                needagain = false;
                form1.Visible = true;
                wmplayer.close();
                this.Dispose();
            }
            else if(debugtext.Text == "endgame")
            {
                wmplayer.close();
                debugtext.Text="endgame";
                timer1.Enabled = false;
                timer2.Enabled = false;
                endform endform = new endform(form1, this);
                endform.getfromlocation = x;
                endform.ShowDialog();
            }
        }

        /*鍵盤控制*/
        private void gameform_KeyDown(object sender, KeyEventArgs e)
        {
            if(debugtext.Text == "startgame")
            {
                if (e.KeyCode == Keys.Space)
                {
                    meblockpicturemovement = "block";
                    timer4.Enabled = true;
                    block = true;
                }
                if(block == false)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        if (me.Left - 10 >= 0)
                        {
                            me.Left -= 10;
                            memove = 1;
                            me.Image = meimages[memove, 0];
                            block = false;
                        }
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        if (me.Left + 10 <= this.Width - 20 - me.Width)
                        {
                            me.Left += 10;
                            memove = 0;
                            me.Image = meimages[memove, 0];
                            block = false;
                        }
                    }
                    if (e.KeyCode == Keys.Z)
                    {
                        if (me.Left + me.Width > boss.Left && me.Left < boss.Left + boss.Width && attack == false)
                        {
                            block = false;
                            attack = true;

                            if (bossheart.Value - 10 > 0)
                            {
                                bossheart.Value -= 10;
                                bosshearttext.Text = bossheart.Value.ToString();
                            }
                            else
                            {
                                bossheart.Maximum += 100;
                                bossheart.Value = bossheart.Maximum;
                                bosshearttext.Text = bossheart.Value.ToString();
                                boss.Left = random.Next(5, this.Width - boss.Width - 10);
                            }
                            meattacksound.Play();
                        }
                    }
                    if (e.KeyCode == Keys.P)
                    {
                        debugtext.Text = "gamepause";
                    }
                }
            }
        }

        /*結束格檔與攻擊*/
        private void gameform_KeyUp(object sender, KeyEventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                if (e.KeyCode == Keys.Space)
                {
                    meblockpicturemovement = "reset";
                    timer4.Enabled = true;
                }
                else if (e.KeyCode == Keys.Z)
                {
                    attack = false;
                }
            }
        }

        /*計時器*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(debugtext.Text == "startgame")
            {
                boss.Image = bossimages[bossmoveint, 0];
                if(bossmove.Text == "left")
                {
                
                    if (boss.Left - 10 >= 0)
                    {
                        bossmoveint = 0;
                        boss.Left -= 10;
                        if(boss.Left < me.Left + me.Width)
                        {
                            //TODO:攻擊
                        }
                    }
                }
                else if(bossmove.Text == "right")
                {
                
                    if (boss.Left + 10 <= this.Width - 20 - boss.Width)
                    {
                        bossmoveint = 1;
                        boss.Left += 10;
                        if (boss.Left + boss.Width > me.Left)
                        {
                            //TODO:攻擊
                        }
                    }
                }
            }
                
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (me.Left + me.Width < boss.Left)
            {
                bossmove.Text = "left";
            }
            else if (me.Left > boss.Left + boss.Width)
            {
                bossmove.Text = "right";
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            /*
            nowmeimage現在圖示編號
            block是否處於格擋
            meimages[方向編號,造型編號]
            */
            if (meblockpicturemovement == "block")
            {
                if (nowmeimage == meimagecount-1)
                {
                    me.Image = meimages[memove, nowmeimage];
                    timer4.Enabled = false;
                }
                else
                {
                    me.Image = meimages[memove, nowmeimage];
                    nowmeimage += 1;
                }
            }
            else if (meblockpicturemovement == "reset")
            {
                if(nowmeimage == 3)
                {
                    nowmeimage = 2;
                }
                if (nowmeimage == 0)
                {
                    me.Image = meimages[memove, nowmeimage];
                    timer4.Enabled = false;
                    block = false;
                }
                else
                {
                    me.Image = meimages[memove, nowmeimage];
                    nowmeimage -= 1;
                }
            }
        }

        /*視窗間傳值*/
        public Form1 GetForm1
        {
            set
            {
                form1 = value;
            }
        }

        public gameformbackground GetGameformbackground
        {
            set
            {
                gameformbackground = value;
            }
        }

        public string getresult
        {
            set
            {
                debugtext.Text = value;
            }
        }

        public Size returnthisformsize
        {
            get
            {
                return this.Size;
            }
        }

        public Point getfromlocation
        {
            set
            {
                x = value;
            }
        }
    }
}
=======
﻿using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace 資訊專題
{
    public partial class gameform : Form
    {
        /*宣告變數*/
        int memove, bossmoveint, nowmeimage, meimagecount = 3;
        bool needagain, block, attack, resume;
        Form1 form1 = new Form1();
        gameformbackground gameformbackground = new gameformbackground();
        Point x;
        Image[,] meimages;
        Image[,] bossimages;
        WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();
        SoundPlayer meattacksound = new SoundPlayer();
        PrivateFontCollection fontcollection = new PrivateFontCollection();
        Random random = new Random();

        /*初始化與視窗關閉*/
        public gameform()
        {
            InitializeComponent();
            meattacksound.SoundLocation = Application.StartupPath + "\\";
            this.KeyPreview = true;
            myhearttext.Text = myheart.Maximum.ToString();
            bosshearttext.Text = bossheart.Maximum.ToString();
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            this.Font = font;
            block = false;
            bossmove.Text = "left";
            meimages = new Image[,] {
                { Image.FromFile("主角 站立.png"), Image.FromFile("主角 格擋1.png"), Image.FromFile("主角 格擋2.png") },
                { Image.FromFile("主角 站立1.png"), Image.FromFile("主角 格擋1(1).png"), Image.FromFile("主角 格擋2(1).png") } 
            };
            bossimages = new Image[,] { 
                { Image.FromFile("魔王 初始.png"), Image.FromFile("魔王 攻擊1.png"), Image.FromFile("魔王 攻擊2.png") }, 
                { Image.FromFile("魔王 初始(1).png"), Image.FromFile("魔王 攻擊1(1).png"), Image.FromFile("魔王 攻擊2(1).png") } 
            };
            nowmeimage = 0;
            resume = false;
        }

        private void gameform_Load(object sender, EventArgs e)
        {
            this.Location = x;
            this.BackColor = Color.White;
            this.TransparencyKey = this.BackColor;
            me.Image = meimages[0,0];
            boss.Image = bossimages[0, 0];
            myheart.Size = new Size(this.Width, myheart.Height);
            bossheart.Size = new Size(this.Width, myheart.Height);
            myheart.Top = this.Height - myheart.Height;
            myhearttext.Left = this.Width - myhearttext.Width - 20;
            myhearttext.Top = this.Height - 110 - myhearttext.Height;
            bosshearttext.Left = this.Width - bosshearttext.Width - 20;
            me.Top = this.Height - me.Height - 150;
            boss.Top = this.Height - boss.Height - 100;
            debugtext.Text = "startgame";
            bossmoveint = 0;
        }


        private void gameform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needagain == false)
            {
                form1.Visible = true;
                gameformbackground.Close();
                wmplayer.close();
            }
        }

        /*遊戲監聽器*/
        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                if(resume == false)
                {
                    wmplayer.URL = Application.StartupPath + "\\遊戲中背景音樂.wav";
                    wmplayer.settings.setMode("loop", true);
                }
                else
                {
                    wmplayer.controls.play();
                }
                this.TopMost = true;
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
            else if (debugtext.Text == "gamepause")
            {
                pauseform pauseform = new pauseform(this);

                wmplayer.controls.pause();
                pauseform.ShowDialog();
            }
            else if(debugtext.Text == "again")
            {
                form1.getinfofromgame = "again";
                debugtext.Text = "again";
                needagain = true;
                wmplayer.close();
                gameformbackground.Close();
                this.Close();
                this.Dispose();
            }
            else if(debugtext.Text == "backtomenu")
            {
                debugtext.Text = "backtomenu";
                gameformbackground.Close();
                this.Close();
                needagain = false;
                form1.Visible = true;
                wmplayer.close();
                this.Dispose();
            }
            else if(debugtext.Text == "endgame")
            {

                wmplayer.close();
                debugtext.Text="endgame";
                timer1.Enabled = false;
                timer2.Enabled = false;
                endform endform = new endform(form1, this);
                endform.getfromlocation = x;
                endform.ShowDialog();
            }
        }

        /*鍵盤控制*/
        private void gameform_KeyDown(object sender, KeyEventArgs e)
        {
            if(debugtext.Text == "startgame")
            {
                if (e.KeyCode == Keys.Space)
                {
                    timer4.Enabled = true;
                    timer5.Enabled = false;
                    block = true;
                }
                if(block == false)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        if (me.Left - 10 >= 0)
                        {
                            me.Left -= 10;
                            memove = 1;
                            me.Image = meimages[memove, 0];
                            block = false;
                        }
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        if (me.Left + 10 <= this.Width - 20 - me.Width)
                        {
                            me.Left += 10;
                            memove = 0;
                            me.Image = meimages[memove, 0];
                            block = false;
                        }
                    }
                    if (e.KeyCode == Keys.Z)
                    {
                        if (me.Left + me.Width > boss.Left && me.Left < boss.Left + boss.Width && attack == false)
                        {
                            block = false;
                            attack = true;

                            if (bossheart.Value - 10 > 0)
                            {
                                bossheart.Value -= 10;
                                bosshearttext.Text = bossheart.Value.ToString();
                            }
                            else
                            {
                                bossheart.Maximum += 100;
                                bossheart.Value = bossheart.Maximum;
                                bosshearttext.Text = bossheart.Value.ToString();
                                boss.Left = random.Next(5, this.Width - boss.Width - 10);
                            }
                            meattacksound.Play();
                        }
                    }
                    if (e.KeyCode == Keys.P)
                    {
                        debugtext.Text = "gamepause";
                    }
                }
            }
        }

        /*結束格檔與攻擊*/
        private void gameform_KeyUp(object sender, KeyEventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                if (e.KeyCode == Keys.Space)
                {
                    timer4.Enabled = false;
                    timer5.Enabled = true;
                }
                else if (e.KeyCode == Keys.Z)
                {
                    attack = false;
                }
            }
        }

        /*計時器*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(debugtext.Text == "startgame")
            {
                boss.Image = bossimages[bossmoveint, 0];
                if(bossmove.Text == "left")
                {
                
                    if (boss.Left - 10 >= 0)
                    {
                        bossmoveint = 0;
                        boss.Left -= 10;
                        if(boss.Left < me.Left + me.Width)
                        {
                        
                        }
                    }
                }
                else if(bossmove.Text == "right")
                {
                
                    if (boss.Left + 10 <= this.Width - 20 - boss.Width)
                    {
                        bossmoveint = 1;
                        boss.Left += 10;
                        if (boss.Left + boss.Width > me.Left)
                        {
                        
                        }
                    }
                }
            }
                
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (me.Left + me.Width < boss.Left)
            {
                bossmove.Text = "left";
            }
            else if (me.Left > boss.Left + boss.Width)
            {
                bossmove.Text = "right";
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //nowmeimage現在圖示編號
            //block是否處於格擋
            //meimage[方向編號,造型編號]
            if(nowmeimage == -1)
            {
                nowmeimage = 0;
            }
            if(block)
            {
                if (nowmeimage < meimagecount)
                {
                    me.Image = meimages[memove, nowmeimage];
                    nowmeimage += 1;
                }
                else
                {
                    timer4.Enabled = false;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (block)
            {
                nowmeimage -= 1;
                if (nowmeimage > 0)
                {
                    me.Image = meimages[memove, nowmeimage];
                    nowmeimage -= 1;
                }
                else
                {
                    timer5.Enabled = false;
                    block = false;

                }
            } 
        }

        /*視窗間傳值*/
        public Form1 GetForm1
        {
            set
            {
                form1 = value;
            }
        }

        public gameformbackground GetGameformbackground
        {
            set
            {
                gameformbackground = value;
            }
        }

        public string getresult
        {
            set
            {
                debugtext.Text = value;
            }
        }

        public Size returnthisformsize
        {
            get
            {
                return this.Size;
            }
        }

        public Point getfromlocation
        {
            set
            {
                x = value;
            }
        }
    }
}
>>>>>>> parent of c299013... 2020-06-23:資訊專題/gameform.cs
