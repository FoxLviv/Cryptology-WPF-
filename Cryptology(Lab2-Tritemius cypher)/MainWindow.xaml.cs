using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptology_Lab2_Tritemius_cypher_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Path = "";        

        public MainWindow()
        {
            InitializeComponent();
        }        

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }        

        private void ButtonPopUpCreate_Click(object sender, RoutedEventArgs e)
        {


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                Path = saveFileDialog.FileName;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(TextBoxOriginal.Text);
                }                
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message);
            }
        }

        private void ButtonPopUpOpen_Click(object sender, RoutedEventArgs e)
        {            
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //    //textByte = File.ReadAllBytes(openFileDialog.FileName);
            //TextBoxOriginal.Text = (openFileDialog.FileName.EndsWith(".txt") || openFileDialog.FileName.EndsWith(".docx")) ? File.ReadAllText(openFileDialog.FileName) : Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName));            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Path = openFileDialog.FileName;                
            }

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    TextBoxOriginal.Text = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonPopUpSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    sw.Write(TextBoxOriginal.Text);
                }                
            }
            catch (Exception exept)
            {
                Console.WriteLine(exept.Message);
            }
        }

        private void ButtonPopUpPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(TextBoxOriginal, "Print");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void ButtonPopUpHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Виконав: Андрій Бурцьо\nГрупа: ПМІ-31");
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch(index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlTritemius());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    break;
                default:
                    break;
            }
        }
    }
}
