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

namespace DBP {
    public partial class messagesPage : UserControl {
        // 채팅 contents 작성 방식
        // 이름|시간|내용\n ...
        //
        // 현재시간 작성 기준
        // DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        //friendsPage fp = new friendsPage();
        private List<string> groupBoxInTexts = new List<string>();
        public messagesPage(string userID)
        {
            InitializeComponent();

            this.userID = userID;
            LoadChatList(userID);
        }

        private string userID = "";
        private void LoadChatList(string userID)
        {
            DataTable chatListDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT friendID FROM s5584534.friends WHERE userID = '" + userID + "' AND currentChat = '1'");
            DataRow chatListDR;

            for (int i = 0; i < chatListDT.Rows.Count; i++)
            {
                chatListDR = chatListDT.Rows[i];
                DataTable friendDT;
                DataRow friendDR;
                DataTable chatDT;
                DataRow lastChatRow;
                if (chatListDR["friendID"].ToString() == "ToMe")
                {
                    friendDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM s5584534.user WHERE userID = '" + userID + "'");
                    friendDR = friendDT.Rows[0];
                    chatDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM s5584534.chatManagement WHERE writerName = '" + userID + "' AND receiverName = 'ToMe'");
                }
                else
                {
                    friendDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM s5584534.user WHERE userID = '" + chatListDR["friendID"].ToString() + "'");
                    friendDR = friendDT.Rows[0];
                    chatDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM s5584534.chatManagement WHERE (writerName = '" + userID + "' AND receiverName = '" + chatListDR["friendID"].ToString() + "') " +
                        "OR (writerName = '" + chatListDR["friendID"].ToString() + "' AND receiverName = '" + userID + "')");
                }

                if (chatDT.Rows.Count != 0) // 일반적인 경우
                    lastChatRow = chatDT.Rows[chatDT.Rows.Count - 1];
                else
                { // currentChat은 1이나 채팅 내용이 없는 경우,, 아마 채팅방 생성만 하고 대화를 나누진 않았을 때?
                    DataTable temp = new DataTable();
                    temp.Columns.Add("contents", typeof(string));
                    lastChatRow = temp.NewRow();
                    lastChatRow["contents"] = "";
                }

                GroupBox groupBox = new GroupBox();
                groupBox.Location = new Point(45, i * 150 + 50);
                groupBox.Text = "";
                groupBox.Width = 600;
                groupBox.Height = 150;
                Controls.Add(groupBox);

                groupBox.MouseClick += groupBox_Clicked;
                groupBox.MouseDoubleClick += groupBox_DoubleClicked;

                PictureBox pictureBoxFriendProfileImage = new PictureBox();
                pictureBoxFriendProfileImage.Location = new Point(25, 25);
                pictureBoxFriendProfileImage.Width = 100;
                pictureBoxFriendProfileImage.Height = 100;
                pictureBoxFriendProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
                byte[] imageByte = (byte[])friendDR["profileImage"];
                pictureBoxFriendProfileImage.Image = new Bitmap(new MemoryStream(imageByte));
                groupBox.Controls.Add(pictureBoxFriendProfileImage);

                //순서가 이렇게 되어야해서ㅠㅠ 죄송죄송합니다 
                //Label friendName = new Label();
                //friendName.Text = friendDR["nickname"].ToString();
                //friendName.AutoSize = true;
                //groupBox.Controls.Add(friendName);


                Label friendRole = new Label();
                friendRole.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                friendRole.Location = new Point(150, 47);
                friendRole.Text = "[" + friendDR["role"].ToString() + "]";
                friendRole.AutoSize = true;
                groupBox.Controls.Add(friendRole);

                Label friendName = new Label();
                friendName.Font = new Font("나눔스퀘어", 12, FontStyle.Bold);
                friendName.Location = new Point(150 + friendRole.Width, 45);
                friendName.Text = friendDR["nickname"].ToString();
                friendName.AutoSize = true;
                groupBox.Controls.Add(friendName);

                Label lastChat = new Label();
                lastChat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                lastChat.Location = new Point(150, 80);
                lastChat.Text = lastChatRow["contents"].ToString();
                lastChat.AutoSize = true;
                groupBox.Controls.Add(lastChat);
            }
        }

        private void groupBox_Clicked(object sender, MouseEventArgs e)
        {
            groupBoxInTexts.Clear();
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                groupBoxInTexts.Add(control.Text);
            }

            if (e.Button.Equals(MouseButtons.Right))
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add("삭제");
                menu.ItemClicked += new ToolStripItemClickedEventHandler(Menu_ItemClicked);

                menu.Show((GroupBox)sender, new Point(e.X, e.Y));
            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "삭제":
                    DataTable dataTableWho = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM s5584534.user WHERE nickname = '" + groupBoxInTexts[2] + "'");
                    DataRow dataRowWho = dataTableWho.Rows[0];
                    string friendID = dataRowWho["userID"].ToString();
                    if (userID == friendID)
                    {
                        DBManager.GetDBManager().SqlNonReturnCommand("DELETE FROM s5584534.chatManagement WHERE writerName = '" + userID + "' AND receiverName = 'ToMe'");
                        DBManager.GetDBManager().SqlNonReturnCommand("UPDATE s5584534.friends SET currentChat = '0' WHERE userID = '" + userID + "' AND friendID = 'ToMe'");
                    }
                    else
                    {
                        DBManager.GetDBManager().SqlNonReturnCommand("DELETE FROM s5584534.chatManagement WHERE (writerName = '" + userID + "' AND receiverName = '" + friendID + "') " +
                            "OR (writerName = '" + friendID + "' AND receiverName = '" + userID + "')");
                        DBManager.GetDBManager().SqlNonReturnCommand("UPDATE s5584534.friends SET currentChat = '0' WHERE userID = '" + userID + "' AND friendID = '" + friendID + "'");
                    }
                    GroupBoxsRemove();
                    LoadChatList(userID);
                    break;
            }
        }

        private void GroupBoxsRemove()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is GroupBox)
                {
                    this.Controls[i].Dispose();
                }
            }
        }

        private void groupBox_DoubleClicked(object sender, MouseEventArgs e)
        {
            groupBoxInTexts.Clear();
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                groupBoxInTexts.Add(control.Text);
            }

            DataTable dataTablefriend = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE nickname = '" + groupBoxInTexts[1] + "'");
            DataRow dataRowFriend = dataTablefriend.Rows[0];
            string friendID = dataRowFriend["userID"].ToString();

            // 챗 폼 열어주기 -> 멸망
            //채팅하는 곳으로 이동
            //friends 테이블에 채팅중인 flag도 함께 디비에 저장(UPDATE문으로)
            if (friendID == userID)
                friendID = "ToMe";

            DBManager.GetDBManager().SqlNonReturnCommand("UPDATE friends SET currentChat = 1 WHERE userID = '" + userID + "' AND friendID = '" + friendID + "'");

            Form CF = Application.OpenForms[userID + friendID];
            //이미 채팅방이 열려있다면
            if (CF != null)
            {
                //맨 앞으로 가져오고 return
                CF.BringToFront();
                return;
            }

            ChatForm ChatForm = new ChatForm(userID, friendID);
            ChatForm.Name = userID + friendID;
            ChatForm.Show();
        }
    }
}
