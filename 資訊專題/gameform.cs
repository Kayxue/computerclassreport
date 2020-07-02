using System;
using System.Drawing;
using System.Drawing.Text;
using System.Media;
using System.Windows.Forms;
using WMPLib;

namespace 資訊專題
{
    public partial class gameform : Form
    {
        /*宣告變數*/

        private int memove, nowmeimage, meimagecount = 5,
            bossimagecount = 3, nowmeattackimage, meattackimagecount = 6,
            nowwalkimage = 0, mewalkwidth = 0, menormalwidth = 0, meblockheight = 0,
            menormalheight = 0, presstimes = 0;

        private bool needagain, attack, resume, startwalk, walking;
        private string meblockpicturemovement = "block", meattackmovement = "attack";
        private Form1 form1 = new Form1();
        private gameformbackground gameformbackground = new gameformbackground();
        private Point x;
        private Image[,] meimagesblock;
        private Image[,] meimagesattackone;
        private Image[,] meimagesattacktwo;
        private Image[,] mewalkimages;
        private WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();
        private SoundPlayer meattacksound = new SoundPlayer();
        private PrivateFontCollection fontcollection = new PrivateFontCollection();
        private Random random = new Random();

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
            GameData.block = false;

            meimagesblock = new Image[,] {
                { Image.FromFile("主角 站立.png"), Image.FromFile("主角 格擋1.png"), Image.FromFile("主角 格擋2.png") , Image.FromFile("主角 格擋3.png"), Image.FromFile("主角 格擋4.png")},
                { Image.FromFile("主角 站立1.png"), Image.FromFile("主角 格擋1(1).png"), Image.FromFile("主角 格擋2(1).png"), Image.FromFile("主角 格擋3(1).png"), Image.FromFile("主角 格擋4(1).png") }
            };
            meimagesattackone = new Image[,] {
                { Image.FromFile("主角 站立.png"), Image.FromFile("504.png"), Image.FromFile("503.png"),Image.FromFile("502.png"),Image.FromFile("501.png"),Image.FromFile("500.png") },
                { Image.FromFile("主角 站立1.png"), Image.FromFile("攻2.png"), Image.FromFile("攻3.png"),Image.FromFile("攻4.png"),Image.FromFile("攻203.png"),Image.FromFile("攻204.png")}
            };
            meimagesattacktwo = new Image[,]
            {
                { Image.FromFile("主角 站立.png"), Image.FromFile("504.png"), Image.FromFile("503.png"),Image.FromFile("502.png"),Image.FromFile("攻.png"),Image.FromFile("攻1.png")},
                { Image.FromFile("主角 站立1.png"), Image.FromFile("攻2.png"), Image.FromFile("攻3.png"),Image.FromFile("攻4.png"),Image.FromFile("攻11.png"),Image.FromFile("攻12.png")}
            };
            mewalkimages = new Image[,] {
                { Image.FromFile("主角 站立.png"),Image.FromFile("21.png"),Image.FromFile("31.png"),Image.FromFile("41.png"),Image.FromFile("51.png"),Image.FromFile("61.png"),Image.FromFile("71.png")},
                { Image.FromFile("主角 站立1.png"),Image.FromFile("2.png"),Image.FromFile("3.png"),Image.FromFile("4.png"),Image.FromFile("5.png"),Image.FromFile("6.png"),Image.FromFile("7.png")}
            };
            nowmeimage = 0;
            nowmeattackimage = 0;
            resume = false;
            startwalk = false;
            walking = false;
            
            mewalkwidth = me.Width + 150;
            menormalwidth = me.Width;
            meblockheight = me.Height + 40;
            menormalheight = me.Height;
        }

        private void gameform_Load(object sender, EventArgs e)
        {
            GameData.gameform = this;
            GameData.bossheart = bossheart.Value;
            GameData.meheart = myheart.Value;
            this.Location = x;
            me.Image = meimagesblock[0, 0];

            myheart.Size = new Size(this.Width, myheart.Height);
            bossheart.Size = new Size(this.Width, myheart.Height);
            myheart.Top = this.Height - myheart.Height;
            myhearttext.Left = this.Width - myhearttext.Width - 20;
            myhearttext.Top = this.Height - 110 - myhearttext.Height;
            bosshearttext.Left = this.Width - bosshearttext.Width - 20;
            me.Top = this.Height - me.Height - 150;

            debugtext.Text = "startgame";
        }

