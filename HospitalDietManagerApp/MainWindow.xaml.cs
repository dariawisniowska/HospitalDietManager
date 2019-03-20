using HospitalDietManagerApp.Pages;
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

namespace HospitalDietManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double przelicznik_Bialko = 4; //kcal na 1g
        public static double przelicznik_Weglowodany = 4; //kcal na 1g
        public static double przelicznik_Tluszcze = 9; //kcal na 1g
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Dashboard":
                    MainFrame.Navigate(new Uri("Pages/MainPages/MainPage.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Products":
                    MainFrame.Navigate(new Uri("Pages/MainPages/MainProductPage.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Recepies":
                    MainFrame.Navigate(new Uri("Pages/MainPages/Recepies.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Menu":
                    MainFrame.Navigate(new Uri("Pages/MainPages/Menu.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Templates":
                    MainFrame.Navigate(new Uri("Pages/MainPages/MainTemplatePage.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Diets":
                    MainFrame.Navigate(new Uri("Pages/MainPages/MainDietPAge.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Units":
                    MainFrame.Navigate(new Uri("Pages/MainPages/MainUnitPage.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "Documents":
                    MainFrame.Navigate(new Uri("Pages/MainPages/Documents.xaml", UriKind.RelativeOrAbsolute));
                    break;
                default:
                    break;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Uri("Pages/MainPages/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
