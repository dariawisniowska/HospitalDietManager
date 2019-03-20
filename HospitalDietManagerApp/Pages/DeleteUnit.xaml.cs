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

namespace HospitalDietManagerApp.Pages
{
    /// <summary>
    /// Interaction logic for DeleteUnit.xaml
    /// </summary>
    public partial class DeleteUnit : Page
    {
        public DeleteUnit()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = Properties.Settings.Default.diet_miasto;
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            DAO.UnitsDAO.Delete(new Models.Unit(miasto.SelectedValue.ToString()));
            this.NavigationService.GoBack();
        }
    }
}
