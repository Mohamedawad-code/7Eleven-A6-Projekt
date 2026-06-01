using System;
using System.Windows;
using System.Windows.Controls;
using _7Eleven.ViewModel;

namespace _7Eleven
{
    public partial class RegisterProduct : UserControl
    {
        private ProductViewModel _viewModel;

        public RegisterProduct()
        {
            InitializeComponent();
            _viewModel = new ProductViewModel();
            
            // Set dates BEFORE setting DataContext
            _viewModel.NewTimeReceived = DateTime.Now;
            _viewModel.NewExpiringDate = DateTime.Now;
            
            DataContext = _viewModel;

            PExpirationDate.DisplayDateStart = DateTime.Now.AddYears(-5);
            PExpirationDate.DisplayDateEnd = DateTime.Now.AddYears(5);
            PExpirationDate.SelectedDate = DateTime.Now;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = null;
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

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
                main.MainContent.Content = null;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PName.Text = string.Empty;
            PQuantity.Text = string.Empty;
            PExpirationDate.Text = null;
        }
    }
}
