using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Vet.Views;
using Vet.DataBase;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;

namespace Vet.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public Entities Entities = new Entities();
        public Role role;
        public ServicesPage()
        {
            InitializeComponent();
            ServicesGrid.ItemsSource = Entities.Service.ToList();
            role = Entities.Role.Find(AuthWindow.authUser.Role.IDRole);
            if (role.RoleName.Equals("Врач"))
            {
                btnDelete.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Collapsed;
                btnAddServiceWindow.Visibility = Visibility.Collapsed;
                ServicesGrid.CanUserAddRows = false;
                ServicesGrid.IsReadOnly = true;
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class ServicesTable
        {
            public ServicesTable(int IDService, string ServiceName, float Price, int Length, bool IsDeleted)
            {
                this.IDService = IDService;
                this.ServiceName = ServiceName;
                this.Price = Price;
                this.Length = Length;
                this.IsDeleted = IsDeleted;
            }
            public int IDService { get; set; }
            public string ServiceName { get; set; }
            public float Price { get; set; }
            public int Length { get; set; }
            public bool IsDeleted { get; set; }

        }

        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tboxSearch.Text;
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(ServicesGrid.ItemsSource);
            if (filter == "") viewSource.Filter = null;
            else
            {
                viewSource.Filter = S =>
                {
                    Service p = S as Service;
                    return p.ServiceName.ToString().ToLower().Contains(filter);
                };
                ServicesGrid.ItemsSource = viewSource;
            }
        }
        private void btnAddServiceWindow_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new AddServiceWindow();
            addServiceWindow.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить данную запись?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (ServicesGrid.SelectedItem is Service service)
                {
                    service.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    ServicesGrid.ItemsSource = Entities.Service.ToList();
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
