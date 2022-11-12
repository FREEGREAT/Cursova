using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{

    public partial class Select_Table : Page
    {
        public Select_Table()
        {
            InitializeComponent();
        }

        private void Software_table_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Table1());  
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client());
        }

        private void Realization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Realization());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
