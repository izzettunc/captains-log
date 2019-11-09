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
    public partial class Register : Form
    {
        Form parent;
        public Register(Form parent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.parent = parent;
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
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

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag == 1)
            {
                this.Location = new Point(System.Windows.Forms.Cursor.Position.X - x, System.Windows.Forms.Cursor.Position.Y - y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.Text == "" || password.Text == "" || secureword.Text == "")
                {
                    throw new emptySlotException("Please fill all the required fields.");
                }
                else
                {
                    if(!RegisterLogin.IsExist(username.Text))
                    {
                        RegisterLogin.Register(username.Text, password.Text, secureword.Text);
                        username.Clear();
                        password.Clear();
                        secureword.Clear();
                        MessageBox.Show("Registration is successful");
                    }
                    else
                    {
                        throw new existingUserException("There is already an user with that username so please take another one.");
                    }
                    
                }
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

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = System.Windows.Forms.Cursor.Position.X - this.Location.X;
                y = System.Windows.Forms.Cursor.Position.Y - this.Location.Y;
                moveFlag = 1;
            }
        }
    }
}
