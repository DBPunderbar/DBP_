
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
            this.SuspendLayout();
            // 
            // buttonFriend
            // 
            this.buttonFriend.Location = new System.Drawing.Point(12, 57);
            this.buttonFriend.Name = "buttonFriend";
            this.buttonFriend.Size = new System.Drawing.Size(75, 23);
            this.buttonFriend.TabIndex = 0;
            this.buttonFriend.Text = "친구";
            this.buttonFriend.UseVisualStyleBackColor = true;
            this.buttonFriend.Click += new System.EventHandler(this.buttonFriend_Click);
            // 
            // buttonChatting
            // 
            this.buttonChatting.Location = new System.Drawing.Point(12, 86);
            this.buttonChatting.Name = "buttonChatting";
            this.buttonChatting.Size = new System.Drawing.Size(75, 23);
            this.buttonChatting.TabIndex = 1;
            this.buttonChatting.Text = "채팅";
            this.buttonChatting.UseVisualStyleBackColor = true;
            // 
            // buttonGoLogin
            // 
            this.buttonGoLogin.Location = new System.Drawing.Point(12, 399);
            this.buttonGoLogin.Name = "buttonGoLogin";
            this.buttonGoLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonGoLogin.TabIndex = 2;
            this.buttonGoLogin.Text = "로그인";
            this.buttonGoLogin.UseVisualStyleBackColor = true;
            this.buttonGoLogin.Click += new System.EventHandler(this.buttonGoLogin_Click);
            // 
            // buttonUpdateInfo
            // 
            this.buttonUpdateInfo.Location = new System.Drawing.Point(13, 365);
            this.buttonUpdateInfo.Name = "buttonUpdateInfo";
            this.buttonUpdateInfo.Size = new System.Drawing.Size(75, 28);
            this.buttonUpdateInfo.TabIndex = 4;
            this.buttonUpdateInfo.Text = "정보수정";
            this.buttonUpdateInfo.UseVisualStyleBackColor = true;
            this.buttonUpdateInfo.Click += new System.EventHandler(this.buttonUpdateInfo_Click);
            // 
            // textBoxSearchResult
            // 
            this.textBoxSearchResult.Location = new System.Drawing.Point(552, 86);
            this.textBoxSearchResult.Multiline = true;
            this.textBoxSearchResult.Name = "textBoxSearchResult";
            this.textBoxSearchResult.Size = new System.Drawing.Size(261, 346);
            this.textBoxSearchResult.TabIndex = 5;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(552, 54);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(104, 25);
            this.textBoxSearch.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(657, 54);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 27);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "검색";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(738, 54);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 26);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "추가";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 459);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.textBoxSearchResult);
            this.Controls.Add(this.buttonUpdateInfo);
            this.Controls.Add(this.buttonGoLogin);
            this.Controls.Add(this.buttonChatting);
            this.Controls.Add(this.buttonFriend);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
    }
}

