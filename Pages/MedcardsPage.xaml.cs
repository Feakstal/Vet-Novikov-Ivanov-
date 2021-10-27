using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Vet.DataBase;
namespace Vet.Pages
{
    public partial class MedcardsPage : Page
    {
        public Entities Entities = new Entities();
        public MedcardsPage()
        {
            InitializeComponent();
            MedcardsGrid.ItemsSource = Entities.Medcard.ToList();
        }
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class MedcardsTable
        {
            public MedcardsTable(int IDMedcard, int IDPatient, string CurrentState, string History)
            {
                this.IDMedcard = IDMedcard;
                this.IDPatient = IDPatient;
                this.CurrentState = CurrentState;
                this.History = History;
            }
            public int IDMedcard { get; set; }
            public int IDPatient { get; set; }
            public string CurrentState { get; set; }
            public string History { get; set; }

        }
    }
}