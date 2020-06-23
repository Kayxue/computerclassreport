using System;
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
    public partial class pauseform : Form
    {
        gameform gameform = new gameform();
        PrivateFontCollection fontcollection = new PrivateFontCollection();
        bool buttonclicked = false;
        public pauseform(gameform game)
        {
            InitializeComponent();
            int distance;
            gameform = game;
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 18);
            label1.Font = font;
            continuegame.Font = font;
            restart.Font = font;
            backtomenu.Font = font;
            label1.Left = ((this.Width - 20) / 2) - (label1.Width / 2);
            continuegame.Left = ((this.Width - 20) / 2) - (continuegame.Width / 2);
            restart.Left = ((this.Width - 20) / 2) - (restart.Width / 2);
            backtomenu.Left = ((this.Width - 20) / 2) - (backtomenu.Width / 2);
            distance = (this.Height - 40 - label1.Height - continuegame.Height - restart.Height - backtomenu.Height) / 5;
            label1.Top = distance;
            continuegame.Top = label1.Top + label1.Height + distance;
            restart.Top = continuegame.Top + continuegame.Height + distance;
            backtomenu.Top = restart.Top + restart.Height + distance;

        }

        private void continuegame_Click(object sender, EventArgs e)
        {
            buttonclicked = true;
            this.Close();
            gameform.getresult = "startgame";
            this.Dispose();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            buttonclicked = true;
            this.Close();
            gameform.getresult = "again";
            this.Dispose();
        }

        private void backtomenu_Click(object sender, EventArgs e)
        {
            buttonclicked = true;
            this.Close();
            gameform.getresult = "backtomenu";
            this.Dispose();
        }

        private void pauseform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (buttonclicked == false)
            {
                gameform.getresult = "startgame";
                this.Dispose();
            }
        }
    }
}
