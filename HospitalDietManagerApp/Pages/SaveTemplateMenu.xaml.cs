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
    /// Interaction logic for SaveTemplateMenu.xaml
    /// </summary>
    public partial class SaveTemplateMenu : Page
    {
        List<Template> listaDekadowek;
        List<Diet> listaDiet;

        public SaveTemplateMenu()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = Properties.Settings.Default.dashboard_unit;
            dekadowka.SelectedIndex = 0;
            dzien.SelectedIndex = 0;
            dieta.SelectedIndex = Properties.Settings.Default.dashboard_diet;
        }

        public string GetDay(string dzien, int licznik)
        {
            if (licznik > 1)
            {
                string[] dni = new string[7] { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };
                int licz = 0;
                for (int i = 0; i < dni.Length; i++)
                {
                    if (dni[i] == dzien)
                        licz = i;
                }

                int j = 0;
                int odliczanie = 1;
                for (int i = 0; i < dni.Length; i++)
                {
                    if (j > licz)
                    {
                        string kolejnyDzien = dni[i];

                        if (odliczanie == licznik - 1)
                            return kolejnyDzien;

                        odliczanie++;
                    }
                    j++;

                    if (i == 6)
                        i = -1;
                }

                return "";
            }
            else
                return dzien;
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDekadowek = DAO.TemplatesDAO.Select(miasto.SelectedValue.ToString());
            dekadowka.ItemsSource = listaDekadowek.Select(x => x.nazwa);
        }

        private void dekadowka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> dni_dekadowki = new List<string>();
            for (int i = 0; i < listaDekadowek[dekadowka.SelectedIndex].dni; i++)
            {
                dni_dekadowki.Add(GetDay(listaDekadowek[dekadowka.SelectedIndex].dzienStart, i + 1));
            }
            dzien.ItemsSource = dni_dekadowki;
        }

        private void dzien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDiet = DAO.DietsDAO.SelectAll(miasto.SelectedValue.ToString());
            string[] customOrder = { "Dieta podstawowa", "Dieta łatwostrawna", "Dieta z ograniczeniem łatwo przyswajalnych węglowodanów", "Dieta bogatobiałkowa", "Dieta łatwostrawna z ograniczeniem tłuszczu", "Dieta łatwostrawna z ograniczeniem substancji pobudzających wydzielanie soku żołądkowego", "Dieta łatwostrawna o zmienionej konsystencji - papkowata" };
            dieta.ItemsSource = listaDiet.OrderBy(x => Array.IndexOf(customOrder, x.nazwa)).Select(x => x.nazwa).ToList();
        }

        private void dieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            DAO.TemplateMenusDAO.Insert(DAO.TemplatesDAO.SelectId(new Models.Template(null,dekadowka.SelectedValue.ToString(),miasto.SelectedValue.ToString(),listaDekadowek[dekadowka.SelectedIndex].dni, listaDekadowek[dekadowka.SelectedIndex].dzienStart, listaDekadowek[dekadowka.SelectedIndex].listaJadlospisow)),dzien.SelectedIndex+1, listaDiet[dieta.SelectedIndex], Properties.Settings.Default.dashboard_nazwa_sniadanie, Properties.Settings.Default.dashboard_nazwa_IIsniadanie, Properties.Settings.Default.dashboard_nazwa_obiad, Properties.Settings.Default.dashboard_nazwa_podwieczorek, Properties.Settings.Default.dashboard_sklad_kolacja, Properties.Settings.Default.dashboard_sklad_sniadanie, Properties.Settings.Default.dashboard_sklad_IIsniadanie, Properties.Settings.Default.dashboard_sklad_obiad, Properties.Settings.Default.dashboard_sklad_podwieczorek, Properties.Settings.Default.dashboard_sklad_kolacja);
            MessageBox.Show("Zapisano jadłospis szablonu");
            this.NavigationService.GoBack();
        }
    }
}
