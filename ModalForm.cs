﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Modal.test
{
    public partial class ModalForm : Form
    {
        public ModalForm()
        {
            InitializeComponent();
            LoadLoginData();
        }

        private void LoadLoginData()
        {
            StreamWriter sw = new StreamWriter(new FileStream("login.dat", FileMode.Append)); // 처음 프로그램 실행 시 login.dat 생성 위함
            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("login.dat", FileMode.Open));

            string a = sr.ReadLine(); // 파일 구조 [ 체크박스 체크여부(1 or 0) / ID / PW ]
            if (a == "1")
            {
                textBoxID.Text = sr.ReadLine();
                textBoxPW.Text = sr.ReadLine();
                sr.Close();

                checkBoxAutoLogin.Checked = true;
            }

            else
            {
                sr.Close();
                sw = new StreamWriter(new FileStream("login.dat", FileMode.Create));

                sw.WriteLine("0");
                sw.WriteLine("");
                sw.WriteLine("");

                sw.Close();
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string strconn = "Server = 27.96.130.41;Port = 3306;Database = s5584534;Uid = s5584534;Pwd=s5584534;Charset=utf8;";

            using (MySqlConnection connection = new MySqlConnection(strconn))
            {
                string insertQuery = "Select Count(*) from user where userID = '" + textBoxID.Text + "' and userPW = '" + textBoxPW.Text + "'";

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                MySqlDataReader rdr = command.ExecuteReader();
                rdr.Read();
                if (rdr[0].ToString() == "1")
                {
                    //로그인 성공
                    this.Hide();

                    this.Close();
                }
                else
                {
                    //로그인 실패
                    MessageBox.Show("아이디와 비밀번호를 확인해주세요.");
                }
                connection.Close();
            }
            if (checkBoxAutoLogin.Checked == true)
            {
                StreamWriter sw = new StreamWriter(new FileStream("login.dat", FileMode.Create));

                sw.WriteLine("1");
                sw.WriteLine(textBoxID.Text);
                sw.WriteLine(textBoxPW.Text);

                sw.Close();
            }

            else
            {
                StreamWriter sw = new StreamWriter(new FileStream("login.dat", FileMode.Create));

                sw.WriteLine("0");
                sw.WriteLine("");
                sw.WriteLine("");

                sw.Close();
            }
        }

        private void buttonAddInfo_Click(object sender, EventArgs e)
        {
            AddInfoForm mainForm2 = new AddInfoForm();
            mainForm2.ShowDialog();
        }

        private void checkBoxAutoLogin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}