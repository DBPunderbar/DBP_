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
    public partial class friendsPage : UserControl
    {
        public friendsPage()
        {
            InitializeComponent();
        }

        private string userID = "";
        DataTable table = new DataTable();

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
        /*
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
        }*/


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
    }
}
