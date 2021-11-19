using BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utility
{
    public class Cryptography
    {
        public static string Encryption(string encryptString)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Constants.EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public static string Decryption(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Constants.EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        //public static string Encryption(string encryptString)
        //{
        //    string strmsg = string.Empty;
        //    byte[] encode = new byte[encryptString.Length];
        //    encode = Encoding.UTF8.GetBytes(encryptString);
        //    strmsg = Convert.ToBase64String(encode);
        //    return strmsg;
        //}

        //public static string Decryption(string cipherText)
        //{
        //    string decryptpwd = string.Empty;
        //    UTF8Encoding encodepwd = new UTF8Encoding();
        //    Decoder Decode = encodepwd.GetDecoder();
        //    byte[] todecode_byte = Convert.FromBase64String(cipherText);
        //    int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        //    char[] decoded_char = new char[charCount];
        //    Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        //    decryptpwd = new String(decoded_char);
        //    return decryptpwd;
        //}
        //public static string Encryption(string encryptString)
        //{
        //    try
        //    {
        //        string textToEncrypt = encryptString;
        //        string ToReturn = "";
        //        string publickey = "santhosh";
        //        string secretkey = "engineer";
        //        byte[] secretkeyByte = { };
        //        secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
        //        byte[] publickeybyte = { };
        //        publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
        //        MemoryStream ms = null;
        //        CryptoStream cs = null;
        //        byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
        //        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        //        {
        //            ms = new MemoryStream();
        //            cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
        //            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
        //            cs.FlushFinalBlock();
        //            ToReturn = Convert.ToBase64String(ms.ToArray());
        //        }
        //        return ToReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //}

        //public static string Decryption(string cipherText)
        //{
        //    try
        //    {
        //        string textToDecrypt = cipherText;
        //        string ToReturn = "";
        //        string publickey = "santhosh";
        //        string privatekey = "engineer";
        //        byte[] privatekeyByte = { };
        //        privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);
        //        byte[] publickeybyte = { };
        //        publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
        //        MemoryStream ms = null;
        //        CryptoStream cs = null;
        //        byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
        //        inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
        //        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        //        {
        //            ms = new MemoryStream();
        //            cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
        //            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
        //            cs.FlushFinalBlock();
        //            Encoding encoding = Encoding.UTF8;
        //            ToReturn = encoding.GetString(ms.ToArray());
        //        }
        //        return ToReturn;
        //    }
        //    catch (Exception ae)
        //    {
        //        throw new Exception(ae.Message, ae.InnerException);
        //    }
        //}
    }
}
