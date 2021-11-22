using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Modal.test
{
    public class DBManager
    {
        private static DBManager instance_ = new DBManager();
        private string strconn = "Server = 27.96.130.41; Port = 3306; Database = s5584534; Uid = s5584534; Pwd = s5584534; Charset = utf8;";

        public static DBManager GetDBManager()
        {
            return instance_;
        }

        // Data테이블 리턴하는 query문 처리 함수
        public DataTable SqlDataTableReturnCommand(string query)
        {
            DataTable result = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                result.Load(rdr);
                conn.Close();
            }

                return result;
        }

        // insert문처럼 단순 실행만 필요한 처리 함수
        public void SqlNonReturnCommand(string query)
        {
            DataTable result = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // image 삽입 쿼리문 함수
        public void SqlImageCommand(string query)
        {
            DataTable result = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Image", bImage);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DBManager()
        {
        }
    }
}
