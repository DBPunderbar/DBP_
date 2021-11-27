﻿using MySql.Data.MySqlClient;
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

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string userID)
        {
            InitializeComponent();
            this.userID = userID;
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
        private void buttonFriend_Click(object sender, EventArgs e)
        {
            friendsPage1.BringToFront();

            //친구 버튼을 클릭하면 그룹박스를 동적생성해
            //첫번째 버튼은 본인 프로필
            //두번째부터는 친구 프로필

            //버튼에는 프로필 사진, 별명, 상태메시지, 

            GroupBox groupBoxMyProfile = new GroupBox();

            groupBoxMyProfile.Text = "";
            groupBoxMyProfile.Location = new Point(150, 30);

            groupBoxMyProfile.Width = 650;
            groupBoxMyProfile.Height = 160;

            //본인 프로필 동적생성
            PictureBox pictureBoxMyProfile = new PictureBox();
            pictureBoxMyProfile.Location = new Point(25, 25);
            pictureBoxMyProfile.Width = 120;
            pictureBoxMyProfile.Height = 120;

            groupBoxMyProfile.Controls.Add(pictureBoxMyProfile);

            Label Mynickname = new Label();
            Mynickname.Location = new Point(215, 45);
            groupBoxMyProfile.Controls.Add(Mynickname);

            Label Myrole = new Label();
            Myrole.Location = new Point(175, 45);
            groupBoxMyProfile.Controls.Add(Myrole);


            Label MystateMessage = new Label();
            MystateMessage.Location = new Point(175, 80);
            groupBoxMyProfile.Controls.Add(MystateMessage);

            Controls.Add(groupBoxMyProfile);

            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();
                string query = "SELECT * FROM user WHERE userID = '" + userID + "'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                byte[] bImage = null;
                string[] friends = null;

                //DB에서 불러와 본인 프로필 작성
                while (rdr.Read())
                {
                    Mynickname.Text = rdr["nickname"].ToString();
                    Myrole.Text = "[" + rdr["role"].ToString() + "]";
                    MystateMessage.Text = rdr["stateMessage"].ToString();
                    friends = rdr["friendsID"].ToString().Split(',');
                    bImage = (byte[])rdr["profileImage"];
                }
                if (bImage != null)
                {
                    pictureBoxMyProfile.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBoxMyProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                rdr.Close();


                //친구 컬럼을 읽어 친구 수만큼 동적생성
                for (int i = 0; i < friends.Length; i++)
                {
                    GroupBox groupBoxFriend = new GroupBox();
                    groupBoxFriend.Location = new Point(190, i * 150 + 200);
                    Controls.Add(groupBoxFriend);
                    //그룹박스에서 우클릭을 하면 삭제할 수 있도록 이벤트설정 ==> 아직 안함
                    //groupBoxFriend.MouseClick += GroupBoxFriend_MouseClick;

                    groupBoxFriend.Text = "";

                    groupBoxFriend.Width = 600;
                    groupBoxFriend.Height = 150;

                    PictureBox pictureBoxFriendProfile = new PictureBox();
                    pictureBoxFriendProfile.Location = new Point(25, 25);
                    pictureBoxFriendProfile.Width = 100;
                    pictureBoxFriendProfile.Height = 100;

                    groupBoxFriend.Controls.Add(pictureBoxFriendProfile);

                    Label friendnickname = new Label();
                    friendnickname.Location = new Point(190, 45);
                    groupBoxFriend.Controls.Add(friendnickname);

                    Label friendrole = new Label();
                    friendrole.Location = new Point(150, 45);
                    groupBoxFriend.Controls.Add(friendrole);

                    Label friendstateMessage = new Label();
                    friendstateMessage.Location = new Point(150, 80);
                    groupBoxFriend.Controls.Add(friendstateMessage);

                    string friendQuery = "SELECT * FROM user WHERE ID =" + Convert.ToInt32(friends[i]);

                    MySqlCommand friendCmd = new MySqlCommand(friendQuery, conn);
                    MySqlDataReader friendRdr = friendCmd.ExecuteReader();

                    byte[] friendbImage = null;
                    while (friendRdr.Read())
                    {
                        friendnickname.Text = friendRdr["nickname"].ToString();
                        friendrole.Text = "[" + friendRdr["role"].ToString() + "]";
                        friendstateMessage.Text = friendRdr["stateMessage"].ToString();
                        friendbImage = (byte[])friendRdr["profileImage"];
                    }
                    if (friendbImage != null)
                    {
                        pictureBoxFriendProfile.Image = new Bitmap(new MemoryStream(friendbImage));
                        pictureBoxFriendProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    friendRdr.Close();
                }
                conn.Close();
            }
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
            friendsPage1.BackColor = DarkMode.backcolor;
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
