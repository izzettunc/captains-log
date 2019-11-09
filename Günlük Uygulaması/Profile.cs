using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Günlük_Uygulaması
{
    public partial class Profile : Form
    {
        Form parent;
        public string activeUser;
        public Profile(Form papa,string activeUser)
        {
            parent = papa;
            this.activeUser = activeUser;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            usernameLabel.Text = "Username: "+activeUser;
        }

        int moveFlag = 0;
        int x, y;
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                moveFlag = 0;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag == 1)
            {
                this.Location = new Point(System.Windows.Forms.Cursor.Position.X - x, System.Windows.Forms.Cursor.Position.Y - y);
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = System.Windows.Forms.Cursor.Position.X - this.Location.X;
                y = System.Windows.Forms.Cursor.Position.Y - this.Location.Y;
                moveFlag = 1;
            }
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            changeAccountInfoForm yeni = new changeAccountInfoForm(1, this);
            yeni.Show();
            this.Visible = false;
        }

        private void changeSecwordButton_Click(object sender, EventArgs e)
        {
            changeAccountInfoForm yeni = new changeAccountInfoForm(2, this);
            yeni.Show();
            this.Visible = false;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

    }
}
