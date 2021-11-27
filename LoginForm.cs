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
using MySql.Data.MySqlClient;

namespace Modal.test
{
    public partial class LoginForm : Form
    {
        //userID를 다른 class에서 얻어올 수 있게 static으로 해야 하나..? 왜냐면 객체 생성없이도 해야 하니까?
        //근데 static이면 textBox에 접근할 수 없어 static은 static속성에만 접근이 가능하니까

        private string userID = "";
        private bool textBoxIDChange = false;
        public string getUserId()
        {
            if (textBoxIDChange)
                return userID;
            else
                return "입력없음";
        }

        public LoginForm()
        {
            InitializeComponent();
            LoadLoginData();
        }

        //창 이동
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

        private void LoadLoginData()
        {
            StreamWriter sw = new StreamWriter(new FileStream("login.dat", FileMode.Append)); // 처음 프로그램 실행 시 login.dat 생성 위함
            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("login.dat", FileMode.Open));

            string a = sr.ReadLine(); // 파일 구조 [ 체크박스 체크여부(1 or 0) / ID / PW(쿼리문을 통한 암호화, 복호화 처리) ]

            if (a == "1")
            {
                textBoxID.Text = sr.ReadLine();
                sr.Close();
                string query = "SELECT * FROM s5584534.user WHERE userID= '" + textBoxID.Text + "'";

                DataTable tb = DBManager.GetDBManager().SqlDataTableReturnCommand(query);
                DataRow data = tb.Rows[0];
                textBoxPW.Text = data["userPW"].ToString();

                // 원하시는 방법을 사용은 했지만 굳이 반복문을 돌아야되는지 모르겠습니다..(성민)
                //foreach (DataRow data in tb.Rows)

                
                checkBoxAutoLogin.Checked = true;
            }
            else
            {
                sr.Close();
                sw = new StreamWriter(new FileStream("login.dat", FileMode.Create));

                sw.WriteLine("0");
                sw.WriteLine("");

                sw.Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string query = "Select Count(*) as cnt from user where userID = '" + textBoxID.Text + "' and userPW = '" + textBoxPW.Text + "'";

            DataTable dt = DBManager.GetDBManager().SqlDataTableReturnCommand(query);
            DataRow dataRow = dt.Rows[0];
            if (dataRow["cnt"].ToString() == "1")
                {
                //로그인 성공

                if (checkBoxAutoLogin.Checked == true)
                {
                    StreamWriter sw = new StreamWriter(new FileStream("login.dat", FileMode.Create));

                    sw.WriteLine("1");
                    sw.WriteLine(textBoxID.Text.ToString());

                    sw.Close();
                }

                else
                {
                    StreamWriter sw = new StreamWriter(new FileStream("login.dat", FileMode.Create));

                    sw.WriteLine("0");
                    sw.WriteLine("");

                    sw.Close();
                }

                MainForm fr = new MainForm(userID);
                    this.Hide();

                    fr.ShowDialog();
                    this.Close();

            }
                else
                {
                    //로그인 실패
                    MessageBox.Show("아이디와 비밀번호를 확인해주세요.");
                }
           
        }

    }
}
