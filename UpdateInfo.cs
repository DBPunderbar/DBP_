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

namespace DBP
{
    public partial class UpdateInfo : Form
    {
        private string userID = "";
        public UpdateInfo()
        {
            InitializeComponent();
            initValues();
        }

        //불러와질때 정보가 남아있도록
        private void initValues()
        {
            DataTable dataTableInfo = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT *, CAST(AES_DECRYPT(UNHEX(userPW), 'pw') as char) as pw FROM user WHERE userID = '" + userID + "'");
            DataRow dataRowInfo = dataTableInfo.Rows[0];

            byte[] friendbImage = (byte[])dataRowInfo["profileImage"];
            if (friendbImage != null)
            {
                pictureBoxProfile.Image = new Bitmap(new MemoryStream(friendbImage));
                pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            string[] stringArrayAddr = dataRowInfo["addr"].ToString().Split('|');
            textBoxAddr.Text = stringArrayAddr[0];
            textBoxAddr2.Text = stringArrayAddr[1];
            textBoxAddr3.Text = stringArrayAddr[2];
            textBoxAddr4.Text = stringArrayAddr[3];

            textBoxPW.Text = dataRowInfo["pw"].ToString();
            textBoxName.Text = dataRowInfo["name"].ToString();
            textBoxNickname.Text = dataRowInfo["nickname"].ToString();
            textBoxPosition.Text = dataRowInfo["role"].ToString();
            textBoxStateMessage.Text = dataRowInfo["stateMessage"].ToString();

        }
        public UpdateInfo(string userID)
        {
            InitializeComponent();
            this.userID = userID;
            labelUserID.Text = userID;
            initValues();
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
            DataTable dataTableInfo = DBManager.GetDBManager().SqlDataTableReturnCommand("SELECT *, CAST(AES_DECRYPT(UNHEX(userPW), 'pw') as char) as pw FROM user WHERE userID = '" + userID + "'");
            DataRow dataRowInfo = dataTableInfo.Rows[0];

            byte[] bImage = (byte[])dataRowInfo["profileImage"];
            if (pictureBoxProfile.Tag != null)
            {
                FileStream fs = new FileStream(pictureBoxProfile.Tag.ToString(), FileMode.Open, FileAccess.Read);
                bImage = new byte[fs.Length];
                fs.Read(bImage, 0, (int)fs.Length);
                fs.Close();
            }

            string addr = textBoxAddr.Text + "|" + textBoxAddr2.Text + "|" + textBoxAddr3.Text + "|" + textBoxAddr4.Text + "|";
            DBManager.GetDBManager().SqlImageCommand("UPDATE user SET userPW = hex(aes_encrypt('" + textBoxPW.Text + "','pw')), name = '" + textBoxName.Text + "', addr = '" + addr + "', nickname = '" + textBoxNickname.Text + "', profileImage = @Image , role = '" + textBoxPosition.Text + "', stateMessage = '" + textBoxStateMessage.Text + "' WHERE userID = '" + userID + "'", bImage);

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
    }
}
