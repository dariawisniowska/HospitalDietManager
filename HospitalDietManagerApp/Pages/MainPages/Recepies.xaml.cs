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
    /// Interaction logic for Recepies.xaml
    /// </summary>
    public partial class Recepies : Page
    {
        List<Recepie> listaReceptur;
        public Recepies()
        {
            InitializeComponent();

            listaReceptur = DAO.RecepiesDAO.SelectAll();
            receptura.ItemsSource = listaReceptur.Select(x => x.nazwa);
            receptura.SelectedIndex = 0;
        }

        private void receptura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (receptura.SelectedIndex > -1)
            {
                sniadanie.Items.Clear();
                nazwa_sniadanie.Text = listaReceptur[receptura.SelectedIndex].nazwa;
                string sklad_sniadanie = listaReceptur[receptura.SelectedIndex].sklad;
                string[] produkty = sklad_sniadanie.Split('$');
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
                }

                energia.Value = suma_sniadanie[0];
                bialko.Value = suma_sniadanie[1];
                tluszcze.Value = suma_sniadanie[2];
                ktn.Value = suma_sniadanie[3];
                weglowodany.Value = suma_sniadanie[4];
                weglowodany_przyswajalne.Value = suma_sniadanie[5];
                blonnik.Value = suma_sniadanie[6];
                sod.Value = suma_sniadanie[7];
            }
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            DAO.RecepiesDAO.Delete(listaReceptur[receptura.SelectedIndex]);
            MessageBox.Show("Usunieto recepturę");
            listaReceptur = DAO.RecepiesDAO.SelectAll();
            receptura.ItemsSource = listaReceptur.Select(x => x.nazwa);
            receptura.SelectedIndex = 0;
        }
    }
}
