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
using AddressFinder;

namespace Modal.test
{
    public partial class AddInfoForm : Form
    {
        public AddInfoForm()
        {
            InitializeComponent();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(pictureBoxProfile.Tag.ToString(), FileMode.Open, FileAccess.Read);
            byte[] bImage = new byte[fs.Length];
            fs.Read(bImage, 0, (int)fs.Length);
            //string query = "INSERT INTO user(ID, userID, userPW, name, addr, nickname, profileImage, role) VALUES (NULL, '" + textBoxID.Text + "', '" + textBoxPW.Text + "', '" + textBoxName.Text + "', '" + textBoxAddr1.Text + "', '" + textBoxNickname.Text + "', @Image, '" + textBoxPosition.Text + "')";

            string addr = textBoxAddr1.Text + "|" + textBoxAddr2.Text + "|" + textBoxAddr3.Text + "|" + textBoxAddr4.Text + "|";
            string query = "INSERT INTO user(ID, userID, userPW, name, addr, nickname, stateMessage, profileImage, role) VALUES (NULL, '" + textBoxID.Text + "', hex(aes_encrypt('" + textBoxPW.Text + "','pw')), '" + textBoxName.Text + "', '" + addr + "', '" + textBoxNickname.Text + "', '" + textBoxStateMessage.Text + "', @Image, '" + textBoxPosition.Text + "')";
            //string query = "UPDATE user SET userPW = '" + textBoxPW.Text + "', name = '" + textBoxName.Text + "', addr = '" + textBoxAddr.Text + "', nickname = '" + textBoxNickname.Text + "', profileImage = @Image , role = '" + textBoxPosition.Text + "' WHERE userID = '" + textBoxID.Text + "'";

            DBManager.GetDBManager().SqlImageCommand(query, bImage);
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
            AdressFinder frm = new AdressFinder();
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
            
            string query = "SELECT COUNT(*) as cnt FROM s5584534.user WHERE userID='" + valueToChecked + "';";
            DataTable checkedTable = new DataTable();
            checkedTable = DBManager.GetDBManager().SqlDataTableReturnCommand(query);
            DataRow dataRow = checkedTable.Rows[0];
            if (Convert.ToInt32(dataRow["cnt"]) == 0)
            {
                MessageBox.Show("사용 가능한 ID입니다.");
                return true;
            }
            else
            {
                MessageBox.Show("이미 존재하는 ID입니다.");
                return false;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
