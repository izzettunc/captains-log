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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        int moveFlag = 0;
        int x, y;
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                moveFlag = 0;
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

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag == 1)
            {
                this.Location = new Point(System.Windows.Forms.Cursor.Position.X - x, System.Windows.Forms.Cursor.Position.Y - y);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register newRegister = new Register(this);
            newRegister.Show();
            this.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPasswordForm newForgetPass = new ForgetPasswordForm(this);
            newForgetPass.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.Text == "" || password.Text == "")
                {
                    throw new emptySlotException("Please fill all the required fields.");
                }
                else
                {
                    if (!RegisterLogin.IsExist(username.Text))
                    {
                        username.Clear();
                        password.Clear();
                        throw new notExistingUserException("This user is not existing.");
                    }
                    else
                    {
                        if (RegisterLogin.Login(username.Text, password.Text))
                        {
                            this.Hide();
                            Main newMain = new Main(username.Text);
                            newMain.Show();
                        }
                        else
                        {
                            MessageBox.Show("Wrong password");
                            password.Clear();
                        }

                    }

                }

            }
            catch (emptySlotException  er)
            {
                MessageBox.Show(er.Message);
            }
            catch(notExistingUserException er)
            {
                MessageBox.Show(er.Message);
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

    }
}
