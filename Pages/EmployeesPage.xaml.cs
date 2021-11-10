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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public Entities Entities = new Entities();
        public static User authUser;
        public Role role;
        public EmployeesPage()
        {
            InitializeComponent();
            EmployeesGrid.ItemsSource = Entities.Employee.ToList();
            role = Entities.Role.Find(AuthWindow.authUser.Role.IDRole);
            if (role.RoleName.Equals("Врач"))
            {
                btnDeleteEmp.Visibility = Visibility.Collapsed;
                btnSaveEmp.Visibility = Visibility.Collapsed;
                btnAddEmp.Visibility = Visibility.Collapsed;
                EmployeesGrid.CanUserAddRows = false;
                EmployeesGrid.IsReadOnly = true;
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class EmployeesTable
        {
            public EmployeesTable(int IDEmployee, string Surname, string Name, string FatherName, string Phone, string PassSerial, string PassNumber, string Address, bool IsDeleted)
            {
                this.IDEmployee = IDEmployee;
                this.Surname = Surname;
                this.Name = Name;
                this.FatherName = FatherName;
                this.Phone = Phone;
                this.PassSerial = PassSerial;
                this.PassNumber = PassNumber;
                this.Address = Address;
                this.IsDeleted = IsDeleted;
            }
            public int IDEmployee { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string Phone { get; set; }
            public string PassSerial { get; set; }
            public string PassNumber { get; set; }
            public string Address { get; set; }
            public bool IsDeleted { get; set; }
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow aew = new AddEmployeeWindow();
            aew.ShowDialog();
        }

        private void btnDeleteEmp_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить данную запись?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                if (EmployeesGrid.SelectedItem is Employee E)
                {
                    E.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    EmployeesGrid.ItemsSource = Entities.Employee.ToList();
                }
                else
                    MessageBox.Show("Вы не выбрали пользователя из списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnSaveEmp_Click(object sender, RoutedEventArgs e)
        {
            Entities.SaveChanges();
            MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tboxSearch.Text;
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(EmployeesGrid.ItemsSource);
            if (filter == "") viewSource.Filter = null;
            else
            {
                viewSource.Filter = SN =>
                {
                    Employee p = SN as Employee;
                    return p.Surname.ToString().ToLower().Contains(filter);
                };
                EmployeesGrid.ItemsSource = viewSource;
            }
        }
    }
}