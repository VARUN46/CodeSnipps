using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security;

namespace DataCrypto
{
    public class PiiCryptography
    {
        private static readonly string EncryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";
        public PiiCryptography()
        {

        }


        public static string EncryptData(string plainText)
        {
            string encryptedResult;
            try
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Standards.encoding.GetBytes(EncryptionKey.ToString());
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using MemoryStream memoryStream = new MemoryStream();
                    using CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }

                encryptedResult = Convert.ToBase64String(array);
            }
            catch (Exception ex)
            {

                throw;
            }
            return encryptedResult;
        }

        public static string DecryptData(string encryptedData)
        {
            string result = string.Empty;
            try
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(encryptedData);

                using Aes aes = Aes.Create();
                aes.Key = Standards.encoding.GetBytes(EncryptionKey.ToString());
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using MemoryStream memoryStream = new MemoryStream(buffer);
                using CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
                using StreamReader streamReader = new StreamReader((Stream)cryptoStream);
                result = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }


        public static string GetMaskedEntry(string val)
        {

            string name;
            try
            {
                name = (val.Length > 3) ? val.Substring(0, 3) + "***" : val.Substring(0, 1) + "***";
            }
            catch (Exception)
            {

                throw;
            }

            return name;
        }

    }
}
