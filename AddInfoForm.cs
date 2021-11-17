using MySql.Data.MySqlClient;
using System;
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
using MouveForm;

namespace Modal.test
{
    public partial class AddInfoForm : Form
    {
        public AddInfoForm()
        {
            InitializeComponent();
            MouveForm.Mouve.Go(panel1);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(pictureBoxProfile.Tag.ToString(), FileMode.Open, FileAccess.Read);
            byte[] bImage = new byte[fs.Length];
            fs.Read(bImage, 0, (int)fs.Length);

            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                string query = "INSERT INTO user(ID, userID, userPW, name, addr, nickname, profileImage) VALUES (NULL, '" + textBoxID.Text + "', '" + textBoxPW.Text + "', '" + textBoxName.Text + "', '" + textBoxAddr1.Text + "', '" + textBoxNickname.Text + "', @Image)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Image", bImage);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            fs.Close();

            this.Close();
        }

        private void buttonPictureRegister_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
            }

            else
                return;

            pictureBoxProfile.Image = Bitmap.FromFile(image_file);
            pictureBoxProfile.Tag = dialog.FileName;
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFindZoneCode_Click(object sender, EventArgs e)
        {
            AddressFinder.AdressFinder frm = new AddressFinder.AdressFinder();
            frm.ShowDialog();

            if (frm.Tag == null) { return; }
            DataRow dr = (DataRow)frm.Tag;

            textBoxAddr1.Text = dr["zonecode"].ToString();
            textBoxAddr2.Text = dr["ADDR1"].ToString();
            textBoxAddr3.Text = "";
            textBoxAddr4.Text = dr["EX"].ToString();

            textBoxAddr3.Focus();
        }

        private void buttonIDCheck_Click(object sender, EventArgs e)
        {
            IsIDChecked(textBoxID.Text);
        }

        public bool IsIDChecked(string valueToChecked)
        {
            if (valueToChecked == null)
            {
                MessageBox.Show("ID를 적어주세요.");
                return false;
            }
            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                string query = "SELECT * FROM s5584534.user WHERE userID='" + valueToChecked + "';";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr == null)
                {
                    MessageBox.Show("사용 가능한 ID입니다.");
                    conn.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("이미 존재하는 ID입니다.");
                    conn.Close();
                    return false;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*
private void buttonFindZoneCode_Click(object sender, EventArgs e)
{
   AddressFinder frm = new AddressFinder();
   frm.ShowDialog();

   if (frm.Tag == null) { return; }
   DataRow dr = (DataRow)frm.Tag;

   textBoxAddr1.Text = dr["zonecode"].ToString();
   textBoxAddr2.Text = dr["ADDR1"].ToString();
   textBoxAddr3.Text = "";
   textBoxAddr4.Text = dr["EX"].ToString();

   textBoxAddr3.Focus();
}
*/
    }
}
