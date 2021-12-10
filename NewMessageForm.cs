using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBP {
    public partial class NewMessageForm : Form {
        public NewMessageForm() {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            this.Visible = false;
        }

        private void NewMessageForm_VisibleChanged(object sender, EventArgs e) {
            timer1.Stop();
            timer1.Start();
        }
    }
}
