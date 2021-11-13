
namespace AddressFinder {
    partial class AdressFinder {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.AddressFinder = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // AddressFinder
            // 
            this.AddressFinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressFinder.Location = new System.Drawing.Point(0, 0);
            this.AddressFinder.MinimumSize = new System.Drawing.Size(20, 20);
            this.AddressFinder.Name = "AddressFinder";
            this.AddressFinder.Size = new System.Drawing.Size(680, 426);
            this.AddressFinder.TabIndex = 0;
            this.AddressFinder.Resize += new System.EventHandler(this.webBrowser1_Resize);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // AdressFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 426);
            this.Controls.Add(this.AddressFinder);
            this.Name = "AdressFinder";
            this.Text = "AddressFinder";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser AddressFinder;
        private System.Windows.Forms.Timer timer1;
    }
}