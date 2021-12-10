
namespace DBP
{
    partial class ChatForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.richTextBoxChatLog = new System.Windows.Forms.RichTextBox();
            this.textBoxWriteMsg = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonSendEmoji = new System.Windows.Forms.Button();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.buttonExitChat = new System.Windows.Forms.Button();
            this.buttonSearchMsg = new System.Windows.Forms.Button();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.buttonBackList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonMin);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonBackList);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 39);
            this.panel1.TabIndex = 19;
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
            this.buttonMin.Location = new System.Drawing.Point(850, 0);
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
            this.buttonClose.Location = new System.Drawing.Point(889, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(39, 39);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // richTextBoxChatLog
            // 
            this.richTextBoxChatLog.BackColor = System.Drawing.Color.White;
            this.richTextBoxChatLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxChatLog.Font = new System.Drawing.Font("나눔스퀘어", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBoxChatLog.ForeColor = System.Drawing.Color.MidnightBlue;
            this.richTextBoxChatLog.Location = new System.Drawing.Point(12, 56);
            this.richTextBoxChatLog.Name = "richTextBoxChatLog";
            this.richTextBoxChatLog.ReadOnly = true;
            this.richTextBoxChatLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxChatLog.Size = new System.Drawing.Size(609, 468);
            this.richTextBoxChatLog.TabIndex = 20;
            this.richTextBoxChatLog.Text = "";
            // 
            // textBoxWriteMsg
            // 
            this.textBoxWriteMsg.Location = new System.Drawing.Point(12, 542);
            this.textBoxWriteMsg.Name = "textBoxWriteMsg";
            this.textBoxWriteMsg.Size = new System.Drawing.Size(564, 25);
            this.textBoxWriteMsg.TabIndex = 21;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(658, 65);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(202, 25);
            this.textBox.TabIndex = 23;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.GhostWhite;
            this.panel14.Location = new System.Drawing.Point(637, 49);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(3, 525);
            this.panel14.TabIndex = 29;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(658, 108);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(244, 410);
            this.textBox3.TabIndex = 30;
            // 
            // buttonSendEmoji
            // 
            this.buttonSendEmoji.BackColor = System.Drawing.Color.Transparent;
            this.buttonSendEmoji.FlatAppearance.BorderSize = 0;
            this.buttonSendEmoji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendEmoji.Image = global::DBP.Properties.Resources.emoticon_b1;
            this.buttonSendEmoji.Location = new System.Drawing.Point(646, 533);
            this.buttonSendEmoji.Name = "buttonSendEmoji";
            this.buttonSendEmoji.Size = new System.Drawing.Size(39, 39);
            this.buttonSendEmoji.TabIndex = 28;
            this.buttonSendEmoji.UseVisualStyleBackColor = false;
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.BackColor = System.Drawing.Color.Transparent;
            this.buttonSendFile.FlatAppearance.BorderSize = 0;
            this.buttonSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendFile.Image = global::DBP.Properties.Resources.file_b;
            this.buttonSendFile.Location = new System.Drawing.Point(691, 533);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(39, 39);
            this.buttonSendFile.TabIndex = 27;
            this.buttonSendFile.UseVisualStyleBackColor = false;
            // 
            // buttonExitChat
            // 
            this.buttonExitChat.BackColor = System.Drawing.Color.Transparent;
            this.buttonExitChat.FlatAppearance.BorderSize = 0;
            this.buttonExitChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitChat.Image = global::DBP.Properties.Resources.exit_b;
            this.buttonExitChat.Location = new System.Drawing.Point(877, 533);
            this.buttonExitChat.Name = "buttonExitChat";
            this.buttonExitChat.Size = new System.Drawing.Size(39, 39);
            this.buttonExitChat.TabIndex = 25;
            this.buttonExitChat.UseVisualStyleBackColor = false;
            // 
            // buttonSearchMsg
            // 
            this.buttonSearchMsg.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearchMsg.FlatAppearance.BorderSize = 0;
            this.buttonSearchMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchMsg.Image = global::DBP.Properties.Resources.search_b;
            this.buttonSearchMsg.Location = new System.Drawing.Point(866, 56);
            this.buttonSearchMsg.Name = "buttonSearchMsg";
            this.buttonSearchMsg.Size = new System.Drawing.Size(39, 39);
            this.buttonSearchMsg.TabIndex = 24;
            this.buttonSearchMsg.UseVisualStyleBackColor = false;
            // 
            // buttonSendMsg
            // 
            this.buttonSendMsg.FlatAppearance.BorderSize = 0;
            this.buttonSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendMsg.Image = global::DBP.Properties.Resources.chatSend_B;
            this.buttonSendMsg.Location = new System.Drawing.Point(582, 533);
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.Size = new System.Drawing.Size(39, 39);
            this.buttonSendMsg.TabIndex = 22;
            this.buttonSendMsg.UseVisualStyleBackColor = true;
            // 
            // buttonBackList
            // 
            this.buttonBackList.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackList.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonBackList.FlatAppearance.BorderSize = 0;
            this.buttonBackList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackList.Image = global::DBP.Properties.Resources.return_b;
            this.buttonBackList.Location = new System.Drawing.Point(0, 0);
            this.buttonBackList.Name = "buttonBackList";
            this.buttonBackList.Size = new System.Drawing.Size(39, 39);
            this.buttonBackList.TabIndex = 26;
            this.buttonBackList.UseVisualStyleBackColor = false;
            this.buttonBackList.Click += new System.EventHandler(this.buttonBackList_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 583);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.buttonSendEmoji);
            this.Controls.Add(this.buttonSendFile);
            this.Controls.Add(this.buttonExitChat);
            this.Controls.Add(this.buttonSearchMsg);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonSendMsg);
            this.Controls.Add(this.textBoxWriteMsg);
            this.Controls.Add(this.richTextBoxChatLog);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RichTextBox richTextBoxChatLog;
        private System.Windows.Forms.TextBox textBoxWriteMsg;
        private System.Windows.Forms.Button buttonSendMsg;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonSearchMsg;
        private System.Windows.Forms.Button buttonExitChat;
        private System.Windows.Forms.Button buttonBackList;
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.Button buttonSendEmoji;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox textBox3;
    }
}