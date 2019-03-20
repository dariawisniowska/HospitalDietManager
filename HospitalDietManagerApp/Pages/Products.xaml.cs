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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        private List<Product> ListaProduktow;
        public Products()
        {
            InitializeComponent();
            ListaProduktow = DAO.ProductsDAO.SelectAll().OrderBy(x => x.nazwa).ToList();
            produkt.ItemsSource = ListaProduktow.Select(x => x.nazwa);
            produkt.SelectedIndex = 0;
        }

        private void produkt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product wybrany = ListaProduktow[produkt.SelectedIndex];
            switch(wybrany.kategoria)
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

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.product_produkt = produkt.SelectedIndex;
        }
    }
}
