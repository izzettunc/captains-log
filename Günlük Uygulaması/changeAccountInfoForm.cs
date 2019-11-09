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
    public partial class changeAccountInfoForm : Form
    {
        int mod;
        Profile papa;
        public changeAccountInfoForm(int mode, Profile Parent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mod = mode;
            papa = Parent;
            if (mod == 1)
            {
                processLabel.Text = "Change Password";
                oldInfoLabel.Text = "New Password:";
                newInfoLabel.Text = "New Password Again:";
            }
            else if (mod == 2)
            {
                processLabel.Text = "Change Secure Word";
                oldInfoLabel.Text = "New Secure Word:";
                newInfoLabel.Text = "New Secure Word Again:";
            }
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

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            if (oldInfoInput.Text != newInfoInput.Text) MessageBox.Show("Inputs are not same");
            else if (!(RegisterLogin.forgetPassword(papa.activeUser, secwordInput.Text))) MessageBox.Show("Secure word is wrong");
            else if(oldInfoInput.Text=="") MessageBox.Show("Please fill all the required fields");
            else
            {
                if (mod == 1)
                {
                    RegisterLogin.changePassword(papa.activeUser, newInfoInput.Text);
                }
                else if (mod == 2)
                {
                    RegisterLogin.changeSecureword(papa.activeUser, newInfoInput.Text);
                }
                MessageBox.Show("Changed");
                this.Close();
                papa.Visible = true;
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            papa.Visible = true;
        }

    }
}
