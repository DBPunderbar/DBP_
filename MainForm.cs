using MySql.Data.MySqlClient;
//using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal.test
{
    public partial class MainForm : Form
    {
        private string userID = "";
        DataTable table = new DataTable();

        public MainForm(string userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        // 창 이동
        private bool onClick;
        private Point startPoint = new Point(0, 0);
        private void moveWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void moveWindow_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
            startPoint = new Point(e.X, e.Y);
        }
        private void moveWindow_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo mainForm3 = new UpdateInfo(userID);
            mainForm3.ShowDialog();
        }
        //↑여기까지
        //친구 테이블이 생성되었으니까 따로 수정 필요

        //main폼이 불러와질때 친구 버튼 클릭 이벤트로 연결해서 폼이 불러와질때 친구목록이 뜨도록..
        //여기에 문제는 버튼이 클릭될때마다 friendsPage 객체가 생성된다는 것..? ==> ㅠㅠ
        //근데 동적생성을 안하면(그러니까 메인폼 Designer에 넣는 방식으로 하면 userID를 생성자로 못넘겨..)
        //생성자로 보내는 방법 말고 다른 방법이 있다면 이 부분도 수정이 가능할텐데.
        private void buttonFriend_Click(object sender, EventArgs e)
        {
            friendsPage friendsPage1 = new friendsPage(userID);
            friendsPage1.Location = new Point(98, 39);
            //828, 543
            friendsPage1.Size = new Size(828, 543);

            Controls.Add(friendsPage1);
            friendsPage1.BringToFront();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SetColor()
        {
            panel1.BackColor = DarkMode.panelcolor;
            panel2.BackColor = DarkMode.panelcolor;
            messagesPage1.BackColor = DarkMode.backcolor;
            buttonDarkMode.Image = DarkMode.imgMode;
            buttonMin.ForeColor = DarkMode.fontcolor;
            buttonClose.ForeColor = DarkMode.fontcolor;
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
            DarkMode.changeMode();
            SetColor();
        }

        private void buttonChatting_Click(object sender, EventArgs e)
        {
            messagesPage1.BringToFront();
        }
    }

}
