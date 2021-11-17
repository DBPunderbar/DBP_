
namespace Modal.test
{
    partial class AddInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddr1 = new System.Windows.Forms.TextBox();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddInfo = new System.Windows.Forms.Button();
            this.buttonPictureRegister = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonFindZoneCode = new System.Windows.Forms.Button();
            this.textBoxAddr2 = new System.Windows.Forms.TextBox();
            this.textBoxAddr3 = new System.Windows.Forms.TextBox();
            this.textBoxAddr4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(107, 40);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(256, 25);
            this.textBoxID.TabIndex = 0;
            // 
            // textBoxPW
            // 
            this.textBoxPW.Location = new System.Drawing.Point(107, 81);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.Size = new System.Drawing.Size(256, 25);
            this.textBoxPW.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(107, 124);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(256, 25);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxAddr1
            // 
            this.textBoxAddr1.Location = new System.Drawing.Point(107, 164);
            this.textBoxAddr1.Name = "textBoxAddr1";
            this.textBoxAddr1.Size = new System.Drawing.Size(129, 25);
            this.textBoxAddr1.TabIndex = 3;
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.Location = new System.Drawing.Point(107, 267);
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.Size = new System.Drawing.Size(256, 25);
            this.textBoxNickname.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "PW";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "주소";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "별명";
            // 
            // buttonAddInfo
            // 
            this.buttonAddInfo.Location = new System.Drawing.Point(382, 303);
            this.buttonAddInfo.Name = "buttonAddInfo";
            this.buttonAddInfo.Size = new System.Drawing.Size(118, 25);
            this.buttonAddInfo.TabIndex = 10;
            this.buttonAddInfo.Text = "회원가입";
            this.buttonAddInfo.UseVisualStyleBackColor = true;
            this.buttonAddInfo.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonPictureRegister
            // 
            this.buttonPictureRegister.Location = new System.Drawing.Point(382, 264);
            this.buttonPictureRegister.Name = "buttonPictureRegister";
            this.buttonPictureRegister.Size = new System.Drawing.Size(118, 27);
            this.buttonPictureRegister.TabIndex = 11;
            this.buttonPictureRegister.Text = "사진 불러오기";
            this.buttonPictureRegister.UseVisualStyleBackColor = true;
            this.buttonPictureRegister.Click += new System.EventHandler(this.buttonPictureRegister_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(382, 81);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(118, 171);
            this.pictureBoxProfile.TabIndex = 12;
            this.pictureBoxProfile.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "프로필 사진";
            // 
            // buttonFindZoneCode
            // 
            this.buttonFindZoneCode.Location = new System.Drawing.Point(242, 159);
            this.buttonFindZoneCode.Name = "buttonFindZoneCode";
            this.buttonFindZoneCode.Size = new System.Drawing.Size(121, 30);
            this.buttonFindZoneCode.TabIndex = 14;
            this.buttonFindZoneCode.Text = "우편번호 찾기";
            this.buttonFindZoneCode.UseVisualStyleBackColor = true;
            this.buttonFindZoneCode.Click += new System.EventHandler(this.buttonFindZoneCode_Click);
            // 
            // textBoxAddr2
            // 
            this.textBoxAddr2.Location = new System.Drawing.Point(107, 195);
            this.textBoxAddr2.Name = "textBoxAddr2";
            this.textBoxAddr2.Size = new System.Drawing.Size(256, 25);
            this.textBoxAddr2.TabIndex = 15;
            // 
            // textBoxAddr3
            // 
            this.textBoxAddr3.Location = new System.Drawing.Point(107, 227);
            this.textBoxAddr3.Name = "textBoxAddr3";
            this.textBoxAddr3.Size = new System.Drawing.Size(155, 25);
            this.textBoxAddr3.TabIndex = 16;
            this.textBoxAddr3.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxAddr4
            // 
            this.textBoxAddr4.Location = new System.Drawing.Point(269, 226);
            this.textBoxAddr4.Name = "textBoxAddr4";
            this.textBoxAddr4.Size = new System.Drawing.Size(94, 25);
            this.textBoxAddr4.TabIndex = 17;
            this.textBoxAddr4.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "직책";
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(107, 305);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(256, 25);
            this.textBoxPosition.TabIndex = 19;
            // 
            // AddInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 349);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAddr4);
            this.Controls.Add(this.textBoxAddr3);
            this.Controls.Add(this.textBoxAddr2);
            this.Controls.Add(this.buttonFindZoneCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.buttonPictureRegister);
            this.Controls.Add(this.buttonAddInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNickname);
            this.Controls.Add(this.textBoxAddr1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxPW);
            this.Controls.Add(this.textBoxID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddInfoForm";
            this.Text = "회원가입";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPW;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddr1;
        private System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddInfo;
        private System.Windows.Forms.Button buttonPictureRegister;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonFindZoneCode;
        private System.Windows.Forms.TextBox textBoxAddr2;
        private System.Windows.Forms.TextBox textBoxAddr3;
        private System.Windows.Forms.TextBox textBoxAddr4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPosition;
    }
}