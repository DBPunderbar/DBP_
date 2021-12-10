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
    public partial class ProfileViewForm : Form
    {
        //지금 디폴트 디자인은 친구로 등록되어있는 친구의 프로필을 눌렀을 때의 화면

        //이걸 불러올 때마다 확인을 해야함 ==> 현재 불러온 사람이 누군지 flag가 필요할 듯
        //0이면 본인, 1이면 친구인 사람, -1이면 친구가 아닌 사람

        //친구인 사람 프로필 눌렀을 때 버튼 : 1:1 채팅하기, 삭제하기
        //친구가 아닌 사람 프로필 눌렀을 때 버튼 : 친구 추가하기(단일)
        //본인 프로필 눌렀을 때 : 나와의 채팅, 프로필 편집

        //placeholder 설정
        public bool test = false;
        TextBox[] txtList;
        const string IdPlaceholder = "친구의 ID를 입력하세요 ...";

        private List<string> profile = new List<string>();
        //현재 클라이언트 정보
        private string userID = "";

        //프로필이 띄워진 사람의 userID
        private string currentUserID = "";

        //프로필 속 사람과의 관계
        private int currentWho = -1;

        public ProfileViewForm(string userID, List<string> profile)
        {
            InitializeComponent();
            panel1.BringToFront();

            //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
            this.profile = profile;
            this.userID = userID;


            InfoLoad();
            checkFriend();

            //사람 별로 buttonChange필요
            buttonChange();

            //본인 프로필 클릭이면 (그냥) 친구 목록이 뜸
            friendsProfileLoad(currentUserID);
        }

        private void buttonChange()
        {
            //모든 버튼 삭제
            for (int i = this.splitContainer1.Panel1.Controls.Count - 1; i >= 0; i--)
            {
                if (this.splitContainer1.Panel1.Controls[i] is Button)
                {
                    //this.Controls[i].MouseClick -= GroupBoxFriend_MouseClick;
                    //DIspose되면 이벤트 핸들러도 사라지나? 그러면 Hide로 해야하낭 Hide와 Visible false는 무슨 차이지
                    this.splitContainer1.Panel1.Controls[i].Dispose();
                }
            }

            switch (currentWho)
            {
                //0일때 본인(나와의채팅, 프로필수정), 1일때 친구(채팅,삭제) , -1일때 친구아님(친구추가)
                case 0:
                    Button buttonChatWithMe = new Button();
                    buttonChatWithMe.Location = new Point(40, 450);
                    buttonChatWithMe.Size = new Size(96, 30);
                    buttonChatWithMe.Text = "나와의 채팅";
                    buttonChatWithMe.BackColor = Color.Lavender;
                    buttonChatWithMe.FlatStyle = FlatStyle.Flat;
                    buttonChatWithMe.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                    buttonChatWithMe.FlatAppearance.BorderSize = 0;
                    buttonChatWithMe.ForeColor = Color.DarkSlateBlue;
                    splitContainer1.Panel1.Controls.Add(buttonChatWithMe);
                    buttonChatWithMe.Click += ButtonChatWithMe_Click;

                    Button buttonProfileUpdate = new Button();
                    buttonProfileUpdate.Location = new Point(160, 450);
                    buttonProfileUpdate.Size = new Size(96, 30);
                    buttonProfileUpdate.Text = "프로필 편집";
                    buttonProfileUpdate.BackColor = Color.Lavender;
                    buttonProfileUpdate.FlatStyle = FlatStyle.Flat;
                    buttonProfileUpdate.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                    buttonProfileUpdate.FlatAppearance.BorderSize = 0;
                    buttonProfileUpdate.ForeColor = Color.DarkSlateBlue;
                    splitContainer1.Panel1.Controls.Add(buttonProfileUpdate);
                    buttonProfileUpdate.Click += ButtonProfileUpdate_Click;
                    break;

                case 1:
                    Button buttonChat = new Button();
                    buttonChat.Location = new Point(40, 450);
                    buttonChat.Size = new Size(96, 30);
                    buttonChat.Text = "1:1 채팅하기";
                    buttonChat.BackColor = Color.Lavender;
                    buttonChat.FlatStyle = FlatStyle.Flat;
                    buttonChat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                    buttonChat.FlatAppearance.BorderSize = 0;
                    buttonChat.ForeColor = Color.DarkSlateBlue;
                    splitContainer1.Panel1.Controls.Add(buttonChat);
                    buttonChat.Click += buttonChatting_Click;

                    Button buttonDel = new Button();
                    buttonDel.Location = new Point(160, 450);
                    buttonDel.Size = new Size(96, 30);
                    buttonDel.Text = "친구 삭제";
                    buttonDel.BackColor = Color.Lavender;
                    buttonDel.FlatStyle = FlatStyle.Flat;
                    buttonDel.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                    buttonDel.FlatAppearance.BorderSize = 0;
                    buttonDel.ForeColor = Color.DarkSlateBlue;
                    splitContainer1.Panel1.Controls.Add(buttonDel);
                    buttonDel.Click += buttonDelete_Click;
                    break;

                case -1:
                    Button buttonAddFriend = new Button();
                    buttonAddFriend.Location = new Point(100, 450);
                    buttonAddFriend.Size = new Size(96, 30);
                    buttonAddFriend.Text = "친구 추가";
                    buttonAddFriend.BackColor = Color.Lavender;
                    buttonAddFriend.FlatStyle = FlatStyle.Flat;
                    buttonAddFriend.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                    buttonAddFriend.FlatAppearance.BorderSize = 0;
                    buttonAddFriend.ForeColor = Color.DarkSlateBlue;
                    splitContainer1.Panel1.Controls.Add(buttonAddFriend);
                    buttonAddFriend.Click += ButtonAddFriend_Click;
                    break;
            }
        }

        private void ButtonAddFriend_Click(object sender, EventArgs e)
        {
            //친구가 아닌사람인지 확인
            if(currentWho == -1)
            {
                MessageBox.Show("친구 추가 완료");
                DBManager.GetDBManager().SqlNonReturnCommand("INSERT INTO friends VALUES('" + userID + "', '" + currentUserID + "', 0)");

                currentWho = 1;
                buttonChange();
            }
        }

        private void ButtonProfileUpdate_Click(object sender, EventArgs e)
        {
            if(currentWho == 0)
            {
                UpdateInfo updateInfo = new UpdateInfo(userID);
                updateInfo.ShowDialog();
            }
        }

        private void ButtonChatWithMe_Click(object sender, EventArgs e)
        {
            DBManager.GetDBManager().SqlDataTableReturnCommand("UPDATE s5584534.friends SET currentChat = '1' WHERE userID = '" + userID + "'");
            ChatForm ChatForm = new ChatForm(userID, "ToMe");
            ChatForm.Name = userID + "ToMe";
            ChatForm.Show();
            this.Close();
        }

        private void checkFriend()
        {
            DataTable dataTableFriendSearch = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM friends WHERE userID = '" + userID + "' AND friendID = '" + currentUserID + "'");
            
            //mainform에서 넘어온 userid와 지금 currentuserid가 같으면 본인
            if (userID == currentUserID)
            {
                currentWho = 0;
            }
            //friends 컬럼을 찾아서 없으면 -1, 있으면 1
            else if (dataTableFriendSearch.Rows.Count == 0)
            {
                currentWho = -1;
            }
            else
                currentWho = 1;
        }

        private void InfoLoad()
        {
            //friendbImage = (byte[])readerFrienInfo["profileImage"];
            //if (friendbImage != null)
            //{
            //    pictureBoxFriendProfile.Image = new Bitmap(new MemoryStream(friendbImage));
            //    pictureBoxFriendProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            //}

            labelPosition.Text = profile[2];
            labelNickname.Text = profile[1];
            labelNickname.Location = new Point(70 + labelPosition.Width + 10, 292);

            labelStateMessage.Text = profile[3];

            DataTable dt = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE nickname = '" + profile[1] + "'");
            DataRow dtRow = dt.Rows[0];

            currentUserID = dtRow["userID"].ToString();          

                byte[] profileImage = (byte[])dtRow["profileImage"];
            if (profileImage != null)
            {
                pictureBoxProfile.Image = new Bitmap(new MemoryStream(profileImage));
                pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void friendsProfileLoad(string ID)
        {
            List<string> friendIDArray = new List<string>();
            DataTable friendsID = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT friendID FROM friends WHERE userID = '" + ID + "'");

            int i = 0;
            foreach (DataRow dataRow in friendsID.Rows)
            {
                if (dataRow["friendID"].ToString() == "ToMe")
                {
                    i++;
                    continue;
                }
                DataTable friendInfo = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE userID = '" + dataRow["friendID"].ToString() + "'");

                //ToMe가 불러질 경우
                //if (friendInfo.Rows.Count == 0)
                //    continue;

                DataRow friendInfoRow = friendInfo.Rows[0];

                GroupBox groupBoxFriend = new GroupBox();
                groupBoxFriend.Location = new Point(35, i * 150 + 20);
                splitContainer1.Panel2.Controls.Add(groupBoxFriend);
                groupBoxFriend.MouseClick += GroupBoxFriend_MouseClick;
                groupBoxFriend.MouseDoubleClick += GroupBoxFriend_MouseDoubleClick;
                groupBoxFriend.Tag = i + 1;

                groupBoxFriend.Text = "";

                groupBoxFriend.Width = 400;
                groupBoxFriend.Height = 150;

                PictureBox pictureBoxFriendProfile = new PictureBox();
                pictureBoxFriendProfile.Location = new Point(25, 25);
                pictureBoxFriendProfile.Width = 100;
                pictureBoxFriendProfile.Height = 100;
                groupBoxFriend.Controls.Add(pictureBoxFriendProfile);

                Label friendnickname = new Label();
                friendnickname.Font = new Font("나눔스퀘어", 10, FontStyle.Bold);
                friendnickname.ForeColor = Color.DarkSlateBlue;
                groupBoxFriend.Controls.Add(friendnickname);

                Label friendrole = new Label();
                friendrole.Font = new Font("나눔스퀘어", 10, FontStyle.Bold);
                friendrole.ForeColor = Color.DarkSlateBlue;
                friendrole.AutoSize = true;
                friendrole.Location = new Point(150, 45);
                groupBoxFriend.Controls.Add(friendrole);

                Label friendstateMessage = new Label();
                friendstateMessage.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                friendstateMessage.ForeColor = Color.DarkSlateBlue;
                friendstateMessage.Location = new Point(150, 80);
                groupBoxFriend.Controls.Add(friendstateMessage);

                byte[] friendbImage = null;



                //role과 상태메시지, 프로필 이미지는 notNull이 아니기 때문에 null이 불러와질 수 있음
                if (friendInfoRow["role"] == System.DBNull.Value)
                    friendrole.Text = "";
                else
                    friendrole.Text = "[" + friendInfoRow["role"].ToString() + "]";

                //role에 값이 있어야 Location 지정가능(원래 공백 + [positon] 길이 + 30띄워
                //자꾸 안되는 이유가 그룹박스에 추가를 먼저 해서 위치정보가 달라져서 그런가
                friendnickname.Location = new Point(150 + friendrole.Width + 10, 45);


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

        bool clicked = false;

        private void GroupBoxFriend_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clicked = false;

            List<string> groupBoxInTexts = new List<string>();
            groupBoxInTexts.Clear();
            //이벤트가 발생한 '그' 그룹박스 내의 컨트롤 들의 text를 모두 list에 저장
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
                groupBoxInTexts.Add(control.Text);
            }

            DataTable dataTablefriend = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE nickname = '" + groupBoxInTexts[1] + "'");
            DataRow dataRowFriend = dataTablefriend.Rows[0];
            string friendID = dataRowFriend["userID"].ToString();

            //채팅중 플래그on
            DBManager.GetDBManager().SqlNonReturnCommand("UPDATE friends SET currentChat = 1 WHERE userID = '" + userID + "' AND friendID = '" + friendID + "'");
            //더블클릭하면 채팅창으로 바로 이동
            MessageBox.Show("Double Clicked");
        }

        private async void GroupBoxFriend_MouseClick(object sender, MouseEventArgs e)
        {
            if (clicked)
                return;
            clicked = true;
            await Task.Delay(SystemInformation.DoubleClickTime);

            //기다리는 동안 double click이 실행되면 doubleclick 이벤트에서 clicked가 false가 되니까 single click에선 return
            //기다리는 동안 double click이 실행되지 않으면 clicked는 여전히 false, 
            if (!(clicked))
                return;
            clicked = false;

            //우클릭은 안넣어놨음
            List<string> groupBoxInTexts = new List<string>();

            groupBoxInTexts.Clear();
            //이벤트가 발생한 '그' 그룹박스 내의 컨트롤 들의 text를 모두 list에 저장
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
                groupBoxInTexts.Add(control.Text);
            }

            ProfileViewForm profileViewForm = new ProfileViewForm(userID, groupBoxInTexts);
            profileViewForm.Show();
        }

        private void buttonChatting_Click(object sender, EventArgs e)
        {
            //채팅하는 곳으로 이동
            //friends 테이블에 채팅중인 flag도 함께 디비에 저장(UPDATE문으로)
            DBManager.GetDBManager().SqlNonReturnCommand("UPDATE friends SET currentChat = 1 WHERE userID = '" + userID + "' AND friendID = '" + currentUserID + "'");
            ChatForm ChatForm = new ChatForm(userID, currentUserID);
            ChatForm.Name = userID + currentUserID;
            ChatForm.Show();
            this.Hide();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("삭제되었습니다.");
            DBManager.GetDBManager().SqlNonReturnCommand("DELETE FROM friends WHERE userID = '" + userID + "' AND friendID = '" + currentUserID + "'");
            currentWho = -1;
            buttonChange();
        }

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
    }
}
