using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;

namespace _7Eleven
{
    /// <summary>
    /// Interaction logic for RegisterProduct.xaml
    /// </summary>
    public partial class RegisterProduct : UserControl
    {
        public RegisterProduct()
        {
            InitializeComponent();
        }

        //Back button to navigate back to the main menu
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;


            main.MainContent.Content = null;
        }

        //Deprecation button to navigate to the deprecation page
        private void DeprecationView_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            main.MainContent.Content = new DeprecationView();
        }

        //Overview button to navigate to the overview page
        private void OverviewView_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            main.MainContent.Content = new OverviewView();
        }

        //Home button to navigate back to the main menu
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            main.MainContent.Content = null;
        }

        //Clear button to clear all the textboxes and datepicker
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PName.Text = string.Empty;
            PCategory.Text = string.Empty;
            PQuantity.Text = string.Empty;
            PExpirationDate.Text = null;
        }

        private void SaveNewProduct_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(PQuantity.Text, out int quantity))
            {
                MessageBox.Show(
                    "Error: Please enter a valid quantity.",
                    "Invalid Input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);


                return;
            }

        }

    }
}
