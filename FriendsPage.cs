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
        
        public void myProfileLoad()
        {
            GroupBox groupBoxMyProfile = new GroupBox();

            groupBoxMyProfile.Text = "";
            groupBoxMyProfile.Location = new Point(15, 50);
            groupBoxMyProfile.Tag = 0;

            groupBoxMyProfile.Width = 650;
            groupBoxMyProfile.Height = 160;
            groupBoxMyProfile.MouseClick += GroupBoxFriend_MouseClick;
            groupBoxMyProfile.MouseDoubleClick += GroupBoxMyProfile_MouseDoubleClick;
            //마이프로필에서도 더블클릭하면 되게 해야할텐데 따로 만들어야하나 아니면 음... 따로 만드는게 나을 것 같기도

            PictureBox pictureBoxMyProfile = new PictureBox();
            pictureBoxMyProfile.Location = new Point(25, 25);
            pictureBoxMyProfile.Width = 120;
            pictureBoxMyProfile.Height = 120;

            groupBoxMyProfile.Controls.Add(pictureBoxMyProfile);

            Label Mynickname = new Label();
            groupBoxMyProfile.Controls.Add(Mynickname);

            Label Myrole = new Label();
            Myrole.Location = new Point(175, 45);
            Myrole.AutoSize = true;
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

            //role에 값이 있어야 Location 지정가능(원래 공백 + [positon] 길이 + 30띄워
            Mynickname.Location = new Point(175 + Myrole.Width + 10, 45);


            if (bImage != null)
            {
                pictureBoxMyProfile.Image = new Bitmap(new MemoryStream(bImage));
                pictureBoxMyProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void friendsProfileLoad(string ID)
        {
            //친구 위에다 친구 검색창 만들기
            TextBox textBoxFriendSearchByNickname = new TextBox();
            textBoxFriendSearchByNickname.Location = new Point(300, 230);
            textBoxFriendSearchByNickname.Width = 90;
            textBoxFriendSearchByNickname.Height = 21;
            Controls.Add(textBoxFriendSearchByNickname);

            Button buttonFriendSearchByNickname = new Button();
            buttonFriendSearchByNickname.Location = new Point(400, 230);
            buttonFriendSearchByNickname.Width = 40;
            buttonFriendSearchByNickname.Height = 21;
            buttonFriendSearchByNickname.Text = "검색";
            Controls.Add(buttonFriendSearchByNickname);
            buttonFriendSearchByNickname.Click += ButtonFriendSearchByNickname_Click;

            List<string> friendIDArray = new List<string>();
            //친구 목록을 모두 불러와서

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

                //ToMe는 유저정보가 없기 때문에 row에서 안불러와짐
                //if (friendInfo.Rows.Count == 0)
                //    continue;


                DataRow friendInfoRow = friendInfo.Rows[0];

                GroupBox groupBoxFriend = new GroupBox();
                groupBoxFriend.Location = new Point(45, i * 150 + 270);
                Controls.Add(groupBoxFriend);

                //여기서 둘다 실행됨
                groupBoxFriend.MouseDoubleClick += GroupBoxFriend_MouseDoubleClick;
                groupBoxFriend.MouseClick += GroupBoxFriend_MouseClick;

                //0은 본인 프로필
                groupBoxFriend.Tag = i + 1;

                groupBoxFriend.Text = "";

                groupBoxFriend.Width = 600;
                groupBoxFriend.Height = 150;

                PictureBox pictureBoxFriendProfile = new PictureBox();
                pictureBoxFriendProfile.Location = new Point(25, 25);
                pictureBoxFriendProfile.Width = 100;
                pictureBoxFriendProfile.Height = 100;
                groupBoxFriend.Controls.Add(pictureBoxFriendProfile);

                Label friendnickname = new Label();
                groupBoxFriend.Controls.Add(friendnickname);

                Label friendrole = new Label();
                friendrole.Location = new Point(150, 45);
                friendrole.AutoSize = true;
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

                //role에 값이 있어야 Location 지정가능(원래 공백 + [positon] 길이 + 30띄워
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

        private void ButtonFriendSearchByNickname_Click(object sender, EventArgs e)
        {
            //친구 그룹박스들을 모두 삭제 <이게 foreach 안에 있으면 안되지, 두명이상일때는 다 없어지고 들어오게 되니까
            //ㅇㅎ.. 그래서 친구가 두명이상인 경우는 아예 안보였구나 스크롤도 없는 상태라서
            GroupBoxsRemove();

            string searchNickname = "";
            //textbox의 닉네임을 가져와서 LIKE 연산으로 검색, 기존의 친구 버튼들 모두 지우고, 다시 그룹박스 생성
            //textbox의 text는 어떻게 가져올 것인가!(동적생성이라)
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    searchNickname = ((TextBox)control).Text;
                    break;
                }
            }

            //잠시만 정신차려 친구 중에서 찾아야지, 친구인 사람 중에서, nickname이 nickname인 사람을 찾아서 그 정보를 얻어와야 하니까 JOIN을 해야하나;
            //JOIN을 하려면 textbox내용이 정확해야하니까 (엥 왜?)LIKE를 못써 ==> select로 user에서 LIKE로 nickname이 포함되는 애들 모두 찾고, 여기서 friend인 사람을 찾아야해

            //select *
            //from user
            //join friends on user.userID = friends.friendID
            //where user.nickname LIKE '%(검색창에 넣은)nickname%'
            //이렇게 하면 되나? ==> 이러면 잠시만. nickname이 이것을 포함하는 userID가 내 친구 테이블에 있어야 하니까 userID = friendID면 될까? ==> 포기 머리안돌아가..

            DataTable dataTableSearchByNickname = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE nickname LIKE '%" + searchNickname + "%'");

            int i = 0;
            foreach (DataRow dataRowSearchByNickname in dataTableSearchByNickname.Rows)
            {
                //리스트에 넣을까 아니면 바로 GroupBox만들까 ==> 친구불러오기 함수를 못쓰는게, 파라미터로 넘긴 userID의 친구가 나오니까..
                string resultUserID = dataRowSearchByNickname["userID"].ToString();

                //resultUserID가 내 친구인지 알아보기 위해
                DataTable dataTableCheckFriend = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM friends WHERE userID = '" + userID + "' AND friendID = '" + resultUserID + "'");

                //검색은 됐는데 친구가 아니라면 계속 for문
                if (dataTableCheckFriend.Rows.Count == 0)
                    continue;

                GroupBox groupBoxFriend = new GroupBox();
                //groupBoxFriend.Location = new Point(45, i * 150 + 270);

                groupBoxFriend.Location = new Point(45, i * 150 + 270);
                groupBoxFriend.MouseClick += GroupBoxFriend_MouseClick;
                groupBoxFriend.MouseDoubleClick += GroupBoxFriend_MouseDoubleClick;

                //0은 본인 프로필
                groupBoxFriend.Tag = i + 1;

                groupBoxFriend.Text = "";

                groupBoxFriend.Width = 600;
                groupBoxFriend.Height = 150;
                Controls.Add(groupBoxFriend);

                Console.WriteLine(groupBoxFriend.Location);

                PictureBox pictureBoxFriendProfile = new PictureBox();
                pictureBoxFriendProfile.Location = new Point(25, 25);
                pictureBoxFriendProfile.Width = 100;
                pictureBoxFriendProfile.Height = 100;
                groupBoxFriend.Controls.Add(pictureBoxFriendProfile);

                Label friendnickname = new Label();
                groupBoxFriend.Controls.Add(friendnickname);

                Label friendrole = new Label();
                friendrole.Location = new Point(150, 45);
                friendrole.AutoSize = true;
                groupBoxFriend.Controls.Add(friendrole);

                Label friendstateMessage = new Label();
                friendstateMessage.Location = new Point(150, 80);
                groupBoxFriend.Controls.Add(friendstateMessage);

                byte[] friendbImage = null;

                //role과 상태메시지, 프로필 이미지는 notNull이 아니기 때문에 null이 불러와질 수 있음
                if (dataRowSearchByNickname["role"] == System.DBNull.Value)
                    friendrole.Text = "";
                else
                    friendrole.Text = "[" + dataRowSearchByNickname["role"].ToString() + "]";

                //role에 값이 있어야 Location 지정가능(원래 공백 + [positon] 길이 + 30띄워
                friendnickname.Location = new Point(150 + friendrole.Width + 10, 45);


                if (dataRowSearchByNickname["stateMessage"] == System.DBNull.Value)
                    friendstateMessage.Text = "";
                else
                    friendstateMessage.Text = dataRowSearchByNickname["stateMessage"].ToString();

                friendnickname.Text = dataRowSearchByNickname["nickname"].ToString();

                //프로필이미지가 없을 경우 기본 이미지 불러오기
                if (dataRowSearchByNickname["profileImage"] == System.DBNull.Value)
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
                    friendbImage = (byte[])dataRowSearchByNickname["profileImage"];
                    if (friendbImage != null)
                    {
                        pictureBoxFriendProfile.Image = new Bitmap(new MemoryStream(friendbImage));
                        pictureBoxFriendProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                i++;
            }

            //i++이 안되었다는 건 검색을 못했다는 거니까
            if (i == 0)
            {
                MessageBox.Show("닉네임이 " + searchNickname + "인 친구가 없습니다.");
            }
        }

        bool clicked = false;

        private void GroupBoxMyProfile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //마이프로필을 더블클릭했을 땐 나와의 채팅으로

            clicked = false;

            //채팅중 플래그on
            //나와의 채팅을 구현할 전용 계정에게
            DBManager.GetDBManager().SqlNonReturnCommand("UPDATE friends SET currentChat = 1 WHERE userID = '" + userID + "' AND friendID = 'ToMe'");

            //더블클릭하면 채팅창으로 바로 이동
            //더블클릭 확인용이라 messageBox빼고 나와의 채팅창 show해주시면 돼요
            MessageBox.Show("Double Clicked");
        }

        private void GroupBoxFriend_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clicked = false;

            //따로 함수로 빼려 했는데 sender가 누군지 모르게 되어서.. sender를 인수로 넣어주면 되려나ㅠㅠ
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
            //더블클릭하면 채팅창으로 바로 이동 더블클릭 확인용이라 messageBox빼고 채팅창 show해주시면 돼요
            MessageBox.Show("Double Clicked");
        }

        private async void GroupBoxFriend_MouseClick(object sender, MouseEventArgs e)
        {
            //더블클릭인지 클릭인지 확인
            if (clicked)
                return;
            clicked = true;
            await Task.Delay(SystemInformation.DoubleClickTime);

            //기다리는 동안 double click이 실행되면 doubleclick 이벤트에서 clicked가 false가 되니까 single click에선 return
            //기다리는 동안 double click이 실행되지 않으면 clicked는 여전히 false, 
            if (!(clicked))
                return;
            clicked = false;

            groupBoxInTexts.Clear();
            //이벤트가 발생한 '그' 그룹박스 내의 컨트롤 들의 text를 모두 list에 저장
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                //[0] : pictureBox, [1] : label(별명), [2] : label(직책), [3] : label(상태메시지)
                groupBoxInTexts.Add(control.Text);
            }

            //우클릭인 경우
            if (e.Button.Equals(MouseButtons.Right))
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add("삭제");
                menu.ItemClicked += new ToolStripItemClickedEventHandler(Menu_ItemClicked);

                menu.Show((GroupBox)sender, new Point(e.X, e.Y));
            }

            else
            {
                //profileViewForm이 닫힐 때 자동 새로고침은 어떻게 하더라
                //showDialog로 하기 좀 그런뎅
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
                    //0이면 본인 프로필이니까 그거 빼고 삭제
                    if(Convert.ToInt32(((GroupBox)this.Controls[i]).Tag) != 0)
                    //this.Controls[i].MouseClick -= GroupBoxFriend_MouseClick;
                        this.Controls[i].Dispose();
                }
            }
        }
    }
}
