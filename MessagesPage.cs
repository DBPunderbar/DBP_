using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal.test
{
    public partial class messagesPage : UserControl
    {
        // 채팅 contents 작성 방식
        // 이름|시간|내용\n ...
        //
        // 현재시간 작성 기준
        // DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        public messagesPage()
        {
            InitializeComponent();
        }

        public void DeleteChat(string chatID, string deleteValues)
        {
            
        }
    }
}
