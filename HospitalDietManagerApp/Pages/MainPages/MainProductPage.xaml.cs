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
    /// Interaction logic for MainProductPage.xaml
    /// </summary>
    public partial class MainProductPage : Page
    {
        public MainProductPage()
        {
            InitializeComponent();
            MainFrame.Navigate(new Uri("Pages/Products.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edytuj_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/EditProduct.xaml", UriKind.RelativeOrAbsolute));
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/DeleteProduct.xaml", UriKind.RelativeOrAbsolute));
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/AddProduct.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
