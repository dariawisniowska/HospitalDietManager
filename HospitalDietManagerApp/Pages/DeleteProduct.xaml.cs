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
    /// Interaction logic for DeleteProduct.xaml
    /// </summary>
    public partial class DeleteProduct : Page
    {
        private List<Product> ListaProduktow;
        public DeleteProduct()
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
            DAO.ProductsDAO.Delete(ListaProduktow[produkt.SelectedIndex]);
            MessageBox.Show("Usunieto produkt");
            this.NavigationService.GoBack();
        }
    }
}
