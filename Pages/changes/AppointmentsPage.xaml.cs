using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Vet.DataBase;
using Vet.Views;

namespace Vet.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage : Page
    {

        Entities Entities = new Entities();

        public AppointmentsPage()
        {
            InitializeComponent();
            LvApps.ItemsSource = Entities.Appointment.ToList();
        }

        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tboxSearch.Text;
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(LvApps.ItemsSource);
            if (filter == "") viewSource.Filter = null;
            else
            {
                viewSource.Filter = SN =>
                {
                    Appointment p = SN as Appointment;
                    return p.Employee.Surname.ToString().ToLower().Contains(filter);
                };
                LvApps.ItemsSource = viewSource;
            }
        }

        private void btnAddAppointmentWindow_Click(object sender, RoutedEventArgs e)
        {
            AddAppointmentWindow addAppointmentWindow = new AddAppointmentWindow();
            addAppointmentWindow.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить данную запись?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (LvApps.SelectedItem is Appointment appointment)
                {
                    appointment.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    LvApps.ItemsSource = Entities.Service.ToList();
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
            MessageBox.Show("Данные успешно сохранены.", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void btnOpenApp_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
