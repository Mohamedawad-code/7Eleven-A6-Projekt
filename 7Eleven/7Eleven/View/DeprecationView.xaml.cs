using System.Windows;
using System.Windows.Controls;
using _7Eleven.ViewModel;

namespace _7Eleven
{
    public partial class DeprecationView : UserControl
    {
        private DepreciationViewModel _viewModel;

        public DeprecationView()
        {
            InitializeComponent();
            _viewModel = new DepreciationViewModel();
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

        private void OverviewView_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = new OverviewView();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PName.SelectedItem = null;
            PQuantity.Text = string.Empty;
        }

        private void DeprecateProduct_Click(object sender, RoutedEventArgs e)
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
