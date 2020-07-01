using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace 資訊專題
{
    public partial class infoform : Form
    {
        /*宣告變數*/
        private PrivateFontCollection fontcollection = new PrivateFontCollection();

        /*初始化*/

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

        /*其他元件*/

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}