using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal.test
{
    public partial class FindFriends : Form
    {
        //placeholder 설정
        public bool test = false;
        TextBox[] txtList;
        const string IdPlaceholder = "친구의 ID를 입력하세요 ...";

        public FindFriends()
        {
            InitializeComponent();

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

        DataTable table = new DataTable();

        private string userID = "";

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                string query = "SELECT * FROM s5584534.user WHERE userID='" + textBoxSearch.Text + "';";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr == null)
                    MessageBox.Show("일치하는 ID가 없습니다.");
                else
                    textBoxSearchResult.Text = rdr["userID"].ToString() + "\t" + rdr["name"].ToString();

                conn.Close();
            }
        }

        public void searchData(string valueToSearch)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                string query = "SELECT * FROM s5584534.user WHERE userID='" + textBoxSearch.Text + "';";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr == null)
                    MessageBox.Show("일치하는 ID가 없습니다.");
                else
                    textBoxSearchResult.Text = rdr["userID"].ToString();

                conn.Close();
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                if (textBoxSearchResult.Text == "")
                {
                    MessageBox.Show("검색 정보를 입력해주세요");
                }
                else
                {
                    string query = "INSERT INTO friends(userID, friendID) VALUES ('" + userID + "', '" + textBoxSearchResult.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    //텍스트 박스 초기화
                    textBoxSearchResult.Text = "";
                }

            }
        }

        private void FindFriends_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }
    }
}
