using System;
using System.Security.Cryptography;

namespace stockdata.utils
{
    class AESUtil
    {
        public const int AES_BITS_128 = 128;
        public const int AES_BITS_256 = 256;

        public static byte[] Key;
        public static byte[] IV;

        public static byte[] createRandomKeys(int bits)
        {
            byte[] buf = new byte[bits / 8];
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            rand.NextBytes(buf);

            return buf;
        }

        public static byte[] createDefaultIV()
        {
            byte[] buf = new byte[16];
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)' ';
            }

            return buf;
        }

        public static byte[] Encrypt(byte[] plainBytes)
        {
            if (Key == null || Key.Length <= 0)
                Key = createRandomKeys(AES_BITS_256);
            if (IV == null || IV.Length <= 0)
                IV = createDefaultIV();

            byte[] encrypted = null;
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.KeySize = Key.Length * 8;
                rijndael.BlockSize = IV.Length * 8;

                rijndael.Key = Key;
                rijndael.IV = IV;

                ICryptoTransform encryptor = rijndael.CreateEncryptor();
                encrypted = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }

            return encrypted;
        }

        public static byte[] Decrypt(byte[] encrypted)
        {
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key is null");
            if (IV == null || IV.Length <= 0)
                IV = createDefaultIV();

            byte[] plain = null;
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.KeySize = Key.Length * 8;
                rijndael.BlockSize = IV.Length * 8;

                rijndael.Key = Key;
                rijndael.IV = IV;

                ICryptoTransform encryptor = rijndael.CreateDecryptor();
                plain = encryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
            }

            return plain;
        }
    }
}
