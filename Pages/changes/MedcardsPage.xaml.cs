using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using Vet.DataBase;
using Vet.Views;

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
            public MedcardsTable(int IDMedcard, int IDPatient, string CurrentState, string History, bool IsDeleted)
            {
                this.IDMedcard = IDMedcard;
                this.IDPatient = IDPatient;
                this.CurrentState = CurrentState;
                this.History = History;
                this.IsDeleted = IsDeleted;
            }
            public int IDMedcard { get; set; }
            public int IDPatient { get; set; }
            public string CurrentState { get; set; }
            public string History { get; set; }
            public bool IsDeleted { get; set; }

        }

        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tboxSearch.Text;
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(MedcardsGrid.ItemsSource);
            if (filter == "") viewSource.Filter = null;
            else
            {
                viewSource.Filter = SN =>
                {
                    Medcard p = SN as Medcard;
                    return p.IDPatient.ToString().ToLower().Contains(filter);
                };
                MedcardsGrid.ItemsSource = viewSource;
            }
        }
        private void btnAddClientWindow_Click(object sender, RoutedEventArgs e)
        {
            AddMedcardWindow addMedcardWindow = new AddMedcardWindow();
            addMedcardWindow.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить данную запись?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (MedcardsGrid.SelectedItem is Client client)
                {
                    client.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    MedcardsGrid.ItemsSource = Entities.Medcard.ToList();
                }
                else
                {
                    MessageBox.Show("Вы не выбрали пользователя из списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Entities.SaveChanges();
            MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}