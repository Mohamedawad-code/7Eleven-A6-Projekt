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

namespace _7Eleven
{
    /// <summary>
    /// Interaction logic for DeprecationView.xaml
    /// </summary>
    public partial class DeprecationView : UserControl
    {
        public DeprecationView()
        {
            InitializeComponent();
        }

        //Back button to navigate back to the main menu
        private void Back_Click(object sender, RoutedEventArgs e)
            {
                var main = Application.Current.MainWindow as MainWindow;
                main.MainContent.Content = null;
            }

        //Home button to navigate back to the main menu
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            main.MainContent.Content = null;
        }

        //Register product button to navigate to the register product page
        private void RegisterProductView_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.MainWindow as MainWindow;
            main.MainContent.Content = new RegisterProduct();
        }

        //Overview button to navigate to the overview page
        private void OverviewView_Click(object sender, RoutedEventArgs e)

        {
            var main = Application.Current.MainWindow as MainWindow;
            main.MainContent.Content = new OverviewView();

        }



    }
}
