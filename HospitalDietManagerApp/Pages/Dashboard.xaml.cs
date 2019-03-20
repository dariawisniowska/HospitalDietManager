using HospitalDietManagerApp.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private string remember_kategoria;
        private Diet wybrana_dieta;
        private List<Product> ListaProduktow;

        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection EnergiaCollection { get; set; }

        public Dashboard()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Śniadanie",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
                 new PieSeries
                {
                    Title = "II Śniadanie",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
                 new PieSeries
                {
                    Title = "Obiad",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
                 new PieSeries
                {
                    Title = "Podwieczorek",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
                 new PieSeries
                {
                    Title = "Kolacja",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
            };
            EnergiaCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Białko",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
                 new PieSeries
                {
                    Title = "Tłuszcze",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
                 new PieSeries
                {
                    Title = "Węglowodany przyswajalne",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                },
                   new PieSeries
                {
                    Title = "Inne",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = false
                }
            };

            DataContext = this;

            ListaProduktow = DAO.ProductsDAO.SelectAll().OrderBy(x => x.nazwa).ToList();
            produkty.ItemsSource = ListaProduktow.Select(x => x.nazwa);

            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);

            posilki.SelectedIndex = Properties.Settings.Default.recepie_tab;

            miasto.SelectedIndex = Properties.Settings.Default.dashboard_unit;
            dieta.SelectedIndex = Properties.Settings.Default.dashboard_diet;
            kategoria.SelectedIndex = Properties.Settings.Default.dashboard_kategoria;

            if (Properties.Settings.Default.dashboard_date == new DateTime(2000, 1, 1))
                data.SelectedDate = DateTime.Now;
            else
                data.SelectedDate = Properties.Settings.Default.dashboard_date;

            nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_sniadanie;
            nazwa_IIsniadanie.Text = Properties.Settings.Default.dashboard_nazwa_IIsniadanie;
            nazwa_obiad.Text = Properties.Settings.Default.dashboard_nazwa_obiad;
            nazwa_podwieczorek.Text = Properties.Settings.Default.dashboard_nazwa_podwieczorek;
            nazwa_kolacja.Text = Properties.Settings.Default.dashboard_nazwa_kolacja;

            LoadMenu();

            LiczSrednia();
        }      

        public void LoadMenu()
        {
            string sklad_sniadanie = Properties.Settings.Default.dashboard_sklad_sniadanie;
            string[] produkty = sklad_sniadanie.Split('$');
            for (int i = 0; i < produkty.Length - 1; i++)
            {
                string[] arr = produkty[i].Split('|');
                Product produkt;
                if (arr.Length==8)
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                 else
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[6]), double.Parse(arr[9]), double.Parse(arr[5]), double.Parse(arr[7]), double.Parse(arr[8]));
                sniadanie.Items.Add(produkt);
            }

            string sklad_IIsniadanie = Properties.Settings.Default.dashboard_sklad_IIsniadanie;
            produkty = sklad_IIsniadanie.Split('$');
            for (int i = 0; i < produkty.Length - 1; i++)
            {
                string[] arr = produkty[i].Split('|');
                Product produkt;
                if (arr.Length == 8)
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                else
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[6]), double.Parse(arr[9]), double.Parse(arr[5]), double.Parse(arr[7]), double.Parse(arr[8]));
                IIsniadanie.Items.Add(produkt);
            }

            string sklad_obiad = Properties.Settings.Default.dashboard_sklad_obiad;
            produkty = sklad_obiad.Split('$');
            for (int i = 0; i < produkty.Length - 1; i++)
            {
                string[] arr = produkty[i].Split('|');
                Product produkt;
                if (arr.Length == 8)
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                else
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[6]), double.Parse(arr[9]), double.Parse(arr[5]), double.Parse(arr[7]), double.Parse(arr[8]));
                obiad.Items.Add(produkt);
            }

            string sklad_podwieczorek = Properties.Settings.Default.dashboard_sklad_podwieczorek;
            produkty = sklad_podwieczorek.Split('$');
            for (int i = 0; i < produkty.Length - 1; i++)
            {
                string[] arr = produkty[i].Split('|');
                Product produkt;
                if (arr.Length == 8)
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                else
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[6]), double.Parse(arr[9]), double.Parse(arr[5]), double.Parse(arr[7]), double.Parse(arr[8]));
                podwieczorek.Items.Add(produkt);
            }

            string sklad_kolacja = Properties.Settings.Default.dashboard_sklad_kolacja;
            produkty = sklad_kolacja.Split('$');
            for (int i = 0; i < produkty.Length - 1; i++)
            {
                string[] arr = produkty[i].Split('|');
                Product produkt;
                if (arr.Length == 8)
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                else
                    produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[6]), double.Parse(arr[9]), double.Parse(arr[5]), double.Parse(arr[7]), double.Parse(arr[8]));
                kolacja.Items.Add(produkt);
            }

            if (Properties.Settings.Default.recepie_sklad != "")
            {
                string sklad = Properties.Settings.Default.recepie_sklad;
                produkty = sklad.Split('$');
                switch (Properties.Settings.Default.recepie_tab)
                {
                    case 0:
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
                        break;
                    case 1:
                        for (int i = 0; i < produkty.Length - 1; i++)
                        {
                            string[] arr = produkty[i].Split('|');
                            Product produkt;
                            if (arr.Length == 8)
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                            else
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), double.Parse(arr[8]), double.Parse(arr[9]));
                            IIsniadanie.Items.Add(produkt);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < produkty.Length - 1; i++)
                        {
                            string[] arr = produkty[i].Split('|');
                            Product produkt;
                            if (arr.Length == 8)
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                            else
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), double.Parse(arr[8]), double.Parse(arr[9]));
                            obiad.Items.Add(produkt);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < produkty.Length - 1; i++)
                        {
                            string[] arr = produkty[i].Split('|');
                            Product produkt;
                            if (arr.Length == 8)
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                            else
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), double.Parse(arr[8]), double.Parse(arr[9]));
                            podwieczorek.Items.Add(produkt);
                        }
                        break;
                    case 4:
                        for (int i = 0; i < produkty.Length - 1; i++)
                        {
                            string[] arr = produkty[i].Split('|');
                            Product produkt;
                            if (arr.Length == 8)
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                            else
                                produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), double.Parse(arr[8]), double.Parse(arr[9]));
                            kolacja.Items.Add(produkt);
                        }
                        break;
                }
                Properties.Settings.Default.recepie_sklad = "";
            }
        }

        public void PodzialEnergii(double sniadanie, double IIsniadanie, double obiad, double podwieczorek, double kolacja)
        {
            SeriesCollection[0].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(sniadanie,2)) };
            SeriesCollection[1].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(IIsniadanie, 2)) };
            SeriesCollection[2].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(obiad, 2)) };
            SeriesCollection[3].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(podwieczorek, 2)) };
            SeriesCollection[4].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(kolacja, 2)) };
        }

        public void PodzialEnergii2(double bialko, double tluszcze, double weglowodany_przyswajalne, double reszta)
        {
            EnergiaCollection[0].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(bialko, 2)) };
            EnergiaCollection[1].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(tluszcze, 2)) };
            EnergiaCollection[2].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(weglowodany_przyswajalne, 2)) };
            EnergiaCollection[3].Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(reszta, 2)) };
        }

        public void WartosciOdzywcze()
        {
            energia.To = wybrana_dieta.wartosciOdzywcze.energia;
            bialko.To = wybrana_dieta.wartosciOdzywcze.bialko;
            weglowodany.To = wybrana_dieta.wartosciOdzywcze.weglowodany;
            weglowodany_przyswajalne.To = wybrana_dieta.wartosciOdzywcze.weglowodany_przyswajalne;
            tluszcze.To = wybrana_dieta.wartosciOdzywcze.tluszcze;
            ktn.To = wybrana_dieta.wartosciOdzywcze.tluszcze_nn;
            blonnik.To = wybrana_dieta.wartosciOdzywcze.blonnik;
            sod.To = wybrana_dieta.wartosciOdzywcze.sod;
        }

        public void LiczSrednia()
        {
            double[] suma = new double[8];
            double[] suma_sniadanie = new double[8];
            foreach (Product p in sniadanie.Items)
            {
                suma_sniadanie[0] += p.energia;
                suma_sniadanie[1] += p.bialko;
                suma_sniadanie[2] += p.tluszcze;
                suma_sniadanie[3] += p.tluszcze_nn;
                suma_sniadanie[4] += p.weglowodany;
                suma_sniadanie[5] += p.weglowodany_przyswajalne;
                suma_sniadanie[6] += p.blonnik;
                suma_sniadanie[7] += p.sod;
                suma[0] += p.energia;
                suma[1] += p.bialko;
                suma[2] += p.tluszcze;
                suma[3] += p.tluszcze_nn;
                suma[4] += p.weglowodany;
                suma[5] += p.weglowodany_przyswajalne;
                suma[6] += p.blonnik;
                suma[7] += p.sod;
            }

            double[] suma_IIsniadanie = new double[8];
            foreach (Product p in IIsniadanie.Items)
            {
                suma_IIsniadanie[0] += p.energia;
                suma_IIsniadanie[1] += p.bialko;
                suma_IIsniadanie[2] += p.tluszcze;
                suma_IIsniadanie[3] += p.tluszcze_nn;
                suma_IIsniadanie[4] += p.weglowodany;
                suma_IIsniadanie[5] += p.weglowodany_przyswajalne;
                suma_IIsniadanie[6] += p.blonnik;
                suma_IIsniadanie[7] += p.sod;
                suma[0] += p.energia;
                suma[1] += p.bialko;
                suma[2] += p.tluszcze;
                suma[3] += p.tluszcze_nn;
                suma[4] += p.weglowodany;
                suma[5] += p.weglowodany_przyswajalne;
                suma[6] += p.blonnik;
                suma[7] += p.sod;
            }

            double[] suma_obiad = new double[8];
            foreach (Product p in obiad.Items)
            {
                suma_obiad[0] += p.energia;
                suma_obiad[1] += p.bialko;
                suma_obiad[2] += p.tluszcze;
                suma_obiad[3] += p.tluszcze_nn;
                suma_obiad[4] += p.weglowodany;
                suma_obiad[5] += p.weglowodany_przyswajalne;
                suma_obiad[6] += p.blonnik;
                suma_obiad[7] += p.sod;
                suma[0] += p.energia;
                suma[1] += p.bialko;
                suma[2] += p.tluszcze;
                suma[3] += p.tluszcze_nn;
                suma[4] += p.weglowodany;
                suma[5] += p.weglowodany_przyswajalne;
                suma[6] += p.blonnik;
                suma[7] += p.sod;
            }

            double[] suma_podwieczorek = new double[8];
            foreach (Product p in podwieczorek.Items)
            {
                suma_podwieczorek[0] += p.energia;
                suma_podwieczorek[1] += p.bialko;
                suma_podwieczorek[2] += p.tluszcze;
                suma_podwieczorek[3] += p.tluszcze_nn;
                suma_podwieczorek[4] += p.weglowodany;
                suma_podwieczorek[5] += p.weglowodany_przyswajalne;
                suma_podwieczorek[6] += p.blonnik;
                suma_podwieczorek[7] += p.sod;
                suma[0] += p.energia;
                suma[1] += p.bialko;
                suma[2] += p.tluszcze;
                suma[3] += p.tluszcze_nn;
                suma[4] += p.weglowodany;
                suma[5] += p.weglowodany_przyswajalne;
                suma[6] += p.blonnik;
                suma[7] += p.sod;
            }

            double[] suma_kolacja = new double[8];
            foreach (Product p in kolacja.Items)
            {
                suma_kolacja[0] += p.energia;
                suma_kolacja[1] += p.bialko;
                suma_kolacja[2] += p.tluszcze;
                suma_kolacja[3] += p.tluszcze_nn;
                suma_kolacja[4] += p.weglowodany;
                suma_kolacja[5] += p.weglowodany_przyswajalne;
                suma_kolacja[6] += p.blonnik;
                suma_kolacja[7] += p.sod;
                suma[0] += p.energia;
                suma[1] += p.bialko;
                suma[2] += p.tluszcze;
                suma[3] += p.tluszcze_nn;
                suma[4] += p.weglowodany;
                suma[5] += p.weglowodany_przyswajalne;
                suma[6] += p.blonnik;
                suma[7] += p.sod;
            }

            PodzialEnergii(suma_sniadanie[0], suma_IIsniadanie[0], suma_obiad[0], suma_podwieczorek[0], suma_kolacja[0]);
            PodzialEnergii2(suma[1] * MainWindow.przelicznik_Bialko, suma[2] * MainWindow.przelicznik_Tluszcze, suma[5] * MainWindow.przelicznik_Weglowodany, suma[0] - (suma[1] * MainWindow.przelicznik_Bialko) - (suma[2] * MainWindow.przelicznik_Tluszcze) - (suma[5] * MainWindow.przelicznik_Weglowodany));
            
            energia.Value = suma[0];
            bialko.Value = suma[1];
            tluszcze.Value = suma[2];
            ktn.Value = suma[3];
            weglowodany.Value = suma[4];
            weglowodany_przyswajalne.Value = suma[5];
            blonnik.Value = suma[6];
            sod.Value = suma[7];
          
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.dashboard_diet = dieta.SelectedIndex;
            Properties.Settings.Default.dashboard_unit = miasto.SelectedIndex;
            Properties.Settings.Default.dashboard_kategoria = kategoria.SelectedIndex;
            Properties.Settings.Default.dashboard_date = Convert.ToDateTime(data.SelectedDate);

            Properties.Settings.Default.dashboard_nazwa_sniadanie = nazwa_sniadanie.Text;
            Properties.Settings.Default.dashboard_nazwa_IIsniadanie = nazwa_IIsniadanie.Text;
            Properties.Settings.Default.dashboard_nazwa_obiad = nazwa_obiad.Text;
            Properties.Settings.Default.dashboard_nazwa_podwieczorek = nazwa_podwieczorek.Text;
            Properties.Settings.Default.dashboard_nazwa_kolacja = nazwa_kolacja.Text;

            Properties.Settings.Default.recepie_tab = posilki.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        private void kategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int wybor = kategoria.SelectedIndex;
            switch (wybor)
            {
                case 0:
                    produkty.ItemsSource = ListaProduktow.Select(x => x.nazwa);
                    remember_kategoria = "Wszystkie";
                    break;
                case 1:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'B').Select(x => x.nazwa);
                    remember_kategoria = "B";
                    break;
                case 2:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'M').Select(x => x.nazwa);
                    remember_kategoria = "M";
                    break;
                case 3:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'P').Select(x => x.nazwa);
                    remember_kategoria = "P";
                    break;
                case 4:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'N').Select(x => x.nazwa);
                    remember_kategoria = "N";
                    break;
                case 5:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'O').Select(x => x.nazwa);
                    remember_kategoria = "O";
                    break;
                case 6:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'W').Select(x => x.nazwa);
                    remember_kategoria = "W";
                    break;
                case 7:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'R').Select(x => x.nazwa);
                    remember_kategoria = "R";
                    break;
                case 8:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'T').Select(x => x.nazwa);
                    remember_kategoria = "T";
                    break;
                case 9:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'S').Select(x => x.nazwa);
                    remember_kategoria = "S";
                    break;
                case 10:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'D').Select(x => x.nazwa);
                    remember_kategoria = "D";
                    break;
                case 11:
                    produkty.ItemsSource = ListaProduktow.Where(x => x.kategoria == 'Z').Select(x => x.nazwa);
                    remember_kategoria = "Z";
                    break;
            }
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] customOrder = { "Dieta podstawowa", "Dieta łatwostrawna", "Dieta z ograniczeniem łatwo przyswajalnych węglowodanów", "Dieta bogatobiałkowa", "Dieta łatwostrawna z ograniczeniem tłuszczu", "Dieta łatwostrawna z ograniczeniem substancji pobudzających wydzielanie soku żołądkowego", "Dieta łatwostrawna o zmienionej konsystencji - papkowata" };
            dieta.ItemsSource = DAO.DietsDAO.SelectAll(miasto.SelectedValue.ToString()).OrderBy(x => Array.IndexOf(customOrder,x.nazwa)).Select(x => x.nazwa).ToList();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (produkty.SelectedIndex != -1)
            {
                if (masa.Text != "")
                {
                    try
                    {
                        double wpisana_masa = Math.Round(double.Parse(masa.Text), 2);
                        int posilek = Int32.Parse(posilki.SelectedIndex.ToString());
                        int ktory = produkty.SelectedIndex;
                        Product produkt;

                        switch (remember_kategoria)
                        {
                            case "Wszystkie":
                                produkt = new Product(wpisana_masa, ListaProduktow[ktory].nazwa, Math.Round(ListaProduktow[ktory].wartosciOdzywcze.energia * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow[ktory].wartosciOdzywcze.bialko * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow[ktory].wartosciOdzywcze.tluszcze * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow[ktory].wartosciOdzywcze.weglowodany * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow[ktory].wartosciOdzywcze.sod * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow[ktory].wartosciOdzywcze.tluszcze_nn * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow[ktory].wartosciOdzywcze.weglowodany_przyswajalne * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow[ktory].wartosciOdzywcze.blonnik * wpisana_masa / 100.0, 2));
                                break;
                            default:
                                produkt = new Product(wpisana_masa, ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].nazwa, Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.energia * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.bialko * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.tluszcze * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.weglowodany * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.sod * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.tluszcze_nn * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.weglowodany_przyswajalne * wpisana_masa / 100.0, 2), Math.Round(ListaProduktow.Where(x => x.kategoria == remember_kategoria[0]).ToList()[ktory].wartosciOdzywcze.blonnik * wpisana_masa / 100.0, 2));
                                break;
                        }

                        switch (posilek)
                        {
                            case 0:
                                sniadanie.Items.Add(produkt);
                                break;
                            case 1:
                                IIsniadanie.Items.Add(produkt);
                                break;
                            case 2:
                                obiad.Items.Add(produkt);
                                break;
                            case 3:
                                podwieczorek.Items.Add(produkt);
                                break;
                            case 4:
                                kolacja.Items.Add(produkt);
                                break;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowa wartość", "Błąd");
                    }
                    LiczSrednia();
                }
                else
                {
                    MessageBox.Show("Nie wpisano masy produktu", "Błąd");
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano produktu", "Błąd");
            }
        }

        private void edytuj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tab = posilki.SelectedIndex;
                int wybrany;
                double wpisana_masa;
                Product produkt, produkt_przed;
                
                switch (tab)
                {
                    case 0:
                        wybrany = sniadanie.SelectedIndex;
                        wpisana_masa = double.Parse(masa.Text);
                        produkt_przed = sniadanie.Items.Cast<Product>().ToList()[0];
                        produkt = new Product(wpisana_masa,produkt_przed.nazwa, Math.Round(wpisana_masa * produkt_przed.energia / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.bialko / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.sod / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze_nn / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany_przyswajalne / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.blonnik / produkt_przed.masa, 2));      
                        sniadanie.Items.Remove(sniadanie.Items[wybrany]);
                        sniadanie.Items.Insert(wybrany, produkt);                        
                        break;
                    case 1:
                        wybrany = IIsniadanie.SelectedIndex;
                        wpisana_masa = double.Parse(masa.Text);
                        produkt_przed = IIsniadanie.Items.Cast<Product>().ToList()[0];
                        produkt = new Product(wpisana_masa, produkt_przed.nazwa, Math.Round(wpisana_masa * produkt_przed.energia / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.bialko / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.sod / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze_nn / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany_przyswajalne / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.blonnik / produkt_przed.masa, 2));
                        IIsniadanie.Items.Remove(IIsniadanie.Items[wybrany]);
                        IIsniadanie.Items.Insert(wybrany, produkt);
                        break;
                    case 2:
                        wybrany = obiad.SelectedIndex;
                        wpisana_masa = double.Parse(masa.Text);
                        produkt_przed = obiad.Items.Cast<Product>().ToList()[0];
                        produkt = new Product(wpisana_masa, produkt_przed.nazwa, Math.Round(wpisana_masa * produkt_przed.energia / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.bialko / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.sod / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze_nn / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany_przyswajalne / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.blonnik / produkt_przed.masa, 2));
                        obiad.Items.Remove(obiad.Items[wybrany]);
                        obiad.Items.Insert(wybrany, produkt);
                        break;
                    case 3:
                        wybrany = podwieczorek.SelectedIndex;
                        wpisana_masa = double.Parse(masa.Text);
                        produkt_przed = podwieczorek.Items.Cast<Product>().ToList()[0];
                        produkt = new Product(wpisana_masa, produkt_przed.nazwa, Math.Round(wpisana_masa * produkt_przed.energia / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.bialko / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.sod / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze_nn / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany_przyswajalne / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.blonnik / produkt_przed.masa, 2));
                        podwieczorek.Items.Remove(podwieczorek.Items[wybrany]);
                        podwieczorek.Items.Insert(wybrany, produkt);
                        break;
                    case 4:
                        wybrany = kolacja.SelectedIndex;
                        wpisana_masa = double.Parse(masa.Text);
                        produkt_przed = kolacja.Items.Cast<Product>().ToList()[0];
                        produkt = new Product(wpisana_masa, produkt_przed.nazwa, Math.Round(wpisana_masa * produkt_przed.energia / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.bialko / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.sod / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.tluszcze_nn / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.weglowodany_przyswajalne / produkt_przed.masa, 2), Math.Round(wpisana_masa * produkt_przed.blonnik / produkt_przed.masa, 2));
                        kolacja.Items.Remove(kolacja.Items[wybrany]);
                        kolacja.Items.Insert(wybrany, produkt);
                        break;
                }
                LiczSrednia();
            }
            catch
            {
                MessageBox.Show("Nie można edytować", "Błąd");
            }
        }

        private void dieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybrana_dieta = DAO.DietsDAO.Select(dieta.SelectedValue.ToString(), miasto.SelectedValue.ToString());
            WartosciOdzywcze();
        }

        private void nazwa_sniadanie_Loaded(object sender, RoutedEventArgs e)
        {
            nazwa_sniadanie.Text = Properties.Settings.Default.dashboard_nazwa_sniadanie;
            if (Properties.Settings.Default.recepie_nazwa != "")
            {
                switch (Properties.Settings.Default.recepie_tab)
                {
                    case 0:
                        nazwa_sniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 1:
                        nazwa_IIsniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 2:
                        nazwa_obiad.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 3:
                        nazwa_podwieczorek.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 4:
                        nazwa_kolacja.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                }
                Properties.Settings.Default.recepie_nazwa = "";
            }
        }

        private void nazwa_IIsniadanie_Loaded(object sender, RoutedEventArgs e)
        {
            nazwa_IIsniadanie.Text = Properties.Settings.Default.dashboard_nazwa_IIsniadanie;
            if (Properties.Settings.Default.recepie_nazwa != "")
            {
                switch (Properties.Settings.Default.recepie_tab)
                {
                    case 0:
                        nazwa_sniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 1:
                        nazwa_IIsniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 2:
                        nazwa_obiad.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 3:
                        nazwa_podwieczorek.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 4:
                        nazwa_kolacja.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                }
                Properties.Settings.Default.recepie_nazwa = "";
            }
        }

        private void nazwa_obiad_Loaded(object sender, RoutedEventArgs e)
        {
            nazwa_obiad.Text = Properties.Settings.Default.dashboard_nazwa_obiad;
            if (Properties.Settings.Default.recepie_nazwa != "")
            {
                switch (Properties.Settings.Default.recepie_tab)
                {
                    case 0:
                        nazwa_sniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 1:
                        nazwa_IIsniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 2:
                        nazwa_obiad.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 3:
                        nazwa_podwieczorek.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 4:
                        nazwa_kolacja.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                }
                Properties.Settings.Default.recepie_nazwa = "";
            }
        }

        private void nazwa_podwieczorek_Loaded(object sender, RoutedEventArgs e)
        {
            nazwa_podwieczorek.Text = Properties.Settings.Default.dashboard_nazwa_podwieczorek;
            if (Properties.Settings.Default.recepie_nazwa != "")
            {
                switch (Properties.Settings.Default.recepie_tab)
                {
                    case 0:
                        nazwa_sniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 1:
                        nazwa_IIsniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 2:
                        nazwa_obiad.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 3:
                        nazwa_podwieczorek.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 4:
                        nazwa_kolacja.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                }
                Properties.Settings.Default.recepie_nazwa = "";
            }
        }

        private void nazwa_kolacja_Loaded(object sender, RoutedEventArgs e)
        {
            nazwa_kolacja.Text = Properties.Settings.Default.dashboard_nazwa_kolacja;
            if (Properties.Settings.Default.recepie_nazwa != "")
            {
                switch (Properties.Settings.Default.recepie_tab)
                {
                    case 0:
                        nazwa_sniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 1:
                        nazwa_IIsniadanie.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 2:
                        nazwa_obiad.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 3:
                        nazwa_podwieczorek.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                    case 4:
                        nazwa_kolacja.Text += Properties.Settings.Default.recepie_nazwa;
                        break;
                }
                Properties.Settings.Default.recepie_nazwa = "";
            }
        }

        private void miasto_Loaded(object sender, RoutedEventArgs e)
        {
            miasto.SelectedIndex = Properties.Settings.Default.dashboard_unit;
        }

        private void dieta_Loaded(object sender, RoutedEventArgs e)
        {
            dieta.SelectedIndex = Properties.Settings.Default.dashboard_diet;
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            int tab = posilki.SelectedIndex;

            switch (tab)
            {
                case 0:
                    sniadanie.Items.RemoveAt(sniadanie.SelectedIndex);
                    break;
                case 1:
                    IIsniadanie.Items.RemoveAt(IIsniadanie.SelectedIndex);
                    break;
                case 2:
                    obiad.Items.RemoveAt(obiad.SelectedIndex);
                    break;
                case 3:
                    podwieczorek.Items.RemoveAt(podwieczorek.SelectedIndex);
                    break;
                case 4:
                    kolacja.Items.RemoveAt(kolacja.SelectedIndex);
                    break;
            }
                LiczSrednia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd usuwania", "Błąd");
            }
        }

        private void w_dol_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tab = posilki.SelectedIndex;

                switch (tab)
                {
                    case 0:
                        int index = sniadanie.SelectedIndex;
                        sniadanie.Items.Insert(sniadanie.SelectedIndex + 2, sniadanie.SelectedItem);
                        sniadanie.Items.RemoveAt(sniadanie.SelectedIndex);
                        sniadanie.SelectedIndex = index + 1;
                        break;
                    case 1:
                        index = IIsniadanie.SelectedIndex;
                        IIsniadanie.Items.Insert(IIsniadanie.SelectedIndex + 2, IIsniadanie.SelectedItem);
                        IIsniadanie.Items.RemoveAt(IIsniadanie.SelectedIndex);
                        IIsniadanie.SelectedIndex = index + 1;
                        break;
                    case 2:
                        index = obiad.SelectedIndex;
                        obiad.Items.Insert(obiad.SelectedIndex + 2, obiad.SelectedItem);
                        obiad.Items.RemoveAt(obiad.SelectedIndex);
                        obiad.SelectedIndex = index + 1;
                        break;
                    case 3:
                        index = podwieczorek.SelectedIndex;
                        podwieczorek.Items.Insert(podwieczorek.SelectedIndex + 2, podwieczorek.SelectedItem);
                        podwieczorek.Items.RemoveAt(podwieczorek.SelectedIndex);
                        podwieczorek.SelectedIndex = index + 1;
                        break;
                    case 4:
                        index = kolacja.SelectedIndex;
                        kolacja.Items.Insert(kolacja.SelectedIndex + 2, kolacja.SelectedItem);
                        kolacja.Items.RemoveAt(kolacja.SelectedIndex);
                        kolacja.SelectedIndex = index + 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przesuwania", "Błąd");
            }
         }
        private void w_gore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tab = posilki.SelectedIndex;

                switch (tab)
                {
                    case 0:
                        int index = sniadanie.SelectedIndex;
                        sniadanie.Items.Insert(sniadanie.SelectedIndex - 1, sniadanie.SelectedItem);
                        sniadanie.Items.RemoveAt(sniadanie.SelectedIndex);
                        sniadanie.SelectedIndex = index - 1;
                        break;
                    case 1:
                     index = IIsniadanie.SelectedIndex;
                    IIsniadanie.Items.Insert(IIsniadanie.SelectedIndex - 1, IIsniadanie.SelectedItem);
                        IIsniadanie.Items.RemoveAt(IIsniadanie.SelectedIndex);
                        sniadanie.SelectedIndex = index - 1;
                        break;
                    case 2:
                     index = obiad.SelectedIndex;
                    obiad.Items.Insert(obiad.SelectedIndex - 1, obiad.SelectedItem);
                        obiad.Items.RemoveAt(obiad.SelectedIndex);
                        sniadanie.SelectedIndex = index - 1;
                        break;
                    case 3:
                    index = podwieczorek.SelectedIndex;
                    podwieczorek.Items.Insert(podwieczorek.SelectedIndex - 1, podwieczorek.SelectedItem);
                        podwieczorek.Items.RemoveAt(podwieczorek.SelectedIndex);
                        sniadanie.SelectedIndex = index - 1;
                        break;
                    case 4:
                    index = kolacja.SelectedIndex;
                    kolacja.Items.Insert(kolacja.SelectedIndex - 1, kolacja.SelectedItem);
                        kolacja.Items.RemoveAt(kolacja.SelectedIndex);
                        sniadanie.SelectedIndex = index - 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przesuwania", "Błąd");
            }
        }

        private void sniadanie_wyczysc_Click(object sender, RoutedEventArgs e)
        {
            sniadanie.Items.Clear();
            nazwa_sniadanie.Text = "";
            LiczSrednia();
        }

        private void IIsniadanie_wyczysc_Click(object sender, RoutedEventArgs e)
        {
            IIsniadanie.Items.Clear();
            nazwa_IIsniadanie.Text = "";
            LiczSrednia();
        }

        private void obiad_wyczysc_Click(object sender, RoutedEventArgs e)
        {
            obiad.Items.Clear();
            nazwa_obiad.Text = "";
            LiczSrednia();
        }

        private void podwieczorek_wyczysc_Click(object sender, RoutedEventArgs e)
        {
            podwieczorek.Items.Clear();
            nazwa_podwieczorek.Text = "";
            LiczSrednia();
        }

        private void kolacja_wyczysc_Click(object sender, RoutedEventArgs e)
        {
            kolacja.Items.Clear();
            nazwa_kolacja.Text = "";
            LiczSrednia();
        }
    }
}
