using Cryptology_Lab2_Tritemius_cypher_.Ciphers;
using System.Windows;
using System.Windows.Controls;

namespace Cryptology_Lab2_Tritemius_cypher_
{
    /// <summary>
    /// Interaction logic for UserControlVigener.xaml
    /// </summary>
    public partial class UserControlVigener : UserControl
    {
        Vigener vigener;
        string text = "";
        public UserControlVigener()
        {
            InitializeComponent();
        }

        private void Encrypt_Vigener_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    vigener = new Vigener(text, KeyWord.Text);
                    (window as MainWindow).TextBoxOriginal.Text = vigener.Encrypt();
                }
            }
        }
        private void Decrypt_Vigener_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    vigener = new Vigener(text, KeyWord.Text);
                    (window as MainWindow).TextBoxOriginal.Text = vigener.Decrypt();
                }
            }
        }
    }
}