        private void gameform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needagain == false)
            {
                form1.Visible = true;
                GameData.gameformbackground.Close();
                wmplayer.close();
                meattacksound.Dispose();
            }
        }

        /*遊戲監聽器*/

        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            GameData.sendstatustobackground(debugtext.Text);
            if (debugtext.Text == "startgame")
            {
                if (resume == false)
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
            else if (debugtext.Text == "again")
            {
                form1.getinfofromgame = "again";
                debugtext.Text = "again";
                needagain = true;
                wmplayer.close();
                gameformbackground.Close();
                gameformbackground.Dispose();
                this.Close();
                this.Dispose();
            }
            else if (debugtext.Text == "backtomenu")
            {
                debugtext.Text = "backtomenu";
                GameData.gameformbackground.Close();
                gameformbackground.Close();
                gameformbackground.Dispose();
                this.Close();
                needagain = false;
                form1.Visible = true;
                wmplayer.close();
                this.Dispose();
            }
            else if (debugtext.Text == "endgame")
            {
                wmplayer.close();
                debugtext.Text = "endgame";
                timer1.Enabled = false;
                endform endform = new endform(form1, this);
                endform.getfromlocation = x;
                if (GameData.ifwin)
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

        private void me_LocationChanged(object sender, EventArgs e)
        {
            GameData.meleft = me.Left;
        }

        /*鍵盤控制*/

        private void gameform_KeyDown(object sender, KeyEventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                presstimes += 1;
                if (e.KeyCode == Keys.Space && attack == false && startwalk == false)
                {
                    meblockpicturemovement = "block";
                    timer4.Enabled = true;
                    GameData.block = true;
                }
                if (GameData.block == false && attack == false)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        if (me.Left - 10 >= 0)
                        {
                            me.Left -= 10;
                            memove = 1;
                            GameData.block = false;
                            startwalk = true;
                            walking = true;
                            timer8.Enabled = true;
                        }
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        if (me.Left + 10 <= this.Width - 20 - me.Width)
                        {
                            me.Left += 10;
                            memove = 0;
                            GameData.block = false;
                            startwalk = true;
                            walking = true;
                            timer8.Enabled = true;
                        }
                    }
                    if (e.KeyCode == Keys.Z)
                    {
                        if (me.Left + me.Width > GameData.bossleft && me.Left < GameData.bossleft + GameData.bosswidth && attack == false && walking == false)
                        {
                            GameData.block = false;
                            
                            meattackmovement = "attack";
                            timer6.Enabled = true;
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
                if (attack == false)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        meblockpicturemovement = "reset";
                        timer4.Enabled = true;
                    }
                }
                    
                if (attack == false && GameData.block == false)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        startwalk = false;
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        startwalk = false;
                    }
                }

                
            }
        }

        /*計時器*/

        private void timer4_Tick(object sender, EventArgs e)
        {
            GameData.mewidth = me.Width;

            /*
            nowmeimage現在圖示編號
            block是否處於格擋
            meimagesblock[方向編號,造型編號]
            */
            if (meblockpicturemovement == "block")
            {
                if (nowmeimage == meimagecount - 1)
                {
                    me.Image = meimagesblock[memove, nowmeimage];
                    meblockpicturemovement = "reset";
                    GameData.block = false;
                    
                }
                else
                {
                    if (nowmeimage >= 2)
                    {
                        me.Size = new Size(me.Width, meblockheight);
                        me.Top = this.Height - me.Height - 150;
                    }
                    me.Image = meimagesblock[memove, nowmeimage];
                    nowmeimage += 1;
                    
                }
            }
            else if (meblockpicturemovement == "reset")
            {
                if (nowmeimage == meimagecount)
                {
                    nowmeimage = (meimagecount - 1);
                }
                if (nowmeimage == 0)
                {
                    me.Image = meimagesblock[memove, nowmeimage];
                    timer4.Enabled = false;
                }
                else
                {
                    if (nowmeimage < 1)
                    {
                        me.Size = new Size(me.Width, menormalheight);
                        me.Top = this.Height - me.Height - 150;
                    }
                    me.Image = meimagesblock[memove, nowmeimage];
                    nowmeimage -= 1;
                }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            GameData.mewidth = me.Width;

            if (presstimes % 2 == 0)
            {
                if (meattackmovement == "attack")
                {
                    if (nowmeattackimage == meattackimagecount - 1)
                    {
                        me.Image = meimagesattackone[memove, nowmeattackimage];
                        meattackmovement = "reset";
                        bosshearttext.Text = bossheart.Value.ToString();
                    }
                    else
                    {
                        if (nowmeattackimage >= 1)
                        {
                            me.Size = new Size(mewalkwidth, me.Height);
                            attack = true;
                        }
                        me.Image = meimagesattackone[memove, nowmeattackimage];
                        nowmeattackimage += 1;
                        if (bossheart.Value - 1 > 0)
                        {
                            bossheart.Value -= 1;
                        }
                        else
                        {
                            GameData.ifwin = true;
                            debugtext.Text = "endgame";
                        }
                        bosshearttext.Text = bossheart.Value.ToString();
                        
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
                        me.Image = meimagesattacktwo[memove, nowmeattackimage];
                        me.Size = new Size(menormalwidth, me.Height);
                        
                        GameData.mewidth = me.Width;
                        GameData.meleft = me.Left;
                        me.Image = meimagesattackone[memove, nowmeattackimage];
                        timer6.Enabled = false;
                        attack = false;
                    }
                    else
                    {
                        me.Image = meimagesattackone[memove, nowmeattackimage];
                        nowmeattackimage -= 1;
                    }
                }
            }
            else
            {
                if (meattackmovement == "attack")
                {
                    if (nowmeattackimage == meattackimagecount - 1)
                    {
                        me.Image = meimagesattacktwo[memove, nowmeattackimage];
                        meattackmovement = "reset";
                        bosshearttext.Text = bossheart.Value.ToString();
                    }
                    else
                    {
                        if (nowmeattackimage >= 1)
                        {
                            me.Size = new Size(mewalkwidth, me.Height);
                        }
                        me.Image = meimagesattacktwo[memove, nowmeattackimage];
                        if (bossheart.Value - 1 > 0)
                        {
                            bossheart.Value -= 1;
                        }
                        else
                        {
                            GameData.ifwin = true;
                            debugtext.Text = "endgame";
                        }
                        bosshearttext.Text = bossheart.Value.ToString();
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
                        me.Image = meimagesattacktwo[memove, nowmeattackimage];
                        me.Size = new Size(menormalwidth, me.Height);
                        GameData.mewidth = me.Width;
                        GameData.meleft = me.Left;
                        timer6.Enabled = false;
                        attack = false;
                    }
                    else
                    {
                        me.Image = meimagesattacktwo[memove, nowmeattackimage];
                        nowmeattackimage -= 1;
                    }
                }
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            GameData.mewidth = me.Width;
            GameData.meleft = me.Left;
            if (startwalk)
            {
                if (nowwalkimage >= 6)
                {
                    nowwalkimage = 2;
                }
                nowwalkimage += 1;
                if (nowwalkimage >= 1)
                {
                    me.Size = new Size(mewalkwidth, me.Height);
                }
                me.Image = mewalkimages[memove, nowwalkimage];
            }
            else
            {
                if (nowwalkimage > 0)
                {
                    nowwalkimage -= 1;
                    me.Image = mewalkimages[memove, nowwalkimage];
                }
                else
                {
                    me.Size = new Size(menormalwidth, me.Height);
                    GameData.mewidth = me.Width;
                    GameData.meleft = me.Left;
                    timer8.Enabled = false;
                    walking = false;
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

        public int minusmeheart
        {
            set
            {
                if (myheart.Value - value <= 0)
                {
                    GameData.ifwin = false;
                    GameData.sendstatustobackground("endgame");
                }
                else
                {
                    myheart.Value -= value;
                }
            }
            get
            {
                return myheart.Value;
            }
        }

        public int addheart
        {
            set
            {
                if(myheart.Value+value > myheart.Maximum)
                {
                    myheart.Value = myheart.Maximum;
                }
                else
                {
                    myheart.Value += value;
                    myhearttext.Text = myheart.Value.ToString();
                }
            }
            get
            {
                return myheart.Value;
            }
        }

        public int minusbossheart
        {
            set
            {
                bossheart.Value -= value;
            }
        }

        public void setmehearttext()
        {
            myhearttext.Text = myheart.Value.ToString();
        }

        public void setbosshearttext()
        {
            bosshearttext.Text = bossheart.Value.ToString();
        }

        public string setgamestatus
        {
            set
            {
                debugtext.Text = value;
            }
        }

        public gameformbackground GetGameformbackground
        {
            set
            {
                gameformbackground = value;
            }
        }
    }
}