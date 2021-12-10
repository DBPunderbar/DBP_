
namespace DBP
{
    partial class ProfileViewForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelStateMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChatting = new System.Windows.Forms.Button();
            this.labelNickname = new System.Windows.Forms.Label();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.labelFriendOfFriend = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelPosition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.labelPosition);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainer1.Panel1.Controls.Add(this.buttonChatting);
            this.splitContainer1.Panel1.Controls.Add(this.labelNickname);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxProfile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.labelFriendOfFriend);
            this.splitContainer1.Size = new System.Drawing.Size(800, 550);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.GhostWhite;
            this.panel3.Controls.Add(this.labelStateMessage);
            this.panel3.Location = new System.Drawing.Point(46, 354);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(196, 26);
            this.panel3.TabIndex = 7;
            // 
            // labelStateMessage
            // 
            this.labelStateMessage.AutoSize = true;
            this.labelStateMessage.Font = new System.Drawing.Font("나눔스퀘어", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelStateMessage.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelStateMessage.Location = new System.Drawing.Point(27, -1);
            this.labelStateMessage.Name = "labelStateMessage";
            this.labelStateMessage.Size = new System.Drawing.Size(189, 18);
            this.labelStateMessage.TabIndex = 2;
            this.labelStateMessage.Text = "         StateMessage         ";
            this.labelStateMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Location = new System.Drawing.Point(293, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 520);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(240, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(32, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "\"";
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Lavender;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonDelete.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonDelete.Location = new System.Drawing.Point(158, 437);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(110, 37);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "삭제하기";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonChatting
            // 
            this.buttonChatting.BackColor = System.Drawing.Color.Lavender;
            this.buttonChatting.FlatAppearance.BorderSize = 0;
            this.buttonChatting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChatting.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonChatting.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonChatting.Location = new System.Drawing.Point(29, 437);
            this.buttonChatting.Name = "buttonChatting";
            this.buttonChatting.Size = new System.Drawing.Size(110, 37);
            this.buttonChatting.TabIndex = 3;
            this.buttonChatting.Text = "1:1 채팅하기";
            this.buttonChatting.UseVisualStyleBackColor = false;
            this.buttonChatting.Click += new System.EventHandler(this.buttonChatting_Click);
            // 
            // labelNickname
            // 
            this.labelNickname.AutoSize = true;
            this.labelNickname.Font = new System.Drawing.Font("나눔스퀘어 Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelNickname.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelNickname.Location = new System.Drawing.Point(153, 292);
            this.labelNickname.Name = "labelNickname";
            this.labelNickname.Size = new System.Drawing.Size(119, 26);
            this.labelNickname.TabIndex = 1;
            this.labelNickname.Text = "nickname";
            this.labelNickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(46, 46);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxProfile.TabIndex = 0;
            this.pictureBoxProfile.TabStop = false;
            // 
            // labelFriendOfFriend
            // 
            this.labelFriendOfFriend.AutoSize = true;
            this.labelFriendOfFriend.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelFriendOfFriend.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelFriendOfFriend.Location = new System.Drawing.Point(3, 7);
            this.labelFriendOfFriend.Name = "labelFriendOfFriend";
            this.labelFriendOfFriend.Size = new System.Drawing.Size(87, 18);
            this.labelFriendOfFriend.TabIndex = 0;
            this.labelFriendOfFriend.Text = "친구의 친구";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonMin);
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 39);
            this.panel2.TabIndex = 53;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveWindow_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveWindow_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveWindow_MouseUp);
            // 
            // buttonMin
            // 
            this.buttonMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMin.FlatAppearance.BorderSize = 0;
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonMin.Location = new System.Drawing.Point(721, 0);
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
            this.buttonClose.Location = new System.Drawing.Point(760, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(39, 39);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("나눔스퀘어 Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPosition.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelPosition.Location = new System.Drawing.Point(71, 292);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(119, 26);
            this.labelPosition.TabIndex = 8;
            this.labelPosition.Text = "[position]";
            this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfileViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 589);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfileViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProfileViewForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChatting;
        private System.Windows.Forms.Label labelStateMessage;
        private System.Windows.Forms.Label labelNickname;
        private System.Windows.Forms.Label labelFriendOfFriend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelPosition;
    }
}