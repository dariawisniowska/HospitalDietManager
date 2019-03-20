using HospitalDietManagerApp.Models;
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
    /// Interaction logic for DeleteDiet.xaml
    /// </summary>
    public partial class DeleteDiet : Page
    {
        List<Diet> listaDiet;
        public DeleteDiet()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = Properties.Settings.Default.diet_miasto;
            dieta.SelectedIndex = Properties.Settings.Default.diet_dieta;
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            DAO.DietsDAO.Delete(listaDiet[dieta.SelectedIndex]);
            this.NavigationService.GoBack();
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDiet = DAO.DietsDAO.SelectAll(miasto.SelectedValue.ToString()).OrderBy(x => x.nazwa).ToList();
            string[] customOrder = { "Dieta podstawowa", "Dieta łatwostrawna", "Dieta z ograniczeniem łatwo przyswajalnych węglowodanów", "Dieta bogatobiałkowa", "Dieta łatwostrawna z ograniczeniem tłuszczu", "Dieta łatwostrawna z ograniczeniem substancji pobudzających wydzielanie soku żołądkowego", "Dieta łatwostrawna o zmienionej konsystencji - papkowata" };
            dieta.ItemsSource = listaDiet.OrderBy(x => Array.IndexOf(customOrder, x.nazwa)).Select(x => x.nazwa).ToList();
            dieta.SelectedIndex = 0;
        }
    }
}
