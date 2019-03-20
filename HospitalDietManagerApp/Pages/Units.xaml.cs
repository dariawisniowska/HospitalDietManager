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
    /// Interaction logic for Units.xaml
    /// </summary>
    public partial class Units : Page
    {
        public Units()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = 0;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.unit_miasto = miasto.SelectedIndex;
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nazwa.Text = miasto.SelectedValue.ToString();
        }
    }
}
