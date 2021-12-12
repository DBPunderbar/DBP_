using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBP
{
    public partial class ChatForm : Form
    {
        public static ChatForm chatform;
        public ChatForm(string userID, string receiverName)
        {
            InitializeComponent();

            chatform = this;
            this.userID = userID;
            this.receiverName = receiverName;
        }
        private string userID = "";
        private string receiverName = "";

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
        //↑여기까지

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonBackList_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            textBoxWriteMsg.Select();
            ChattedLoad();
        }

        private void buttonSendMsg_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, textBoxWriteMsg.Text, "0");
            textBoxWriteMsg.Clear();
        }

        private void textBoxWriteMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonSendMsg_Click(sender, e);
        }

        private void ChattedLoad()
        {
            string line1 = DBManager.GetDBManager().SelectAll("SELECT date_format(dateTime, '%Y-%m-%d %H:%i:%s') AS dateTime FROM s5584534.chatManagement WHERE (writerName = '" + userID + "' AND receiverName = '" + receiverName + "') "
                + "OR (writerName = '" + receiverName + "' AND receiverName = '" + userID + "')", "dateTime");
            string line2 = DBManager.GetDBManager().SelectAll("SELECT writerName FROM s5584534.chatManagement WHERE (writerName = '" + userID + "' AND receiverName = '" + receiverName + "') "
                + "OR (writerName = '" + receiverName + "' AND receiverName = '" + userID + "')", "writerName");
            string line3 = DBManager.GetDBManager().SelectAll("SELECT contents FROM s5584534.chatManagement WHERE (writerName = '" + userID + "' AND receiverName = '" + receiverName + "') "
                + "OR (writerName = '" + receiverName + "' AND receiverName = '" + userID + "')", "contents");
            string[] dateTime = line1.Split('|');
            string[] writerName = line2.Split('|');
            string[] contents = line3.Split('|');
            for (int i = 0; i < contents.Length; i++)
            {
                string message = string.Format("[{0}] {1} : {2}", dateTime[i], writerName[i], contents[i]);

                this.Invoke(new Action(delegate () {
                    if (message.Contains("[emoticon"))
                    { // 이모티콘
                        GroupBox groupBoxChat = new GroupBox();
                        groupBoxChat.Location = new Point(35, 150 + 20);
                        groupBoxChat.Text = "";
                        groupBoxChat.Width = 500;
                        groupBoxChat.Height = 160;
                        groupBoxChat.Tag = message;
                        groupBoxChat.MouseClick += GroupBoxChat_MouseClick;

                        flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                        flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);

                        PictureBox emoticon = new PictureBox();
                        emoticon.Size = new Size(100, 100);
                        emoticon.SizeMode = PictureBoxSizeMode.Zoom;

                        if (message.Contains("[emoticon1]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon1;
                        }
                        else if (message.Contains("[emoticon2]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon2;
                        }
                        else if (message.Contains("[emoticon3]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon3;
                        }
                        else if (message.Contains("[emoticon4]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon4;
                        }
                        groupBoxChat.Controls.Add(emoticon);

                        Label chat = new Label();
                        chat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                        chat.ForeColor = Color.DarkSlateBlue;
                        chat.Dock = DockStyle.Top;
                        if (writerName.Equals(userID))
                        {
                            chat.TextAlign = ContentAlignment.MiddleRight;
                            emoticon.Location = new Point(380, 50);
                        }
                        else
                        {
                            chat.TextAlign = ContentAlignment.MiddleLeft;
                            emoticon.Location = new Point(20, 50);
                        }
                        chat.AutoSize = false;
                        groupBoxChat.Controls.Add(chat);

                        message = message.Substring(0, message.Length - 12);
                        chat.Text = message;
                    }
                    else if (message.Contains("[ZIP"))          // 다운로드 파일 있을 경우
                    {
                        GroupBox groupBoxChat = new GroupBox();
                        groupBoxChat.Location = new Point(35, 150 + 20);
                        groupBoxChat.Text = "";
                        groupBoxChat.Width = 500;
                        groupBoxChat.Height = 50;
                        groupBoxChat.Tag = message;
                        groupBoxChat.MouseClick += GroupBoxChat_MouseClick;

                        flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                        flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);

                        // 파일이름 전처리
                        string[] filename = message.Split(']');

                        Button filebutton = new Button();
                        filebutton.Size = new Size(80, 30);
                        filebutton.Text = filename[3];
                        filebutton.Location = new Point(400, 13);
                        if (writerName.Equals(userID))
                            filebutton.Location = new Point(50, 13);
                        groupBoxChat.Controls.Add(filebutton);
                    }
                    else
                    { // 일반메세지
                        GroupBox groupBoxChat = new GroupBox();
                        groupBoxChat.Location = new Point(35, 150 + 20);
                        groupBoxChat.Text = "";
                        groupBoxChat.Width = 500;
                        groupBoxChat.Height = 50;
                        groupBoxChat.Tag = message;
                        groupBoxChat.MouseClick += GroupBoxChat_MouseClick;

                        flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                        flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);

                        Label chat = new Label();
                        chat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                        chat.ForeColor = Color.DarkSlateBlue;
                        chat.Dock = DockStyle.Fill;
                        if (writerName.Equals(userID))
                            chat.TextAlign = ContentAlignment.MiddleRight;
                        else
                            chat.TextAlign = ContentAlignment.MiddleLeft;
                        chat.AutoSize = false;
                        groupBoxChat.Controls.Add(chat);
                        chat.Text = message;

                    }
                }));
            }
        }

        public void ReceiveChat(string writer, string receiver, string message)
        {
            if (writer == userID && receiver == receiverName || writer == receiverName && receiver == userID)
            {
                this.Invoke(new Action(delegate () {
                    if (message.Contains("[emoticon")) { // 이모티콘
                        GroupBox groupBoxChat = new GroupBox();
                        groupBoxChat.Location = new Point(35, 150 + 20);
                        groupBoxChat.Text = "";
                        groupBoxChat.Width = 500;
                        groupBoxChat.Height = 160;
                        groupBoxChat.Tag = message;
                        groupBoxChat.MouseClick += GroupBoxChat_MouseClick;

                        flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                        flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);

                        PictureBox emoticon = new PictureBox();
                        emoticon.Size = new Size(100, 100);
                        emoticon.SizeMode = PictureBoxSizeMode.Zoom;

                        if (message.Contains("[emoticon1]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon1;
                        }
                        else if (message.Contains("[emoticon2]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon2;
                        }
                        else if (message.Contains("[emoticon3]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon3;
                        }
                        else if (message.Contains("[emoticon4]"))
                        {
                            emoticon.Image = DBP.Properties.Resources.emoticon4;
                        }
                        groupBoxChat.Controls.Add(emoticon);

                        Label chat = new Label();
                        chat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                        chat.ForeColor = Color.DarkSlateBlue;
                        chat.Dock = DockStyle.Top;
                        if (writer == userID)
                        {
                            chat.TextAlign = ContentAlignment.MiddleRight;
                            emoticon.Location = new Point(380, 50);
                        }
                        else
                        {
                            chat.TextAlign = ContentAlignment.MiddleLeft;
                            emoticon.Location = new Point(20, 50);
                        }
                        chat.AutoSize = false;
                        groupBoxChat.Controls.Add(chat);

                        message = message.Substring(0, message.Length - 12);
                        chat.Text = message;
                    }
                    else if (message.Contains("[ZIP"))          // 다운로드 파일 있을 경우
                    {
                        GroupBox groupBoxChat = new GroupBox();
                        groupBoxChat.Location = new Point(35, 150 + 20);
                        groupBoxChat.Text = "";
                        groupBoxChat.Width = 500;
                        groupBoxChat.Height = 50;
                        groupBoxChat.Tag = message;
                        groupBoxChat.MouseClick += GroupBoxChat_MouseClick;

                        flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                        flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);

                        // 파일이름 전처리
                        string[] filename = message.Split(']');

                        Button filebutton = new Button();
                        filebutton.Size = new Size(80, 30);
                        filebutton.Text = filename[3];
                        filebutton.Location = new Point(400, 13);
                        //filebutton.Click += Filebutton_Click;
                        if (writer != userID)
                            filebutton.Location = new Point(50,13);

                        groupBoxChat.Controls.Add(filebutton);
                    }
                    else { // 일반메세지
                        GroupBox groupBoxChat = new GroupBox();
                        groupBoxChat.Location = new Point(35, 150 + 20);
                        groupBoxChat.Text = "";
                        groupBoxChat.Width = 500;
                        groupBoxChat.Height = 50;
                        groupBoxChat.Tag = message;
                        groupBoxChat.MouseClick += GroupBoxChat_MouseClick;

                        flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                        flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);

                        Label chat = new Label();
                        chat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                        chat.ForeColor = Color.DarkSlateBlue;
                        chat.Dock = DockStyle.Fill;
                        if (writer == userID)
                            chat.TextAlign = ContentAlignment.MiddleRight;
                        else
                            chat.TextAlign = ContentAlignment.MiddleLeft;
                        chat.AutoSize = false;
                        groupBoxChat.Controls.Add(chat);
                        chat.Text = message;
                                               
                    }

                    flowLayoutPanelChatLog.Refresh();
                }));
            }
        }

        List<string> groupBoxInTexts = new List<string>();
        string groupBoxTag = string.Empty;
        private void GroupBoxChat_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(sender.ToString());
            groupBoxInTexts.Clear();
            foreach (Control control in ((GroupBox)sender).Controls)
            {
                //무슨 순서로 들어오는지 모르니까 일단은 확인 필요
                // 버튼 있는 경우
                //[0] : 버튼text
                // 이모티콘의 경우
                // [0] : 픽처박스, [1] :  라벨(본문 내용)
                // 일반메세지의 경우
                // [0] : 라벨(본문내용)
                groupBoxInTexts.Add(control.Text);
            }

            //우클릭인 경우
            if (e.Button.Equals(MouseButtons.Right))
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                menu.Items.Add("삭제");
                // 버튼(다운로드)의 경우
                groupBoxTag = ((GroupBox)sender).Tag.ToString();
                menu.ItemClicked += new ToolStripItemClickedEventHandler(Menu_ItemClicked);

                menu.Show((GroupBox)sender, new Point(e.X, e.Y));
            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Console.WriteLine( sender.ToString());
            switch (e.ClickedItem.Text)
            {
                case "삭제":
                    string[] contentValue = groupBoxTag.Split(':');
                    string[] contentTime = groupBoxTag.Split(']');
                    string query = "UPDATE s5584534.chatManagement SET contents='메세지가 삭제되었습니다.' WHERE ((writerName = '" + userID + "' AND receiverName = '" + receiverName + "') "
                + "OR (writerName = '" + receiverName + "' AND receiverName = '" + userID + "')) AND dateTime LIKE '%"+contentTime[0].Substring(1)+"%'AND contents='" + contentValue[3].Substring(1) + "';";
                    DBManager.GetDBManager().SqlNonReturnCommand(query);
                    flowLayoutPanelChatLog.Controls.Clear();
                    ChattedLoad();
                    break;
            }
        }

