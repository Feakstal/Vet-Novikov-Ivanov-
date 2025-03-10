﻿using System.Linq;
using System.Windows;
using System.Windows.Input;
using Vet.DataBase;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AddMedcardWindow.xaml
    /// </summary>
    public partial class AddMedcardWindow : Window
    {

        Entities Entities = new Entities();

        public AddMedcardWindow()
        {
            InitializeComponent();
            AMWindow = this;
            tblockTitle.Text = "Добавление медкарты";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tboxAddPatient.Text.Length != 0 || tboxAddCurrentState.Text.Length != 0)
            {

                Entities.Medcard.Add(new Medcard
                {
                    IDPatient = Entities.Patient.Where(i => i.PatientName == tboxAddPatient.Text).Select(i => i.IDPatient).FirstOrDefault(),
                    CurrentState = tboxAddCurrentState.Text,
                    History = tboxAddHistory.Text,
                    IsDeleted = false
                });

                Entities.SaveChanges();
                MessageBox.Show($"Пациент {tboxAddPatient.Text} успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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
                AMWindow.DragMove();
        }
    }
}
