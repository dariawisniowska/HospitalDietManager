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
    /// Interaction logic for AddDiet.xaml
    /// </summary>
    public partial class AddDiet : Page
    {
        public AddDiet()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = 0;
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            if (nazwa.Text != "" && energia.Text != "" && bialko.Text != "" && tluszcze.Text != "" && weglowodany.Text != "" && sod.Text != "" && ktn.Text != "" && przyswajalne.Text != "" && blonnik.Text != "")
            {
                try
                {
                    DAO.DietsDAO.Insert(nazwa.Text, miasto.SelectedValue.ToString(), Convert.ToDouble(energia.Text), Convert.ToDouble(bialko.Text), Convert.ToDouble(tluszcze.Text), Convert.ToDouble(weglowodany.Text), Convert.ToDouble(sod.Text), Convert.ToDouble(ktn.Text), Convert.ToDouble(przyswajalne.Text), Convert.ToDouble(blonnik.Text));
                    MessageBox.Show("Dodano dietę");
                }
                catch
                {
                    MessageBox.Show("Błąd dodawania diety", "Błąd");

                }
            }
            else
                MessageBox.Show("Nie uzupełniono wszystkich danych", "Błąd");
           
        }

        private void miasto_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
