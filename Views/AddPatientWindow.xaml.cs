using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Vet.DataBase;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {

        Entities Entities = new Entities();

        public AddPatientWindow()
        {
            InitializeComponent();
            cboxAddAnimalGender.ItemsSource = Entities.AnimalGender.Select(i => i.AnimalGender1).ToList();
            APWindow = this;
            tblockTitle.Text = "Добавление пациента";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tboxAddPatientName.Text.Length != 0 || tboxAddAge.Text.Length != 0 || cboxAddAnimalGender.Text.Length != 0 || tboxAddAnimalType.Text.Length != 0)
            {

                Entities.Patient.Add(new Patient
                {
                    PatientName = tboxAddPatientName.Text,
                    Age = Convert.ToByte(tboxAddAge.Text),
                    IDAnimalGender = Entities.AnimalGender.Where(i => i.AnimalGender1 == cboxAddAnimalGender.Text).Select(i => i.IDAnimalGender).FirstOrDefault(),
                    IDAnimalType = Entities.AnimalType.Where(i => i.AnimalType1 == tboxAddAnimalType.Text).Select(i => i.IDAnimalType).FirstOrDefault()
                });

                Entities.SaveChanges();
                MessageBox.Show($"Пациент {tboxAddPatientName.Text} успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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
                APWindow.DragMove();
        }
    }
}
