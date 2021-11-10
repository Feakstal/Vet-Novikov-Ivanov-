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
            PatientsGrid.ItemsSource = Entities.Patient.ToList();
            role = Entities.Role.Find(AuthWindow.authUser.Role.IDRole);
            if (role.RoleName.Equals("Врач"))
            {
                btnDelete.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Collapsed;
                btnAddPatientWindow.Visibility = Visibility.Collapsed;
                PatientsGrid.CanUserAddRows = false;
                PatientsGrid.IsReadOnly = true;
            }
        }

        class PatientsTable
        {
            public PatientsTable(int IDPatient, string PatientName, int Age, int IDAnimalGender, int IDAnimalType, bool IsDeleted)
            {
                this.IDPatient = IDPatient;
                this.PatientName = PatientName;
                this.Age = Age;
                this.IDAnimalGender = IDAnimalGender;
                this.IDAnimalType = IDAnimalType;
                this.IsDeleted = IsDeleted;
            }

            public int IDPatient { get; set; }
            public string PatientName { get; set; }
            public int Age { get; set; }
            public int IDAnimalGender { get; set; }
            public int IDAnimalType { get; set; }
            public bool IsDeleted { get; set; }
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
                if (PatientsGrid.SelectedItem is Patient patient)
                {
                    patient.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    PatientsGrid.ItemsSource = Entities.Client.ToList();
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
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(PatientsGrid.ItemsSource);
            if (filter == "") viewSource.Filter = null;
            else
            {
                viewSource.Filter = SN =>
                {
                    Patient p = SN as Patient;
                    return p.PatientName.ToString().ToLower().Contains(filter);
                };
                PatientsGrid.ItemsSource = viewSource;
            }
        }
    }
}
