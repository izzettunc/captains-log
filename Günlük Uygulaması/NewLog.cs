using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Günlük_Uygulaması
{
    public partial class NewLog : UserControl
    {
        public NewLog()
        {
            InitializeComponent();
        }

        private void NewLog_MouseClick(object sender, MouseEventArgs e)
        {
            NewLogScreen yeni = new NewLogScreen(this.ParentForm,((Main)this.ParentForm).activeUser);
            yeni.Show();
        }
    }
}
