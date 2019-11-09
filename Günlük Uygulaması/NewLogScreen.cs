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
    public partial class NewLogScreen : Form
    {
        private Form parent;
        string activeUser;
        List<string> tagList = new List<string>();
        int hareketEttir = 0;
        int x, y;
        string oldTitle;
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                hareketEttir = 0;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = System.Windows.Forms.Cursor.Position.X - this.Location.X;
                y = System.Windows.Forms.Cursor.Position.Y - this.Location.Y;
                hareketEttir = 1;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (hareketEttir == 1)
            {
                this.Location = new Point(System.Windows.Forms.Cursor.Position.X - x, System.Windows.Forms.Cursor.Position.Y - y);
            }
        }

        public NewLogScreen(Form parent, string activeUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.parent = parent;
            this.activeUser = activeUser;
        }

        public NewLogScreen(Form parent, string activeUser,string Title)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.parent = parent;
            this.activeUser = activeUser;
            button2.Click += Button2_Click;
            button2.Click -= button2_Click;
            button2.Text = "Edit";
            Dictionary<string,string> logInfo = LogOperations.getThisUsersLogsInfo(activeUser);
            string info = logInfo[Encryption.MD5encryption(Title)];
            string[] items = info.Split('@');
            string[] date =items[2].Split('/');
            oldTitle=title.Text = items[0];
            foreach(string s in items[1].Split('*'))
            {
                if (s.Length > 0)
                {
                    tagList.Add(s.Replace("\n", ""));
                }
            }
            fillTags();
            if(DateTime.Today.Day.ToString()!=date[0] || DateTime.Today.Month.ToString() != date[1] || DateTime.Today.Year.ToString() != date[2])
            {
                checkBox1.Checked = false;
                foreach (NumericUpDown N in basicDatePicker1.Controls.OfType<NumericUpDown>())
                {
                    if (N.Maximum>32)
                    {
                        N.Value = int.Parse(date[2]);
                    }
                    else if(N.Maximum>12)
                    {
                        N.Value = int.Parse(date[0]);
                    }
                    else
                    {
                        N.Value = int.Parse(date[1]);
                    }
                }
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)// edit click event
        {
            try
            {
                if (title.Text == "" || tags.Text == "")
                {
                    throw new emptySlotException("Please fill all the fields");
                }
                else if (oldTitle!=title.Text && LogOperations.isThisLogExist(title.Text, activeUser))
                {
                    throw new alreadyExistingLog("There is a log with this title please select another one");
                }
                else
                {
                    LogOperations.editLogInfo(activeUser, oldTitle, title.Text, tags.Text, basicDatePicker1.getDate());
                    MessageBox.Show("Log infos are successfully edited.");
                    Close();
                }
            }
            catch (alreadyExistingLog er)
            {
                MessageBox.Show(er.Message);
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

        private void NewLogScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
            if (((Main)parent).Sort=="month")
                ((Main)parent).sortLogs("month");
            else if (((Main)parent).Sort == "tag")
                ((Main)parent).sortLogs("tag");
            else if (((Main)parent).Sort == "year")
                ((Main)parent).sortLogs("year");
            else if (((Main)parent).Sort == "all")
                ((Main)parent).sortLogs("all");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool deg;
            if(basicDatePicker1.Visible==true)
            {
                basicDatePicker1.Visible=deg = false;
            }
            else
            {
                basicDatePicker1.Visible = deg = true;
            }
            if (deg)
            {
                label5.Location = new Point(label5.Location.X, label5.Location.Y + 85);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 85);
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 85);
                button3.Location = new Point(button3.Location.X, button3.Location.Y + 85);
            }
            else
            {
                label5.Location = new Point(label5.Location.X, label5.Location.Y - 85);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 85);
                button2.Location = new Point(button2.Location.X, button2.Location.Y - 85);
                button3.Location = new Point(button3.Location.X, button3.Location.Y - 85);
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

        private void button3_Click(object sender, EventArgs e)
        {
            tag.Text = "";
            title.Text = "";
            tags.Text = "";
            checkBox1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (title.Text == "" || tags.Text == "")
                {
                    throw new emptySlotException("Please fill all the fields");
                }
                else if (LogOperations.isThisLogExist(title.Text, activeUser))
                {
                    throw new alreadyExistingLog("There is a log with this title please select another one");
                }
                else
                {

                    string path=LogOperations.createNewLog(title.Text, activeUser);
                    LogOperations.addToBelongingList(activeUser, title.Text, tags.Text, basicDatePicker1.getDate());
                    MessageBox.Show("Log successfully created.");
                    TextEditor yeni = new TextEditor(parent,title.Text);
                    yeni.Show();
                    parent.Visible = false;
                    Close();
                }
            }
            catch (alreadyExistingLog er)
            {
                MessageBox.Show(er.Message);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tag.Text == "")
                {
                    throw new emptySlotException("Please fill the new tag field.");
                }
                else if (!tag.Text.All(Char.IsLetter))
                {
                    throw new notOnlyLettersException("Tags must be made by only letters.");
                }
                else
                {
                    tagList.Add(tag.Text);
                    tag.Text = "";
                    fillTags();
                }
            }
            catch (emptySlotException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (notOnlyLettersException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(tagList.Count>0)
            {
                tagList.RemoveAt(tagList.Count - 1);
                fillTags();
            }
        }

        private void fillTags()
        {
            tags.Text = "";
            foreach(string s in tagList)
            tags.Text += "*" + s + "\n";
        }
    }
}
