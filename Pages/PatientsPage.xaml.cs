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
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {

        Entities Entities = new Entities();
        public Role role;

        public PatientsPage()
        {
            InitializeComponent();
            LvPatients.ItemsSource = Entities.Patient.ToList();

            role = Entities.Role.Find(AuthWindow.authUser.Role.IDRole);
            if (role.RoleName.Equals("Врач"))
            {
                btnDelete.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Collapsed;
                btnAddPatientWindow.Visibility = Visibility.Collapsed;
            }
        }


        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Entities.SaveChanges();
            MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить данную запись?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (LvPatients.SelectedItem is Patient patient)
                {
                    patient.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    LvPatients.ItemsSource = Entities.Patient.ToList();
                }
                else
                    MessageBox.Show("Вы не выбрали пользователя из списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddPatientWindow_Click(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientWindow = new AddPatientWindow();
            addPatientWindow.ShowDialog();
        }

        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tboxSearch.Text;
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(LvPatients.ItemsSource);
            if (filter == "") viewSource.Filter = null;
            else
            {
                viewSource.Filter = SN =>
                {
                    Patient p = SN as Patient;
                    return p.PatientName.ToString().ToLower().Contains(filter);
                };
                LvPatients.ItemsSource = viewSource;
            }
        }

        private void btnEditApp_Click(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientWindow = new AddPatientWindow((Patient)LvPatients.SelectedItem);
            addPatientWindow.ShowDialog();
        }
    }
}