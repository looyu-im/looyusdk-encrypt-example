using System;
using System.Security.Cryptography;
using System.Text;

namespace LooyuSdk
{
    public class EncryptHelper
    {
        private static String HEX = "0123456789ABCDEF";

        private static byte[] generateKey(String key)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes(key));

        }
        private static byte[] encodeDecode(bool encrypt, byte[] bytes, String key)
        {
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.IV = Encoding.UTF8.GetBytes(HEX);
            aes.Key = generateKey(key);
            ICryptoTransform transform = encrypt ? aes.CreateEncryptor() : aes.CreateDecryptor();
            return transform.TransformFinalBlock(bytes, 0, bytes.Length);
        }
        public static String encode(String blank, String key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(blank);
            byte[] encrypted = encodeDecode(true, bytes, key);
            return Convert.ToBase64String(encrypted);
        }
        public static String decode(String encrypted, String key)
        {
            byte[] bytes = Convert.FromBase64String(encrypted);
            byte[] decrypted = encodeDecode(false, bytes, key);
            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
