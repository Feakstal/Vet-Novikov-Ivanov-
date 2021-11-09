<<<<<<< HEAD
﻿using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
=======
﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
>>>>>>> parent of a57e67c (medcards доделать добавить-удалить-редактировать)
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
<<<<<<< HEAD
        public Role role;
=======
        public static User authUser;
>>>>>>> parent of a57e67c (medcards доделать добавить-удалить-редактировать)
        public EmployeesPage()
        {
            InitializeComponent();
            EmployeesGrid.ItemsSource = Entities.Employee.ToList();
<<<<<<< HEAD
            role = Entities.Role.Find(AuthWindow.authUser.Role.IDRole);
            if (role.RoleName.Equals("Врач"))
            {
                btnDelete.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Collapsed;
                btnAddEmployeeWindow.Visibility = Visibility.Collapsed;
                EmployeesGrid.CanUserAddRows = false;
                EmployeesGrid.IsReadOnly = true;
            }
=======
>>>>>>> parent of a57e67c (medcards доделать добавить-удалить-редактировать)
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class EmployeesTable
        {
            public EmployeesTable(int IDEmployee, string Surname, string Name, string FatherName, string Phone, string PassSerial, string PassNumber, string Address)
            {
                this.IDEmployee = IDEmployee;
                this.Surname = Surname;
                this.Name = Name;
                this.FatherName = FatherName;
                this.Phone = Phone;
                this.PassSerial = PassSerial;
                this.PassNumber = PassNumber;
                this.Address = Address;
            }
            public int IDEmployee { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string Phone { get; set; }
            public string PassSerial { get; set; }
            public string PassNumber { get; set; }
            public string Address { get; set; }
        }

<<<<<<< HEAD
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Entities.SaveChanges();
            MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить данную запись?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (EmployeesGrid.SelectedItem is Employee employee)
                {
                    employee.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    EmployeesGrid.ItemsSource = Entities.Employee.ToList();
                }
                else
                {
                    MessageBox.Show("Вы не выбрали пользователя из списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAddEmployeeWindow_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();
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
=======
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            switch (AuthWindow.authUser.IDRole)
            {
                case 1: EmployeesGrid.IsReadOnly = false; break;
                case 2: EmployeesGrid.IsReadOnly = true; break;
                case 3: EmployeesGrid.IsReadOnly = false; break;
                default: break;
>>>>>>> parent of a57e67c (medcards доделать добавить-удалить-редактировать)
            }
        }
    }
}