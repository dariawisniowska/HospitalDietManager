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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
        {
            InitializeComponent();
            kategoria.SelectedIndex = 0;
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
                if (kategoria.SelectedIndex != -1 && nazwa.Text != "" && energia.Text != "" && bialko.Text != "" && ktn.Text != "" && tluszcze.Text != "" && weglowodany.Text != "" && przyswajalne.Text != "" && blonnik.Text != "" && sod.Text != "")
                {
                    switch (kategoria.SelectedIndex)
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
                    DAO.ProductsDAO.Insert(nazwa.Text, wybrana_kategoria, Convert.ToDouble(energia.Text), Convert.ToDouble(bialko.Text), Convert.ToDouble(tluszcze.Text), Convert.ToDouble(weglowodany.Text), Convert.ToDouble(sod.Text), Convert.ToDouble(ktn.Text), Convert.ToDouble(przyswajalne.Text), Convert.ToDouble(blonnik.Text));
                    MessageBox.Show("Dodano produkt");
                }
                else
                {
                    MessageBox.Show("Nie uzupełniono wszystkich danych", "Błąd");
                }
            }
            catch
            {
                MessageBox.Show("Błąd dodawania produktu", "Błąd");
            }
            this.NavigationService.GoBack();
        }

        private void przelicz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sol.Text != "")
                    sod.Text = (Double.Parse(sol.Text) / 0.0025).ToString();
            }
            catch
            {
                MessageBox.Show("Błąd przeliczania", "Błąd");
            }
        }
    }
}
