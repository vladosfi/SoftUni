using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.ActivationKeys
{
    class ActivationKeys
    {
        static void Main()
        {
            string[] line = Console.ReadLine().Split("&");
            List<string> keys = new List<string>();

            for (int i = 0; i < line.Length; i++)
            {
                string key = line[i];

                if (KeyIsValid(key))
                {
                    key = PutDashaes(key);
                    key = key.ToUpper();
                    key = ReplaceEveryDigit(key);
                    keys.Add(key);
                }
            }

            Console.WriteLine(string.Join(", ",keys));
        }

        private static string ReplaceEveryDigit(string key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < key.Length; i++)
            {
                if (char.IsDigit(key[i]))
                {
                    result.Append(9 - (key[i] - '0'));
                }
                else
                {
                    result.Append(key[i]);
                }
                
            }

            return result.ToString();
        }

        public static string PutDashaes(string key)
        {
            int index = 0;

            if (key.Length == 16)
            {
                for (int i = 1; i < 4; i++)
                {
                    index = (i * 4) + i - 1;
                    key = key.Insert(index, "-");
                }
            }
            else
            {
                for (int i = 1; i < 5; i++)
                {
                    index = (i * 5)+i-1;
                    key = key.Insert(index, "-");
                }
            }

            return key;
        }

        public static bool KeyIsValid(string key)
        {

            Regex regex = new Regex(@"[^A-Za-z\d]+");

            if (!(key.Length == 16 || key.Length == 25)
                || regex.IsMatch(key))
            {
                return false;
            }

            return true;
        }
    }
}

