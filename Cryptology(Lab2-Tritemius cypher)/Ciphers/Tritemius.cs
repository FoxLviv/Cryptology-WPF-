using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Cryptology_Lab2_Tritemius_cypher_.Ciphers
{
    public class Tritemius
    {
        // L=(m+k)modN
        private string _text;
        private string kirilics = "абвгдеєжзиіїйклмнопрстуфхцчшщьюя ";
        private string latin = "abcdefghijklmnopqrstuvwxyz ";
        public int _keyOne { get; private set; }
        public int _keyTwo { get; private set; }
        public int _keyThree { get; private set; }
        private string _keyWord { get; set; }

        public Tritemius(string text, int key)
        {
            _text = text;
            _keyOne = key;
        }

        public Tritemius(string text, int keyOne, int keyTwo)
        {
            _text = text;
            _keyOne = keyOne;
            _keyTwo = keyTwo;
        }

        public Tritemius(string text, int keyOne, int keyTwo, int keyThree)
        {
            _text = text;
            _keyOne = keyOne;
            _keyTwo = keyTwo;
            _keyThree = keyThree;
        }

        public Tritemius(string text, string key)
        {
            _text = text;
            _keyWord = key;
        }        

        public bool IsKirilics(string text)
        {
            foreach(char c in kirilics)
            {
                if(text[0]==c)
                {
                    return true;
                }
            }
            return false;
        }

        #region 2 keys
        //k = Ap+B
        public string TritemiusOneEnctrypt()
        {
            string res = "";
            if (this.IsKirilics(_text)==true)
            {                
                for (int i = 0; i < _text.Length; i++)
                {                    
                    int m = 0;
                    for(int j =0;j<kirilics.Length; j++)
                    {
                        if (_text[i] == kirilics[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }                            
                    }
                    res += kirilics[(m + _keyOne * i + _keyTwo) % kirilics.Length];
                }                
            }
            else
            {
                for (int i = 0; i < _text.Length; i++)
                {                    
                    int m = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (_text[i] == latin[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    res += latin[(m + _keyOne * i + _keyTwo) % latin.Length];
                }
            }
            return res;
        }

        public string TritemiusOneDectrypt()
        {
            string res = "";
            if (this.IsKirilics(_text) == true)
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < kirilics.Length; j++)
                    {
                        if (_text[i] == kirilics[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int check = (m + kirilics.Length-( _keyOne * i + _keyTwo)%kirilics.Length);                    
                    res += kirilics[check % kirilics.Length];
                }
            }
            else
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (_text[i] == latin[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int check = (m + latin.Length - (_keyOne * i + _keyTwo)%latin.Length);                    
                    res += latin[check % latin.Length];
                }
            }
            return res;
        }
        #endregion

        #region 3 keys
        //k = Ap^2+Bp+C
        public string TritemiusTwoEnctrypt()
        {
            string res = "";
            if (this.IsKirilics(_text) == true)
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < kirilics.Length; j++)
                    {
                        if (_text[i] == kirilics[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    res += kirilics[(m + _keyOne * i*i + _keyTwo* i +_keyThree) % kirilics.Length];
                }
            }
            else
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (_text[i] == latin[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    res += latin[(m + _keyOne * i * i + _keyTwo * i + _keyThree) % latin.Length];
                }
            }
            return res;
        }

        public string TritemiusTwoDectrypt()
        {
            string res = "";
            if (this.IsKirilics(_text) == true)
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < kirilics.Length; j++)
                    {
                        if (_text[i] == kirilics[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int check = (m + kirilics.Length - (_keyOne * i * i + _keyTwo * i + _keyThree) % kirilics.Length);
                    res += kirilics[check % kirilics.Length];
                }
            }
            else
            {
                for (int i = 0; i < _text.Length; i++)
                {
                    int m = 0;
                    for (int j = 0; j < latin.Length; j++)
                    {
                        if (_text[i] == latin[j])
                        {
                            m = j; // number of letter in alphabet
                            break;
                        }
                    }
                    int check = (m + latin.Length - (_keyOne * i * i + _keyTwo * i + _keyThree) % latin.Length);
                    res += latin[check % latin.Length];
                }
            }
            return res;
        }
        #endregion

        #region Gausa
        private string AlternativeAlphabet(string word, string res = "")
        {
            
            foreach(char k in word)
            {
                bool IsLetterAlreadyPresent = false;
                foreach(char a in res)
                {
                    if(k == a)
                    {
                        IsLetterAlreadyPresent = true;
                        break;
                    }
                }
                if(IsLetterAlreadyPresent == false)
                {
                    res += k;
                }
            }
            return res;
        }

        public string GausaEncrypt()
        {
            string res = "";
            string alphabet = this.AlternativeAlphabet(_keyWord);// to get only unique elements added
            if (IsKirilics(_text) == true && IsKirilics(alphabet) == true)
            {
                alphabet = this.AlternativeAlphabet(kirilics, alphabet);
                foreach (char letter in _text)
                {
                    for (int i = 0; i < alphabet.Length;i++)
                    {
                        if(letter == kirilics[i])
                        {
                            res += alphabet[i];
                            break;
                        }
                    }
                }
            }                
            else if (IsKirilics(_text) == false && IsKirilics(alphabet) == false)
            {
                alphabet = this.AlternativeAlphabet(latin, alphabet);
                foreach (char letter in _text)
                {
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (letter == latin[i])
                        {
                            res += alphabet[i];
                            break;
                        }
                    }
                }
            }                
            else
                throw new Exception("Key word and original text must be on the same language");
            
            return res;
        }

        public string GausaDecrypt()
        {
            string res = "";
            string alphabet = this.AlternativeAlphabet(_keyWord);// to get only unique elements added
            if (IsKirilics(_text) == true && IsKirilics(alphabet) == true)
            {
                alphabet = this.AlternativeAlphabet(kirilics, alphabet);
                foreach (char letter in _text)
                {
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (letter == alphabet[i])
                        {
                            res += kirilics[i];
                            break;
                        }
                    }
                }
            }
            else if (IsKirilics(_text) == false && IsKirilics(alphabet) == false)
            {
                alphabet = this.AlternativeAlphabet(latin, alphabet);
                foreach (char letter in _text)
                {
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (letter == alphabet[i])
                        {
                            res += latin[i];
                            break;
                        }
                    }
                }
            }
            else
                throw new Exception("Key word and original text must be on the same language");

            return res;
        }
        #endregion
        public void TritemiusHackTwo(string encrypted, out int one, out int two)
        {
            one = 0;
            two = 0;
            int keyone = 0;
            int keytwo = 0;
            string res = "";
            //string test = "";
            if (this.IsKirilics(_text) == true)
            {

                while (res != encrypted)
                {
                    res = "";
                    for (int i = 0; i < encrypted.Length; i++)
                    {
                        int m = 0;
                        for (int j = 0; j < kirilics.Length; j++)
                        {
                            if (_text[i] == kirilics[j])
                            {
                                m = j; // number of letter in alphabet
                                break;
                            }
                        }
                        res += kirilics[(m + keyone * i + keytwo) % kirilics.Length];
                    }
                    keytwo += 1;
                    if (kirilics.Length <= keytwo)
                    {
                        keyone += 1;
                        keytwo = 0;
                        
                    }
                    if(res == encrypted)
                    {
                        one = keyone;
                        two = keytwo- 1;
                        break;
                    }
                    _keyOne = keyone;
                    _keyTwo = keytwo;
                }   
            }
            //else
            //{
            //    for (int i = 0; i < _text.Length; i++)
            //    {
            //        int m = 0;
            //        for (int j = 0; j < latin.Length; j++)
            //        {
            //            if (_text[i] == latin[j])
            //            {
            //                m = j; // number of letter in alphabet
            //                break;
            //            }
            //        }
            //        res += latin[(m + _keyOne * i + _keyTwo) % latin.Length];
            //    }
            //}                      
        }

        

        //public string CaesarEncrypt()
        //{
        //    string res = "";
        //    char tmp;
        //    for (int i = 0; i < _text.Length; i++)
        //    {
        //        tmp = _text[i];
        //        for (int j = 0; j < _keyOne; j++)
        //            tmp++;
        //        res += tmp;
        //    }
        //    return res;
        //}

        //public string CaesarDecrypt()
        //{
        //    string res = "";
        //    char tmp;
        //    for (int i = 0; i < _text.Length; i++)
        //    {
        //        tmp = _text[i];
        //        for (int j = 0; j < _keyOne; j++)
        //            tmp--;
        //        res += tmp;
        //    }
        //    return res;
        //}

        //public string Brute(string keyWorld)
        //{
        //    string res = "";
        //    for (int i = 0; i < keyWorld.Length; i++)
        //    {
        //        res += _text[i];
        //    }
        //    int counter = 0;
        //    do
        //    {
        //        string temp = "";
        //        char tmp;
        //        for (int i = 0; i < res.Length; i++)
        //        {
        //            tmp = res[i];
        //            temp += --tmp;
        //        }
        //        res = temp;
        //        counter++;
        //    }
        //    while (res != keyWorld);
        //    _key = counter;
        //    res = CaesarDecrypt();
        //    return res;
        //}
    }
}
