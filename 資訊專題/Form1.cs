using System;
using System.Drawing;
using System.Drawing.Text;
using System.Media;
using System.Windows.Forms;

namespace 資訊專題
{
    public partial class Form1 : Form
    {
        /*宣告變數*/
        private Point x;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private PrivateFontCollection fontcollection = new PrivateFontCollection();

        /*初始化與視窗音樂控制*/

        public Form1()
        {
            InitializeComponent();
            x = new Point(this.Location.X, this.Location.Y);
            soundPlayer.SoundLocation = Application.StartupPath + "\\進場音樂.wav";
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            this.Font = font;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer.PlayLooping();
            int top = this.Height - 40 - button1.Height;
            int distance = (this.Width - button1.Width - button2.Width - button3.Width) / 4;
            button1.Top = top;
            button2.Top = top;
            button3.Top = top;
            button1.Left = distance;
            button2.Left = button1.Left + button1.Width + distance;
            button3.Left = button2.Left + button2.Width + distance;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                soundPlayer.PlayLooping();
            }
            else
            {
                soundPlayer.Stop();
            }
        }

        /*底部按鈕*/

        private void leavegame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            infoform infoform = new infoform();
            infoform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameformboss gameformbackground = new gameformboss();
            gameform gameform = new gameform();
            gameformbackground gameformbackground1 = new gameformbackground();
            GameData.gameformbackground = gameformbackground;
            GameData.gameform = gameform;
            gameform.GetForm1 = this;
            gameform.GetGameformbackground = gameformbackground1;
            gameformbackground.getformposition = new Point(this.Location.X, this.Location.Y);
            gameformbackground.getgameformsize = gameform.returnthisformsize;
            gameform.getfromlocation = new Point(this.Location.X, this.Location.Y);
            gameformbackground1.Show();
            gameformbackground.Show();
            gameform.Show();
            this.Visible = false;
        }

        /*事件監聽器*/

        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            if (debugtext.Text == "again")
            {
                gameformboss gameformbackground = new gameformboss();
                gameform gameform = new gameform();
                gameformbackground gameformbackground1 = new gameformbackground();
                GameData.gameformbackground = gameformbackground;
                GameData.gameform = gameform;
                gameform.GetForm1 = this;
                gameform.GetGameformbackground = gameformbackground1;
                gameformbackground.getformposition = new Point(this.Location.X, this.Location.Y);
                gameformbackground.getgameformsize = gameform.returnthisformsize;
                gameform.getfromlocation = new Point(this.Location.X, this.Location.Y);
                gameformbackground1.Show();
                gameformbackground.Show();
                gameform.Show();
                debugtext.Text = "debugtext";
            }
        }

        /*視窗間傳值*/

        public string getinfofromgame
        {
            set
            {
                debugtext.Text = value;
            }
        }
    }
}