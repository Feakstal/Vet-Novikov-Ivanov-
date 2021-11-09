using System.Linq;
using System.Windows;
using System.Windows.Input;
using Vet.DataBase;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {

        Entities Entities = new Entities();

        public AddClientWindow()
        {
            InitializeComponent();
            ACWindow = this;
            tblockTitle.Text = "Добавление клиента";
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                ACWindow.DragMove();
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            if (tboxAddLastName.Text.Length != 0 || tboxAddName.Text.Length != 0 || tboxAddPassportNumber.Text.Length != 0 || tboxAddSeries.Text.Length != 0)
            {
                if (tboxAddPatient.Text.Length == 0)
                {
                    Entities.Client.Add(new Client
                    {
                        Surname = tboxAddLastName.Text,
                        Name = tboxAddName.Text,
                        FatherName = tboxAddFatherName.Text,
                        PassSerial = tboxAddSeries.Text,
                        PassNumber = tboxAddPassportNumber.Text,
                        Phone = tboxAddPhone.Text,
                        IDPatient = null
                    });
                }
                else
                {
                    Entities.Client.Add(new Client
                    {
                        Surname = tboxAddLastName.Text,
                        Name = tboxAddName.Text,
                        FatherName = tboxAddFatherName.Text,
                        PassSerial = tboxAddSeries.Text,
                        PassNumber = tboxAddPassportNumber.Text,
                        Phone = tboxAddPhone.Text,
                        IDPatient = Entities.Patient.Where(i => i.PatientName == tboxAddPatient.Text).Select(i => i.IDPatient).FirstOrDefault()
                    });
                }
                Entities.SaveChanges();
                MessageBox.Show($"Клиент {tboxAddLastName.Text} {tboxAddName.Text} успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните строки, которые отмечеы '*'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
