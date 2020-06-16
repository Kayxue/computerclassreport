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
    public partial class gameformbackground : Form
    {
        /*變數*/
        Point x;
        Size gameformsize;

        /*初始化*/
        public gameformbackground()
        {
            InitializeComponent();
        }

        private void gameformbackground_Load(object sender, EventArgs e)
        {
            this.Location = x;
            this.Size = gameformsize;
        }

        /*傳值*/
        public Point getformposition
        {
            set
            {
                x = value;
            }
        }

        public Size getgameformsize
        {
            set
            {
                gameformsize = value;
            }
        }

        public Point setgameformbackgroundlocation
        {
            set
            {
                this.Location = value;
            }
        }
        
    }
}
