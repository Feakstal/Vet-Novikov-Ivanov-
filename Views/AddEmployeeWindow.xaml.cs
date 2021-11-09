using System.Windows;
using System.Windows.Input;
using Vet.DataBase;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {

        Entities Entities = new Entities();

        public AddEmployeeWindow()
        {
            InitializeComponent();
            AEWindow = this;
            tblockTitle.Text = "Добавление работника";
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                AEWindow.DragMove();
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            if (tboxAddLastName.Text.Length != 0 || tboxAddName.Text.Length != 0 || tboxAddPassportNumber.Text.Length != 0 || tboxAddSeries.Text.Length != 0)
            {
                Entities.Employee.Add(new Employee
                {
                    Surname = tboxAddLastName.Text,
                    Name = tboxAddName.Text,
                    FatherName = tboxAddFatherName.Text,
                    PassSerial = tboxAddSeries.Text,
                    PassNumber = tboxAddPassportNumber.Text,
                    Phone = tboxAddPhone.Text,
                    Address = tboxAddAddress.Text,
                    IsDeleted = false
                });
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
