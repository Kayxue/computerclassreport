using System;
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
        int memove, bossmoveint, nowmeimage,
            meimagecount = 5, nowbossimage, bossimagecount = 3,
            nowmeattackimage, meattackimagecount = 3, nowwalkimage = 0,
            mewalkwidth = 0, menormalwidth = 0, meblockheight = 0, menormalheight = 0;
        bool needagain, block, attack, resume, ifwin, iffreeze, startwalk;
        string meblockpicturemovement = "block", meattackmovement = "attack", bossattackmovement = "attack";
        Form1 form1 = new Form1();
        gameformbackground gameformbackground = new gameformbackground();
        Point x;
        Image[,] meimagesblock;
        Image[,] bossimages;
        Image[,] meimagesattack;
        Image[,] mewalkimages;
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
            meimagesblock = new Image[,] {
                { Image.FromFile("主角 站立.png"), Image.FromFile("主角 格擋1.png"), Image.FromFile("主角 格擋2.png") , Image.FromFile("主角 格擋3.png"), Image.FromFile("主角 格擋4.png")},
                { Image.FromFile("主角 站立1.png"), Image.FromFile("主角 格擋1(1).png"), Image.FromFile("主角 格擋2(1).png"), Image.FromFile("主角 格擋3(1).png"), Image.FromFile("主角 格擋4(1).png") } 
            };
            meimagesattack = new Image[,] { 
                { Image.FromFile("主角 站立.png"), Image.FromFile("主角 攻擊1.png"), Image.FromFile("主角 攻擊2.png") }, 
                { Image.FromFile("主角 站立1.png"), Image.FromFile("主角 攻擊1(1).png"), Image.FromFile("主角 攻擊2(1).png") } 
            };
            bossimages = new Image[,] { 
                { Image.FromFile("魔王 初始.png"), Image.FromFile("魔王 攻擊1.png"), Image.FromFile("魔王 攻擊2.png") }, 
                { Image.FromFile("魔王 初始(1).png"), Image.FromFile("魔王 攻擊1(1).png"), Image.FromFile("魔王 攻擊2(1).png") } 
            };
            mewalkimages = new Image[,] {
                { Image.FromFile("主角 站立.png"),Image.FromFile("21.png"),Image.FromFile("31.png"),Image.FromFile("41.png"),Image.FromFile("51.png"),Image.FromFile("61.png"),Image.FromFile("71.png")},
                { Image.FromFile("主角 站立1.png"),Image.FromFile("2.png"),Image.FromFile("3.png"),Image.FromFile("4.png"),Image.FromFile("5.png"),Image.FromFile("6.png"),Image.FromFile("7.png")}
            };
            nowmeimage = 0;                                                             
            nowbossimage = 0;
            nowmeattackimage = 0;
            resume = false;
            startwalk = false;
            mewalkwidth = me.Width + 150;
            menormalwidth = me.Width;
            meblockheight = me.Height + 40;
            menormalheight = me.Height;
        }

        private void gameform_Load(object sender, EventArgs e)
        {
            this.Location = x;                                              
            this.BackColor = Color.White;                                   
            this.TransparencyKey = this.BackColor;                          
            me.Image = meimagesblock[0, 0];                                 
            boss.Image = bossimages[0, 0];                                  
            myheart.Size = new Size(this.Width, myheart.Height);            
            bossheart.Size = new Size(this.Width, myheart.Height);          
            myheart.Top = this.Height - myheart.Height;                     
            myhearttext.Left = this.Width - myhearttext.Width - 20;         
            myhearttext.Top = this.Height - 110 - myhearttext.Height;       
            bosshearttext.Left = this.Width - bosshearttext.Width - 20;     
            me.Top = this.Height - me.Height - 150;                         
            boss.Top = this.Height - boss.Height - 100;                     
            boss.Left = this.Width - 20 - boss.Width;                       
            bossmoveint = 0;                                                
            debugtext.Text = "startgame";                                   
        }

        private void gameform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needagain == false)                                         
            {
                form1.Visible = true;                                       
                gameformbackground.Close();                                 
                wmplayer.close();                                           
                meattacksound.Dispose();                                    
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
                endform endform = new endform(form1, this);
                endform.getfromlocation = x;
                if (ifwin)
                {
                    endform.getwinorlose = "win";
                }
                else
                {
                    endform.getwinorlose = "lose";
                }
                endform.TopMost = true;
                endform.ShowDialog();
            }
        }

        /*鍵盤控制*/
        private void gameform_KeyDown(object sender, KeyEventArgs e)
        {
            if(debugtext.Text == "startgame")
            {
                if (e.KeyCode == Keys.Space && attack == false)
                {
                    meblockpicturemovement = "block";
                    timer4.Enabled = true;
                    block = true;
                }
                if(block == false && attack == false)
                {
                    if(e.KeyCode == Keys.V)
                    {
                        bossattackmovement = "attack";
                        timer5.Enabled = true;
                        timer3.Enabled = false;
                        timer1.Enabled = false;
                    }
                    if (e.KeyCode == Keys.Left)
                    {
                        if (me.Left - 10 >= 0)
                        {
                            me.Left -= 10;
                            memove = 1;
                            block = false;
                            startwalk = true;
                            timer8.Enabled = true;
                        }
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        if (me.Left + 10 <= this.Width - 20 - me.Width)
                        {
                            me.Left += 10;
                            memove = 0;
                            block = false;
                            startwalk = true;
                            timer8.Enabled = true;
                        }
                    }
                    if (e.KeyCode == Keys.Z)
                    {
                        if (me.Left + me.Width > boss.Left && me.Left < boss.Left + boss.Width && attack == false)
                        {
                            block = false;
                            attack = true;

                            if (bossheart.Value - 1 > 0)
                            {
                                meattackmovement = "attack";
                                timer6.Enabled = true;
                            }
                            else
                            {
                                ifwin = true;
                                debugtext.Text = "endgame";
                                
                            }
                            //meattacksound.Play();
                        }
                    }
                    if (e.KeyCode == Keys.P || e.KeyCode == Keys.Escape)
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
                    meattackmovement = "reset";
                    timer6.Enabled = true;
                }
                if(attack==false && block == false)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        startwalk = false;
                    }
                    else if(e.KeyCode == Keys.Right)
                    {
                        startwalk = false;
                    }
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
                            bossattackmovement = "attack";
                            timer5.Enabled = true;
                            timer3.Enabled = false;
                            timer1.Enabled = false;
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
            meimagesblock[方向編號,造型編號]
            */
            if (meblockpicturemovement == "block")
            {
                if (nowmeimage == meimagecount-1)
                {
                    me.Image = meimagesblock[memove, nowmeimage];
                    timer4.Enabled = false;
                }
                else
                {
                    if (nowmeimage >= 2)
                    {
                        me.Size = new Size(me.Width, meblockheight);
                        me.Top=this.Height - me.Height - 150;
                    }
                    me.Image = meimagesblock[memove, nowmeimage];
                    nowmeimage += 1;
                    
                }
            }
            else if (meblockpicturemovement == "reset")
            {
                if(nowmeimage == meimagecount)
                {
                    nowmeimage = (meimagecount-1);
                }
                if (nowmeimage == 0)
                {
                    me.Image = meimagesblock[memove, nowmeimage];
                    timer4.Enabled = false;
                    block = false;
                }
                else
                {
                    if(nowmeimage < 1)
                    {
                        me.Size = new Size(me.Width, menormalheight);
                        me.Top = this.Height - me.Height - 150;
                    }
                    me.Image = meimagesblock[memove, nowmeimage];
                    nowmeimage -= 1;
                }
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
                    if (!block)
                    {
                        myheart.Value -= 10;
                        myhearttext.Text = myheart.Value.ToString();
                    }
                    else
                    {
                        iffreeze = true;
                    }
                        
                    if (myheart.Value == 0)
                    {
                        ifwin = false;
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

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (meattackmovement == "attack")
            {
                if (nowmeattackimage == meattackimagecount - 1)
                {
                    me.Image = meimagesattack[memove, nowmeattackimage];
                    timer6.Enabled = false;
                    bossheart.Value -= 1;
                    bosshearttext.Text = bossheart.Value.ToString();
                }
                else
                {
                    me.Image = meimagesattack[memove, nowmeattackimage];
                    nowmeattackimage += 1;
                }
            }
            else if (meattackmovement == "reset")
            {
                if (nowmeattackimage == meattackimagecount)
                {
                    nowmeattackimage = (meattackimagecount - 1);
                }
                if (nowmeattackimage == 0)
                {
                    me.Image = meimagesattack[memove, nowmeattackimage];
                    timer6.Enabled = false;
                    attack = false;
                }
                else
                {
                    me.Image = meimagesattack[memove, nowmeattackimage];
                    nowmeattackimage -= 1;
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

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (startwalk)
            {
                if(nowwalkimage >= 6)
                {
                    nowwalkimage = 2;
                }
                nowwalkimage += 1;
                if(nowwalkimage >= 1)
                {
                    me.Size = new Size(mewalkwidth, me.Height);
                }
                me.Image = mewalkimages[memove, nowwalkimage];

            }
            else
            {
                if(nowwalkimage > 0)
                {
                    nowwalkimage -= 1;
                    me.Image = mewalkimages[memove, nowwalkimage];
                }
                else
                {
                    me.Size = new Size(menormalwidth, me.Height);
                    timer8.Enabled = false;
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
