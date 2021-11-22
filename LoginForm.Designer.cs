
namespace Modal.test
{
    partial class LoginForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAutoLogin = new System.Windows.Forms.CheckBox();
            this.buttonAddInfo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonMin);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 39);
            this.panel1.TabIndex = 0;
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
            this.buttonMin.Location = new System.Drawing.Point(306, 0);
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
            this.buttonClose.Location = new System.Drawing.Point(345, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(39, 39);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(76, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 46);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-2, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "u     n     d     e     r     b     a     r";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔스퀘어 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(46, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // textBoxID
            // 
            this.textBoxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxID.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxID.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBoxID.Location = new System.Drawing.Point(85, 260);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(234, 23);
            this.textBoxID.TabIndex = 2;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.Location = new System.Drawing.Point(85, 290);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 3);
            this.panel3.TabIndex = 5;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Lavender;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonLogin.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonLogin.Location = new System.Drawing.Point(110, 445);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(168, 45);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "로그인";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Lavender;
            this.panel4.Location = new System.Drawing.Point(85, 369);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 3);
            this.panel4.TabIndex = 9;
            // 
            // textBoxPW
            // 
            this.textBoxPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPW.Font = new System.Drawing.Font("나눔스퀘어", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxPW.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBoxPW.Location = new System.Drawing.Point(85, 339);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.PasswordChar = '●';
            this.textBoxPW.Size = new System.Drawing.Size(234, 23);
            this.textBoxPW.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔스퀘어 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(38, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "PW";
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAutoLogin.Font = new System.Drawing.Font("나눔스퀘어 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxAutoLogin.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(147, 398);
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(100, 21);
            this.checkBoxAutoLogin.TabIndex = 7;
            this.checkBoxAutoLogin.Text = "자동 로그인";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = true;
            this.checkBoxAutoLogin.CheckedChanged += new System.EventHandler(this.checkBoxAutoLogin_CheckedChanged);
            // 
            // buttonAddInfo
            // 
            this.buttonAddInfo.BackColor = System.Drawing.Color.Lavender;
            this.buttonAddInfo.FlatAppearance.BorderSize = 0;
            this.buttonAddInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddInfo.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonAddInfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonAddInfo.Location = new System.Drawing.Point(110, 506);
            this.buttonAddInfo.Name = "buttonAddInfo";
            this.buttonAddInfo.Size = new System.Drawing.Size(168, 45);
            this.buttonAddInfo.TabIndex = 6;
            this.buttonAddInfo.Text = "회원가입";
            this.buttonAddInfo.UseVisualStyleBackColor = false;
            this.buttonAddInfo.Click += new System.EventHandler(this.buttonAddInfo_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 628);
            this.Controls.Add(this.buttonAddInfo);
            this.Controls.Add(this.checkBoxAutoLogin);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.textBoxPW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxPW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxAutoLogin;
        private System.Windows.Forms.Button buttonAddInfo;
    }
}