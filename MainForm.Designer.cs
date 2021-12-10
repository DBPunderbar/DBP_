
namespace DBP
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonFriend = new System.Windows.Forms.Button();
            this.buttonChatting = new System.Windows.Forms.Button();
            this.buttonAddFriends = new System.Windows.Forms.Button();
            this.buttonDarkMode = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonAddFriends);
            this.panel1.Controls.Add(this.buttonDarkMode);
            this.panel1.Controls.Add(this.buttonMin);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 39);
            this.panel1.TabIndex = 9;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveWindow_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveWindow_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveWindow_MouseUp);
            // 
            // buttonMin
            // 
            this.buttonMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMin.FlatAppearance.BorderSize = 0;
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonMin.Location = new System.Drawing.Point(848, 0);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(39, 39);
            this.buttonMin.TabIndex = 1;
            this.buttonMin.Text = "_";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonClose.Location = new System.Drawing.Point(887, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(39, 39);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.buttonFriend);
            this.panel2.Controls.Add(this.buttonChatting);
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 546);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(98, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 546);
            this.panel3.TabIndex = 11;
            // 
            // buttonFriend
            // 
            this.buttonFriend.BackColor = System.Drawing.Color.Transparent;
            this.buttonFriend.FlatAppearance.BorderSize = 0;
            this.buttonFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFriend.Image = global::DBP.Properties.Resources.friend_c1;
            this.buttonFriend.Location = new System.Drawing.Point(12, 40);
            this.buttonFriend.Name = "buttonFriend";
            this.buttonFriend.Size = new System.Drawing.Size(75, 76);
            this.buttonFriend.TabIndex = 0;
            this.buttonFriend.UseVisualStyleBackColor = false;
            this.buttonFriend.Click += new System.EventHandler(this.buttonFriend_Click);
            // 
            // buttonChatting
            // 
            this.buttonChatting.BackColor = System.Drawing.Color.Transparent;
            this.buttonChatting.FlatAppearance.BorderSize = 0;
            this.buttonChatting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChatting.Image = global::DBP.Properties.Resources.message_nc1;
            this.buttonChatting.Location = new System.Drawing.Point(12, 158);
            this.buttonChatting.Name = "buttonChatting";
            this.buttonChatting.Size = new System.Drawing.Size(75, 76);
            this.buttonChatting.TabIndex = 1;
            this.buttonChatting.UseVisualStyleBackColor = false;
            this.buttonChatting.Click += new System.EventHandler(this.buttonChatting_Click);
            // 
            // buttonAddFriends
            // 
            this.buttonAddFriends.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddFriends.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddFriends.FlatAppearance.BorderSize = 0;
            this.buttonAddFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFriends.Image = global::DBP.Properties.Resources.addFriend_b;
            this.buttonAddFriends.Location = new System.Drawing.Point(770, 0);
            this.buttonAddFriends.Name = "buttonAddFriends";
            this.buttonAddFriends.Size = new System.Drawing.Size(39, 39);
            this.buttonAddFriends.TabIndex = 3;
            this.buttonAddFriends.UseVisualStyleBackColor = false;
            this.buttonAddFriends.Click += new System.EventHandler(this.buttonAddFriends_Click);
            // 
            // buttonDarkMode
            // 
            this.buttonDarkMode.BackColor = System.Drawing.Color.Transparent;
            this.buttonDarkMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDarkMode.FlatAppearance.BorderSize = 0;
            this.buttonDarkMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDarkMode.Image = global::DBP.Properties.Resources.dark1;
            this.buttonDarkMode.Location = new System.Drawing.Point(809, 0);
            this.buttonDarkMode.Name = "buttonDarkMode";
            this.buttonDarkMode.Size = new System.Drawing.Size(39, 39);
            this.buttonDarkMode.TabIndex = 2;
            this.buttonDarkMode.UseVisualStyleBackColor = false;
            this.buttonDarkMode.Click += new System.EventHandler(this.buttonDarkMode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 583);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.buttonFriend_Click);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFriend;
        private System.Windows.Forms.Button buttonChatting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonDarkMode;
        private System.Windows.Forms.Button buttonAddFriends;
    }
}

