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
    public partial class endform : Form
    {
        gameform gameform=new gameform();
        Form1 form1 = new Form1();
        bool needagain;
        Point x;
        PrivateFontCollection fontcollection = new PrivateFontCollection();
        public endform(Form1 menu,gameform form,Point form1point)
        {
            InitializeComponent();
            gameform = form;
            gameform.getresult = "endgame";
            form1 = menu;
            this.Location = new Point(form1point.X, form1point.Y);
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            this.Font = font;
        }

        private void again_Click(object sender, EventArgs e)
        {
            gameform.getresult = "again";
            needagain = true;
            this.Close();
            this.Dispose();
        }

        private void backtomenu_Click(object sender, EventArgs e)
        {
            gameform.getresult = "backtomenu";
            needagain = false;
            form1.Visible = true;
            this.Close();
            this.Dispose();
        }


        private void endform_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x.X, x.Y);
        }
        public Point getfromlocation
        {
            set
            {
                x = new Point(value.X, value.Y);
            }
        }

        private void endform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needagain == false)
            {
                gameform.getresult = "backtomenu";
                form1.Visible = true;
                this.Close();
                this.Dispose();
            }
        }
    }
}
