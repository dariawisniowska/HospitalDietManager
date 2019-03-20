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

namespace HospitalDietManager
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();


            MainFrame.Source = new Uri("Pages/Dashboard.xaml,UriKind.Relative");
            MainFrame.NavigationService.Refresh();
        }

        private void documents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void units_Click(object sender, RoutedEventArgs e)
        {

        }

        private void diets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void templates_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void recipies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void products_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dashboard_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
