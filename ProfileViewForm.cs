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
    public partial class ProfileViewForm : Form
    {

        //지금 디폴트 디자인은 친구로 등록되어있는 친구의 프로필을 눌렀을 때의 화면

        //이걸 불러올 때마다 확인을 해야함 ==> 현재 불러온 사람이 누군지 flag가 필요할 듯
        //0이면 본인, 1이면 친구인 사람, -1이면 친구가 아닌 사람

        //친구인 사람 프로필 눌렀을 때 버튼 : 1:1 채팅하기, 삭제하기
        //친구가 아닌 사람 프로필 눌렀을 때 버튼 : 친구 추가하기(단일)
        //본인 프로필 눌렀을 때 : 나와의 채팅, 프로필 편집

        private List<string> profile = new List<string>();
        private string userID = "";
        private string currentUserID = "";
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
                    Console.WriteLine(this.splitContainer1.Panel1.Controls[i].Location);
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
                    buttonChatWithMe.Location = new Point(60, 300);
                    buttonChatWithMe.Size = new Size(96, 30);
                    buttonChatWithMe.Text = "나와의 채팅";
                    splitContainer1.Panel1.Controls.Add(buttonChatWithMe);
                    buttonChatWithMe.Click += ButtonChatWithMe_Click;

                    Button buttonProfileUpdate = new Button();
                    buttonProfileUpdate.Location = new Point(180, 300);
                    buttonProfileUpdate.Size = new Size(96, 30);
                    buttonProfileUpdate.Text = "프로필 편집";
                    splitContainer1.Panel1.Controls.Add(buttonProfileUpdate);
                    buttonProfileUpdate.Click += ButtonProfileUpdate_Click;
                    break;

                case 1:
                    Button buttonChat = new Button();
                    buttonChat.Location = new Point(60, 300);
                    buttonChat.Size = new Size(96, 30);
                    buttonChat.Text = "1:1 채팅하기";
                    splitContainer1.Panel1.Controls.Add(buttonChat);
                    buttonChat.Click += buttonChatting_Click;

                    Button buttonDel = new Button();
                    buttonDel.Location = new Point(180, 300);
                    buttonDel.Size = new Size(96, 30);
                    buttonDel.Text = "친구 삭제";
                    splitContainer1.Panel1.Controls.Add(buttonDel);
                    buttonDel.Click += buttonDelete_Click;
                    break;

                case -1:
                    Button buttonAddFriend = new Button();
                    buttonAddFriend.Location = new Point(135, 300);
                    buttonAddFriend.Size = new Size(96, 30);
                    buttonAddFriend.Text = "친구 추가";
                    splitContainer1.Panel1.Controls.Add(buttonAddFriend);
                    buttonAddFriend.Click += ButtonAddFriend_Click;
                    break;
            }
        }

        private void ButtonAddFriend_Click(object sender, EventArgs e)
        {

        }

        private void ButtonProfileUpdate_Click(object sender, EventArgs e)
        {

        }

        private void ButtonChatWithMe_Click(object sender, EventArgs e)
        {

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
            else if (dataTableFriendSearch.Rows[0] == null)
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

            labelNickname.Text = profile[2] + " " + profile[1];
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
                DataTable friendInfo = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE userID = '" + dataRow["friendID"].ToString() + "'");
                DataRow friendInfoRow = friendInfo.Rows[0];

                GroupBox groupBoxFriend = new GroupBox();
                groupBoxFriend.Location = new Point(45, i * 150 + 20);
                splitContainer1.Panel2.Controls.Add(groupBoxFriend);
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
            //friends 테이블에 채팅중인 flag도 함께 디비에 저장
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DBManager.GetDBManager().SqlNonReturnCommand("DELETE FROM friends WHERE userID = '" + userID + "' AND friendID = '" + currentUserID + "'");
            currentWho = -1;
        }
    }
}
