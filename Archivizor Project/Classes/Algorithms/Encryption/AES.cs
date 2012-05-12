/*
* Copyright (C) 2011, Dextrey (0xDEADDEAD)
* Removing this copyright notice is prohibited without permission from author
* Using this code in your own software product, commercial or not is allowed
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Archivizor_Project.Classes.Algorithms.Encryption
{
    class PolyAES
    {
        //Copyright (C) 2011, Dextrey (0xDEADDEAD)
        public static byte[] PolyAESEncrypt(byte[] plainText, string Key)
        {
            byte[] salt;
            SymmetricAlgorithm algo = new RijndaelManaged();
            RNGCryptoServiceProvider rngAlgo = new RNGCryptoServiceProvider();
            algo.Mode = CipherMode.CBC;
            byte[] key = System.Text.Encoding.ASCII.GetBytes(Key);

            algo.GenerateIV();
            salt = new byte[32];
            rngAlgo.GetBytes(salt);
            Rfc2898DeriveBytes pwDeriveAlg = new Rfc2898DeriveBytes(key, salt, 2000);
            algo.Key = pwDeriveAlg.GetBytes(32);

            ICryptoTransform encTransform = algo.CreateEncryptor();

            byte[] enced = encTransform.TransformFinalBlock(plainText, 0, plainText.Length);

            int origLength = enced.Length;
            Array.Resize(ref enced, enced.Length + salt.Length);
            Buffer.BlockCopy(salt, 0, enced, origLength, salt.Length);

            origLength = enced.Length;
            Array.Resize(ref enced, enced.Length + algo.IV.Length);
            Buffer.BlockCopy(algo.IV, 0, enced, origLength, algo.IV.Length);

            return enced;
        }
        public static byte[] PolyAESDecrypt(byte[] cipherText, string Key)
        {
            byte[] salt;
            SymmetricAlgorithm algo = new RijndaelManaged();
            algo.Mode = CipherMode.CBC;
            RNGCryptoServiceProvider rngAlgo = new RNGCryptoServiceProvider();
            byte[] key = System.Text.Encoding.ASCII.GetBytes(Key);
            byte[] cipherTextWithSalt = new byte[1];
            byte[] encSalt = new byte[1];
            byte[] origCipherText = new byte[1];
            byte[] encIv = new byte[1];

            Array.Resize(ref encIv, 16);
            Buffer.BlockCopy(cipherText, (int)(cipherText.Length - 16), encIv, 0, 16);
            Array.Resize(ref cipherTextWithSalt, (int)(cipherText.Length - 16));
            Buffer.BlockCopy(cipherText, 0, cipherTextWithSalt, 0, (int)(cipherText.Length - 16));

            Array.Resize(ref encSalt, 32);
            Buffer.BlockCopy(cipherTextWithSalt, (int)(cipherTextWithSalt.Length - 32), encSalt, 0, 32);
            Array.Resize(ref origCipherText, (int)(cipherTextWithSalt.Length - 32));
            Buffer.BlockCopy(cipherTextWithSalt, 0, origCipherText, 0, (int)(cipherTextWithSalt.Length - 32));

            algo.IV = encIv;
            salt = encSalt;
            Rfc2898DeriveBytes pwDeriveAlg = new Rfc2898DeriveBytes(key, salt, 2000);
            algo.Key = pwDeriveAlg.GetBytes(32);

            ICryptoTransform decTransform = algo.CreateDecryptor();
            byte[] plainText = decTransform.TransformFinalBlock(origCipherText, 0, origCipherText.Length);
            return plainText;
        }
    }
}