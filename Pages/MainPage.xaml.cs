using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Vet.Pages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoServices_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new ServicesPage());
        }

        private void GoCabs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new CabsPage());
        }

        private void GoMedcards_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MedcardsPage());
        }

        private void GoEmployees_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new EmployeesPage());
        }

        private void GoClients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new ClientsPage());
        }

        private void btnCheques_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new ChequesPage());
        }
    }
}