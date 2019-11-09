using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Günlük_Uygulaması
{
    class RegisterLogin
    {
        static List<string> settingsName = new List<string> { "AutoSave"};
        static string path = Application.StartupPath + @"\Data\accounts.txt";
        public static void Register(string uname, string pass, string secword)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Data"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Data");
            }
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(Encryption.MD5encryption(uname) + "@" + Encryption.MD5encryption(pass) + "@" + Encryption.MD5encryption(secword));
            writer.Close();
        }
        public static bool IsExist(string uname)
        {
            string hashed_uname = Encryption.MD5encryption(uname);
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                reader.DiscardBufferedData();
                string line;
                string[] items;
                while ((line = reader.ReadLine()) != null)
                {
                    items = line.Split('@');
                    if (items[0] == hashed_uname)
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
            }
            else return false;
            return false;
        }
        public static bool Login(string uname, string pass)
        {
            string hashed_uname = Encryption.MD5encryption(uname);
            string hashed_pass = Encryption.MD5encryption(pass);
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                reader.DiscardBufferedData();
                string line;
                string[] items;
                while ((line = reader.ReadLine()) != null)
                {
                    items = line.Split('@');
                    if (items[0] == hashed_uname && items[1] == hashed_pass)
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
            }
            else return false;
            return false;
        }
        public static bool forgetPassword(string uname, string secword)
        {
            string hashed_uname = Encryption.MD5encryption(uname);
            string hashed_secword = Encryption.MD5encryption(secword);
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                reader.DiscardBufferedData();
                string line;
                string[] items;
                while ((line = reader.ReadLine()) != null)
                {
                    items = line.Split('@');
                    if (items[0] == hashed_uname && items[2] == hashed_secword)
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
            }
            else return false;
            return false;
        }
        public static void saveLastLogin(string uname)
        {
            FileStream fs = new FileStream(Application.StartupPath + @"\Data\" + Encryption.MD5encryption(uname) + ".txt", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(Encryption.XOR_Encryption(DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year,0));
            writer.Close();
            fs.Close();
        }
        public static string getLastLogin(string uname)
        {
            if (File.Exists(Application.StartupPath + @"\Data\" + Encryption.MD5encryption(uname) + ".txt"))
            {
                FileStream fs = new FileStream(Application.StartupPath + @"\Data\" + Encryption.MD5encryption(uname) + ".txt", FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(fs);
                string lastLogin = "";
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    lastLogin += Encryption.XOR_Encryption(reader.ReadString().Replace("\r\n", ""),1);
                }
                reader.Close();
                fs.Close();
                return lastLogin;
            }
            else return DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
        }
        public static void saveUserSettings(List<string> settings)
        {
            
            FileStream fs = new FileStream(Application.StartupPath + @"\Data\settings.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            for (int i = 0; i < settings.Count;i++)
            {
                writer.WriteLine(settingsName[i]+" "+settings[i]);
            }
            writer.Close();
            fs.Close();
        }
        public static Dictionary<string,string> getUserSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            if (File.Exists(Application.StartupPath + @"\Data\settings.txt"))
            {
                FileStream fs = new FileStream(Application.StartupPath + @"\Data\settings.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string line;
                string[] items;
                while ((line = reader.ReadLine()) != null)
                {
                    items = line.Replace(Environment.NewLine, "").Split(' ');
                    settings.Add(items[0], items[1]);
                }
                reader.Close();
                fs.Close();
                return settings;
            }
            else
            {
                for(int i=0;i< settingsName.Count;i++)
                {
                    settings.Add(settingsName[i],"0");
                }
                return settings;
            }
        }
        public static void changePassword(string uname, string newPassword)
        {
            string hashed_uname = Encryption.MD5encryption(uname);
            string hashed_pass = Encryption.MD5encryption(newPassword);
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                reader.DiscardBufferedData();
                string line;
                List<string> data = new List<string>();
                string[] items;
                while ((line = reader.ReadLine()) != null)
                {
                    items = line.Split('@');
                    if (items[0] == hashed_uname)
                    {
                        items[1] = hashed_pass;
                        data.Add(items[0] + "@" + items[1] + "@" + items[2]);
                    }
                    else
                    {
                        data.Add(line);
                    }
                }
                reader.Close();
                StreamWriter writer = new StreamWriter(path);
                foreach (string s in data)
                {
                    writer.WriteLine(s);
                }
                writer.Close();
            }

        }
        public static void changeSecureword(string uname, string newSecword)
        {
            string hashed_uname = Encryption.MD5encryption(uname);
            string hashed_secword = Encryption.MD5encryption(newSecword);
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                reader.DiscardBufferedData();
                string line;
                List<string> data = new List<string>();
                string[] items;
                while ((line = reader.ReadLine()) != null)
                {
                    items = line.Split('@');
                    if (items[0] == hashed_uname)
                    {
                        items[2] = hashed_secword;
                        data.Add(items[0] + "@" + items[1] + "@" + items[2]);
                    }
                    else
                    {
                        data.Add(line);
                    }
                }
                reader.Close();
                StreamWriter writer = new StreamWriter(path);
                foreach (string s in data)
                {
                    writer.WriteLine(s);
                }
                writer.Close();
            }

        }
    }
}
