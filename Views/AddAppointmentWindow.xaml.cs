using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Vet.DataBase;
using Vet.Pages;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {

        Entities Entities = new Entities();
        private Appointment app = new Appointment();
        private bool EditAppoinment = false;
        public AddAppointmentWindow()
        {
            InitializeComponent();
            cboxCabNumber.ItemsSource = Entities.Cab.Select(i => i.Number).ToList();
            cboxService.ItemsSource = Entities.Service.Select(i => i.ServiceName).ToList();
            AAWindow = this;
            tblockTitle.Text = "Добавление записи";
        }
        public AddAppointmentWindow(Appointment appointment)
        {
            if(appointment != null)
            {
                InitializeComponent();
                EditAppoinment = true;
                app = appointment;
                cboxCabNumber.ItemsSource = Entities.Cab.Select(i => i.Number).ToList();
                cboxService.ItemsSource = Entities.Service.Select(i => i.ServiceName).ToList();
                AAWindow = this;
                tblockTitle.Text = "Запись №" + appointment.IDApp;
                dtp.Text = appointment.AppDate.ToString();
                tboxAddClientSurname.Text = Entities.Client.Where(i => i.IDClient == appointment.IDClient).Select(i => i.Surname).FirstOrDefault();
                tboxAddEmployeeSurname.Text = Entities.Employee.Where(i => i.IDEmployee == appointment.IDEmployee).Select(i => i.Surname).FirstOrDefault();
                cboxCabNumber.SelectedItem = Entities.Cab.Where(i => i.IDCab == appointment.IDCab).Select(i => i.Number).FirstOrDefault();
                cboxService.SelectedItem = Entities.Service.Where(i => i.IDService == appointment.IDService).Select(i => i.ServiceName).FirstOrDefault();
            }
        }
        private void btnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            if (EditAppoinment)
            {
                Appointment appointment = Entities.Appointment.Find(app.IDApp);
                if (dtp.Text.Length != 0 || cboxCabNumber.SelectedItem != null || tboxAddEmployeeSurname.Text.Length != 0 || tboxAddClientSurname.Text.Length != 0 || cboxService.SelectedItem != null)
                {
                    appointment.AppDate = Convert.ToDateTime(dtp.Text);
                    appointment.IDCab = Entities.Cab.Where(i => i.Number == (byte)cboxCabNumber.SelectedItem).Select(i => i.IDCab).FirstOrDefault();
                    appointment.IDClient = Entities.Client.Where(i => i.Surname == tboxAddClientSurname.Text).Select(i => i.IDClient).FirstOrDefault();
                    appointment.IDEmployee = Entities.Employee.Where(i => i.Surname == tboxAddEmployeeSurname.Text).Select(i => i.IDEmployee).FirstOrDefault();
                    appointment.IDService = Entities.Service.Where(i => i.ServiceName == cboxService.SelectedItem.ToString()).Select(i => i.IDService).FirstOrDefault();
                    
                    Entities.SaveChanges();
                    MessageBox.Show("Данные клиента успешно обновлены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                    MessageBox.Show("Пожалуйста, заполните строки, которые отмечеы '*'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(!EditAppoinment && MessageBox.Show("Вы действительно хотите добавить запись?", "Добавление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (dtp.Text.Length != 0 || cboxCabNumber.SelectedItem != null || tboxAddEmployeeSurname.Text.Length != 0 || tboxAddClientSurname.Text.Length != 0 || cboxService.SelectedItem != null)
                {
                    Entities.Appointment.Add(new Appointment
                    {
                        AppDate = Convert.ToDateTime(dtp.Text),
                        Created = DateTime.Now,
                        IDCab = Entities.Cab.Where(i => i.Number == (byte)cboxCabNumber.SelectedItem).Select(i => i.IDCab).FirstOrDefault(),
                        IDClient = Entities.Client.Where(i => i.Surname == tboxAddClientSurname.Text).Select(i => i.IDClient).FirstOrDefault(),
                        IDEmployee = Entities.Employee.Where(i => i.Surname == tboxAddEmployeeSurname.Text).Select(i => i.IDEmployee).FirstOrDefault(),
                        IDService = Entities.Service.Where(i => i.ServiceName == cboxService.SelectedItem.ToString()).Select(i => i.IDService).FirstOrDefault(),
                        IDStatus = 1,
                        IsDeleted = false
                    });
                    if (Convert.ToDateTime(dtp.Text) >= DateTime.Now)
                    {
                        Entities.SaveChanges();
                        MessageBox.Show("Запись успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Дата создания записи > даты записи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Пожалуйста, заполните строки, которые отмечеы '*'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                AAWindow.DragMove();
        }
    }
}
