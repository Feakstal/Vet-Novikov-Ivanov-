using System;
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
        private bool updateApp = false, updateMed = false;
        private Appointment editApp = null;
        private Medcard editMed = null;
        private Patient editPatient = null;

        public AppointmentsPage()
        {
            InitializeComponent();
            btnStartSession.IsEnabled = false;
            btnEndSession.IsEnabled = false;
            LvApps.ItemsSource = Entities.Appointment.ToList();
            cbService.ItemsSource = Entities.Service.Select(i => i.ServiceName).ToList();
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
                    LvApps.Items.Remove(appointment);
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

        private void btnEndSession_Click(object sender, RoutedEventArgs e)
        {
            if (updateApp && updateMed)
            {

                Appointment newApp = Entities.Appointment.Find(editApp.IDApp);
                Medcard medcard = Entities.Medcard.Find(editMed.IDMedcard);

                newApp.IDService = Entities.Service.Where(i => i.ServiceName == cbService.SelectedItem.ToString()).Select(i => i.IDService).FirstOrDefault();
                newApp.IDStatus = 3;

                medcard.IDPatient = Entities.Patient.Where(i => i.PatientName == tboxIdPat.Text).Select(i => i.IDPatient).FirstOrDefault();
                medcard.CurrentState = tboxState.Text;
                medcard.History = tboxHistory.Text;

                Entities.SaveChanges();
                MessageBox.Show("Запись завершена, сохранение данных", "Запись №" + newApp.IDApp, MessageBoxButton.OK, MessageBoxImage.Information);

                btnStartSession.IsEnabled = true;
                btnOpenApp.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnEditAppointment.IsEnabled = true;
                btnAddAppointmentWindow.IsEnabled = true;
                btnGoBack.IsEnabled = true;
            }
            else if (updateApp && !updateMed)
            {
                Appointment newApp = Entities.Appointment.Find(editApp.IDApp);

                newApp.IDService = Entities.Service.Where(i => i.ServiceName == cbService.SelectedItem.ToString()).Select(i => i.IDService).FirstOrDefault();
                newApp.IDStatus = 3;

                if (tboxIdPat.Text.Length != 0)
                {

                    Entities.Medcard.Add(new Medcard
                    {
                        IDPatient = Entities.Patient.Where(i => i.PatientName == tboxIdPat.Text).Select(i => i.IDPatient).FirstOrDefault(),
                        CurrentState = tboxState.Text,
                        History = tboxHistory.Text,
                        IsDeleted = false
                    });

                    Entities.SaveChanges();
                    MessageBox.Show($"Медкарта пациента {tboxIdPat.Text} успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    btnStartSession.IsEnabled = true;
                    btnOpenApp.IsEnabled = true;
                    btnDelete.IsEnabled = true;
                    btnEditAppointment.IsEnabled = true;
                    btnAddAppointmentWindow.IsEnabled = true;
                    btnGoBack.IsEnabled = true;
                }
                else
                    MessageBox.Show("Пожалуйста, заполните строки, которые отмечеы '*'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void btnOpenApp_Click(object sender, RoutedEventArgs e)
        {
            EditApp((Appointment)LvApps.SelectedItem);
            EditMedcard((Appointment)LvApps.SelectedItem);
            if (editApp != null && editApp.IDStatus == 3)
            {
                btnStartSession.IsEnabled = false;
                btnEndSession.IsEnabled = false;
            }
            else if(editApp != null)
            {
                btnStartSession.IsEnabled = true;
                btnEndSession.IsEnabled = true;
            }
        }

        private void EditApp(Appointment app)
        {
            if (app != null)
            {
                editApp = app;
                updateApp = true;
                dpAppDate.Text = app.AppDate.ToString();
                tblockAppNumberTitle.Text = "Запись №" + app.IDApp.ToString();
                tblockLastNameOfClient.Text = Entities.Client.Where(i => i.IDClient == app.IDClient).Select(i => i.Surname).FirstOrDefault();
                tblockLastNameOfDoc.Text = Entities.Employee.Where(i => i.IDEmployee == app.IDEmployee).Select(i => i.Surname).FirstOrDefault();
                cbService.SelectedItem = Entities.Service.Where(i => i.IDService == app.IDService).Select(i => i.ServiceName).FirstOrDefault();
                tblockNumberOfCab.Text = Entities.Cab.Where(i => i.IDCab == app.IDCab).Select(i => i.Number.ToString()).FirstOrDefault();
                tblockStatus.Text = Entities.Status.Where(i => i.IDStatus == app.IDStatus).Select(i => i.StatusName.ToString()).FirstOrDefault();
            }
        }

        private void EditMedcard(Appointment ap)
        {
            if (ap != null)
            {
                var cliFound = Entities.Client.Where(i => i.IDClient == ap.IDClient).FirstOrDefault();
                var patFound = Entities.Patient.Where(i => i.IDPatient == cliFound.IDPatient).FirstOrDefault();
                var medFound = Entities.Medcard.Where(i => i.IDPatient == patFound.IDPatient).FirstOrDefault();
                editMed = medFound;
                updateMed = true;
                tboxIdMed.Text = medFound.IDMedcard.ToString();
                tboxIdPat.Text = patFound.PatientName;
                tboxState.Text = medFound.CurrentState;
                tboxHistory.Text = medFound.History;
            }
            else
                MessageBox.Show("Вы не выбрали запись.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnStartSession_Click(object sender, RoutedEventArgs e)
        {

            editApp.IDStatus = 2;
            var EditStatus = Entities.Status.Where(i => i.IDStatus == editApp.IDStatus).Select(i => i.StatusName).FirstOrDefault();
            tblockStatus.Text = EditStatus;

            if (editApp.IDStatus != 3 && editApp.IsDeleted == false)
            {
                btnStartSession.IsEnabled = false;
                btnOpenApp.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnEditAppointment.IsEnabled = false;
                btnAddAppointmentWindow.IsEnabled = false;
                btnGoBack.IsEnabled = false;
            }
        }

        private void btnEditAppointment_Click(object sender, RoutedEventArgs e)
        {
            AddAppointmentWindow editAppointmentWindow = new AddAppointmentWindow((Appointment)LvApps.SelectedItem);
            editAppointmentWindow.ShowDialog();
        }
    }
}
