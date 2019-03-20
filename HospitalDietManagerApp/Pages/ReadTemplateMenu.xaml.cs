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
    /// Interaction logic for ReadTemplateMenu.xaml
    /// </summary>
    /// 
    public partial class ReadTemplateMenu : Page
    {
        List<Template> listaDekadowek;
        List<Models.Menu> jadlospisyDanegoDnia;
        public ReadTemplateMenu()
        {
            InitializeComponent();

            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = 0;
            dekadowka.SelectedIndex = 0;
            dzien.SelectedIndex = 0;
            dieta.SelectedIndex = 0;
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
            List<string> diety = new List<string>();
            jadlospisyDanegoDnia = DAO.TemplateMenusDAO.SelectForDay(Convert.ToInt32(listaDekadowek[dekadowka.SelectedIndex].id), dzien.SelectedIndex + 1);
            foreach (Models.Menu d in jadlospisyDanegoDnia)
            {
                if (d.dzien - 1 == dzien.SelectedIndex)
                {
                    diety.Add(d.dieta.nazwa);
                }
            }

            string[] customOrder = { "Dieta podstawowa", "Dieta łatwostrawna", "Dieta z ograniczeniem łatwo przyswajalnych węglowodanów", "Dieta bogatobiałkowa", "Dieta łatwostrawna z ograniczeniem tłuszczu", "Dieta łatwostrawna z ograniczeniem substancji pobudzających wydzielanie soku żołądkowego", "Dieta łatwostrawna o zmienionej konsystencji - papkowata" };
            dieta.ItemsSource = diety.OrderBy(x => Array.IndexOf(customOrder, x));
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDekadowek = DAO.TemplatesDAO.Select(miasto.SelectedValue.ToString());
            dekadowka.ItemsSource = listaDekadowek.Select(x => x.nazwa);
        }

        private void dieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Models.Menu menu = jadlospisyDanegoDnia[dieta.SelectedIndex];

            if (menu != null)
            {
                Properties.Settings.Default.dashboard_nazwa_sniadanie = menu.nazwa_sniadanie;
                Properties.Settings.Default.dashboard_nazwa_IIsniadanie = menu.nazwa_IIsniadanie;
                Properties.Settings.Default.dashboard_nazwa_obiad = menu.nazwa_obiad;
                Properties.Settings.Default.dashboard_nazwa_podwieczorek = menu.nazwa_podwieczorek;
                Properties.Settings.Default.dashboard_nazwa_kolacja = menu.nazwa_kolacja;

                Properties.Settings.Default.dashboard_sklad_sniadanie = menu.sklad_sniadanie;
                Properties.Settings.Default.dashboard_sklad_IIsniadanie = menu.sklad_IIsniadanie;
                Properties.Settings.Default.dashboard_sklad_obiad = menu.sklad_obiad;
                Properties.Settings.Default.dashboard_sklad_podwieczorek = menu.sklad_podwieczorek;
                Properties.Settings.Default.dashboard_sklad_kolacja = menu.sklad_kolacja;

                Properties.Settings.Default.dashboard_diet = dieta.SelectedIndex;
                Properties.Settings.Default.dashboard_unit = miasto.SelectedIndex;

                Properties.Settings.Default.Save();

                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Nie znaleziono jadłospisu", "Błąd");
            }
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
