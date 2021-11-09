using System;
using System.Windows;
using System.Windows.Input;
using Vet.DataBase;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {

        Entities Entities = new Entities();

        public AddServiceWindow()
        {
            InitializeComponent();
            ASWindow = this;
            tblockTitle.Text = "Добавление услуги";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tboxAddService.Text.Length != 0)
            {

                Entities.Service.Add(new Service
                {
                    ServiceName = tboxAddService.Text,
                    Price = Convert.ToDecimal(tboxAddPrice.Text),
                    Length = Convert.ToByte(tboxAddLength.Text),
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
                ASWindow.DragMove();
        }
    }
}
