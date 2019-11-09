using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Günlük_Uygulaması
{
    class LogOperations
    {
        public enum Month { January = 1, February, March, April, May, June, July, August, September, October, November, December };
        static string path = Application.StartupPath + @"\Data";
        public static string createNewLog(string title, string user)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Data\Logs"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Data\Logs");
            }
            StreamWriter writer = new StreamWriter(path + @"\Logs\" + Encryption.MD5encryption(title) + Encryption.MD5encryption(user) + ".txt");
            writer.Close();
            return path + @"\Logs\" + Encryption.MD5encryption(title) + Encryption.MD5encryption(user) + ".txt";
        }

        public static void addToBelongingList(string user, string title, string tags, string date)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Data\Belongings"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Data\Belongings");
            }
            FileStream fs = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Append);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(Encryption.XOR_Encryption(title,0) + "@*-*@" + Encryption.XOR_Encryption(tags,0) + "@*-*@" + Encryption.XOR_Encryption(date,0) + Environment.NewLine);
            writer.Close();
            fs.Close();
        }

        public static List<string> getAllTheTags(string user)
        {
            FileStream fs = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string line;
            string[] items;
            string[] tags;
            List<string> tagList = new List<string>();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                line = reader.ReadString();
                items = line.Split(new string[] { "@*-*@" }, StringSplitOptions.None);
                tags = Encryption.XOR_Encryption(items[1],1).Split('*');
                foreach (string s in tags)
                {
                    if (s.Length > 0 && !tagList.Contains(s.Replace("\n", "")))
                    {
                        tagList.Add(s.Replace("\n", ""));
                    }
                }
            }
            reader.Close();
            fs.Close();
            return tagList;
        }

        public static List<string> getAllTheYears(string user)
        {
            FileStream fs = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string line;
            string[] items;
            string[] date;
            List<string> yearList = new List<string>();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                line = reader.ReadString();
                items = line.Split(new string[] { "@*-*@" }, StringSplitOptions.None);
                date = Encryption.XOR_Encryption(items[2].Replace("\r\n", ""),1).Split('/');
                if (date[2].Length > 0 && !yearList.Contains(date[2]))
                {
                    yearList.Add(date[2]);
                }
            }
            reader.Close();
            fs.Close();
            return yearList;
        }

        public static List<string> getAllTheMonths(string user)
        {
            FileStream fs = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string line;
            string[] items;
            string[] date;
            List<string> monthList = new List<string>();
            Month value;
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                line = reader.ReadString();
                items = line.Split(new string[] { "@*-*@" }, StringSplitOptions.None);
                date = Encryption.XOR_Encryption(items[2].Replace("\r\n", ""),1).Split('/');
                value = (Month)int.Parse(date[1]);
                if (value.ToString().Length > 0 && !monthList.Contains(value.ToString()))
                {
                    monthList.Add(value.ToString());
                }
            }
            reader.Close();
            fs.Close();
            return monthList;
        }

        public static bool isThisLogExist(string title, string user)
        {
            if (File.Exists(path + @"\Logs\" + Encryption.MD5encryption(title) + Encryption.MD5encryption(user) + ".txt"))
                return true;
            else return false;
        }

        public static void editTheBelongingList()
        {

        }

        public static void saveTheLog(string user, string title, List<string> log, string pageColor, string textColor, string fontFamily, int size, int[] style, int alig)
        {
            FileStream fs = new FileStream(path + @"\Logs\" + Encryption.MD5encryption(title) + Encryption.MD5encryption(user) + ".txt", FileMode.Truncate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(Encryption.XOR_Encryption("<pagecolor>" + pageColor + "<pagecolor>" + "<textcolor>" + textColor + "<textcolor>" + "<fontfamily>" + fontFamily + "<fontfamily>" + "<size>" + size + "<size>" + "<style>" + style[0] + style[1] + style[2] + "<style>" + "<aligment>" + alig + "<aligment>" + "<pagecount>" + log.Count + "<pagecount>",0));
            writer.Write(Encryption.XOR_Encryption("<log>",0));
            foreach (string s in log)
            {
                writer.Write(Encryption.XOR_Encryption("<page>",0));
                writer.Write(Encryption.XOR_Encryption(s,0));
                writer.Write(Encryption.XOR_Encryption("<page>",0));
            }
            writer.Write(Encryption.XOR_Encryption("<log>",0));
            writer.Close();
            fs.Close();
        }

        public static string getRawLog(string user, string title)
        {
            FileStream fs = new FileStream(path + @"\Logs\" + Encryption.MD5encryption(title) + Encryption.MD5encryption(user) + ".txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string log = "";
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                log += Encryption.XOR_Encryption(reader.ReadString().Replace("\r\n", ""),1);
            }
            reader.Close();
            fs.Close();
            return log;
        }

        public static List<string> getLog(string user, string title)
        {
            string rawLog = getRawLog(user, title);
            List<string> log = new List<string>();
            if (rawLog.Length > 0)
            {
                string[] items = rawLog.Split(new string[] { "<log>" }, StringSplitOptions.None);
                string[] pages = items[1].Split(new string[] { "<page>" }, StringSplitOptions.None);
                foreach (string s in pages)
                {
                    if (s.Length > 0)
                    {
                        log.Add(s);
                    }
                }
                return log;
            }
            else
            {
                return log;
            }
        }

        public static List<string> getPageStyle(string user, string title)
        {
            string rawLog = getRawLog(user, title);
            List<string> style = new List<string>();
            if (rawLog.Length > 0)
            {
                string[] items = rawLog.Split(new string[] { "<log>" }, StringSplitOptions.None);
                string rawStyle = items[0];
                string[] styleElement;
                styleElement = rawStyle.Split(new string[] { "<pagecolor>" }, StringSplitOptions.None);
                style.Add(styleElement[1]);
                styleElement = rawStyle.Split(new string[] { "<textcolor>" }, StringSplitOptions.None);
                style.Add(styleElement[1]);
                styleElement = rawStyle.Split(new string[] { "<fontfamily>" }, StringSplitOptions.None);
                style.Add(styleElement[1]);
                styleElement = rawStyle.Split(new string[] { "<size>" }, StringSplitOptions.None);
                style.Add(styleElement[1]);
                styleElement = rawStyle.Split(new string[] { "<style>" }, StringSplitOptions.None);
                style.Add(styleElement[1]);
                styleElement = rawStyle.Split(new string[] { "<aligment>" }, StringSplitOptions.None);
                style.Add(styleElement[1]);
                return style;
            }
            else
            {
                return style;
            }
        }

        public static void editLogInfo(string user, string title, string newTitle, string newTags, string newDate)
        {
            string oldPath = path + @"\Logs\" + Encryption.MD5encryption(title) + Encryption.MD5encryption(user) + ".txt";
            string newPath = path + @"\Logs\" + Encryption.MD5encryption(newTitle) + Encryption.MD5encryption(user) + ".txt";
            File.Move(oldPath, newPath);
            FileStream fs = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string line;
            string[] items;
            List<string> logBelongings = new List<string>();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                line = reader.ReadString();
                items = line.Split(new string[] { "@*-*@" }, StringSplitOptions.None);
                if (title == Encryption.XOR_Encryption(items[0],1))
                {
                    items[0] = Encryption.XOR_Encryption(newTitle,0);
                    items[1] = Encryption.XOR_Encryption(newTags,0);
                    items[2] = Encryption.XOR_Encryption(newDate,0);
                    logBelongings.Add(items[0] + "@*-*@" + items[1] + "@*-*@" + items[2]);
                }
                else
                {
                    logBelongings.Add(line);
                }
            }
            reader.Close();
            fs.Close();
            FileStream fsw = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Truncate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fsw);
            foreach (string s in logBelongings)
                writer.Write(s);
            writer.Close();
            fs.Close();
        }

        public static void deleteLog(string user, string title)
        {
            File.Delete(path + @"\Logs\" + Encryption.MD5encryption(title) + Encryption.MD5encryption(user) + ".txt");
            FileStream fs = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string line;
            string[] items;
            List<string> logBelongings = new List<string>();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                line = reader.ReadString();
                items = line.Split(new string[] { "@*-*@" }, StringSplitOptions.None);
                if (title != Encryption.XOR_Encryption(items[0],1))
                {
                    logBelongings.Add(line);
                }
            }
            reader.Close();
            fs.Close();
            FileStream fsw = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Truncate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fsw);
            foreach (string s in logBelongings)
                writer.Write(s);
            writer.Close();
            fs.Close();

        }

        public static Dictionary<string, string> getThisUsersLogsInfo(string user)
        {
            FileStream fs = new FileStream(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string line;
            string[] items;
            Dictionary<string, string> info = new Dictionary<string, string>();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                line = reader.ReadString();
                items = line.Split(new string[] { "@*-*@" }, StringSplitOptions.None);
                for (int i = 0; i < items.Length - 1; i++)
                    items[i] = Encryption.XOR_Encryption(items[i],1);
                items[2] = Encryption.XOR_Encryption(items[2].Replace("\r\n", ""),1);
                info.Add(Encryption.MD5encryption(items[0]), items[0] + "@" + items[1] + "@" + items[2]);
            }
            reader.Close();
            fs.Close();
            return info;
        }

        public static bool areThereLogsOfThisUser(string user)
        {
            if (File.Exists(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt"))
            {
                FileInfo fi = new FileInfo(path + @"\Belongings\" + Encryption.MD5encryption(user) + ".txt");
                if (fi.Length > 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
