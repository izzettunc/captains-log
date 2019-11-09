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
    public partial class TextEditor : Form
    {
        Color standartColor = Color.FromArgb(50, 54, 66);
        Color selectedColor = Color.FromArgb(39, 42, 51);
        Color standartTextColor = Color.LightGray;
        Color standartPageColor = Color.FromArgb(56, 60, 74);
        Font standartFont = new Font("Verdana", 11, FontStyle.Regular);
        int currentPage;
        Main parentForm;
        int alig = 1;
        int writtenLetters=0;
        bool autoSave;
        List<string> Page = new List<string>();
        public TextEditor(Form parent, string title)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            parentForm = ((Main)parent);
            parentForm.loseFocus();
            currentPage = 0;
            header.Text = title.Replace(Environment.NewLine, "");
            labelfont.Text = LogText.Font.FontFamily.Name;
            sizeLabel.Text = LogText.Font.Size.ToString();
            Page = LogOperations.getLog(parentForm.activeUser, title);
            if (Page.Count > 0)
            {
                LogText.Text = Page[0];
            }
            else
            {
                Page.Add("");
            }
            LogText.SelectAll();
            List<string> style = LogOperations.getPageStyle(parentForm.activeUser, title);
            if (style.Count > 0)
            {
                string[] items;
                items = style[0].Split('@');
                LogText.BackColor = Color.FromArgb(int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]));
                items = style[1].Split('@');
                LogText.SelectionColor=LogText.ForeColor = Color.FromArgb(int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]));
                LogText.SelectionFont = LogText.Font = new Font(style[2], int.Parse(style[3]));
                
                labelfont.Text = style[2];
                sizeLabel.Text = style[3];
                if (style[4][0] == '1') { Bold.BackColor = selectedColor; LogText.Font = new Font(LogText.Font, LogText.Font.Style ^ FontStyle.Bold); }
                if (style[4][1] == '1') { Italic.BackColor = selectedColor; LogText.Font = new Font(LogText.Font, LogText.Font.Style ^ FontStyle.Italic); }
                if (style[4][2] == '1') { underLine.BackColor = selectedColor; LogText.Font = new Font(LogText.Font, LogText.Font.Style ^ FontStyle.Underline); }
                alig = int.Parse(style[5]);
                if (alig == 1)
                {
                    alignLeft.BackColor = selectedColor;
                    alignMiddle.BackColor = alignRight.BackColor = standartColor;
                }
                else if(alig==2)
                {
                    alignMiddle.BackColor = selectedColor;
                    alignLeft.BackColor = alignRight.BackColor = standartColor;
                }
                else
                {
                    alignRight.BackColor = selectedColor;
                    alignMiddle.BackColor = alignMiddle.BackColor = standartColor;
                }
                changeAligment();
                LogText.DeselectAll();

            }
            LogText.SelectionStart = LogText.Text.Length;
            Dictionary<string,string> settings = RegisterLogin.getUserSettings();
            if (settings["AutoSave"] == "0")
            {
                autoSave = false;
            }
            else autoSave = true;
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
            Close();
            parentForm.Visible = true;
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else WindowState = FormWindowState.Normal;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = LogText.ForeColor;
            colorDialog1.ShowDialog();
            LogText.ForeColor = colorDialog1.Color;
        }

        private void pageColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = LogText.BackColor;
            colorDialog1.ShowDialog();
            LogText.BackColor = colorDialog1.Color;
        }

        private void Font_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = new Font(LogText.Font.FontFamily, LogText.Font.Size, LogText.Font.Style);
            fontDialog1.ShowDialog();
            LogText.Font = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, LogText.Font.Style);
            labelfont.Text = LogText.Font.FontFamily.Name;
            sizeLabel.Text = LogText.Font.Size.ToString();
        }

        private void Bold_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == standartColor) ((PictureBox)sender).BackColor = selectedColor;
            else ((PictureBox)sender).BackColor = standartColor;
            LogText.Font = new Font(LogText.Font, LogText.Font.Style ^ FontStyle.Bold);
        }

        private void Italic_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == standartColor) ((PictureBox)sender).BackColor = selectedColor;
            else ((PictureBox)sender).BackColor = standartColor;
            LogText.Font = new Font(LogText.Font, LogText.Font.Style ^ FontStyle.Italic);
        }

        private void underLine_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == standartColor) ((PictureBox)sender).BackColor = selectedColor;
            else ((PictureBox)sender).BackColor = standartColor;
            LogText.Font = new Font(LogText.Font, LogText.Font.Style ^ FontStyle.Underline);
        }

        private void alignLeft_Click(object sender, EventArgs e)
        {
            alignLeft.BackColor = selectedColor;
            alignMiddle.BackColor = alignRight.BackColor = standartColor;
            alig = 1;
            changeAligment();
        }

        private void alignMiddle_Click(object sender, EventArgs e)
        {
            alignMiddle.BackColor = selectedColor;
            alignLeft.BackColor = alignRight.BackColor = standartColor;
            alig = 2;
            changeAligment();
        }

        private void alignRight_Click(object sender, EventArgs e)
        {
            alignRight.BackColor = selectedColor;
            alignMiddle.BackColor = alignLeft.BackColor = standartColor;
            alig = 3;
            changeAligment();
        }

        void changeAligment()
        {
            int i = LogText.SelectionStart;
            LogText.SelectAll();
            if (alig == 1) LogText.SelectionAlignment = HorizontalAlignment.Left;
            else if (alig == 2) LogText.SelectionAlignment = HorizontalAlignment.Center;
            else if (alig == 3) LogText.SelectionAlignment = HorizontalAlignment.Right;
            LogText.DeselectAll();
             LogText.SelectionStart = i;
        }

        int maxExtendable = 5;
        int curExt = 0;
        private void extendTextBox_Click(object sender, EventArgs e)
        {
            if (curExt != maxExtendable)
            {
                int increment = 30;
                LogText.Location = new Point(LogText.Location.X - increment, LogText.Location.Y);
                LogText.Width += increment * 2;
                curExt++;
            }
        }

        private void shortenTextBox_Click(object sender, EventArgs e)
        {
            if (curExt != 0)
            {
                int increment = 30;
                LogText.Location = new Point(LogText.Location.X + increment, LogText.Location.Y);
                LogText.Width -= increment * 2;
                curExt--;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string backcolor = LogText.BackColor.R + "@" + LogText.BackColor.G + "@" + LogText.BackColor.B;
            string forecolor = LogText.ForeColor.R + "@" + LogText.ForeColor.G + "@" + LogText.ForeColor.B;
            int[] style = new int[3];
            if (LogText.Font.Bold) style[0] = 1;
            if (LogText.Font.Italic) style[1] = 1;
            if (LogText.Font.Underline) style[2] = 1;
            LogOperations.saveTheLog(parentForm.activeUser, header.Text, Page, backcolor, forecolor, LogText.Font.FontFamily.Name, Convert.ToInt32(LogText.Font.Size), style, alig);
            MessageBox.Show("Saved");
        }

        private void clearFormatting_Click(object sender, EventArgs e)
        {
            int i = LogText.SelectionStart;
            LogText.Font = standartFont;
            LogText.ForeColor = standartTextColor;
            LogText.BackColor = standartPageColor;
            Bold.BackColor = standartColor;
            Italic.BackColor = standartColor;
            underLine.BackColor = standartColor;
            alignRight.BackColor = standartColor;
            alignMiddle.BackColor = standartColor;
            alignLeft.BackColor = selectedColor;
            alig = 1;
            changeAligment();
            labelfont.Text = LogText.Font.FontFamily.Name;
            sizeLabel.Text = LogText.Font.Size.ToString();
            LogText.SelectionStart = i;
        }

        private void newPage_Click(object sender, EventArgs e)
        {
            Page.Add("");
            currentPage = Page.Count - 1;
            curPageLabel.Text = (currentPage + 1).ToString();
            LogText.Text = "";
            changeAligment();
        }

        private void deletePage_Click(object sender, EventArgs e)
        {
            if (Page.Count > 1)
            {
                Page.RemoveAt(currentPage);
                if (currentPage - 1 < 0)
                {
                    LogText.Text = Page[currentPage];
                    curPageLabel.Text = (currentPage + 1).ToString();
                    changeAligment();
                }
                else
                {
                    currentPage--;
                    LogText.Text = Page[currentPage];
                    curPageLabel.Text = (currentPage + 1).ToString();
                    changeAligment();
                }
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = standartColor;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = standartPageColor;
        }

        private void pictureBox2_MouseUpv2(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = standartColor;
        }

        private void pictureBox2_MouseDownv2(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = selectedColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currentPage != Page.Count - 1)
            {
                currentPage++;
                LogText.Text = Page[currentPage];
                curPageLabel.Text = (currentPage + 1).ToString();
                changeAligment();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (currentPage != 0)
            {
                currentPage--;
                LogText.Text = Page[currentPage];
                curPageLabel.Text = (currentPage + 1).ToString();
                changeAligment();
            }
        }

        private void LogText_TextChanged(object sender, EventArgs e)
        {
            int i = LogText.SelectionStart;
            Page[currentPage] = LogText.Text;
            LogText.SelectAll();
            LogText.SelectionFont = new Font(LogText.Font.FontFamily, LogText.Font.Size, LogText.Font.Style);
            LogText.DeselectAll();
            LogText.SelectionStart = i;
            writtenLetters++;
            if(writtenLetters==25 && autoSave)
            {
                writtenLetters = 0;
                string backcolor = LogText.BackColor.R + "@" + LogText.BackColor.G + "@" + LogText.BackColor.B;
                string forecolor = LogText.ForeColor.R + "@" + LogText.ForeColor.G + "@" + LogText.ForeColor.B;
                int[] style = new int[3];
                if (LogText.Font.Bold) style[0] = 1;
                if (LogText.Font.Italic) style[1] = 1;
                if (LogText.Font.Underline) style[2] = 1;
                LogOperations.saveTheLog(parentForm.activeUser, header.Text, Page, backcolor, forecolor, LogText.Font.FontFamily.Name, Convert.ToInt32(LogText.Font.Size), style, alig);
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {

        }
    }
}
