using AddressFinder;
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
        private string userID = "";
        public UpdateInfo()
        {
            InitializeComponent();
        }
        public UpdateInfo(string userID)
        {
            InitializeComponent();
            this.userID = userID;
            labelUserID.Text = userID;
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

            string addr = textBoxAddr.Text + "|" + textBoxAddr2.Text + "|" + textBoxAddr3.Text + "|" + textBoxAddr4.Text + "|";
            DBManager.GetDBManager().SqlImageCommand("UPDATE user SET userPW = hex(aes_encrypt('" + textBoxPW.Text + "','pw')), name = '" + textBoxName.Text + "', addr = '" + addr + "', nickname = '" + textBoxNickname.Text + "', profileImage = @Image , role = '" + textBoxPosition.Text + "' WHERE userID = '" + userID + "'", bImage);

            fs.Close();
            this.Close();


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

        private void buttonFindZoneCode_Click(object sender, EventArgs e)
        {
            AdressFinder addressFinder = new AdressFinder();
            addressFinder.ShowDialog();

            if (addressFinder.Tag == null) { return; }
            DataRow dr = (DataRow)addressFinder.Tag;

            textBoxAddr.Text = dr["zonecode"].ToString();
            textBoxAddr2.Text = dr["ADDR1"].ToString();
            textBoxAddr3.Text = "";
            textBoxAddr4.Text = dr["EX"].ToString();

            textBoxAddr4.Focus();
        }
    }
}
