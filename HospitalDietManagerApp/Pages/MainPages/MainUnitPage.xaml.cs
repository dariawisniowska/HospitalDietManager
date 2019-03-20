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

namespace HospitalDietManagerApp.Pages.MainPages
{
    /// <summary>
    /// Interaction logic for MainUnitPage.xaml
    /// </summary>
    public partial class MainUnitPage : Page
    {
        public MainUnitPage()
        {
            InitializeComponent();
            MainFrame.Navigate(new Uri("Pages/Units.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/AddUnit.xaml", UriKind.RelativeOrAbsolute));
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/DeleteUnit.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
