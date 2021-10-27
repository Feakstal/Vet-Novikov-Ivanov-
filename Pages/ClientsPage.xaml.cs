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
using Vet.DataBase;

namespace Vet.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public static Entities Entities = new Entities();
        public ClientsPage()
        {
            InitializeComponent();
            ClientsGrid.ItemsSource = Entities.Client.ToList();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class ClientsTable
        {
            public ClientsTable(int IDClient, string Surname, string Name, string FatherName, string Phone, string PassSerial, string PassNumber, int IDPatient)
            {
                this.IDClient = IDClient;
                this.Surname = Surname;
                this.Name = Name;
                this.FatherName = FatherName;
                this.Phone = Phone;
                this.PassSerial = PassSerial;
                this.PassNumber = PassNumber;
                this.IDPatient = IDPatient;
            }
            public int IDClient { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string Phone { get; set; }
            public string PassSerial { get; set; }
            public string PassNumber { get; set; }
            public int IDPatient { get; set; }
        }
    }
}
