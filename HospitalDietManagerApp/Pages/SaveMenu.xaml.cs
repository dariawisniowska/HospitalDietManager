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
    /// Interaction logic for SaveMenu.xaml
    /// </summary>
    public partial class SaveMenu : Page
    {
        public SaveMenu()
        {
            InitializeComponent();

            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = Properties.Settings.Default.dashboard_unit;
            data.SelectedDate = Properties.Settings.Default.dashboard_date;
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            string data_format = data.SelectedDate.Value.Day + " " + GetMonth(data.SelectedDate.Value.Month) + " " + data.SelectedDate.Value.Year;
            DAO.MenusDAO.Insert(data_format, dieta.SelectedValue.ToString(), miasto.SelectedValue.ToString(), Properties.Settings.Default.dashboard_nazwa_sniadanie, Properties.Settings.Default.dashboard_nazwa_IIsniadanie, Properties.Settings.Default.dashboard_nazwa_obiad, Properties.Settings.Default.dashboard_nazwa_podwieczorek, Properties.Settings.Default.dashboard_sklad_kolacja, Properties.Settings.Default.dashboard_sklad_sniadanie, Properties.Settings.Default.dashboard_sklad_IIsniadanie, Properties.Settings.Default.dashboard_sklad_obiad, Properties.Settings.Default.dashboard_sklad_podwieczorek, Properties.Settings.Default.dashboard_sklad_kolacja);
            this.NavigationService.GoBack();
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] customOrder = { "Dieta podstawowa", "Dieta łatwostrawna", "Dieta z ograniczeniem łatwo przyswajalnych węglowodanów", "Dieta bogatobiałkowa", "Dieta łatwostrawna z ograniczeniem tłuszczu", "Dieta łatwostrawna z ograniczeniem substancji pobudzających wydzielanie soku żołądkowego", "Dieta łatwostrawna o zmienionej konsystencji - papkowata" };
            dieta.ItemsSource = DAO.DietsDAO.SelectAll(miasto.SelectedValue.ToString()).OrderBy(x => Array.IndexOf(customOrder, x.nazwa)).Select(x => x.nazwa).ToList();
            dieta.SelectedIndex = Properties.Settings.Default.dashboard_diet;
        }

        private void dieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "stycznia";
                case 2:
                    return "lutego";
                case 3:
                    return "marca";
                case 4:
                    return "kwietnia";
                case 5:
                    return "maja";
                case 6:
                    return "czerwca";
                case 7:
                    return "lipca";
                case 8:
                    return "siepnia";
                case 9:
                    return "września";
                case 10:
                    return "października";
                case 11:
                    return "listopada";
                case 12:
                    return "grudnia";
            }
            return "";
        }
    }
}
