using System;

namespace Cryptology_Lab2_Tritemius_cypher_.Ciphers
{
    public class Vigener
    {
        private string _text;
        private string kirilics = "абвгдеєжзиіїйклмнопрстуфхцчшщьюя";
        private string latin = "abcdefghijklmnopqrstuvwxyz";
        private string exclusions = "_ ;:,.-=+?!"; //TO DO for several words
        private string _keyWord { get; set; }
        public Vigener(string text, string key)
        {
            _text = text;
            _keyWord = key;
        }

        public bool IsKirilics(string text)
        {
            int i = 0;
            foreach (char c in kirilics)
            {                         
                if (text[i] == c)
                {
                    return true;
                }
            }
            return false;
        }

        public string Encrypt()
        {
            string res = "";
            string key = "";
            while (key.Length < _text.Length)
            {
                key += _keyWord;
            }
            if (IsKirilics(_text) == true && IsKirilics(_keyWord) == true)
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < kirilics.Length; j++)
                    {
                        if (exclusions.Contains(_text[i]))
                            continue;
                        if (_text[i] == kirilics[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int p = 0;
                    for (int j = 0; j < kirilics.Length; j++)
                    {                        
                        if (key[i] == kirilics[j])
                        {
                            p = j; // number of letter in alphabet
                            break;
                        }
                    }
                    res += kirilics[(m + p) % kirilics.Length];
                }
            }
            else if (IsKirilics(_text) == false && IsKirilics(_keyWord) == false)
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (exclusions.Contains(_text[i]))
                            continue;
                        if (_text[i] == latin[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int p = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (key[i] == latin[j])
                        {
                            p = j; // number of letter in alphabet
                            break;
                        }
                    }
                    res += latin[(m + p) % latin.Length];
                }
            }
            else
                throw new Exception("Key word and original text must be on the same language");
            return res;
        }
        public string Decrypt()
        {
            string res = "";
            string key = "";
            while (key.Length < _text.Length)
            {
                key += _keyWord;
            }
            if (IsKirilics(_text) == true && IsKirilics(_keyWord) == true)
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < kirilics.Length; j++)
                    {
                        if (exclusions.Contains(_text[i]))
                            continue;
                        if (_text[i] == kirilics[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int p = 0;
                    for (int j = 0; j < kirilics.Length; j++)
                    {
                        if (key[i] == kirilics[j])
                        {
                            p = j; // number of letter in alphabet
                            break;
                        }
                    }
                    res += kirilics[(m - p) % kirilics.Length];
                }
            }
            else if (IsKirilics(_text) == false && IsKirilics(_keyWord) == false)
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (exclusions.Contains(_text[i]))
                            continue;
                        if (_text[i] == latin[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int p = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (key[i] == latin[j])
                        {
                            p = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int check = (m - p);
                    while (check < 0)
                        check += latin.Length;
                    res += latin[check % latin.Length];
                }
            }
            else
                throw new Exception("Key word and original text must be on the same language");
            return res;
        }
    }
}