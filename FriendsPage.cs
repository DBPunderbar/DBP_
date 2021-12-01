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
            groupBoxMyProfile.Location = new Point(15, 50);

            groupBoxMyProfile.Width = 650;
            groupBoxMyProfile.Height = 160;
            groupBoxMyProfile.MouseClick += GroupBoxFriend_MouseClick;

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

            DataTable dataTableMyProfile = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE userID = '" + userID + "'");
            DataRow dataRowMyProfile = dataTableMyProfile.Rows[0];

            byte[] bImage = null;

            Mynickname.Text = dataRowMyProfile["nickname"].ToString();
            Myrole.Text = "[" + dataRowMyProfile["role"].ToString() + "]";
            MystateMessage.Text = dataRowMyProfile["stateMessage"].ToString();
            bImage = (byte[])dataRowMyProfile["profileImage"];

            if (bImage != null)
            {
                pictureBoxMyProfile.Image = new Bitmap(new MemoryStream(bImage));
                pictureBoxMyProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void friendsProfileLoad(string ID)
        {
            List<string> friendIDArray = new List<string>();
            DataTable friendsID = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT friendID FROM friends WHERE userID = '" + ID + "'");

            int i = 0;
            foreach (DataRow dataRow in friendsID.Rows)
            {
                DataTable friendInfo = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE userID = '" + dataRow["friendID"].ToString() + "'");
                DataRow friendInfoRow = friendInfo.Rows[0];

                GroupBox groupBoxFriend = new GroupBox();
                groupBoxFriend.Location = new Point(45, i * 150 + 220);
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



                //role과 상태메시지, 프로필 이미지는 notNull이 아니기 때문에 null이 불러와질 수 있음
                if (friendInfoRow["role"] == System.DBNull.Value)
                    friendrole.Text = "";
                else
                    friendrole.Text = "[" + friendInfoRow["role"].ToString() + "]";

                if (friendInfoRow["stateMessage"] == System.DBNull.Value)
                    friendstateMessage.Text = "";
                else
                    friendstateMessage.Text = friendInfoRow["stateMessage"].ToString();

                friendnickname.Text = friendInfoRow["nickname"].ToString();

                //프로필이미지가 없을 경우 기본 이미지 불러오기
                if (friendInfoRow["profileImage"] == System.DBNull.Value)
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
                    friendbImage = (byte[])friendInfoRow["profileImage"];
                    if (friendbImage != null)
                    {
                        pictureBoxFriendProfile.Image = new Bitmap(new MemoryStream(friendbImage));
                        pictureBoxFriendProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                i++;
            }
        }

        private void GroupBoxFriend_MouseClick(object sender, MouseEventArgs e)
        {
            groupBoxInTexts.Clear();
            //이벤트가 발생한 '그' 그룹박스 내의 컨트롤 들의 text를 모두 list에 저장
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
                groupBoxInTexts.Add(control.Text);
            }

            if (e.Button.Equals(MouseButtons.Right))
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add("삭제");
                menu.ItemClicked += new ToolStripItemClickedEventHandler(Menu_ItemClicked);

                menu.Show((GroupBox)sender, new Point(e.X, e.Y));
            }

            else
            {
                ProfileViewForm profileViewForm = new ProfileViewForm(userID, groupBoxInTexts);
                profileViewForm.Show();
            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "삭제":
                    //현재 groupBoxInTexts에 담긴 모든 text를 불러와서 
                    //select로 nickname, role이 맞는 사람(친구)를 알아내고 그 친구의 userID로                //role이 null이면 결과가 안나와서 pk로만 검색해야할듯
                    DataTable dataTableWho = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE nickname = '" + groupBoxInTexts[1] + "'");
                    DataRow dataRowWho = dataTableWho.Rows[0];
                    //string friendUserID = rdr[userID].toString();
                    string friendUserID = dataRowWho["userID"].ToString();

                    //friends table에서 삭제한 후 다시 load      
                    //string DeleteFriendQuery = "DELETE FROM friends WHERE friendID = " + friendUserID;
                    //잠시만 이렇게 하면 friendUserID가 저거인 게 모두 없어지니까 userID도 조건을 걸어야 할듯
                    DBManager.GetDBManager().SqlNonReturnCommand("DELETE FROM friends WHERE friendID = '" + friendUserID + "' AND userID = '" + userID + "'");

                    GroupBoxsRemove();
                    myProfileLoad();
                    friendsProfileLoad(userID);
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
