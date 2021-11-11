using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Vet.DataBase;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {

        Entities Entities = new Entities();

        public AddAppointmentWindow()
        {
            InitializeComponent();
            AAWindow = this;
            tblockTitle.Text = "Добавление записи";
        }
        private void btnSaveApp_Click(object sender, RoutedEventArgs e)
        {
            if (tboxAppointmentDate.Text.Length != 0 || tboxCabNumber.Text.Length != 0 || tboxAddEmployeeSurname.Text.Length != 0 || tboxAddClientSurname.Text.Length != 0 || tboxAddService.Text.Length !=0)
            {
                Entities.Appointment.Add(new Appointment
                {
                    AppDate = Convert.ToDateTime(dtp.Text),
                    Created = DateTime.Now,
                    IDCab = Entities.Cab.Where(i => i.Number.ToString() == tboxCabNumber.Text).Select(i => i.IDCab).FirstOrDefault(),
                    IDClient = Entities.Client.Where(i => i.Surname == tboxAddClientSurname.Text).Select(i => i.IDClient).FirstOrDefault(),
                    IDEmployee = Entities.Employee.Where(i => i.Surname == tboxAddEmployeeSurname.Text).Select(i => i.IDEmployee).FirstOrDefault(),
                    IDService = Entities.Service.Where(i => i.ServiceName == tboxAddService.Text).Select(i => i.IDService).FirstOrDefault(),
                    IsDeleted = false
                });

                Entities.SaveChanges();
                MessageBox.Show($"Пациент {tboxAddService.Text} успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Пожалуйста, заполните строки, которые отмечеы '*'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
