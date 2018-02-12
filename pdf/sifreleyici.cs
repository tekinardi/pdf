using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace pdf
{
    public static class sifreleyici
    {

        // herhangi birşey olabilir
        private const string passPhrase = "ABCDEFGabcdefg";

        // herhangi birşey olabilir
        private const string saltValue = "klmnuyKLMNUY";

        // SHA1 ya da MD5
        private const string hashAlgorithm = "SHA1";

        // herhangi bir sayı olabilir
        private const int passwordIterations = 2;

        // 16 byte olmalı
        private const string initVector = "@1B2c3Dq@5F6x7H8";

        // kaç bit şifreleme?
        private const int keySize = 256;


        public static string Sifrele(this string plainText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password =
                new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

            byte[] keyBytes = password.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();

            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor =
                symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream =
                new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }

        public static string SifreCoz(this string cipherText)
        {

            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password =
                    new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor =
                    symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream =
                    new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount =
                    cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                string plainText =
                    Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                return plainText;
            }
            catch (Exception)
            {

                return "";
            }
           
        }

        public static string sifreleme(this string plainText)
        {
       
           
                return plainText.Sifrele();
        }

        public static string SifreCozme(this string cipherText)
        {
                           return cipherText.SifreCoz();
        }


    }
}
