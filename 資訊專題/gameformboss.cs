using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 資訊專題
{
    public partial class gameformboss : Form
    {
        Point x;
        public gameformboss()
        {
            InitializeComponent();
        }

        private void gameformboss_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            boss.Top = this.Height - boss.Height - 100;
        }

        public Size getgameformsize
        {
            set
            {
                Size = value;
            }
        }

        public Point getformposition
        {
            set
            {
                x = value;
            }
        }
    }
}
