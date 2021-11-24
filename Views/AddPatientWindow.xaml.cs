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
        private Patient pt = new Patient();
        private bool EditPatient = false;
        public AddPatientWindow()
        {
            InitializeComponent();
            cboxAddAnimalGender.ItemsSource = Entities.AnimalGender.Select(i => i.AnimalGender1).ToList();
            cboxAddAnimalType.ItemsSource = Entities.AnimalType.Select(i => i.AnimalType1).ToList();
            APWindow = this;
            tblockTitle.Text = "Добавление пациента";
        }

        public AddPatientWindow(Patient patient)
        {
            if (patient != null)
            {
                InitializeComponent();
                EditPatient = true;
                pt = patient;
                cboxAddAnimalGender.ItemsSource = Entities.AnimalGender.Select(i => i.AnimalGender1).ToList();
                cboxAddAnimalType.ItemsSource = Entities.AnimalType.Select(i => i.AnimalType1).ToList();
                tblockTitle.Text = "Запись №" + patient.IDPatient;
                tboxAddPatientName.Text = patient.PatientName;
                tboxAddAge.Text = patient.Age.ToString();
                cboxAddAnimalGender.SelectedItem = Entities.AnimalGender.Where(i => i.IDAnimalGender == patient.IDAnimalGender).Select(i => i.AnimalGender1).FirstOrDefault();
                cboxAddAnimalType.SelectedItem = Entities.AnimalType.Where(i => i.IDAnimalType == patient.IDAnimalType).Select(i => i.AnimalType1).FirstOrDefault();
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditPatient)
            {
                Patient patient = Entities.Patient.Find(pt.IDPatient);
                if (tboxAddPatientName.Text.Length != 0 || tboxAddAge.Text.Length != 0 || cboxAddAnimalGender.Text.Length != 0 || cboxAddAnimalGender.SelectedItem != null)
                {
                    patient.PatientName = tboxAddPatientName.Text;
                    patient.Age = Convert.ToByte(tboxAddAge.Text);
                    patient.IDAnimalGender = Entities.AnimalGender.Where(i => i.AnimalGender1 == cboxAddAnimalGender.SelectedItem.ToString()).Select(i => i.IDAnimalGender).FirstOrDefault();
                    patient.IDAnimalType = Entities.AnimalType.Where(i => i.AnimalType1 == cboxAddAnimalType.SelectedItem.ToString()).Select(i => i.IDAnimalType).FirstOrDefault();
                    Entities.SaveChanges();
                    MessageBox.Show("Данные клиента успешно обновлены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                    MessageBox.Show("Пожалуйста, заполните строки, которые отмечеы '*'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(!EditPatient && MessageBox.Show("Вы действительно хотите добавить пациента?", "Добавление пациента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (tboxAddPatientName.Text.Length != 0 || tboxAddAge.Text.Length != 0 || cboxAddAnimalGender.Text.Length != 0 || cboxAddAnimalGender.SelectedItem != null)
                {
                    Entities.Patient.Add(new Patient
                    {
                        PatientName = tboxAddPatientName.Text,
                        Age = Convert.ToByte(tboxAddAge.Text),
                        IDAnimalGender = Entities.AnimalGender.Where(i => i.AnimalGender1 == cboxAddAnimalGender.SelectedItem.ToString()).Select(i => i.IDAnimalGender).FirstOrDefault(),
                        IDAnimalType = Entities.AnimalType.Where(i => i.AnimalType1 == cboxAddAnimalType.SelectedItem.ToString()).Select(i => i.IDAnimalType).FirstOrDefault()
                    });

                    Entities.SaveChanges();
                    MessageBox.Show($"Пациент {tboxAddPatientName.Text} успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
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
                APWindow.DragMove();
        }
    }
}