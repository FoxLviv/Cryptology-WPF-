namespace Cryptology_Lab2_Tritemius_cypher_.Ciphers
{
    public class Gamma
    {
        string text { get; set; }
        string secretKey { get; set; }
        public Gamma(string t, string key)
        {
            text = t;
            secretKey = key;
        }        
        
        private string Cipher()
        {
            char[] output = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                output[i] = (char)(text[i] ^ secretKey[i % secretKey.Length]);
            }

            return new string(output);
        }
        
        public string Encrypt()
            => Cipher();
        
        public string Decrypt()
            => Cipher();
    }
}
