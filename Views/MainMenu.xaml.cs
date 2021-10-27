using System;
using System.Windows;
using Vet.Pages;
using Vet.DataBase;
using System.Windows.Input;

namespace Vet.Views
{
    public partial class MainMenu : Window
    {
        public static Entities Entities = new Entities();
        public User userUpdate = AuthWindow.authUser;
        public Employee employee;
        public MainMenu()
        {
            InitializeComponent();
            MM = this;
            employee = Entities.Employee.Find(AuthWindow.authUser.Employee.IDEmployee);
            frmLoader.Navigate(new MainPage());
            frmLoader2.Navigate(new SchedulePage());
            tbkFIO.Text = userUpdate.Employee.Surname + " " + userUpdate.Employee.Name + " " + userUpdate.Employee.FatherName;
            tbkRank.Text = userUpdate.Role.RoleName;
            tbxPhone.Text = employee.Phone;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { lbCurrentDateTime.Content = DateTime.Now.ToString(); };
            timer.Start();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AuthWindow.authUser = null;
            AuthWindow aw = new AuthWindow();
            aw.Show();
        }

        private void btnSavePhone_Click(object sender, RoutedEventArgs e)
        {
            employee = Entities.Employee.Find(AuthWindow.authUser.Employee.IDEmployee);
            if (tbxPhone == null)
            {
                MessageBox.Show("Заполните поле 'Телефон'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var res = MessageBox.Show("Вы хотите сохранить изменения?", "да", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                employee.Phone = tbxPhone.Text;
                Entities.SaveChanges();
            }
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                MM.DragMove();
        }

        private void btnMinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            
            else
                this.WindowState = WindowState.Normal;
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
