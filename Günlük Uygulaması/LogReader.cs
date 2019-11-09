using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Günlük_Uygulaması
{
    public partial class LogReader : Form
    {
        Color standartColor = Color.FromArgb(50, 54, 66);
        Color selectedColor = Color.FromArgb(39, 42, 51);
        Color standartTextColor = Color.LightGray;
        Color standartPageColor = Color.FromArgb(56, 60, 74);
        Font standartFont = new Font("Verdana", 11, FontStyle.Regular);
        int currentPage;
        Main parentForm;
        List<string> Page = new List<string>();
        public LogReader(Form parent, string title)
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            parentForm = ((Main)parent);
            parentForm.loseFocus();
            currentPage = 0;
            header.Text = title.Replace(Environment.NewLine, "");
            Page = LogOperations.getLog(parentForm.activeUser, title);
            LogText.TabStop = false;
            if (Page.Count > 0)
            {
                LogText.Text = Page[0];
            }
            else
            {
                Page.Add("");
            }
            label1.Text = Page.Count.ToString();
        }
        // <formMovement>
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
        // </formMovement>


        private void CloseButton_Click(object sender, EventArgs e)
        {
            settingsForm.Close();
            isOpen = false;
            Close();
            parentForm.Visible = true;

        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else WindowState = FormWindowState.Normal;
            settingsForm.Close();
            isOpen = false;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            settingsForm.Close();
            isOpen = false;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = standartColor;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = standartPageColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currentPage != Page.Count - 1)
            {
                currentPage++;
                LogText.Text = Page[currentPage];
                curPageLabel.Text = (currentPage + 1).ToString();
            }
            settingsForm.Close();
            isOpen = false;
        }

        private void LogText_Enter(object sender, EventArgs e)
        {
            pictureBox2.Focus();
        }

        Form settingsForm = new Form();
        bool isOpen = false;
        private void settings_Click(object sender, EventArgs e)
        {
            int heightOfButtons = 40;
            if (!isOpen)
            {
                List<string> elements = new List<string>();
                elements.Add("Edit");
                List<Button> instances = new List<Button>();
                settingsForm = new Form();
                if (elements.Count > 1) heightOfButtons = 25;
                settingsForm.BackColor = selectedColor;
                settingsForm.StartPosition = FormStartPosition.Manual;
                Point Loc = settings.PointToScreen(settings.Location);
                settingsForm.Location = new Point(Loc.X - 10, Loc.Y + 20);
                settingsForm.FormBorderStyle = FormBorderStyle.None;
                settingsForm.Height = heightOfButtons * elements.Count;
                settingsForm.Width = 150;
                settingsForm.AutoScaleMode = AutoScaleMode.None;
                settingsForm.Show();
                int height = 0;
                foreach (string s in elements)
                {
                    Button yeni = new Button();
                    yeni.Location = new Point(0, height);
                    yeni.Width = 150;
                    yeni.Height = heightOfButtons;
                    yeni.Text = s;
                    yeni.ForeColor = standartTextColor;
                    settingsForm.Controls.Add(yeni);
                    yeni.FlatStyle = FlatStyle.Flat;
                    yeni.FlatAppearance.BorderSize = 0;
                    height += heightOfButtons;
                    instances.Add(yeni);
                }
                instances[0].Click += edit_click;
            }
            else
            {
                settingsForm.Close();
            }
            isOpen = !isOpen;
        }

        private void edit_click(object sender, EventArgs e)
        {
            TextEditor newTextEditor = new TextEditor(parentForm, header.Text);
            newTextEditor.Show();
            settingsForm.Close();
            this.Close();
        }

        private void settingsClose(object sender, EventArgs e)
        {
            settingsForm.Close();
            isOpen = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (currentPage != 0)
            {
                currentPage--;
                LogText.Text = Page[currentPage];
                curPageLabel.Text = (currentPage + 1).ToString();
            }
            settingsForm.Close();
            isOpen = false;
        }
    }
}
