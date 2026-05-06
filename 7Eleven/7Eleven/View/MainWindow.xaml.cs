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

namespace _7Eleven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OverviewViewPage_Click(object sender, RoutedEventArgs e)
        {
          
            MainContent.Content = new OverviewView();

        }

        private void RegisterProductView_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RegisterProduct();
        }

        private void DeprecationView_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DeprecationView();
        }
       

    }
}