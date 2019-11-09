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
    public partial class ForgetPasswordForm : Form
    {
        Form parent;
        public ForgetPasswordForm(Form parent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.Text == "" || secureword.Text == "")
                {
                    throw new emptySlotException("Please fill all the required fields.");
                }
                else if(!RegisterLogin.IsExist(username.Text))
                {
                    throw new notExistingUserException("This user is not existing.");
                }
                else
                {
                    if(RegisterLogin.forgetPassword(username.Text,secureword.Text))
                    {
                        username.Visible = false;
                        secureword.Visible = false;
                        button1.Visible = false;
                        label1.Text = "New Password";
                        label3.Text = "New Password Again";
                        newPassword.Visible = true;
                        newPasswordValidate.Visible = true;
                        button2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong secure word");
                    }
                }
            }
            catch(notExistingUserException er)
            {
                MessageBox.Show(er.Message);
            }
            catch(emptySlotException er)
            {
                MessageBox.Show(er.Message);
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (newPassword.Text == "" || newPasswordValidate.Text == "")
                {
                    throw new emptySlotException("Please fill all the required fields.");
                }
                else
                {
                    if(newPassword.Text==newPasswordValidate.Text)
                    {
                        RegisterLogin.changePassword(username.Text, newPassword.Text);
                        MessageBox.Show("Password successfuly changed.");
                        Close();
                    }
                    else
                    {
                        throw new validationErrorException("These passwords are not the same.");
                    }
                    
                }
            }
            catch(validationErrorException er)
            {
                MessageBox.Show(er.Message);
                newPassword.Clear();
                newPasswordValidate.Clear();
            }
            catch (emptySlotException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
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

        private void ForgetPasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag == 1)
            {
                this.Location = new Point(System.Windows.Forms.Cursor.Position.X - x, System.Windows.Forms.Cursor.Position.Y - y);
            }
        }


    }
}
