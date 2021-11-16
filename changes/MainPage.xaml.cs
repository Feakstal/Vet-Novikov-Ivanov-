using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Vet.DataBase;
using Vet.Views;

namespace Vet.Pages
{
    public partial class MainPage : Page
    {
        public Entities Entities = new Entities();
        public Role role;
        public MainPage()
        {
            InitializeComponent();
            role = Entities.Role.Find(AuthWindow.authUser.Role.IDRole);
            if (role.RoleName.Equals("Врач"))
            {
                btnShowCheques.IsEnabled = false;
                btnShowEmployees.IsEnabled = false;
                btnShowCabs.IsEnabled = false;
            }
            //else if (role.RoleName.Equals("Администратор"))
            //{

            //}
            //else if (role.RoleName.Equals("Менеджер"))
            //{

            //}
        }

        private void btnShowServices_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicesPage());
        }

        private void btnShowCabs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CabsPage());
        }

        private void btnShowMedcards_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MedcardsPage());
        }

        private void btnShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesPage());
        }

        private void btnShowClients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientsPage());
        }

        private void btnShowCheques_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChequesPage());
        }

        private void btnShowPatients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientsPage());
        }

        private void btnShowApps_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AppointmentsPage());
        }
    }
}