using System;
using System.Collections.Generic;
using System.Text;

namespace Archivizor_Project.Classes
{
    class Password
    {
        private readonly Random rng = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        public string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = chars[rng.Next(chars.Length)];
            }
            return new string(buffer);
        }
    }
}
