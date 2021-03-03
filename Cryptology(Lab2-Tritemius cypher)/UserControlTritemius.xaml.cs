using System;
using System.Windows;
using System.Windows.Controls;
using Cryptology_Lab2_Tritemius_cypher_.Ciphers;

namespace Cryptology_Lab2_Tritemius_cypher_
{
    /// <summary>
    /// Interaction logic for UserControlTritemius.xaml
    /// </summary>
    public partial class UserControlTritemius : UserControl
    {

        Tritemius tritemius;
        public UserControlTritemius()
        {
            InitializeComponent();
        }
        string text = "";
        private void Encrypt_One_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    tritemius = new Tritemius(text, Convert.ToInt32(FirstNumberBox_One.Text), Convert.ToInt32(SecondNumberBox_One.Text));
                    (window as MainWindow).TextBoxOriginal.Text = tritemius.TritemiusOneEnctrypt();
                }
            }
            //TextBoxOriginal.Text
        }

        private void Decrypt_One_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    tritemius = new Tritemius(text, Convert.ToInt32(FirstNumberBox_One.Text), Convert.ToInt32(SecondNumberBox_One.Text));
                    (window as MainWindow).TextBoxOriginal.Text = tritemius.TritemiusOneDectrypt();
                }
            }
        }

        private void Encrypt_Two_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    tritemius = new Tritemius(text, Convert.ToInt32(FirstNumberBox_Two.Text), Convert.ToInt32(SecondNumberBox_Two.Text), Convert.ToInt32(ThirdNumberBox_Two.Text));
                    (window as MainWindow).TextBoxOriginal.Text = tritemius.TritemiusTwoEnctrypt();
                }
            }
        }

        private void Decrypt_Two_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    tritemius = new Tritemius(text, Convert.ToInt32(FirstNumberBox_Two.Text), Convert.ToInt32(SecondNumberBox_Two.Text), Convert.ToInt32(ThirdNumberBox_Two.Text));
                    (window as MainWindow).TextBoxOriginal.Text = tritemius.TritemiusTwoDectrypt();
                }
            }
        }

        private void Encrypt_Three_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    tritemius = new Tritemius(text, KeyWord.Text);
                    (window as MainWindow).TextBoxOriginal.Text = tritemius.GausaEncrypt();
                }
            }
        }

        private void Decrypt_Three_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    tritemius = new Tritemius(text, KeyWord.Text);
                    (window as MainWindow).TextBoxOriginal.Text = tritemius.GausaDecrypt();
                }
            }
        }

        private void Hack_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    tritemius = new Tritemius(text, KeyWord.Text);
                    int first = 0;
                    int second = 0;
                    tritemius.TritemiusHackTwo(Encrypted.Text,out first, out second);
                    FirstNumberBox_One.Text = first.ToString();
                    SecondNumberBox_One.Text = second.ToString();
                }
            }

        }

        private void Hack2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
