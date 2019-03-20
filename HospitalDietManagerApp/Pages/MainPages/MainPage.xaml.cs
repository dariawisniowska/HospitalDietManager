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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {       
        public MainPage()
        {
            InitializeComponent();
            dashboard();           
        }

        public void dashboard()
        {
            MainFrame.Navigate(new Uri("Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void wczytaj_jadlospis_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/ReadMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void wczytaj_jadlospis_szablonu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/ReadTemplateMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void zapisz_jadlospis_szablonu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/SaveTemplateMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void zapisz_jadlospis_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/SaveMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void wczytaj_recepture_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/ReadRecepie.xaml", UriKind.RelativeOrAbsolute));
        }

        private void zapisz_recepture_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/SaveRecepie.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
