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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection EnergiaCollection { get; set; }
        private Diet wybrana_dieta;
        public Menu()
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

            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);

            miasto.SelectedIndex = Properties.Settings.Default.dashboard_unit;
            dieta.SelectedIndex = Properties.Settings.Default.dashboard_diet;

            data.SelectedDate = DateTime.Now;
            
            LiczSrednia();
        }

        public void PodzialEnergii(double sniadanie, double IIsniadanie, double obiad, double podwieczorek, double kolacja)
        {
            SeriesCollection[0].Values = new ChartValues<ObservableValue> { new ObservableValue(sniadanie) };
            SeriesCollection[1].Values = new ChartValues<ObservableValue> { new ObservableValue(IIsniadanie) };
            SeriesCollection[2].Values = new ChartValues<ObservableValue> { new ObservableValue(obiad) };
            SeriesCollection[3].Values = new ChartValues<ObservableValue> { new ObservableValue(podwieczorek) };
            SeriesCollection[4].Values = new ChartValues<ObservableValue> { new ObservableValue(kolacja) };
        }

        public void PodzialEnergii2(double bialko, double tluszcze, double weglowodany_przyswajalne, double reszta)
        {
            EnergiaCollection[0].Values = new ChartValues<ObservableValue> { new ObservableValue(bialko) };
            EnergiaCollection[1].Values = new ChartValues<ObservableValue> { new ObservableValue(tluszcze) };
            EnergiaCollection[2].Values = new ChartValues<ObservableValue> { new ObservableValue(weglowodany_przyswajalne) };
            EnergiaCollection[3].Values = new ChartValues<ObservableValue> { new ObservableValue(reszta) };
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
        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dieta.ItemsSource = DAO.DietsDAO.SelectAll(miasto.SelectedValue.ToString()).OrderBy(x => x.nazwa).Select(x => x.nazwa).ToList();
            Aktualizuj();
        }
        private void dieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybrana_dieta = DAO.DietsDAO.Select(dieta.SelectedValue.ToString(), miasto.SelectedValue.ToString());
            WartosciOdzywcze();
            Aktualizuj();
        }

        public void Aktualizuj()
        {
            if (data.SelectedDate != null && miasto.SelectedIndex > -1 && dieta.SelectedIndex > -1)
            {
                string data_format = data.SelectedDate.Value.Day + " " + GetMonth(data.SelectedDate.Value.Month) + " " + data.SelectedDate.Value.Year;
                Models.Menu menu = DAO.MenusDAO.SelectAll(data_format, miasto.SelectedValue.ToString(), dieta.SelectedValue.ToString());

                if (menu != null)
                {
                    sniadanie.Items.Clear();
                    IIsniadanie.Items.Clear();
                    obiad.Items.Clear();
                    podwieczorek.Items.Clear();
                    kolacja.Items.Clear();

                    nazwa_sniadanie.Text = menu.nazwa_sniadanie;
                    nazwa_IIsniadanie.Text = menu.nazwa_IIsniadanie;
                    nazwa_obiad.Text = menu.nazwa_obiad;
                    nazwa_podwieczorek.Text = menu.nazwa_podwieczorek;
                    nazwa_kolacja.Text = menu.nazwa_kolacja;

                    string sklad_sniadanie = menu.sklad_sniadanie;
                    string[] produkty = sklad_sniadanie.Split('$');
                    for (int i = 0; i < produkty.Length - 1; i++)
                    {
                        string[] arr = produkty[i].Split('|');
                        Product produkt;
                        if (arr.Length == 8)
                            produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[5]), double.Parse(arr[6]), double.Parse(arr[7]), 0, 0);
                        else
                            produkt = new Product(double.Parse(arr[1]), arr[0], double.Parse(arr[2]), double.Parse(arr[3]), double.Parse(arr[4]), double.Parse(arr[6]), double.Parse(arr[9]), double.Parse(arr[5]), double.Parse(arr[7]), double.Parse(arr[8]));
                        sniadanie.Items.Add(produkt);
                    }

                    string sklad_IIsniadanie = menu.sklad_IIsniadanie;
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

                    string sklad_obiad = menu.sklad_obiad;
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

                    string sklad_podwieczorek = menu.sklad_podwieczorek;
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

                    string sklad_kolacja = menu.sklad_kolacja;
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

                    LiczSrednia();
                }
            }
          
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

        private void data_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Aktualizuj();
        }
    }
}
