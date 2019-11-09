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
    public partial class Settings : Form
    {
        Form parent;
        public Settings(Form papa)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            parent = papa;
            Dictionary<string, string> settings = RegisterLogin.getUserSettings();
            if (settings["AutoSave"] == "1") Autosave_checkBox.Checked = true;
            else Autosave_checkBox.Checked = false;
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            List<string> settings = new List<string>();
            foreach (CheckBox x in this.Controls.OfType<CheckBox>())
            {
                if (x.Checked) settings.Add("1");
                else settings.Add("0");
            }
            RegisterLogin.saveUserSettings(settings);
            MessageBox.Show("Saved");
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

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
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
