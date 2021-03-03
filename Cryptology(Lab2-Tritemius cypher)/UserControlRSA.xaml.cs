using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace Cryptology_Lab2_Tritemius_cypher_
{
    /// <summary>
    /// Interaction logic for UserControlRSA.xaml
    /// </summary>
    public partial class UserControlRSA : UserControl
    {
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;


        static CspParameters cspParameters = new CspParameters() { 
        KeyContainerName = "Hyulo"};       
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);
        //"Key added to container: {rsa.ToXmlString(true)}"; 


        public UserControlRSA()
        {
            InitializeComponent();
        }

        private void Encrypt_RSA_Click(object sender, RoutedEventArgs e)
        {            
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    plaintext = ByteConverter.GetBytes((window as MainWindow).TextBoxOriginal.Text);
                    PrivateKey.Text = RSA.ToXmlString(true).ToString();
                    int lenght = PrivateKey.Text.Length;
                    //rsa.ImportRSAPrivateKey(Convert.FromBase64String(PrivateKey.Text), out lenght);
                    //rsa.ImportRSAPublicKey(Convert.FromBase64String(Publickey.Text), out lenght);
                    encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
                    CspParameters cspParameters = new CspParameters()
                    {
                        KeyContainerName = "Helo"
                    };
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);
                    string publicKey = rsa.ToXmlString(false);
                    Publickey.Text = publicKey;
                    
                    EncryptedText.Text = ByteConverter.GetString(encryptedtext);
                }
            }
        }

        private void Decrypt_RSA_Click(object sender, RoutedEventArgs e)
        {
            byte[] decryptedtex = Decryption(encryptedtext,RSA.ExportParameters(true), false);
            DecryptedText.Text = ByteConverter.GetString(decryptedtex);
        }
    }
}
