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

namespace DBP
{
    public partial class FindFriends : Form
    {
        string userID = "";
        private List<string> groupBoxInTexts = new List<string>();
        //placeholder 설정
        public bool test = false;
        TextBox[] txtList;
        const string IdPlaceholder = "친구의 ID를 입력하세요 ...";

        public FindFriends(string userID)
        {
            InitializeComponent();
            this.userID = userID;

            txtList = new TextBox[] { textBoxSearch };
            foreach (var txt in txtList)
            {
                //처음 공백 Placeholder 지정
                txt.ForeColor = Color.LightSteelBlue;
                if (txt == textBoxSearch) txt.Text = IdPlaceholder;
                //텍스트박스 커서 Focus 여부에 따라 이벤트 지정
                txt.GotFocus += RemovePlaceholder;
                txt.LostFocus += SetPlaceholder;
            }
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender; 
            if (txt.Text == IdPlaceholder)
            { //텍스트박스 내용이 사용자가 입력한 값이 아닌 Placeholder일 경우에만, 커서 포커스일때 빈칸으로 만들기
                txt.ForeColor = Color.MidnightBlue; //사용자 입력 진한 글씨
                txt.Text = string.Empty;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                //사용자 입력값이 하나도 없는 경우에 포커스 잃으면 Placeholder 적용해주기
                txt.ForeColor = Color.LightSteelBlue; //Placeholder 흐린 글씨
                if (txt == textBoxSearch) txt.Text = IdPlaceholder;
            }
        }
        //여기까지

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        // ↑여기까지
        private void FindFriends_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }
        
        public void myProfileLoad()
        {
            /*
            Panel pane1 = new Panel();
            pane1.Location = new System.Drawing.Point(30, 123);
            //Controls.Add(panel);
            pane1.Width = 315;
            pane1.Height = 471; 
            pane1.AutoSize = true; 
            pane1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            pane1.AutoScroll = true;
            this.Controls.Add(pane1); 
            */

            GroupBox groupBoxMyProfile = new GroupBox();
            this.Controls.Add(groupBoxMyProfile);
            groupBoxMyProfile.Text = "";
            groupBoxMyProfile.Location = new Point(29, 122);
            groupBoxMyProfile.Width = 313;
            groupBoxMyProfile.Height = 135;

            PictureBox pictureBoxMyProfile = new PictureBox();
            pictureBoxMyProfile.Location = new Point(9, 30);
            pictureBoxMyProfile.Width = 80;
            pictureBoxMyProfile.Height = 80;

            groupBoxMyProfile.Controls.Add(pictureBoxMyProfile);

            Label Mynickname = new Label();
            Mynickname.Font = new Font("나눔스퀘어", 12, FontStyle.Bold);
            Mynickname.Location = new Point(170, 33);

            Mynickname.TabIndex = 4;
            groupBoxMyProfile.Controls.Add(Mynickname);

            Label Myrole = new Label();
            Myrole.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
            Myrole.Location = new Point(110, 35);
            groupBoxMyProfile.Controls.Add(Myrole);


            Label MystateMessage = new Label();
            MystateMessage.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
            MystateMessage.Location = new Point(110, 70);
            groupBoxMyProfile.Controls.Add(MystateMessage);

            Button buttonAdd = new Button();
            buttonAdd.Text = "추가";
            buttonAdd.Font = new Font("나눔스퀘어", 10, FontStyle.Bold);
            buttonAdd.ForeColor = Color.DarkSlateBlue;
            buttonAdd.Location = new Point(250, 56);
            buttonAdd.Width = 55;
            buttonAdd.Height = 30;
            buttonAdd.TabIndex = 0;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.BackColor = Color.Lavender;
            buttonAdd.FlatAppearance.BorderSize = 0;
            groupBoxMyProfile.Controls.Add(buttonAdd);

            buttonAdd.Click += new EventHandler(buttonAdd_Click);
            groupBoxMyProfile.MouseClick += new MouseEventHandler(groupBoxMyProfile_MouseClick);

            void buttonAdd_Click(object sender, EventArgs e)
            {
                using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
                {
                    conn.Open();

                    string query = "INSERT INTO friends(userID, friendID, currentChat) VALUES ('" + userID + "', '" + textBoxSearch.Text + "', 0)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                buttonAdd.Visible = false;
            }

            void groupBoxMyProfile_MouseClick(object sender, MouseEventArgs e)
            {
                groupBoxInTexts.Clear();

                foreach (Control control in ((GroupBox)sender).Controls)
                {
                    //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                    //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
                    groupBoxInTexts.Add(control.Text);
                }

                ProfileViewForm profileViewForm = new ProfileViewForm(userID, groupBoxInTexts);
                profileViewForm.Show();
                
            }

            //Controls.Add(groupBoxMyProfile); ㅋㅋ;

            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                //userID로 바꾸기
                string query = "SELECT * FROM user WHERE userID = '" + textBoxSearch.Text + "'";
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
        /*
        public void friendsProfileLoad()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();
                List<string> friendIDArray = new List<string>();

                string friendSearchQuery = "SELECT friendID FROM friends WHERE userID = '" + textBoxSearch.Text + "'"; //userID + "'";
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
                    groupBoxFriend.Location = new Point(14, i * 126 + 132);
                    Controls.Add(groupBoxFriend);
                    groupBoxFriend.MouseClick += GroupBoxFriend_MouseClick;
                    groupBoxFriend.Tag = i;

                    groupBoxFriend.Text = "";

                    groupBoxFriend.Width = 296;
                    groupBoxFriend.Height = 117;

                    PictureBox pictureBoxFriendProfile = new PictureBox();
                    pictureBoxFriendProfile.Location = new Point(9, 33);
                    pictureBoxFriendProfile.Width = 71;
                    pictureBoxFriendProfile.Height = 75;
                    groupBoxFriend.Controls.Add(pictureBoxFriendProfile);

                    Label friendnickname = new Label();
                    friendnickname.Location = new Point(139, 33);
                    groupBoxFriend.Controls.Add(friendnickname);

                    Label friendrole = new Label();
                    friendrole.Location = new Point(89, 33);
                    groupBoxFriend.Controls.Add(friendrole);

                    Label friendstateMessage = new Label();
                    friendstateMessage.Location = new Point(100, 70);
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
            groupBoxInTexts.Clear();
            //이벤트가 발생한 '그' 그룹박스 내의 컨트롤 들의 text를 모두 list에 저장
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
                groupBoxInTexts.Add(control.Text);
            }

            if (e.Button.Equals(MouseButtons.Left))
            {
                ProfileViewForm profileViewForm = new ProfileViewForm(userID, groupBoxInTexts);
                profileViewForm.Show();
            }
        }*/

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
                    this.Controls[i].Dispose();
                }
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
               buttonSearchID_Click(sender, e);
        }

        private void buttonSearchID_Click(object sender, EventArgs e)
        {
            myProfileLoad();
            //friendsProfileLoad();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Length == 0)
                GroupBoxsRemove();
        }
    }
}
