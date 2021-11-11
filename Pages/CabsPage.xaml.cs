using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Vet.DataBase;

namespace Vet.Pages
{
    /// <summary>
    /// Логика взаимодействия для CabsPage.xaml
    /// </summary>
    public partial class CabsPage : Page
    {
        public Entities Entities = new Entities();
        public Cab cab = new Cab();
        public CabsPage()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        private void btnCab1_Click(object sender, RoutedEventArgs e)
        {
            cab = Entities.Cab.Where(i => i.IDCab = 1);
            switch ()
            {
                case true: btnCab1.Foreground = Brushes.DarkRed; cab.IsUsedAtm = false; break;
                case false: btnCab1.Foreground = Brushes.Purple; cab.IsUsedAtm = true; break;
            }
               
        }

        private void btnCab2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCab3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCab4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCab5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