/*        private void Filebutton_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            client.Connect("118.67.142.129", 1028);
            NetworkStream stream = MainForm.mainform.client.GetStream();
            byte[] data = Encoding.Default.GetBytes(message);
            data = new byte[256];
            string responseData = "";

            int bytes = stream.Read(data, 0, data.Length);
            responseData = Encoding.Default.GetString(data, 0, bytes);
            Console.WriteLine("수신: {0}", responseData);

            throw new NotImplementedException();
        }
*/
        int flag = 0;
        private void buttonSendEmoji_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                panelEmoticonBox.Visible = true;
                flag = 1;
            }
            else
            {
                panelEmoticonBox.Visible = false;
                flag = 0;
            }
        }

        private void pictureBoxEmo1_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, "[emoticon1]","0");
        }

        private void pictureBoxEmo2_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, "[emoticon2]","0");
        }

        private void pictureBoxEmo3_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, "[emoticon3]","0");
        }

        private void pictureBoxEmo4_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, "[emoticon4]","0");
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                MainForm.mainform.SendMessage(receiverName, "[ZIP]"+filepath+"]"+fileName, "0");  // zip부터 보내고 알아듣게 하기
            }
        }

        private void buttonSearchMsg_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            string line1 = DBManager.GetDBManager().SelectAll("SELECT date_format(dateTime, '%Y-%m-%d %H:%i:%s') AS dateTime FROM s5584534.chatManagement WHERE ((writerName = '" + userID + "' AND receiverName = '" + receiverName + "') "
                + "OR (writerName = '" + receiverName + "' AND receiverName = '" + userID + "')) AND contents LIKE '%" + chatSearchtextBox.Text + "%'", "dateTime");
            string line2 = DBManager.GetDBManager().SelectAll("SELECT writerName FROM s5584534.chatManagement WHERE ((writerName = '" + userID + "' AND receiverName = '" + receiverName + "') "
                + "OR (writerName = '" + receiverName + "' AND receiverName = '" + userID + "')) AND contents LIKE '%" + chatSearchtextBox.Text + "%'", "writerName");
            string line3 = DBManager.GetDBManager().SelectAll("SELECT contents FROM s5584534.chatManagement WHERE ((writerName = '" + userID + "' AND receiverName = '" + receiverName + "') "
                + "OR (writerName = '" + receiverName + "' AND receiverName = '" + userID + "')) AND contents LIKE '%" + chatSearchtextBox.Text + "%'", "contents");
            string[] dateTime = line1.Split('|');
            string[] writerName = line2.Split('|');
            string[] contents = line3.Split('|');
            for (int i = 0; i < contents.Length; i++)
            {
                string message = string.Format("[{0}]{1} : {2}", dateTime[i], writerName[i], contents[i]);
                if (message.Contains("[ZIP]"))
                {
                    continue;
                }
                else
                {
                    this.Invoke(new Action(delegate ()
                    {
                        textBox3.AppendText("\r\n" + message);
                        //textBox3.ScrollToCaret();
                    }));
                }
            }
        }
    }
}
