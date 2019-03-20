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
    /// Interaction logic for SaveRecepie.xaml
    /// </summary>
    public partial class SaveRecepie : Page
    {
        string sklad;
        public SaveRecepie()
        {
            InitializeComponent();
                switch (Properties.Settings.Default.recepie_tab)
                {
                    case 0:
                        nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_sniadanie;
                        sklad = Properties.Settings.Default.dashboard_sklad_sniadanie;
                    break;
                    case 1:
                        nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_IIsniadanie;
                    sklad = Properties.Settings.Default.dashboard_sklad_IIsniadanie;
                    break;
                    case 2:
                        nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_obiad;
                    sklad = Properties.Settings.Default.dashboard_sklad_obiad;
                    break;
                    case 3:
                        nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_podwieczorek;
                    sklad = Properties.Settings.Default.dashboard_sklad_podwieczorek;
                    break;
                    case 4:
                        nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_kolacja;
                    sklad = Properties.Settings.Default.dashboard_sklad_kolacja;
                    break;
                }
            string[] produkty = sklad.Split('$');
            for (int i = 0; i < produkty.Length - 1; i++)
            {
                string[] arr = produkty[i].Split('|');
                Product produkt;
                if (arr.Length == 8)
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                else
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), double.Parse(arr[8]), double.Parse(arr[9]));
                sniadanie.Items.Add(produkt);
            }
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            DAO.RecepiesDAO.Insert(nazwa_sniadanie.Text, sklad);
            this.NavigationService.GoBack();
        }

        private void nazwa_sniadanie_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.recepie_tab)
            {
                case 0:
                    nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_sniadanie;
                    sklad = Properties.Settings.Default.dashboard_sklad_sniadanie;
                    break;
                case 1:
                    nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_IIsniadanie;
                    sklad = Properties.Settings.Default.dashboard_sklad_IIsniadanie;
                    break;
                case 2:
                    nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_obiad;
                    sklad = Properties.Settings.Default.dashboard_sklad_obiad;
                    break;
                case 3:
                    nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_podwieczorek;
                    sklad = Properties.Settings.Default.dashboard_sklad_podwieczorek;
                    break;
                case 4:
                    nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_kolacja;
                    sklad = Properties.Settings.Default.dashboard_sklad_kolacja;
                    break;
            }
            string[] produkty = sklad.Split('$');
            for (int i = 0; i < produkty.Length - 1; i++)
            {
                string[] arr = produkty[i].Split('|');
                Product produkt;
                if (arr.Length == 8)
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                else
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), double.Parse(arr[8]), double.Parse(arr[9]));
                sniadanie.Items.Add(produkt);
            }
        }
    }
}
