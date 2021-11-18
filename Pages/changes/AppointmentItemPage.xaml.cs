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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vet.DataBase;

namespace Vet.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppointmentItemPage.xaml
    /// </summary>
    public partial class AppointmentItemPage : Page
    {

        Entities Entities = new Entities();

        public AppointmentItemPage(App app)
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
