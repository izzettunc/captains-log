using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Günlük_Uygulaması
{
    class Encryption
    {
        public static string MD5encryption(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] array = Encoding.UTF8.GetBytes(text);
            array = md5.ComputeHash(array);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in array)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        public static string XOR_Encryption(string text, int mode)
        {
            if (mode == 0)
            {
                string encryptedText = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\n' || text[i] == '\r' || text[i] == 'İ' || text[i] == 'ı' || text[i]==' ' || text[i] == 'ş' || text[i] == 'Ş' || text[i] == 'ü' || text[i] == 'Ü' || text[i] == 'ğ' || text[i] == 'Ğ' || text[i] == 'ç' || text[i] == 'Ç' || text[i] == 'ö' || text[i] == 'Ö') encryptedText += Convert.ToChar(text[i]);
                    else if (text[i] + 2 >= 127) encryptedText += Convert.ToChar(text[i] + 2 - 95);
                    else
                        encryptedText += Convert.ToChar(text[i] + 2);
                }
                return encryptedText;
            }
            else
            {
                string decrpytedText = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\n' || text[i] == '\r' || text[i] == 'İ' || text[i] == 'ı' || text[i] == ' ' || text[i] == 'ş' || text[i] == 'Ş' || text[i] == 'ü' || text[i] == 'Ü' || text[i] == 'ğ' || text[i] == 'Ğ' || text[i] == 'ç' || text[i] == 'Ç' || text[i] == 'ö' || text[i] == 'Ö') decrpytedText += Convert.ToChar(text[i]);
                    else if (text[i] - 2 <= 33 ) decrpytedText += Convert.ToChar(text[i] -2 + 95);
                    else
                        decrpytedText += Convert.ToChar(text[i] - 2);
                }
                return decrpytedText;
            }
        }
    }

}

