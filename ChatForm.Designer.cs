﻿
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
            this.buttonBackList = new System.Windows.Forms.Button();
            this.textBoxWriteMsg = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panelEmoticonBox = new System.Windows.Forms.Panel();
            this.pictureBoxEmo4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmo3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmo2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmo1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSendEmoji = new System.Windows.Forms.Button();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.buttonExitChat = new System.Windows.Forms.Button();
            this.buttonSearchMsg = new System.Windows.Forms.Button();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.flowLayoutPanelChatLog = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panelEmoticonBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonMin);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonBackList);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 31);
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
            this.buttonMin.Location = new System.Drawing.Point(744, 0);
            this.buttonMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(34, 31);
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
            this.buttonClose.Location = new System.Drawing.Point(778, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(34, 31);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            // textBoxWriteMsg
            // 
            this.textBoxWriteMsg.Location = new System.Drawing.Point(10, 434);
            this.textBoxWriteMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxWriteMsg.Name = "textBoxWriteMsg";
            this.textBoxWriteMsg.Size = new System.Drawing.Size(494, 21);
            this.textBoxWriteMsg.TabIndex = 21;
            this.textBoxWriteMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWriteMsg_KeyDown);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(576, 52);
            this.textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(177, 21);
            this.textBox.TabIndex = 23;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.GhostWhite;
            this.panel14.Location = new System.Drawing.Point(557, 39);
            this.panel14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(3, 420);
            this.panel14.TabIndex = 29;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(576, 86);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(214, 329);
            this.textBox3.TabIndex = 30;
            // 
            // panelEmoticonBox
            // 
            this.panelEmoticonBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelEmoticonBox.Controls.Add(this.pictureBoxEmo4);
            this.panelEmoticonBox.Controls.Add(this.pictureBoxEmo3);
            this.panelEmoticonBox.Controls.Add(this.pictureBoxEmo2);
            this.panelEmoticonBox.Controls.Add(this.pictureBoxEmo1);
            this.panelEmoticonBox.Location = new System.Drawing.Point(658, 323);
            this.panelEmoticonBox.Name = "panelEmoticonBox";
            this.panelEmoticonBox.Size = new System.Drawing.Size(184, 168);
            this.panelEmoticonBox.TabIndex = 31;
            this.panelEmoticonBox.Visible = false;
            // 
            // pictureBoxEmo4
            // 
            this.pictureBoxEmo4.Image = global::DBP.Properties.Resources.emoticon4;
            this.pictureBoxEmo4.Location = new System.Drawing.Point(94, 86);
            this.pictureBoxEmo4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxEmo4.Name = "pictureBoxEmo4";
            this.pictureBoxEmo4.Size = new System.Drawing.Size(88, 80);
            this.pictureBoxEmo4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEmo4.TabIndex = 6;
            this.pictureBoxEmo4.TabStop = false;
            this.pictureBoxEmo4.Click += new System.EventHandler(this.pictureBoxEmo4_Click);
            // 
            // pictureBoxEmo3
            // 
            this.pictureBoxEmo3.Image = global::DBP.Properties.Resources.emoticon3;
            this.pictureBoxEmo3.Location = new System.Drawing.Point(3, 86);
            this.pictureBoxEmo3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxEmo3.Name = "pictureBoxEmo3";
            this.pictureBoxEmo3.Size = new System.Drawing.Size(88, 80);
            this.pictureBoxEmo3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEmo3.TabIndex = 5;
            this.pictureBoxEmo3.TabStop = false;
            this.pictureBoxEmo3.Click += new System.EventHandler(this.pictureBoxEmo3_Click);
            // 
            // pictureBoxEmo2
            // 
            this.pictureBoxEmo2.Image = global::DBP.Properties.Resources.emoticon2;
            this.pictureBoxEmo2.Location = new System.Drawing.Point(94, 2);
            this.pictureBoxEmo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxEmo2.Name = "pictureBoxEmo2";
            this.pictureBoxEmo2.Size = new System.Drawing.Size(88, 80);
            this.pictureBoxEmo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEmo2.TabIndex = 4;
            this.pictureBoxEmo2.TabStop = false;
            this.pictureBoxEmo2.Click += new System.EventHandler(this.pictureBoxEmo2_Click);
            // 
            // pictureBoxEmo1
            // 
            this.pictureBoxEmo1.Image = global::DBP.Properties.Resources.emoticon1;
            this.pictureBoxEmo1.Location = new System.Drawing.Point(3, 2);
            this.pictureBoxEmo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxEmo1.Name = "pictureBoxEmo1";
            this.pictureBoxEmo1.Size = new System.Drawing.Size(88, 80);
            this.pictureBoxEmo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEmo1.TabIndex = 3;
            this.pictureBoxEmo1.TabStop = false;
            this.pictureBoxEmo1.Click += new System.EventHandler(this.pictureBoxEmo1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(529, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSendEmoji
            // 
            this.buttonSendEmoji.BackColor = System.Drawing.Color.Transparent;
            this.buttonSendEmoji.FlatAppearance.BorderSize = 0;
            this.buttonSendEmoji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendEmoji.Image = global::DBP.Properties.Resources.emoticon_b;
            this.buttonSendEmoji.Location = new System.Drawing.Point(646, 533);
            this.buttonSendEmoji.Name = "buttonSendEmoji";
            this.buttonSendEmoji.Size = new System.Drawing.Size(34, 31);
            this.buttonSendEmoji.TabIndex = 28;
            this.buttonSendEmoji.UseVisualStyleBackColor = false;
            this.buttonSendEmoji.Click += new System.EventHandler(this.buttonSendEmoji_Click);
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.BackColor = System.Drawing.Color.Transparent;
            this.buttonSendFile.FlatAppearance.BorderSize = 0;
            this.buttonSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendFile.Image = global::DBP.Properties.Resources.file_b;
            this.buttonSendFile.Location = new System.Drawing.Point(605, 426);
            this.buttonSendFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(34, 31);
            this.buttonSendFile.TabIndex = 27;
            this.buttonSendFile.UseVisualStyleBackColor = false;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // buttonExitChat
            // 
            this.buttonExitChat.BackColor = System.Drawing.Color.Transparent;
            this.buttonExitChat.FlatAppearance.BorderSize = 0;
            this.buttonExitChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitChat.Image = global::DBP.Properties.Resources.exit_b;
            this.buttonExitChat.Location = new System.Drawing.Point(767, 426);
            this.buttonExitChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExitChat.Name = "buttonExitChat";
            this.buttonExitChat.Size = new System.Drawing.Size(34, 31);
            this.buttonExitChat.TabIndex = 25;
            this.buttonExitChat.UseVisualStyleBackColor = false;
            // 
            // buttonSearchMsg
            // 
            this.buttonSearchMsg.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearchMsg.FlatAppearance.BorderSize = 0;
            this.buttonSearchMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchMsg.Image = global::DBP.Properties.Resources.search_b;
            this.buttonSearchMsg.Location = new System.Drawing.Point(758, 45);
            this.buttonSearchMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearchMsg.Name = "buttonSearchMsg";
            this.buttonSearchMsg.Size = new System.Drawing.Size(34, 31);
            this.buttonSearchMsg.TabIndex = 24;
            this.buttonSearchMsg.UseVisualStyleBackColor = false;
            // 
            // buttonSendMsg
            // 
            this.buttonSendMsg.FlatAppearance.BorderSize = 0;
            this.buttonSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendMsg.Image = global::DBP.Properties.Resources.chatSend_B;
            this.buttonSendMsg.Location = new System.Drawing.Point(509, 426);
            this.buttonSendMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.Size = new System.Drawing.Size(34, 31);
            this.buttonSendMsg.TabIndex = 22;
            this.buttonSendMsg.UseVisualStyleBackColor = true;
            this.buttonSendMsg.Click += new System.EventHandler(this.buttonSendMsg_Click);
            // 
            // flowLayoutPanelChatLog
            // 
            this.flowLayoutPanelChatLog.AutoScroll = true;
            this.flowLayoutPanelChatLog.Location = new System.Drawing.Point(12, 56);
            this.flowLayoutPanelChatLog.Name = "flowLayoutPanelChatLog";
            this.flowLayoutPanelChatLog.Size = new System.Drawing.Size(609, 471);
            this.flowLayoutPanelChatLog.TabIndex = 33;
            // 
            this.buttonBackList.Name = "buttonBackList";
            this.buttonBackList.Size = new System.Drawing.Size(39, 39);
            this.buttonBackList.TabIndex = 26;
            this.buttonBackList.UseVisualStyleBackColor = false;
            this.buttonBackList.Click += new System.EventHandler(this.buttonBackList_Click);
            // 
            this.buttonBackList.Name = "buttonBackList";
            this.buttonBackList.Size = new System.Drawing.Size(39, 39);
            this.buttonBackList.TabIndex = 26;
            this.buttonBackList.UseVisualStyleBackColor = false;
            this.buttonBackList.Click += new System.EventHandler(this.buttonBackList_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 466);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelEmoticonBox);
            this.Controls.Add(this.flowLayoutPanelChatLog);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.buttonSendEmoji);
            this.Controls.Add(this.buttonSendFile);
            this.Controls.Add(this.buttonExitChat);
            this.Controls.Add(this.buttonSearchMsg);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonSendMsg);
            this.Controls.Add(this.textBoxWriteMsg);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.panel1.ResumeLayout(false);
            this.panelEmoticonBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonClose;
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
        private System.Windows.Forms.Panel panelEmoticonBox;
        private System.Windows.Forms.PictureBox pictureBoxEmo4;
        private System.Windows.Forms.PictureBox pictureBoxEmo3;
        private System.Windows.Forms.PictureBox pictureBoxEmo2;
        private System.Windows.Forms.PictureBox pictureBoxEmo1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChatLog;
    }
}