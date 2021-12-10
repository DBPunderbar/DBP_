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
        public messagesPage(string userID) {
            InitializeComponent();

            this.userID = userID;
            LoadChatList(userID);
        }

        private string userID = "";
        private void LoadChatList(string userID) {
            DataTable chatListDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT friendID FROM s5584534.friends WHERE userID = '" + userID + "' AND currentChat = '1'");
            DataRow chatListDR;

            for (int i = 0; i < chatListDT.Rows.Count; i++) {
                chatListDR = chatListDT.Rows[i];
                DataTable friendDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM s5584534.user WHERE userID = '" + chatListDR["friendID"].ToString() + "'");
                DataRow friendDR = friendDT.Rows[0];
                DataTable chatDT = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM s5584534.chatManagement WHERE (writerName = '" + userID + "' AND receiverName = '" + chatListDR["friendID"].ToString() + "') " +
                    "OR (writerName = '" + chatListDR["friendID"].ToString() + "' AND receiverName = '" + userID + "')");
                DataRow lastChatRow;
                if (chatDT.Rows.Count != 0) // 일반적인 경우
                    lastChatRow = chatDT.Rows[chatDT.Rows.Count - 1];
                else { // currentChat은 1이나 채팅 내용이 없는 경우,, 아마 채팅방 생성만 하고 대화를 나누진 않았을 때?
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

                Label friendRole = new Label();
                friendRole.Location = new Point(150, 45);
                friendRole.Text = "[" + friendDR["role"].ToString() + "]";
                friendRole.AutoSize = true;
                groupBox.Controls.Add(friendRole);

                Label friendName = new Label();
                friendName.Location = new Point(150 + friendRole.Width, 45);
                friendName.Text = chatListDR["friendID"].ToString();
                friendName.AutoSize = true;
                groupBox.Controls.Add(friendName);

                Label lastChat = new Label();
                lastChat.Location = new Point(150, 80);
                lastChat.Text = lastChatRow["contents"].ToString();
                lastChat.AutoSize = true;
                groupBox.Controls.Add(lastChat);
            }
        }

        public void DeleteChatList(string friendID, string deleteValues) {
            DBManager.GetDBManager().SqlNonReturnCommand("UPDATE s5584534.friends SET currentChat = '0' WHERE userID = '" + userID + "' AND friendID = '" + friendID + "'");
        }

        private void groupBox_Clicked(object sender, MouseEventArgs e) { // 클릭 이벤트 어케한건지 모루겟소요,,,
            if (e.Button.Equals(MouseButtons.Right)) {
                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add("삭제");
                //menu.ItemClicked += new ToolStripItemClickedEventHandler(Menu_ItemClicked);

                menu.Show((GroupBox)sender, new Point(e.X, e.Y));
            }
        }

        private void groupBox_DoubleClicked(object sender, MouseEventArgs e) {
            // 챗 폼 열어주기 -> 멸망
        }
    }
}
