using System.Drawing;

namespace 資訊專題
{
    internal class GameData
    {
        public static int bosswidth;
        public static int bossleft;
        public static int mewidth;
        public static int meleft;
        public static int meheart;
        public static int bossheart;
        public static int metop;
        public static bool iffreeze;
        public static bool block;
        public static bool ifwin;
        public static Point formpoint;
        public static Size formsize;
        public static gameform gameform;
        public static gameformboss gameformbackground;

        public static void minusmeheart()
        {
            meheart = (gameform.minusmeheart = 2);
        }

        public static void addmeheart()
        {
            meheart = (gameform.addheart = 2);
        }

        public static void setmeheart()
        {
            gameform.setmehearttext();
        }

        public static void sendstatustobackground(string status)
        {
            gameformbackground.setgamestatus = status;
        }

        public static void sendstatustomain(string status)
        {
            gameform.setgamestatus = status;
        }
    }
}