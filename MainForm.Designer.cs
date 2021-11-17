
namespace Modal.test
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
            this.buttonFriend = new System.Windows.Forms.Button();
            this.buttonChatting = new System.Windows.Forms.Button();
            this.buttonGoLogin = new System.Windows.Forms.Button();
            this.buttonUpdateInfo = new System.Windows.Forms.Button();
            this.textBoxSearchResult = new System.Windows.Forms.TextBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonDarkMode = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFriend
            // 
            this.buttonFriend.Location = new System.Drawing.Point(12, 32);
            this.buttonFriend.Name = "buttonFriend";
            this.buttonFriend.Size = new System.Drawing.Size(75, 23);
            this.buttonFriend.TabIndex = 0;
            this.buttonFriend.Text = "친구";
            this.buttonFriend.UseVisualStyleBackColor = true;
            this.buttonFriend.Click += new System.EventHandler(this.buttonFriend_Click);
            // 
            // buttonChatting
            // 
            this.buttonChatting.Location = new System.Drawing.Point(12, 73);
            this.buttonChatting.Name = "buttonChatting";
            this.buttonChatting.Size = new System.Drawing.Size(75, 23);
            this.buttonChatting.TabIndex = 1;
            this.buttonChatting.Text = "채팅";
            this.buttonChatting.UseVisualStyleBackColor = true;
            // 
            // buttonGoLogin
            // 
            this.buttonGoLogin.Location = new System.Drawing.Point(12, 494);
            this.buttonGoLogin.Name = "buttonGoLogin";
            this.buttonGoLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonGoLogin.TabIndex = 2;
            this.buttonGoLogin.Text = "로그인";
            this.buttonGoLogin.UseVisualStyleBackColor = true;
            this.buttonGoLogin.Click += new System.EventHandler(this.buttonGoLogin_Click);
            // 
            // buttonUpdateInfo
            // 
            this.buttonUpdateInfo.Location = new System.Drawing.Point(12, 448);
            this.buttonUpdateInfo.Name = "buttonUpdateInfo";
            this.buttonUpdateInfo.Size = new System.Drawing.Size(75, 28);
            this.buttonUpdateInfo.TabIndex = 4;
            this.buttonUpdateInfo.Text = "정보수정";
            this.buttonUpdateInfo.UseVisualStyleBackColor = true;
            this.buttonUpdateInfo.Click += new System.EventHandler(this.buttonUpdateInfo_Click);
            // 
            // textBoxSearchResult
            // 
            this.textBoxSearchResult.Location = new System.Drawing.Point(626, 143);
            this.textBoxSearchResult.Multiline = true;
            this.textBoxSearchResult.Name = "textBoxSearchResult";
            this.textBoxSearchResult.Size = new System.Drawing.Size(261, 346);
            this.textBoxSearchResult.TabIndex = 5;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(626, 112);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(104, 25);
            this.textBoxSearch.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(736, 112);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 27);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "검색";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(812, 113);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 26);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "추가";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDarkMode);
            this.panel1.Controls.Add(this.buttonMin);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 39);
            this.panel1.TabIndex = 9;
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
            this.panel2.Controls.Add(this.buttonFriend);
            this.panel2.Controls.Add(this.buttonChatting);
            this.panel2.Controls.Add(this.buttonUpdateInfo);
            this.panel2.Controls.Add(this.buttonGoLogin);
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 546);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(323, 512);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 546);
            this.panel3.TabIndex = 11;
            // 
            // buttonDarkMode
            // 
            this.buttonDarkMode.BackColor = System.Drawing.Color.Transparent;
            this.buttonDarkMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDarkMode.FlatAppearance.BorderSize = 0;
            this.buttonDarkMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDarkMode.Image = global::Modal.test.Properties.Resources.dark;
            this.buttonDarkMode.Location = new System.Drawing.Point(809, 0);
            this.buttonDarkMode.Name = "buttonDarkMode";
            this.buttonDarkMode.Size = new System.Drawing.Size(39, 39);
            this.buttonDarkMode.TabIndex = 2;
            this.buttonDarkMode.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 583);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.textBoxSearchResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFriend;
        private System.Windows.Forms.Button buttonChatting;
        private System.Windows.Forms.Button buttonGoLogin;
        private System.Windows.Forms.Button buttonUpdateInfo;
        private System.Windows.Forms.TextBox textBoxSearchResult;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonDarkMode;
    }
}

