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
    public partial class DropDownList : UserControl
    {
        int height;
        List<string> elements;
        Main parent;
        bool isOpen;

        /*
         * Must have change the way it opens.
         * Instead of using itself to expand must have change to use a panel to expand
         * Create a new panel and expand it for every item until you reach borders of application
         * Or you reach limit of how much item will shown in the same time.And dont forget to use autoscroll property of panel
         */

        public DropDownList(List<string> gelen, Main parentForm)
        {
            InitializeComponent();
            height = this.Size.Height;
            elements = new List<string>();
            foreach (string a in gelen)
            {
                elements.Add(a);
            }
            isOpen = false;
            parent = parentForm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int sayac = 30;
            if (!isOpen)
            {
                foreach (string elm in elements)
                {
                    Button element = new Button();
                    element.Width = this.Width;
                    element.Height = height;
                    this.Controls.Add(element);
                    this.Height += height;
                    element.Font = new Font("Verdana", 8);
                    element.ForeColor = Color.White;
                    element.FlatStyle = FlatStyle.Flat;
                    element.FlatAppearance.BorderSize = 0;
                    element.Text = elm;
                    element.TextAlign = ContentAlignment.MiddleLeft;
                    element.Click += choose;
                    element.Location = new Point(0, sayac);
                    sayac += 30;
                }
                this.Height += 30;
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                        this.Controls.Remove(c);
                }
                this.Height = height;
            }
            isOpen = !isOpen;
        }

        private void choose(object sender, EventArgs e)
        {
            label1.Text = ((Button)sender).Text;
            if (label1.Text.Contains("month"))
                parent.sortLogs("month");
            else if (label1.Text.Contains("tag"))
                parent.sortLogs("tag");
            else if (label1.Text.Contains("year"))
                parent.sortLogs("year");
            else
                parent.sortLogs("all");
            //Close
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                    this.Controls.Remove(c);
            }
            this.Height = height;
            isOpen = !isOpen;

        }
    }
}
