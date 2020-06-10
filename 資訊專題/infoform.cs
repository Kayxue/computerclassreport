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
    public partial class infoform : Form
    {
        PrivateFontCollection fontcollection = new PrivateFontCollection();
        public infoform()
        {
            InitializeComponent();
            fontcollection.AddFontFile(Application.StartupPath + "\\新特明體.TTC");
            Font font = new Font(fontcollection.Families[0], 20);
            Font fonttitle = new Font(fontcollection.Families[0], 24);
            this.Font = font;
            ruletitle.Font = fonttitle;
            ruleinfo.Font = font;
            controltitle.Font = fonttitle;
            controlinfo.Font = font;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
