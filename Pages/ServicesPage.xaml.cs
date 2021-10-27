using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Vet.Views;
using Vet.DataBase;
using System.Linq;
namespace Vet.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public Entities Entities = new Entities();
        public ServicesPage()
        {
            InitializeComponent();
            ServicesGrid.ItemsSource = Entities.Service.ToList();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class ServicesTable
        {
            public ServicesTable(int IDService, string ServiceName, float Price, int Length)
            {
                this.IDService = IDService;
                this.ServiceName = ServiceName;
                this.Price = Price;
                this.Length = Length;
            }
            public int IDService { get; set; }
            public string ServiceName { get; set; }
            public float Price { get; set; }
            public int Length { get; set; }

        }
    }
}
