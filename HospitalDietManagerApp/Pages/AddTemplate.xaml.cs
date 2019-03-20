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
    /// Interaction logic for AddTemplate.xaml
    /// </summary>
    public partial class AddTemplate : Page
    {
        public AddTemplate()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = 0;
            dzienStart.SelectedIndex = 0;
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dzienStart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
           
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            DAO.TemplatesDAO.Insert(dekadowka.Text, miasto.SelectedValue.ToString(), Convert.ToInt32(dni.Text), dzienStart.SelectedValue.ToString(), null);
            this.NavigationService.GoBack();
        }
    }
}
