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
    /// Interaction logic for MainDietPage.xaml
    /// </summary>
    public partial class MainDietPage : Page
    {
        public MainDietPage()
        {
            InitializeComponent();
            MainFrame.Navigate(new Uri("Pages/Diets.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edytuj_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/EditDiet.xaml", UriKind.RelativeOrAbsolute));
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/DeleteDiet.xaml", UriKind.RelativeOrAbsolute));
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/AddDiet.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
