using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vet.DataBase;
namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEmpWindow.xaml
    /// </summary>
    public partial class AddEmpWindow : Window
    {

        Entities Entities = new Entities();

        public AddEmpWindow()
        {
            InitializeComponent();
            ACWindow = this;
            tblockTitle.Text = "Добавление сотрудника";
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
                Entities.Employee.Add(new Employee
                {
                    Surname = tboxAddLastName.Text,
                    Name = tboxAddName.Text,
                    FatherName = tboxAddFatherName.Text,
                    PassSerial = tboxAddSeries.Text,
                    PassNumber = tboxAddPassportNumber.Text,
                    Phone = tboxAddPhone.Text,
                    Address = tboxAddress.Text,
                    IsDeleted = false
                });
                Entities.SaveChanges();
                MessageBox.Show($"Сотрудник {tboxAddLastName.Text} {tboxAddName.Text} успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Пожалуйста, заполните строки, которые отмечены '*'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
