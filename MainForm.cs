﻿using DBP.Properties;
using MySql.Data.MySqlClient;
//using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBP
{
    public partial class MainForm : Form
    {
        private string userID = "";
        DataTable table = new DataTable();

        TcpClient client;
        public Thread receiveMessageThread = null;
        public static MainForm mainform;

        public MainForm(string userID)
        {
            this.userID = userID;
            mainform = this;
            InitializeComponent();
            SetColor();

            DataTable dataTableInfo = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT * FROM user WHERE userID = '" + userID + "'");
            DataRow dataRowInfo = dataTableInfo.Rows[0];
            string DarkFlag = dataRowInfo["DarkFlag"].ToString();

            if (DarkFlag == "False")
            {
                DarkMode.SetarModeDark();
                SetColor();
            }
            else if (DarkFlag == "True")
            {
                DarkMode.SetarModeClear();
                SetColor();
            }

            Connect();
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
        //↑여기까지

        /*private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo mainForm3 = new UpdateInfo(userID);
            mainForm3.ShowDialog();
        }*/

        //친구 테이블이 생성되었으니까 따로 수정 필요

        //main폼이 불러와질때 친구 버튼 클릭 이벤트로 연결해서 폼이 불러와질때 친구목록이 뜨도록..
        //여기에 문제는 버튼이 클릭될때마다 friendsPage 객체가 생성된다는 것..? ==> ㅠㅠ
        //근데 동적생성을 안하면(그러니까 메인폼 Designer에 넣는 방식으로 하면 userID를 생성자로 못넘겨..)
        //생성자로 보내는 방법 말고 다른 방법이 있다면 이 부분도 수정이 가능할텐데.
        private void buttonFriend_Click(object sender, EventArgs e)
        {
            buttonChatting.Image = Resources.message_nc;
            buttonFriend.Image = Resources.friend_c;
            friendsPage friendsPage1 = new friendsPage(userID);
            friendsPage1.Location = new Point(98, 39);
            //828, 543
            friendsPage1.Size = new Size(828, 543);

            Controls.Add(friendsPage1);
            friendsPage1.BringToFront();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            SendMessage("Server", "/exit");
            receiveMessageThread.Abort();
            this.Close();
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SetColor()
        {
            //panel1.BackColor = DarkMode.panelcolor;
            panel2.BackColor = DarkMode.panelcolor;
            //messagePage1.BackColor = DarkMode.backcolor; -> messagePage1을 새로 생성해서 다크모드 적용이 안되는 것 같습니다,,
            buttonDarkMode.Image = DarkMode.imgMode;
            buttonMin.ForeColor = DarkMode.fontcolor;
            buttonClose.ForeColor = DarkMode.fontcolor;
            buttonFriend.Image = DarkMode.imgMode_fbtn;

            if (buttonChatting.Image == Resources.message_nc)
            {
                buttonChatting.Image = DarkMode.imgMode_cbtn;
            }
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
            DarkMode.changeMode(userID);
            SetColor();
        }

        private void buttonChatting_Click(object sender, EventArgs e)
        {
            buttonChatting.Image = Resources.message_c;
            buttonFriend.Image = Resources.friend_nc;
            messagesPage messagePage1 = new messagesPage(userID);
            messagePage1.Location = new Point(98, 39);
            messagePage1.Size = new Size(828, 543);

            Controls.Add(messagePage1);
            messagePage1.BringToFront();
        }

        private void buttonAddFriends_Click(object sender, EventArgs e)
        {
            FindFriends findfriends = new FindFriends(userID);
            findfriends.Show();
        }

        private void Connect()
        {
            client = new TcpClient();
            client.Connect("118.67.142.129", 1026); //118.67.142.129

            string parsedName = "|||" + userID;
            byte[] byteData = new byte[1024];
            byteData = Encoding.Unicode.GetBytes(parsedName);
            client.GetStream().Write(byteData, 0, byteData.Length);

            receiveMessageThread = new Thread(ReceiveMessage);
            receiveMessageThread.Start();
        }

        public string receiveMessage = "";
        public string parsedMessage = "";
        public void ReceiveMessage()
        {
            //ChatForm chatform = new ChatForm(userID, "");
            while (true)
            {
                byte[] receiveByte = new byte[1024];
                client.GetStream().Read(receiveByte, 0, receiveByte.Length);
                receiveMessage = Encoding.Unicode.GetString(receiveByte);
                string[] parse = receiveMessage.Split('|'); // [0]:writerName, [1]:receiverName, [2]:dateTime, [3]:contents
                parsedMessage = string.Format("[{0}]{1} : {2}", parse[2], parse[0], parse[3]);

                if (parsedMessage.Contains("/exit"))
                {
                    return;
                }

                string receiver;
                if (parse[1] == userID)
                {
                    receiver = parse[0];
                }
                else
                {
                    receiver = parse[1];
                }

                Form CF = Application.OpenForms[userID + receiver];
                if (CF == null)
                {
                    MessageBox.Show("알림");
                }
                else
                {
                    this.Invoke(new Action(delegate ()
                    {
                        //((ChatForm)CF).richTextBoxChatLog.AppendText("\r\n" + parsedMessage);
                        //((ChatForm)CF).richTextBoxChatLog.ScrollToCaret();
                    }));
                }

                if (parsedMessage.Contains("[emoticon")) {
                    if (parsedMessage.Contains("[emoticon1]")) {
                        ((ChatForm)CF).pictureBox1.Image = DBP.Properties.Resources.emoticon1;
                    }
                    else if (parsedMessage.Contains("[emoticon2]")) {
                        ((ChatForm)CF).pictureBox1.Image = DBP.Properties.Resources.emoticon2;
                    }
                    else if (parsedMessage.Contains("[emoticon3]")) {
                        ((ChatForm)CF).pictureBox1.Image = DBP.Properties.Resources.emoticon3;
                    }
                    else if (parsedMessage.Contains("[emoticon4]")) {
                        ((ChatForm)CF).pictureBox1.Image = DBP.Properties.Resources.emoticon4;
                    }
                }


                //ChatForm CF = new ChatForm(parse[0], parse[1]);
                //CF.richTextBoxChatLog.AppendText("\r\n" + parsedMessage);
                //ChatForm CF2 = new ChatForm(parse[1], parse[0]);
                //CF2.richTextBoxChatLog.AppendText("\r\n" + parsedMessage);

                //if (ChatForm.chatform.Created == false)
                //    MessageBox.Show("새 메시지");
                //ChatForm.chatform.ReceiveChat(parse[0], parse[1], parsedMessage);
                //ChatForm.chatform.ReceiveChat(parse[1], parse[0], parsedMessage);
            }
        }

        public void SendMessage(string receiverName, string text)
        {
            string message = string.Format("{0}|{1}|{2}|{3}|", userID, receiverName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), text);
            byte[] byteData = null;

            byteData = new byte[message.Length];
            byteData = Encoding.Unicode.GetBytes(message);
            client.GetStream().Write(byteData, 0, byteData.Length);
        }
    }
}
