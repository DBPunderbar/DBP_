using Modal.test.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.test
{
    class DarkMode
    {
        public static Color fontcolor;
        public static Color backcolor;
        public static Color panelcolor;
        public static Image imgMode;

        public static bool on = false;

        public static void changeMode()
        {
            if (on)
            {
                SetarModeClear();
            }
            else
            {
                SetarModeDark();
            }
        }

        private static void SetarModeDark()
        {
            imgMode = Resources.dark;
            fontcolor = Color.Black;
            backcolor = Color.FromArgb(242, 242, 242);
            panelcolor = Color.FromArgb(191, 191, 191);
            on = true;
        }

        private static void SetarModeClear()
        {
            imgMode = Resources.bright;
            fontcolor = Color.White;
            backcolor = Color.FromArgb(51, 51, 51);
            panelcolor = Color.FromArgb(38, 38, 38);
            on = false;
        }
    }
}
