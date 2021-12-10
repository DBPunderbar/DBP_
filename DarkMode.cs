using DBP.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBP
{
    class DarkMode
    {
        public static Color fontcolor;
        public static Color backcolor;
        public static Color panelcolor;
        public static Image imgMode;
        public static Image imgMode_fbtn;
        public static Image imgMode_cbtn;
        public static Image imgMode_fadd;

        public static bool on = false;

        public static void changeMode(string userID)
        {
            if (on)
            {
                DBManager.GetDBManager().SqlNonReturnCommand("UPDATE user SET DarkFlag = '1' WHERE userID = '" + userID + "'");
                SetarModeClear();
            }
            else
            {
                DBManager.GetDBManager().SqlNonReturnCommand("UPDATE user SET DarkFlag = '0' WHERE userID = '" + userID + "'");
                SetarModeDark();
            }
        }

        public static void SetarModeDark()
        {
            imgMode = Resources.dark;
            imgMode_fbtn = Resources.friend_c;
            imgMode_cbtn = Resources.message_nc;
            imgMode_fadd = Resources.addfriend_b;
            fontcolor = Color.DarkSlateBlue;
            backcolor = Color.FromArgb(0, 0, 0);
            panelcolor = Color.Lavender;
            on = true;
        }

        public static void SetarModeClear()
        {
            imgMode = Resources.bright;
            imgMode_fbtn = Resources.friend_c_b;
            imgMode_fadd = Resources.addFriend_d;
            imgMode_cbtn = Resources.message_c_b;
            fontcolor = Color.DarkSlateBlue;
            backcolor = Color.FromArgb(51, 51, 51);
            panelcolor = Color.FromArgb(38, 38, 38);
            on = false;
        }
    }
}
