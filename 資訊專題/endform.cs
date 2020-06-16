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
        /*宣告變數*/
        gameform gameform=new gameform();
        Form1 form1 = new Form1();
        bool needagain;
        Point x;
        PrivateFontCollection fontcollection = new PrivateFontCollection();

        /*初始化*/
        public endform(Form1 menu,gameform form)
        {
            InitializeComponent();
            gameform = form;
            gameform.getresult = "endgame";
            form1 = menu;
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            this.Font = font;
        }

        private void endform_Load(object sender, EventArgs e)
        {
            this.Location = x;
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
        
        public Point getfromlocation
        {
            set
            {
                x = value;
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
