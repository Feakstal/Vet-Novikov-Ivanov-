<<<<<<< HEAD
﻿using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using Vet.DataBase;
using Vet.Views;

=======
﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Vet.DataBase;
>>>>>>> parent of a57e67c (medcards доделать добавить-удалить-редактировать)
namespace Vet.Pages
{
    public partial class MedcardsPage : Page
    {
        public Entities Entities = new Entities();
        public Role role;
        public MedcardsPage()
        {
            InitializeComponent();
            MedcardsGrid.ItemsSource = Entities.Medcard.ToList();
            role = Entities.Role.Find(AuthWindow.authUser.Role.IDRole);
            if (role.RoleName.Equals("Врач"))
            {
                btnDelete.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Collapsed;
                btnAddMedcardWindow.Visibility = Visibility.Collapsed;
                MedcardsGrid.CanUserAddRows = false;
                MedcardsGrid.IsReadOnly = true;
            }
        }
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = this.NavigationService;
            ns.Navigate(new MainPage());
        }

        class MedcardsTable
        {
            public MedcardsTable(int IDMedcard, int IDPatient, string CurrentState, string History)
            {
                this.IDMedcard = IDMedcard;
                this.IDPatient = IDPatient;
                this.CurrentState = CurrentState;
                this.History = History;
            }
            public int IDMedcard { get; set; }
            public int IDPatient { get; set; }
            public string CurrentState { get; set; }
            public string History { get; set; }
<<<<<<< HEAD
            public bool IsDeleted { get; set; }

        }
        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tboxSearch.Text;
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(MedcardsGrid.ItemsSource);
            if (filter == "") viewSource.Filter = null;
            else
            {
                viewSource.Filter = PN =>
                {
                    Medcard p = PN as Medcard;
                    return p.Patient.PatientName.ToString().ToLower().Contains(filter);
                };
                MedcardsGrid.ItemsSource = viewSource;
            }
        }
        private void btnAddMedcardWindow_Click(object sender, RoutedEventArgs e)
        {
            AddMedcardWindow addMedcardWindow = new AddMedcardWindow();
            addMedcardWindow.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите удалить данную запись?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (MedcardsGrid.SelectedItem is Medcard medcard)
                {
                    medcard.IsDeleted = true;
                    Entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    MedcardsGrid.ItemsSource = Entities.Medcard.ToList();
                }
                else
                {
                    MessageBox.Show("Вы не выбрали пользователя из списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Entities.SaveChanges();
            MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
=======

>>>>>>> parent of a57e67c (medcards доделать добавить-удалить-редактировать)
        }
    }
}