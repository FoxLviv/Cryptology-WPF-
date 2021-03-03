using System.Windows;
using System.Windows.Controls;
using Cryptology_Lab2_Tritemius_cypher_.Ciphers;

namespace Cryptology_Lab2_Tritemius_cypher_
{
    /// <summary>
    /// Interaction logic for UserControlGamma.xaml
    /// </summary>
    public partial class UserControlGamma : UserControl
    {
        Gamma gamma;
        string text = "";
        public UserControlGamma()
        {
            InitializeComponent();
        }

        private void Encrypt_Gamma_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    gamma = new Gamma(text, KeyWord.Text);
                    (window as MainWindow).TextBoxOriginal.Text = gamma.Encrypt();
                }
            }
        }

        private void Decrypt_Gamma_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    text = (window as MainWindow).TextBoxOriginal.Text;
                    gamma = new Gamma(text, KeyWord.Text);
                    (window as MainWindow).TextBoxOriginal.Text = gamma.Decrypt();
                }
            }
        }
    }
}
