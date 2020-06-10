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
        Form1 form1 = new Form1();
        bool needagain, block;
        Point x;
        WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();
        SoundPlayer soundPlayer = new SoundPlayer();
        PrivateFontCollection fontcollection = new PrivateFontCollection();
        ImageList[] imageList = new ImageList[2];
        int memove;
        int jump = 20;
        int oritop;
        Random random = new Random();

        public gameform()
        {
            InitializeComponent();
            this.KeyPreview = true;
            myhearttext.Text = myheart.Maximum.ToString();
            bosshearttext.Text = bossheart.Maximum.ToString();
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            this.Font = font;
            block = false;
            bossmove.Text = "left";
            imageList[0] = imageList1;
            imageList[1] = imageList2;
            oritop = me.Top;
        }

        public string getresult
        {
            set
            {
                debugtext.Text = value;
            }
        }

        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                wmplayer.URL = Application.StartupPath + "\\遊戲中背景音樂.wav";
                wmplayer.settings.setMode("loop", true);
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else if(debugtext.Text == "again")
            {
                form1.getinfofromgame = "again";
                debugtext.Text = "again";
                needagain = true;
                wmplayer.close();
                this.Close();
                this.Dispose();
            }
            else if(debugtext.Text == "backtomenu")
            {
                debugtext.Text = "backtomenu";
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
                endform endform = new endform(form1, this, x);
                endform.ShowDialog();
            }
        }
        public Form1 GetForm1
        {
            set
            {
                form1 = value;
            }
        }

        private void gameform_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x.X, x.Y);
            me.Image = imageList1.Images[0];
            debugtext.Text = "startgame";
            
        }

        public Point getfromlocation
        {
            set
            {
                x = new Point(value.X, value.Y);
            }
        }

        private void gameform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needagain == false)
            {
                form1.Visible = true;
                wmplayer.close();
            }
        }

        private void gameform_KeyDown(object sender, KeyEventArgs e)
        {
            if(debugtext.Text == "startgame")
            {
                if (e.KeyCode == Keys.Space)
                {
                    me.Image = imageList[memove].Images[1];
                    block = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (me.Left - 10 >= 0)
                    {
                        me.Left -= 10;
                        memove = 1;
                        me.Image = imageList[memove].Images[0];
                        block = false;
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (me.Left + 10 <= this.Width - 20 - me.Width)
                    {
                        me.Left += 10;
                        memove = 0;
                        me.Image = imageList[memove].Images[0];
                        block = false;
                    }
                }
                if(e.KeyCode == Keys.Z)
                {
                    if (me.Left + me.Width > boss.Left && me.Left<boss.Left+boss.Width)
                    {
                        block = false;
                        if(bossheart.Value - 10 > 0)
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
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    timer3.Enabled = true;
                }
            }
        }

        private void me_LocationChanged(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(bossmove.Text == "left")
            {
                if (boss.Left - 10 >= 0)
                {
                    boss.Left -= 10;
                }
            }
            else if(bossmove.Text == "right")
            {
                if (boss.Left + 10 <= this.Width - 20 - boss.Width)
                {

                    boss.Left += 10;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            me.Top -= jump;

            if (me.Top < 70) jump = 0 - jump;

            if (me.Top > oritop)
            {
                jump = 0 - jump;
                timer3.Enabled = false;
            }
        }

        private void gameform_KeyUp(object sender, KeyEventArgs e)
        {
            if (debugtext.Text == "startgame")
            {
                if (e.KeyCode == Keys.Space)
                {
                    me.Image = imageList[memove].Images[0];
                    block = false;
                }
            }
        }
    }
}
