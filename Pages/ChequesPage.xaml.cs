using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Vet.DataBase;

namespace Vet.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChequesPage.xaml
    /// </summary>
    public partial class ChequesPage : Page
    {
        public static Entities Entities = new Entities();
        public ChequesPage()
        {
            InitializeComponent();
            ChequesGrid.ItemsSource = Entities.Cheque.ToList();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class ClientsTable
        {
            public ClientsTable(int IDCheque, float Price, int IDApp, DateTime ChequeDate, string DepAddress)
            {
                this.IDCheque = IDCheque;
                this.Price = Price;
                this.IDApp = IDApp;
                this.ChequeDate = ChequeDate;
                this.DepAddress = DepAddress;
            }
            public int IDCheque { get; set; }
            public float Price { get; set; }
            public int IDApp { get; set; }
            public DateTime ChequeDate { get; set; }
            public string DepAddress { get; set; }
        }
    }
}
