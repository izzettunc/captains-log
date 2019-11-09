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
    public partial class BasicDatePicker : UserControl
    {
        public BasicDatePicker()
        {
            InitializeComponent();
            day.Value = DateTime.Today.Day;
            month.Value = DateTime.Today.Month;
            year.Value = DateTime.Today.Year;
            dayCalculator(month.Value, year.Value);
        }

        public string getDate()
        {
            return day.Value + "/" + month.Value + "/" + year.Value;
        }

        private void dayCalculator(decimal month,decimal year)
        {
            switch(month)
            {
                case 1:
                    if (day.Value > 31) day.Value = 31;
                    day.Maximum = 31;
                    break;
                case 2:
                    if(year%4==0)
                    {
                        if (day.Value > 29) day.Value = 29;
                        day.Maximum = 29;
                    }
                    else
                    {
                        if (day.Value > 28) day.Value = 28;
                        day.Maximum = 28;
                    }
                    break;
                case 3:
                    if (day.Value > 31) day.Value = 31;
                    day.Maximum = 31;
                    break;
                case 4:
                    if (day.Value > 30) day.Value = 30;
                    day.Maximum = 30;
                    break;
                case 5:
                    if (day.Value > 31) day.Value = 31;
                    day.Maximum = 31;
                    break;
                case 6:
                    if (day.Value > 30) day.Value = 30;
                    day.Maximum = 30;
                    break;
                case 7:
                    if (day.Value > 31) day.Value = 31;
                    day.Maximum = 31;
                    break;
                case 8:
                    if (day.Value > 31) day.Value = 31;
                    day.Maximum = 31;
                    break;
                case 9:
                    if (day.Value > 30) day.Value = 30;
                    day.Maximum = 30;
                    break;
                case 10:
                    if (day.Value > 31) day.Value = 31;
                    day.Maximum = 31;
                    break;
                case 11:
                    if (day.Value > 30) day.Value = 30;
                    day.Maximum = 30;
                    break;
                case 12:
                    if (day.Value > 31) day.Value = 31;
                    day.Maximum = 31;
                    break;
            }
        }

        private void year_ValueChanged(object sender, EventArgs e)
        {
            dayCalculator(month.Value, year.Value);
        }

        private void month_ValueChanged(object sender, EventArgs e)
        {
            dayCalculator(month.Value, year.Value);
        }
    }
}
