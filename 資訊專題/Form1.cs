using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 資訊專題
{
    public partial class Form1 : Form
    {
        Point x;
        SoundPlayer soundPlayer = new SoundPlayer();
        PrivateFontCollection fontcollection = new PrivateFontCollection();

        public Form1()
        {
            InitializeComponent();
            x = new Point(this.Location.X, this.Location.Y);
            soundPlayer.SoundLocation = Application.StartupPath + "\\進場音樂.wav";
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            this.Font = font;
        }

        private void leavegame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            infoform infoform = new infoform();
            infoform.ShowDialog();
        }
        public string getinfofromgame
        {
            set
            {
                debugtext.Text = value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameform gameform = new gameform();
            gameform.GetForm1 = this;
            gameform.getfromlocation = new Point(this.Location.X, this.Location.Y);
            gameform.Show();
            this.Visible=false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            
        }

        private void debugtext_TextChanged(object sender, EventArgs e)
        {
            if(debugtext.Text == "again")
            {
                gameform gameform = new gameform();
                gameform.GetForm1 = this;
                gameform.getfromlocation = new Point(this.Location.X, this.Location.Y);
                gameform.Show();
                debugtext.Text = "debugtext";
            }
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == true)
            {
                soundPlayer.PlayLooping();
            }
            else
            {
                soundPlayer.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer.PlayLooping();
        }


    }
}
