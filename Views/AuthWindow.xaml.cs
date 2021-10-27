using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Vet.DataBase;
using System.Windows.Input;

namespace Vet.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public Entities Entities = new Entities();
        public static User authUser = null;
        public string login, pass;
        public AuthWindow()
        {
            InitializeComponent();
            Auth = this;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = Tb1.Text.Trim();
            string pass = Tb2.Text.Trim();

            ToolTip toolTip = new ToolTip();

            if (Tb1.Text.Length == 0 && Tb2.Text.Length == 0)
            {
                Tb1.ToolTip = "Вы не ввели логин.";
                Tb2.ToolTip = "Вы не ввели пароль.";
            }
            else
            {
                Tb1.ToolTip = null;
                Tb2.ToolTip = null;
                authUser = Entities.User.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
            }

            if (authUser != null)
            {
                MessageBox.Show("Вы успешно авторизованы.");
                MainMenu mainWindow = new MainMenu();
                mainWindow.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Вы ввели некорректные данные.");
                Tb2.Text = null;
            }
        }
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                Auth.DragMove();
        }
    }
}

/* EmployeeSchedule : только менеджер
IDEmployee
Datetime-start
datetime-finish
freedayspermonth
HoursPerMonth
OffDaysPerMonth
*/
