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
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
        private List<Product> ListaProduktow;
        public EditProduct()
        {
            InitializeComponent();
            ListaProduktow = DAO.ProductsDAO.SelectAll().OrderBy(x => x.nazwa).ToList();
            produkt.ItemsSource = ListaProduktow.Select(x => x.nazwa);
            produkt.SelectedIndex = Properties.Settings.Default.product_produkt;
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            char wybrana_kategoria = 'A';
            try
            {
                if ( kategoria.SelectedIndex != -1 &&  nazwa.Text != "" &&  energia.Text != "" &&  bialko.Text != "" &&  ktn.Text != "" &&  tluszcze.Text != "" &&  weglowodany.Text != "" && przyswajalne.Text != "" && blonnik.Text != "" &&  sod.Text != "")
                {
                    switch ( kategoria.SelectedIndex)
                    {
                        case 0:
                            wybrana_kategoria = 'B';
                            break;
                        case 1:
                            wybrana_kategoria = 'M';
                            break;
                        case 2:
                            wybrana_kategoria = 'P';
                            break;
                        case 3:
                            wybrana_kategoria = 'N';
                            break;
                        case 4:
                            wybrana_kategoria = 'O';
                            break;
                        case 5:
                            wybrana_kategoria = 'W';
                            break;
                        case 6:
                            wybrana_kategoria = 'R';
                            break;
                        case 7:
                            wybrana_kategoria = 'T';
                            break;
                        case 8:
                            wybrana_kategoria = 'S';
                            break;
                        case 9:
                            wybrana_kategoria = 'D';
                            break;
                        case 10:
                            wybrana_kategoria = 'Z';
                            break;
                    }
                    DAO.ProductsDAO.Update(ListaProduktow[produkt.SelectedIndex],  nazwa.Text, wybrana_kategoria, Convert.ToDouble( energia.Text), Convert.ToDouble( bialko.Text), Convert.ToDouble( tluszcze.Text), Convert.ToDouble( weglowodany.Text), Convert.ToDouble( sod.Text), Convert.ToDouble( ktn.Text), Convert.ToDouble(przyswajalne.Text), Convert.ToDouble(blonnik.Text));
                    MessageBox.Show("Edytowano produkt");
                }
                else
                {
                    MessageBox.Show("Nie uzupełniono wszystkich danych", "Błąd");
                }
            }
            catch
            {
                MessageBox.Show("Błąd edycji produktu", "Błąd");
            }
            this.NavigationService.GoBack();
        }

        private void produkt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product wybrany = ListaProduktow[produkt.SelectedIndex];
            switch (wybrany.kategoria)
            {
                case 'B':
                    kategoria.SelectedIndex = 0;
                    break;
                case 'M':
                    kategoria.SelectedIndex = 1;
                    break;
                case 'P':
                    kategoria.SelectedIndex = 2;
                    break;
                case 'N':
                    kategoria.SelectedIndex = 3;
                    break;
                case 'O':
                    kategoria.SelectedIndex = 4;
                    break;
                case 'W':
                    kategoria.SelectedIndex = 5;
                    break;
                case 'R':
                    kategoria.SelectedIndex = 6;
                    break;
                case 'T':
                    kategoria.SelectedIndex = 7;
                    break;
                case 'S':
                    kategoria.SelectedIndex = 8;
                    break;
                case 'D':
                    kategoria.SelectedIndex = 9;
                    break;
                case 'Z':
                    kategoria.SelectedIndex = 10;
                    break;
            }
            nazwa.Text = wybrany.nazwa;
            energia.Text = wybrany.wartosciOdzywcze.energia.ToString();
            bialko.Text = wybrany.wartosciOdzywcze.bialko.ToString();
            tluszcze.Text = wybrany.wartosciOdzywcze.tluszcze.ToString();
            ktn.Text = wybrany.wartosciOdzywcze.tluszcze_nn.ToString();
            weglowodany.Text = wybrany.wartosciOdzywcze.weglowodany.ToString();
            przyswajalne.Text = wybrany.wartosciOdzywcze.weglowodany_przyswajalne.ToString();
            blonnik.Text = wybrany.wartosciOdzywcze.blonnik.ToString();
            sod.Text = wybrany.wartosciOdzywcze.sod.ToString();
        }
    }
}
