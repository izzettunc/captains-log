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
    public partial class Log : UserControl
    {
        public Log()
        {
            InitializeComponent();
            TabStop = false;
        }

        private void log_Click(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.LogPaper_Clicked;
        }

        private void log_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Log control = (Log)sender;
            Main form = (Main)control.ParentForm;
            form.log_doubleClick(control);
            BackgroundImage = Properties.Resources.LogPaper;
        }

        private void log_Enter(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.LogPaper_Clicked;
        }

        private void log_Leave(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.LogPaper;
        }
    }
}
