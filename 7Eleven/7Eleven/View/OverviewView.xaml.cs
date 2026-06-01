using System.Windows;
using System.Windows.Controls;
using _7Eleven.ViewModel;

namespace _7Eleven
{
    public partial class OverviewView : UserControl
    {
        private ProductViewModel _viewModel;

        public OverviewView()
        {
            InitializeComponent();
            _viewModel = new ProductViewModel();
            DataContext = _viewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = null;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = null;
        }

        private void RegisterProductView_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = new RegisterProduct();
        }

        private void DeprecationView_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = new DeprecationView();
        }

        private void OverviewView_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = new OverviewView();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
