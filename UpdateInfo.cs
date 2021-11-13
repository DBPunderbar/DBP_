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

namespace Modal.test
{
    public partial class UpdateInfo : Form
    {
        public UpdateInfo()
        {
            InitializeComponent();
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(pictureBoxProfile.Tag.ToString(), FileMode.Open, FileAccess.Read);
            byte[] bImage = new byte[fs.Length];
            fs.Read(bImage, 0, (int)fs.Length);

            using (MySqlConnection conn = new MySqlConnection("Server=27.96.130.41;Database=s5584534;Uid=s5584534;Pwd=s5584534;Charset=utf8"))
            {
                conn.Open();

                //string query = "INSERT INTO user(ID, userID, userPW, name, addr, nickname, profileImage) VALUES (NULL, '" + textBoxID.Text + "', '" + textBoxPW.Text + "', '" + textBoxName.Text + "', '" + textBoxAddr.Text + "', '" + textBoxNickname.Text + "', @Image)";
                string query = "UPDATE user SET userPW = '" + textBoxPW.Text + "', name = '" + textBoxName.Text + "', addr = '" + textBoxAddr.Text + "', nickname = '" + textBoxNickname.Text + "', profileImage = @Image WHERE userID = '" + textBoxID.Text + "'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Image", bImage);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            fs.Close();

            /* 혹시 사진을 불러오고 싶을 때
             *
            SqlCommand cmd = new SqlCommand("SELECT Image FROM IMAGE WHERE ImageNo=@ImageNo", conn);
            cmd.Parameters.AddWithValue("@ImageNo", 1);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
           
            byte[] bImage = null;
            while (reader.Read())
            {
                bImage =  (byte[])reader[0];
            }
            if (bImage != null)
                 pbxImage.Image = new Bitmap(new MemoryStream(bImage));                       
            reader.Close();
            conn.Close();
             *
             */
        }
    }
}
