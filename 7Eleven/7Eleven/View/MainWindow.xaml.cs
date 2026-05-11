using System.Windows;

namespace _7Eleven
{
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