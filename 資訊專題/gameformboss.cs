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
