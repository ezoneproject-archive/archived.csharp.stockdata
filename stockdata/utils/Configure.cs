using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace stockdata.utils
{
    public class Configure
    {
        /// <summary>
        /// 메인폼 윈도우 위치(X)
        /// </summary>
        public static int windowX
        {
            get
            {
                return checkIntValue(ConfigureImpl.get("windowX"));
            }
            set
            {
                ConfigureImpl.set("windowX", ""+value);
            }
        }

        /// <summary>
        /// 메인폼 윈도우 위치(Y)
        /// </summary>
        public static int windowY
        {
            get
            {
                return checkIntValue(ConfigureImpl.get("windowY"));
            }
            set
            {
                ConfigureImpl.set("windowY", "" + value);
            }
        }

        /// <summary>
        /// 메인폼 윈도우 크기(Width)
        /// </summary>
        public static int windowW
        {
            get
            {
                return checkIntValue(ConfigureImpl.get("windowW"));
            }
            set
            {
                ConfigureImpl.set("windowW", "" + value);
            }
        }

        /// <summary>
        /// 메인폼 윈도우 크기(Height)
        /// </summary>
        public static int windowH
        {
            get
            {
                return checkIntValue(ConfigureImpl.get("windowH"));
            }
            set
            {
                ConfigureImpl.set("windowH", "" + value);
            }
        }

        /// <summary>
        /// 접속 서버 정보
        /// </summary>
        public static string server
        {
            get
            {
                return ConfigureImpl.get("server");
            }
            set
            {
                ConfigureImpl.set("server", value);
            }
        }

        /// <summary>
        /// http 프로토콜에서 암호화여부, 1 or 0
        /// </summary>
        public static bool httpEncrypt
        {
            get
            {
                string val = ConfigureImpl.get("httpEncrypt");
                if (val == null || val.Length == 0)
                    return false;
                return (val.Equals("1") ? true : false);
            }
            set
            {
                string val = (value ? "1" : "0");
                ConfigureImpl.set("httpEncrypt", val);
            }
        }

        /// <summary>
        /// API 버전
        /// </summary>
        public static string apiVersion
        {
            get
            {
                return ConfigureImpl.get("apiVersion");
            }
            set
            {
                ConfigureImpl.set("apiVersion", value);
            }
        }

        /// <summary>
        /// API 키(ID)
        /// </summary>
        public static string apiKey
        {
            get
            {
                return ConfigureImpl.get("apiKey");
            }
            set
            {
                ConfigureImpl.set("apiKey", value);
            }
        }

        /// <summary>
        /// API 인증정보(Password)
        /// </summary>
        public static string apiSecret
        {
            get
            {
                string encodedSecret = ConfigureImpl.get("apiSecret");
                if (encodedSecret == null || encodedSecret.Length == 0)
                    return "";

                string key = apiKey;
                if (key == null || key.Length == 0)
                    return "";
                while (key.Length < 32)
                    key += key;
                if (key.Length > 32)
                    key = key.Substring(0, 32);

                RijndaelManaged rijndael = new RijndaelManaged();
                string iv = "                ";

                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.KeySize = 256;
                rijndael.BlockSize = 128;
                rijndael.Key = Encoding.UTF8.GetBytes(key);
                rijndael.IV = Encoding.UTF8.GetBytes(iv);

                byte[] encrypted = Convert.FromBase64String(encodedSecret);

                byte[] plain = rijndael.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
                string secret = Encoding.UTF8.GetString(plain);

                //Console.WriteLine("key = [" + key + "]");
                //Console.WriteLine("dec = [" + secret + "]");

                return secret;
            }
            set
            {
                string key = apiKey;
                if (key == null || key.Length == 0)
                    return;
                while (key.Length < 32)
                    key+= key;
                if (key.Length > 32)
                    key = key.Substring(0, 32);

                RijndaelManaged rijndael = new RijndaelManaged();
                string iv = "                ";

                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.KeySize = 256;
                rijndael.BlockSize = 128;
                rijndael.Key = Encoding.UTF8.GetBytes(key);
                rijndael.IV = Encoding.UTF8.GetBytes(iv);

                byte[] text = Encoding.UTF8.GetBytes(value);

                byte[] cipherBytes = rijndael.CreateEncryptor().TransformFinalBlock(text, 0, text.Length);
                string encrypted = Convert.ToBase64String(cipherBytes);

                //Console.WriteLine("key = [" + key + "]");
                //Console.WriteLine("enc = [" + encrypted + "]");

                ConfigureImpl.set("apiSecret", encrypted);
            }
        }

        /// <summary>
        /// string -> int 컨버전
        /// </summary>
        /// <param name="val">string value</param>
        /// <returns>int value, error = -1</returns>
        private static int checkIntValue(string val)
        {
            if (val == null || val.Length == 0)
                return -1;
            try
            {
                return int.Parse(val);
            }
            catch
            {
                return -1;
            }
        }
    }
}

