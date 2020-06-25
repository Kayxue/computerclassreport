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
        int memove, bossmoveint, nowmeimage, meimagecount = 5, nowbossimage, bossimagecount = 3;            
        bool needagain, block, attack, resume;
        string meblockpicturemovement = "block", meattackmovement = "attack", bossattackmovement = "attack";
        Form1 form1 = new Form1();
        gameformbackground gameformbackground = new gameformbackground();
        Point x;
        Image[,] meimagesblock;
        Image[,] bossimages;
        Image[,] meimagesattack;
        WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();
        SoundPlayer meattacksound = new SoundPlayer();
        PrivateFontCollection fontcollection = new PrivateFontCollection();
        Random random = new Random();

        /*初始化與視窗關閉*/
        public gameform()
        {
            InitializeComponent();
            meattacksound.SoundLocation = Application.StartupPath + "\\";               //載入音樂
            this.KeyPreview = true;                                                     //讓form優先接受鍵盤按下事件
            myhearttext.Text = myheart.Maximum.ToString();                              //設定我方血量
            bosshearttext.Text = bossheart.Maximum.ToString();                          //設定boss血量
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");     //將自備字體載入私有字體集
            Font font = new Font(fontcollection.Families[0], 20);                       //建立字體物件
            this.Font = font;                                                           //設定此Form字體
            block = false;                                                              //設定現在不是格擋狀態
            bossmove.Text = "left";                                                     //設定敵方向左移動
            meimagesblock = new Image[,] {
                { Image.FromFile("主角 站立.png"), Image.FromFile("主角 格擋1.png"), Image.FromFile("主角 格擋2.png") , Image.FromFile("主角 格擋3.png"), Image.FromFile("主角 格擋4.png")},
                { Image.FromFile("主角 站立1.png"), Image.FromFile("主角 格擋1(1).png"), Image.FromFile("主角 格擋2(1).png"), Image.FromFile("主角 格擋3(1).png"), Image.FromFile("主角 格擋4(1).png") } 
            };                                                                          //載入我方角色圖片
            bossimages = new Image[,] { 
                { Image.FromFile("魔王 初始.png"), Image.FromFile("魔王 攻擊1.png"), Image.FromFile("魔王 攻擊2.png") }, 
                { Image.FromFile("魔王 初始(1).png"), Image.FromFile("魔王 攻擊1(1).png"), Image.FromFile("魔王 攻擊2(1).png") } 
            };                                                                          //載入敵方角色圖片
            nowmeimage = 0;                                                             //我方造型設定顯示第0張
            nowbossimage = 0;                                                           //敵方造型設定顯示第0張
            resume = false;                                                             //設定遊戲是視窗開啟後要開始不是從結束暫停後要開始
        }

        private void gameform_Load(object sender, EventArgs e)
        {
            this.Location = x;                                              //設定視窗座標
            this.BackColor = Color.White;                                   //設定視窗背景
            this.TransparencyKey = this.BackColor;                          //視窗與角色透明
            me.Image = meimagesblock[0, 0];                                 //設定我方造型
            boss.Image = bossimages[0, 0];                                  //設定敵方造型
            myheart.Size = new Size(this.Width, myheart.Height);            //重新設定我方血條長度
            bossheart.Size = new Size(this.Width, myheart.Height);          //重新設定敵方血條長度
            myheart.Top = this.Height - myheart.Height;                     //重新設定我方血條在視窗中位置
            myhearttext.Left = this.Width - myhearttext.Width - 20;         //重新設定我方血量顯示位置（X軸）
            myhearttext.Top = this.Height - 110 - myhearttext.Height;       //重新設定我方血量顯示位置（Y軸）
            bosshearttext.Left = this.Width - bosshearttext.Width - 20;     //重新設定敵方血量顯示位置（X軸）
            me.Top = this.Height - me.Height - 150;                         //重新設定我方顯示位置
            boss.Top = this.Height - boss.Height - 100;                     //重新設定敵方顯示位置（Y軸）
            boss.Left = this.Width - 20 - boss.Width;                       //重新設定敵方顯示位置（X軸）
            bossmoveint = 0;                                                //設定目前敵方移動方向
            debugtext.Text = "startgame";                                   //設定遊戲狀態為開始
        }

        private void gameform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needagain == false)                                         //如果不再玩一次
            {
                form1.Visible = true;                                       //form1顯示
                gameformbackground.Close();                                 //背景圖示窗關閉
                wmplayer.close();                                           //關閉背景音樂播放器
                meattacksound.Dispose();                                    //摧毀我方攻擊音效播放物件
            }
        }

        /*遊戲監聽器*/
        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            if (debugtext.Text == "startgame")                                      //若遊戲狀態為開始
            {
                if(resume == false)                                                 //若不是從暫停中繼續
                {
                    wmplayer.URL = Application.StartupPath + "\\遊戲中背景音樂.wav";//設定播放音檔路徑並播放
                    wmplayer.settings.setMode("loop", true);                        //設定播放模式
                }
                else                                                                //若從暫停中繼續
                {
                    wmplayer.controls.play();                                       //純粹繼續播放音樂，不用再創造播放器
                }
                this.TopMost = true;                                                //設定視窗常駐本程式最上層
                timer1.Enabled = true;                                              //敵方偵測是否需切換方向計時器啟動
                timer3.Enabled = true;                                              //敵方移動計時器啟動
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
                            me.Image = meimagesblock[memove, 0];
                            block = false;
                        }
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        if (me.Left + 10 <= this.Width - 20 - me.Width)
                        {
                            me.Left += 10;
                            memove = 0;
                            me.Image = meimagesblock[memove, 0];
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
                    me.Image = meimagesblock[memove, nowmeimage];
                    nowmeimage -= 1;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (bossattackmovement == "attack")
            {

            }
            else
            {

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
