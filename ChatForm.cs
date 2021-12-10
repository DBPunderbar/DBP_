using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            MainForm.mainform.SendMessage(receiverName, textBoxWriteMsg.Text);
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
                    GroupBox groupBoxChat = new GroupBox();
                    groupBoxChat.Location = new Point(35, i * 150 + 20);

                    flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                    flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);
                    groupBoxChat.Tag = i + 1;

                    groupBoxChat.Text = "";

                    groupBoxChat.Width = 500;
                    groupBoxChat.Height = 50;

                    Label chat = new Label();
                    chat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                    chat.ForeColor = Color.DarkSlateBlue;
                    chat.Location = new Point(20, 20);
                    chat.AutoSize = true;

                    groupBoxChat.Controls.Add(chat);

                    chat.Text = message;

                    //Console.WriteLine(chat.Text);
                    //flowLayoutPanelChatLog.AppendText("\r\n" + message);
                    //flowLayoutPanelChatLog.ScrollToCaret();
                }));
            }
        }

        public void ReceiveChat(string writer, string receiver, string Message)
        {
            if (writer == userID && receiver == receiverName)
            {
                this.Invoke(new Action(delegate () {

                    GroupBox groupBoxChat = new GroupBox();
                    groupBoxChat.Location = new Point(35, 150 + 20);

                    flowLayoutPanelChatLog.Controls.Add(groupBoxChat);
                    flowLayoutPanelChatLog.ScrollControlIntoView(groupBoxChat);

                    groupBoxChat.Text = "";

                    groupBoxChat.Width = 500;
                    groupBoxChat.Height = 50;

                    Label chat = new Label();
                    chat.Font = new Font("나눔스퀘어", 10, FontStyle.Regular);
                    chat.ForeColor = Color.DarkSlateBlue;
                    chat.Location = new Point(20, 20);
                    chat.AutoSize = true;

                    groupBoxChat.Controls.Add(chat);

                    chat.Text = Message;

                    //flowLayoutPanelChatLog.AppendText("\r\n" + Message);
                    //flowLayoutPanelChatLog.ScrollToCaret();
                }));
            }
        }

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
            MainForm.mainform.SendMessage(receiverName, "[emoticon1]");
        }

        private void pictureBoxEmo2_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, "[emoticon2]");
        }

        private void pictureBoxEmo3_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, "[emoticon3]");
        }

        private void pictureBoxEmo4_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SendMessage(receiverName, "[emoticon4]");
        }
    }
}
