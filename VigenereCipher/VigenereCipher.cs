using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    static class Cipher
    {
        public static String Vigenere(String key, String plain)
        {
            if (key.Length == 0)
                return String.Empty;

            StringBuilder sb = new StringBuilder();
            int[] intkey = new int[key.Length];
            for (int i = 0; i != key.Length; i++)
            {
                intkey[i] = (Char.IsUpper(key[i]) ? key[i] - 'A' : key[i] - 'a');
            }

            for (int i = 0; i != plain.Length; i++)
            {
                char t = plain[i];
                if (Char.IsLetter(t))
                {
                    char b = Char.IsLower(t) ? 'a' : 'A';
                    t = (char)((t - b + intkey[i % intkey.Length]) % 26 + b);
                }
                sb.Append(t);
            }

            return sb.ToString();
        }
    }
}
