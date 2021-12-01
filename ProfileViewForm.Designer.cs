
namespace Modal.test
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
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChatting = new System.Windows.Forms.Button();
            this.labelStateMessage = new System.Windows.Forms.Label();
            this.labelNickname = new System.Windows.Forms.Label();
            this.labelFriendOfFriend = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(70, 40);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxProfile.TabIndex = 0;
            this.pictureBoxProfile.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainer1.Panel1.Controls.Add(this.buttonChatting);
            this.splitContainer1.Panel1.Controls.Add(this.labelStateMessage);
            this.splitContainer1.Panel1.Controls.Add(this.labelNickname);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxProfile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.labelFriendOfFriend);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(210, 377);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(110, 37);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "삭제하기";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonChatting
            // 
            this.buttonChatting.Location = new System.Drawing.Point(70, 377);
            this.buttonChatting.Name = "buttonChatting";
            this.buttonChatting.Size = new System.Drawing.Size(110, 37);
            this.buttonChatting.TabIndex = 3;
            this.buttonChatting.Text = "1:1 채팅하기";
            this.buttonChatting.UseVisualStyleBackColor = true;
            this.buttonChatting.Click += new System.EventHandler(this.buttonChatting_Click);
            // 
            // labelStateMessage
            // 
            this.labelStateMessage.AutoSize = true;
            this.labelStateMessage.Location = new System.Drawing.Point(145, 329);
            this.labelStateMessage.Name = "labelStateMessage";
            this.labelStateMessage.Size = new System.Drawing.Size(101, 15);
            this.labelStateMessage.TabIndex = 2;
            this.labelStateMessage.Text = "StateMessage";
            this.labelStateMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNickname
            // 
            this.labelNickname.AutoSize = true;
            this.labelNickname.Location = new System.Drawing.Point(130, 299);
            this.labelNickname.Name = "labelNickname";
            this.labelNickname.Size = new System.Drawing.Size(139, 15);
            this.labelNickname.TabIndex = 1;
            this.labelNickname.Text = "[position] nickname";
            this.labelNickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFriendOfFriend
            // 
            this.labelFriendOfFriend.AutoSize = true;
            this.labelFriendOfFriend.Location = new System.Drawing.Point(16, 12);
            this.labelFriendOfFriend.Name = "labelFriendOfFriend";
            this.labelFriendOfFriend.Size = new System.Drawing.Size(87, 15);
            this.labelFriendOfFriend.TabIndex = 0;
            this.labelFriendOfFriend.Text = "친구의 친구";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(397, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 450);
            this.panel1.TabIndex = 5;
            // 
            // ProfileViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProfileViewForm";
            this.Text = "ProfileViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
    }
}