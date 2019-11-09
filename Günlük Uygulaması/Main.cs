using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Günlük_Uygulaması
{
    public partial class Main : Form
    {
        public string activeUser;
        private List<Control> sorterList;//It has all the sorter controls(only picture boxes(folders) not labels)
        public string Sort;
        private Control lastRightClicked;
        private Dictionary<Log, string> Logs = new Dictionary<Log, string>();
        int result;
        //Sorting Operations <Starts>

        //Creates sorting control and fill it by default values
        public void createSorting()
        {
            List<string> listElements = new List<string>();
            listElements.Add("See All");
            listElements.Add("Sort by tag");
            listElements.Add("Sort by month");
            listElements.Add("Sort by year");
            DropDownList newDDL = new DropDownList(listElements, this);
            this.Controls.Add(newDDL);
            newDDL.Location = new Point(0, 48);
            newDDL.BringToFront();
        }

        //Creates folders for sorting and returns a list that it has controls of folders
        public List<Control> fillTheSorters(List<string> nameList)
        {
            leftPanel.Controls.Clear();
            int sorterStartX = 17;
            int sorterStartY = 18;
            List<Control> indexList = new List<Control>();
            foreach (string s in nameList)
            {
                PictureBox newPB = new PictureBox();//folder control
                newPB.Location = new Point(sorterStartX, sorterStartY);
                newPB.Width = 139;
                newPB.Height = 100;
                sorterStartY += 177;
                newPB.Image = Properties.Resources.folder;
                newPB.SizeMode = PictureBoxSizeMode.Zoom;
                newPB.Click += sorter_Click;
                Label newSorterFolderLabel = new Label();//label control
                newSorterFolderLabel.Text = s;
                newSorterFolderLabel.Font = label4.Font;
                newSorterFolderLabel.ForeColor = Color.LightGray;
                newSorterFolderLabel.Location = new Point(newPB.Location.X + 35, newPB.Location.Y + 125);
                newSorterFolderLabel.AutoSize = true;
                leftPanel.Controls.Add(newPB);
                leftPanel.Controls.Add(newSorterFolderLabel);
                indexList.Add(newPB);
            }
            return indexList;
        }

        //Creates a filler text for left panel(sorting panel)
        public void createFillerText()
        {
            Label filler = new Label();
            filler.Text = "Please select";
            filler.AutoSize = true;
            filler.TextAlign = ContentAlignment.MiddleCenter;
            filler.Font = new Font("Verdana", 13);
            filler.ForeColor = Color.LightGray;
            filler.Location = new Point(16, 200);
            leftPanel.Controls.Add(filler);
            Label filler2 = new Label();
            Label filler3 = new Label();
            Label filler4 = new Label();
            filler2.AutoSize = filler3.AutoSize = filler4.AutoSize = filler.AutoSize;
            filler2.Font = filler3.Font = filler4.Font = filler.Font;
            filler2.ForeColor = filler3.ForeColor = filler4.ForeColor = filler.ForeColor;
            filler2.TextAlign = filler3.TextAlign = filler4.TextAlign = filler.TextAlign;
            filler2.Location = new Point(18, 225);
            filler3.Location = new Point(2, 250);
            filler4.Location = new Point(60, 275);
            filler2.Text = "a sorting so";
            filler3.Text = "I can show them";
            filler4.Text = ":3";
            leftPanel.Controls.Add(filler2);
            leftPanel.Controls.Add(filler3);
            leftPanel.Controls.Add(filler4);
        }

        //Event that occurs when user clicked on a folder(sorter) and sorts the logs 
        private void sorter_Click(object sender, EventArgs e)
        {
            int index = sorterList.IndexOf((Control)sender);
            int counter = 0;
            //with sorterList index and foreach labels in leftpanel control ,counter and index become synchronized
            foreach (Label l in leftPanel.Controls.OfType<Label>())
            {
                if (counter == index)//when correct label found it fills the logs by its sort and text
                {
                    if (Sort == "month") fillTheLogsByMonth(l.Text);
                    else if (Sort == "tag") fillTheLogsByTag(l.Text);
                    else if (Sort == "year") fillTheLogsByYear(l.Text);
                }
                counter++;
            }
        }

        //Sorts by selected criteria and fills the panel
        public void sortLogs(string sort)
        {
            /* after select a sorting criteria
             * first algorithm takes months/tags/years of logs that belongs to current user
             * and creates folders with these months/tags/years 
             * and also assign the controls of folders list to global variable sorterlist
             * after that if there is any months/tags/years fills the screen with logs with that month/tag/year
             * if there isn't shows nothing
             */
            List<string> list;
            if (sort == "month")
            {
                Sort = "month";
                list = LogOperations.getAllTheMonths(activeUser);
                sorterList = fillTheSorters(list);
                if (list.Count > 0)
                    fillTheLogsByMonth(list[0]);
                else
                    fillTheLogsByMonth("");
            }
            else if (sort == "tag")
            {
                Sort = "tag";
                list = LogOperations.getAllTheTags(activeUser);
                sorterList = fillTheSorters(list);
                if (list.Count > 0)
                    fillTheLogsByTag(list[0]);
                else
                    fillTheLogsByTag("");
            }
            else if (sort == "year")
            {
                Sort = "year";
                list = LogOperations.getAllTheYears(activeUser);
                sorterList = fillTheSorters(list);
                if (list.Count > 0)
                    fillTheLogsByYear(list[0]);
                else
                    fillTheLogsByYear("");
            }
            else
            {
                Sort = "all";
                leftPanel.Controls.Clear();
                fillTheLogs();
                createFillerText();
            }
        }

        //Sorting Operations <Ends>

        //Log operations <Starts>

        //Creates log control
        public void createLog(int x, int y, string title)
        {
            Log newLog = new Log();
            newLog.Width = 115;
            newLog.Height = 115;
            newLog.Location = new Point(x, y);
            newLog.MouseClick += log_rightClickEvent;
            logPanel.Controls.Add(newLog);
            Label newLogLabel = new Label();
            int counter = 0;
            foreach (char c in title)
            {
                newLogLabel.Text += c;
                counter++;
                if (counter == 20) { counter = 0; newLogLabel.Text += "\n"; }
            }
            newLogLabel.Font = label4.Font;
            newLogLabel.AutoSize = true;
            newLogLabel.ForeColor = Color.LightGray;
            newLogLabel.Location = new Point(newLog.Location.X + 17, newLog.Location.Y + 125);
            logPanel.Controls.Add(newLogLabel);
            Logs.Add(newLog, newLogLabel.Text.Replace("\n", ""));
        }

        //Removes all controls except new log control
        public void removePanelControls()
        {
            logPanel.Controls.Clear();
            Logs.Clear();
            NewLog newLogControl = new NewLog();
            newLogControl.Width = 115;
            newLogControl.Height = 115;
            newLogControl.Location = new Point(3, 3);
            newLogControl.MouseClick += newLog1_MouseClick;
            logPanel.Controls.Add(newLogControl);
        }

        //Fill the panel with all logs that user have
        public void fillTheLogs()
        {
            /* If there is any logs of the current user
             * first takes a dictionary that haves encrypted and decrypted versions of files name
             * after that takes every logs that has been created by any user
             * each log that contains encrypted version of current user name
             * decrypt the text name and reach the log name after that logs are created by their names
             */
            int logStartX = 3;
            int logStartY = 3;
            removePanelControls();
            if (LogOperations.areThereLogsOfThisUser(activeUser))
            {
                Dictionary<string, string> LogInfo = LogOperations.getThisUsersLogsInfo(activeUser);
                DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + @"\Data\Logs");
                FileInfo[] Files = DirInfo.GetFiles("*.txt");
                string x = "";
                for (int i = 0; i < Files.Length; i++)
                {
                    if (Files[i].Name.Contains(Encryption.MD5encryption(this.activeUser)))
                    {
                        x = Files[i].Name;
                        x = x.Replace(".txt", "");
                        x = x.Remove(x.Length - 32, 32);
                        string[] info = LogInfo[x].Split('@');
                        logStartX += 150;
                        if (logStartX > 900)
                        {
                            logStartX = logStartX % 900;
                            logStartY += 200;
                        }
                        createLog(logStartX, logStartY, info[0]);
                    }
                }
            }
            sortText.Text = "All";
        }
        /* Algorithm explanation of fillTheLogsBy.... functions
         * 
         * If there is any logs of the current user
         * first takes a dictionary that haves encrypted and decrypted versions of files name
         * after that takes every logs that has been created by any user
         * each log that contains encrypted version of current user name
         * decrypt the text name and reach the log name and its selected criteria 
         * after that if logs selecte criteria and users selected criteria matches
         * then that logs getting created by its decrypted names
         */

        //Fill the panel with logs that has selected criteria
        public void fillTheLogsByTag(string tag)
        {
            int logStartX = 3;
            int logStartY = 3;
            removePanelControls();
            if (LogOperations.areThereLogsOfThisUser(activeUser))
            {
                Dictionary<string, string> LogInfo = LogOperations.getThisUsersLogsInfo(activeUser);
                DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + @"\Data\Logs");
                FileInfo[] Files = DirInfo.GetFiles("*.txt");
                for (int i = 0; i < Files.Length; i++)
                {
                    if (Files[i].Name.Contains(Encryption.MD5encryption(this.activeUser)))
                    {
                        string[] info = LogInfo[Files[i].Name.Replace(Encryption.MD5encryption(this.activeUser), "").Replace(".txt", "")].Split('@');
                        string[] tags = info[1].Split('*');
                        List<string> tagList = new List<string>();
                        foreach (string s in tags)
                        {
                            if (s.Length > 0)
                            {
                                tagList.Add(s.Replace("\n", ""));
                            }
                        }
                        if (tagList.Contains(tag))
                        {
                            logStartX += 150;
                            if (logStartX > 900)
                            {
                                logStartX = logStartX % 900;
                                logStartY += 200;
                            }
                            createLog(logStartX, logStartY, info[0]);
                        }
                    }
                }
            }
            sortText.Text = "Sorted by " + Sort + " : " + tag;
        }

        public void fillTheLogsByName(string name)
        {
            int res = 0;
            int logStartX = 3;
            int logStartY = 3;
            logPanel.Controls.Clear();
            NewLog newLogControl = new NewLog();
            newLogControl.Width = 115;
            newLogControl.Height = 115;
            newLogControl.Location = new Point(3, 3);
            newLogControl.MouseClick += newLog1_MouseClick;
            logPanel.Controls.Add(newLogControl);
            if (LogOperations.areThereLogsOfThisUser(activeUser))
            {
                Dictionary<string, string> LogInfo = LogOperations.getThisUsersLogsInfo(activeUser);
                DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + @"\Data\Logs");
                FileInfo[] Files = DirInfo.GetFiles("*.txt");
                for (int i = 0; i < Files.Length; i++)
                {
                    if (Files[i].Name.Contains(Encryption.MD5encryption(this.activeUser)))
                    {
                        string[] info = LogInfo[Files[i].Name.Replace(Encryption.MD5encryption(this.activeUser), "").Replace(".txt", "")].Split('@');
                        if ((info[0].Contains(name) || info[0] == name) && Logs.ContainsValue(info[0]))
                        {
                            logStartX += 150;
                            if (logStartX > 900)
                            {
                                logStartX = logStartX % 900;
                                logStartY += 200;
                            }
                            createLog(logStartX, logStartY, info[0]);
                            res++;
                        }

                    }
                }
            }
            sortText.Text = "Sorted by name : " + name;
            result = res;
        }

        public void fillTheLogsByYear(string year)
        {
            int logStartX = 3;
            int logStartY = 3;
            removePanelControls();
            if (LogOperations.areThereLogsOfThisUser(activeUser))
            {
                Dictionary<string, string> LogInfo = LogOperations.getThisUsersLogsInfo(activeUser);
                DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + @"\Data\Logs");
                FileInfo[] Files = DirInfo.GetFiles("*.txt");
                for (int i = 0; i < Files.Length; i++)
                {
                    if (Files[i].Name.Contains(Encryption.MD5encryption(this.activeUser)))
                    {
                        string[] info = LogInfo[Files[i].Name.Replace(Encryption.MD5encryption(this.activeUser), "").Replace(".txt", "")].Split('@');
                        if (info[2].Contains(year))
                        {
                            logStartX += 150;
                            if (logStartX > 900)
                            {
                                logStartX = logStartX % 900;
                                logStartY += 200;
                            }
                            createLog(logStartX, logStartY, info[0]);
                        }
                    }
                }
            }
            sortText.Text = "Sorted by " + Sort + " : " + year;
        }

        public void fillTheLogsByMonth(string month)
        {
            int logStartX = 3;
            int logStartY = 3;
            removePanelControls();
            if (LogOperations.areThereLogsOfThisUser(activeUser))
            {
                Dictionary<string, string> LogInfo = LogOperations.getThisUsersLogsInfo(activeUser);
                DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + @"\Data\Logs");
                FileInfo[] Files = DirInfo.GetFiles("*.txt");
                for (int i = 0; i < Files.Length; i++)
                {
                    if (Files[i].Name.Contains(Encryption.MD5encryption(this.activeUser)))
                    {
                        string[] info = LogInfo[Files[i].Name.Replace(Encryption.MD5encryption(this.activeUser), "").Replace(".txt", "")].Split('@');
                        string[] date = info[2].Split('/');
                        LogOperations.Month value = (LogOperations.Month)int.Parse(date[1]);
                        if (value.ToString() == month)
                        {
                            logStartX += 150;
                            if (logStartX > 900)
                            {
                                logStartX = logStartX % 900;
                                logStartY += 200;
                            }
                            createLog(logStartX, logStartY, info[0]);
                        }
                    }
                }
            }
            sortText.Text = "Sorted by " + Sort + " : " + month;
        }

        //Log operations <Ends>

        public Main(string user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            createSorting();
            activeUser = user;
            fillTheLogs();
            createFillerText();
            nameLabel.Text = "Welcome " + activeUser;
            lastLogin.Text = "Last Login : " + RegisterLogin.getLastLogin(activeUser);
        }

        //Form movement <Starts>

        int movementVariable = 0;
        int x, y;
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                movementVariable = 0;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (movementVariable == 1)
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
                movementVariable = 1;
            }
        }

        //Form movement <Ends>

        //Form events <Starts>

        public void log_doubleClick(Log clicked)
        {
            LogReader newLogReaderForm = new LogReader(this, Logs[clicked]);
            newLogReaderForm.Show();
        }

        private void log_rightClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show((Control)sender, new Point(e.X, e.Y));
                lastRightClicked = (Control)sender;
            }
        }

        public void loseFocus()
        {
            label4.Focus();
            settingsForm.Dispose();
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            loseFocus();
        }

        private void newLog1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = false;
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else WindowState = FormWindowState.Normal;
            loseFocus();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            loseFocus();
            RegisterLogin.saveLastLogin(activeUser);
            Application.Exit();
        }

        private void leftPanel_Click(object sender, EventArgs e)
        {
            loseFocus();
        }

        private void logPanel_MouseClick(object sender, MouseEventArgs e)
        {
            loseFocus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOperations.deleteLog(activeUser, Logs[(Log)lastRightClicked]);
            sortLogs(Sort);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLogScreen newLogControlsScreen = new NewLogScreen(this, activeUser, Logs[(Log)lastRightClicked]);
            newLogControlsScreen.Show();
            this.Visible = false;
            sortLogs(Sort);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEditor newTextEditor = new TextEditor(this, Logs[(Log)lastRightClicked]);
            newTextEditor.Show();
            this.Visible = false;
        }

        Form settingsForm = new Form();
        bool isOpen = false;
        //Opens drop down list of settings
        private void settings_Click(object sender, EventArgs e)
        {
            int heightOfButtons = 40;
            if (!isOpen)
            {
                List<string> elements = new List<string>();
                elements.Add("New Log");
                elements.Add("Search");
                elements.Add("Profile");
                elements.Add("Settings");
                elements.Add("Credit");
                elements.Add("Upcoming Update Info");
                List<Button> instances = new List<Button>();
                settingsForm = new Form();
                settingsForm.ShowInTaskbar = false;
                if (elements.Count > 1) heightOfButtons = 25;
                settingsForm.BackColor = Color.FromArgb(44, 48, 59);
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
                    Button newButton = new Button();
                    newButton.Location = new Point(0, height);
                    newButton.Width = 150;
                    newButton.Height = heightOfButtons;
                    newButton.Text = s;
                    newButton.ForeColor = Color.LightGray;
                    settingsForm.Controls.Add(newButton);
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 0;
                    height += heightOfButtons;
                    instances.Add(newButton);
                }
                instances[0].Click += newLog_Click;
                instances[1].Click += openSearchBar;
                instances[2].Click += openProfile;
                instances[3].Click += openSettings;
                instances[4].Click += openCredit;
                instances[5].Click += openUpdate;
            }
            else
            {
                settingsForm.Close();
            }
            isOpen = !isOpen;
        }

        private void openUpdate(object sender, EventArgs e)
        {
            MessageBox.Show("While reading logs you can also print and export them in a readable way.\n\nOn main menu you can import a text file and convert to it a log.\n\nWill be add more statistics and settings.");
        }

        private void openCredit(object sender, EventArgs e)
        {
            MessageBox.Show("This application programmed by Izzet Tunç and this is first version which is finished on 17.08.2018.\n\n\nIf you want to send a bug report or give me an idea please mail me at izzet.tunc1997@gmail.com");
            settingsForm.Close();
            isOpen = false;
        }

        private void openSettings(object sender, EventArgs e)
        {
            Settings newSettingsScreen = new Settings(this);
            newSettingsScreen.Show();
            settingsForm.Close();
            isOpen = false;
            this.Visible = false;
        }

        private void openProfile(object sender, EventArgs e)
        {
            Profile newProfileScreen = new Profile(this, activeUser);
            newProfileScreen.Show();
            settingsForm.Close();
            isOpen = false;
            this.Visible = false;

        }

        bool flag = false;
        //Opens search bar using drop down list
        private void openSearchBar(object sender, EventArgs e)
        {
            object empty = new object();
            EventArgs emtpyArgs = new EventArgs();
            if (!flag)
            {
                search_Click(empty, emtpyArgs);
            }
            else
            {
                Close_Click(empty, emtpyArgs);
            }
            settingsForm.Close();
            isOpen = false;
            flag = !flag;
        }

        private void newLog_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            NewLogScreen newLogControlScreen = new NewLogScreen(this, this.activeUser);
            newLogControlScreen.Show();
            settingsForm.Close();
            isOpen = false;
        }

        private void settingsClose(object sender, EventArgs e)
        {
            settingsForm.Close();
            isOpen = false;
        }

        int oldWidth;
        int oldHeight;
        PictureBox temp;
        TextBox searchBox;
        Label resLabel;
        //Opens search bar with left down search button
        private void search_Click(object sender, EventArgs e)
        {
            temp = search;
            oldWidth = searchBar.Width;
            oldHeight = searchBar.Height;
            search.Visible = false;
            searchBar.Width = 300;
            searchBar.Height = 100;
            if (this.WindowState == FormWindowState.Normal)
            {
                searchBar.Location = new Point(825, 481);
            }
            else
            {
                searchBar.Location = new Point(1236, 736);
            }
            Label close = new Label();
            close.Font = new Font("Verdana", 15);
            close.Text = "X";
            close.Location = new Point(close.Location.X + 275, close.Location.Y);
            close.ForeColor = Color.LightGray;
            searchBar.Controls.Add(close);
            TextBox searchText = new TextBox();
            searchBox = searchText;
            searchText.Font = new Font("Verdana", 10);
            searchText.ForeColor = Color.LightGray;
            searchText.BackColor = Color.FromArgb(56, 60, 74);
            searchText.BorderStyle = BorderStyle.None;
            searchText.Text = "";
            searchText.Location = new Point(searchText.Location.X + 5, searchText.Location.Y + 45);
            searchText.Width = 200;
            searchBar.Controls.Add(searchText);
            close.Click += Close_Click;
            searchText.TextChanged += SearchText_TextChanged;
            Button research = new Button();
            research.ForeColor = Color.LightGray;
            research.Text = "Search";
            research.FlatStyle = FlatStyle.Flat;
            research.FlatAppearance.BorderSize = 0;
            research.BackColor = Color.FromArgb(56, 60, 74);
            research.Location = new Point(searchText.Location.X + 210, searchText.Location.Y + 30);
            research.Click += Research_Click;
            searchBar.Controls.Add(research);
            Label lab1 = new Label();
            Label lab2 = new Label();
            lab1.Text = "Search";
            lab2.Text = "Waiting for input...";
            lab2.AutoSize = true;
            resLabel = lab2;
            lab1.Font = lab2.Font = searchText.Font;
            lab1.ForeColor = lab2.ForeColor = close.ForeColor;
            lab1.Location = new Point(lab1.Location.X + 2, lab1.Location.Y + 5);
            lab2.Location = new Point(lab2.Location.X + 2, lab1.Location.Y + 75);
            searchBar.Controls.Add(lab1);
            searchBar.Controls.Add(lab2);
        }

        private void Research_Click(object sender, EventArgs e)
        {
            fillTheLogsByName(searchBox.Text);
            if (result == 0) resLabel.Text = "No result found";
            else resLabel.Text = result + " result found";
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            fillTheLogsByName(searchBox.Text);
            if (result == 0) resLabel.Text = "No result found";
            else resLabel.Text = result + " result found";

        }

        private void Close_Click(object sender, EventArgs e)
        {
            searchBar.Controls.Clear();
            searchBar.Controls.Add(temp);
            searchBar.Width = oldWidth;
            searchBar.Height = oldHeight;
            search.Visible = true;
            if (this.WindowState == FormWindowState.Normal)
            {
                searchBar.Location = new Point(1081, 539);
            }
            else
            {
                searchBar.Location = new Point(1492, 794);
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            loseFocus();
        }


        //Form events <Ends>
    }
}
