using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal.test
{
    public partial class friendsPage : UserControl
    {
        private List<string> groupBoxInTexts = new List<string>();
        //그룹박스를 동적생성 해서 누가 이벤트를 발생시켰는지 알기 위해 선언한 전역변수
        public friendsPage()
        {

        }

        public friendsPage(string userID)
        {
            InitializeComponent();

            this.userID = userID;
            myProfileLoad();
            friendsProfileLoad(userID);
        }

        private string userID = "";
        /*
        DataTable table = new DataTable();

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                string query = "SELECT * FROM s5584534.user WHERE userID='" + textBoxSearch.Text + "';";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr == null)
                    MessageBox.Show("일치하는 ID가 없습니다.");
                else
                    textBoxSearchResult.Text = rdr["userID"].ToString() + "\t" + rdr["name"].ToString();

                conn.Close();
            }
        }
        /*
        public void searchData(string valueToSearch)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                string query = "SELECT * FROM s5584534.user WHERE userID='" + textBoxSearch.Text + "';";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr == null)
                    MessageBox.Show("일치하는 ID가 없습니다.");
                else
                    textBoxSearchResult.Text = rdr["userID"].ToString();

                conn.Close();
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                if (textBoxSearchResult.Text == "")
                {
                    MessageBox.Show("검색 정보를 입력해주세요");
                }
                else
                {
                    string query = "INSERT INTO friends(userID, friendID) VALUES ('" + userID + "', '" + textBoxSearchResult.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    //텍스트 박스 초기화
                    textBoxSearchResult.Text = "";
                }

            }
        }
        */
        public void myProfileLoad()
        {
            GroupBox groupBoxMyProfile = new GroupBox();

            groupBoxMyProfile.Text = "";
            groupBoxMyProfile.Location = new Point(150, 30);

            groupBoxMyProfile.Width = 650;
            groupBoxMyProfile.Height = 160;

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

                //userID로 바꾸기
                string query = "SELECT * FROM user WHERE userID = '" + userID + "'";
                //string query = "INSERT INTO user(ID, userID, userPW, name, addr, nickname, profileImage) VALUES (NULL, '" + textBoxID.Text + "', '" + textBoxPW.Text + "', '" + textBoxName.Text + "', '" + textBoxAddr.Text + "', '" + textBoxNickname.Text + "', @Image)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                byte[] bImage = null;
                while (rdr.Read())
                {
                    Mynickname.Text = rdr["nickname"].ToString();
                    Myrole.Text = "[" + rdr["role"].ToString() + "]";
                    MystateMessage.Text = rdr["stateMessage"].ToString();
                    bImage = (byte[])rdr["profileImage"];
                }
                if (bImage != null)
                {
                    pictureBoxMyProfile.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBoxMyProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                rdr.Close();
            }
        }

        public void friendsProfileLoad(string ID)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();
                List<string> friendIDArray = new List<string>();

                string friendSearchQuery = "SELECT friendID FROM friends WHERE userID = '" + ID + "'"; //userID + "'";
                MySqlCommand cmd2 = new MySqlCommand(friendSearchQuery, conn);
                MySqlDataReader readerFriends = cmd2.ExecuteReader();

                //friendID들을 리스트에 넣기
                while (readerFriends.Read())
                {
                    friendIDArray.Add(readerFriends["friendID"].ToString());
                }
                readerFriends.Close();
                conn.Close();

                //1. 데이터테이블
                //2. for로 돌리기..

                conn.Open();
                for (int i = 0; i < friendIDArray.Count; i++)
                {
                    string friendInfoSearch = "SELECT * FROM user WHERE userID = '" + friendIDArray[i] + "'";
                    MySqlCommand cmdFriendSearch = new MySqlCommand(friendInfoSearch, conn);
                    MySqlDataReader readerFrienInfo = cmdFriendSearch.ExecuteReader();
                    readerFrienInfo.Read();

                    GroupBox groupBoxFriend = new GroupBox();
                    groupBoxFriend.Location = new Point(190, i * 150 + 200);
                    Controls.Add(groupBoxFriend);
                    groupBoxFriend.MouseClick += GroupBoxFriend_MouseClick;
                    groupBoxFriend.Tag = i;

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

                    byte[] friendbImage = null;

                    friendnickname.Text = readerFrienInfo["nickname"].ToString();

                    //role과 상태메시지, 프로필 이미지는 notNull이 아니기 때문에 null이 불러와질 수 있음
                    if (readerFrienInfo["role"] == System.DBNull.Value)
                        friendrole.Text = "";
                    else
                        friendrole.Text = "[" + readerFrienInfo["role"].ToString() + "]";

                    if (readerFrienInfo["stateMessage"] == System.DBNull.Value)
                        friendstateMessage.Text = "";
                    else
                        friendstateMessage.Text = readerFrienInfo["stateMessage"].ToString();

                    //프로필이미지가 없을 경우 기본 이미지 불러오기
                    if (readerFrienInfo["profileImage"] == System.DBNull.Value)
                    {
                        var ms = new MemoryStream();
                        string imagePath = "C:\\Users\\김서지\\게임\\메이플\\이또님_블로그_모바일.jpg";
                        Image standardImage = Image.FromFile(imagePath);

                        if (standardImage != null)
                        {
                            pictureBoxFriendProfile.Image = (Image)standardImage;
                            pictureBoxFriendProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        friendbImage = (byte[])readerFrienInfo["profileImage"];
                        if (friendbImage != null)
                        {
                            pictureBoxFriendProfile.Image = new Bitmap(new MemoryStream(friendbImage));
                            pictureBoxFriendProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    readerFrienInfo.Close();
                }

            }
        }

        private void GroupBoxFriend_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add("삭제");
                menu.ItemClicked += new ToolStripItemClickedEventHandler(Menu_ItemClicked);

                groupBoxInTexts.Clear();
                //이벤트가 발생한 '그' 그룹박스 내의 컨트롤 들의 text를 모두 list에 저장
                foreach (Control control in ((GroupBox)sender).Controls)
                {
                    //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                    //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
                    groupBoxInTexts.Add(control.Text);
                }
                menu.Show((GroupBox)sender, new Point(e.X, e.Y));
            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "삭제":
                    //현재 groupBoxInTexts에 담긴 모든 text를 불러와서 
                    //select로 nickname, role이 맞는 사람(친구)를 알아내고 그 친구의 userID로                //role이 null이면 결과가 안나와서 pk로만 검색해야할듯
                    string whoQuery = "SELECT * FROM user WHERE nickname = '" + groupBoxInTexts[1] + "'"; //AND role = '" + groupBoxInTexts[2] + "' AND stateMessage = '" + groupBoxInTexts[3] + "'";
                    //using
                    using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(whoQuery, conn);
                        MySqlDataReader rdr = cmd.ExecuteReader();

                        //rdr.read
                        rdr.Read();

                        //string friendUserID = rdr[userID].toString();
                        string friendUserID = rdr["userID"].ToString();
                        rdr.Close();
                        //friends table에서 삭제한 후 다시 load      
                        //string DeleteFriendQuery = "DELETE FROM friends WHERE friendID = " + friendUserID;
                        //잠시만 이렇게 하면 friendUserID가 저거인 게 모두 없어지니까 userID도 조건을 걸어야 할듯
                        string DeleteFriendQuery = "DELETE FROM friends WHERE friendID = '" + friendUserID + "' AND userID = '" + userID + "'"; //userID
                        MySqlCommand cmdDelete = new MySqlCommand(DeleteFriendQuery, conn);
                        cmdDelete.ExecuteNonQuery();

                        GroupBoxsRemove();
                        myProfileLoad();
                        friendsProfileLoad(userID);
                    }
                    break;
            }
        }
        private void GroupBoxsRemove()
        {
            //foreach로 하니까 컨트롤 내에서 컨트롤이 없어지면 count는 그대로인데 control 전체 수는 작아져서 마지막 컨트롤 삭제를 못함
            //ex) 전체 컨트롤 수가 4개인데 한개를 삭제하면 전체 수가 3개로 줄지만 4번째 컨트롤을 삭제를 못함
            //foreach (Control control in this.Controls)
            //{
            //    if (control is GroupBox)
            //    {
            //        control.MouseClick -= GroupBoxFriend_MouseClick;
            //        //this.Controls.Remove(control);
            //        control.Dispose();
            //    }
            //}

            //위의 foreach에서의 문제를 해결하기 위해 뒤에서부터 없애기로 함
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is GroupBox)
                {
                    //this.Controls[i].MouseClick -= GroupBoxFriend_MouseClick;
                    this.Controls[i].Dispose();
                }
            }
        }
    }
}
