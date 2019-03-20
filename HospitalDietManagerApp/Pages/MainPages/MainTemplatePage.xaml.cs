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
    /// Interaction logic for MainTemplatePage.xaml
    /// </summary>
    public partial class MainTemplatePage : Page
    {
        public MainTemplatePage()
        {
            InitializeComponent();
            templates();
        }

        public void templates()
        {
            MainFrame.Navigate(new Uri("Pages/Templates.xaml", UriKind.RelativeOrAbsolute));
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/AddTemplate.xaml", UriKind.RelativeOrAbsolute));
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/DeleteTemplate.xaml", UriKind.RelativeOrAbsolute));
        }

        private void generuj_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/GenrateTemplate.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
