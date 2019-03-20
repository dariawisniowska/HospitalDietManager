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
    /// Interaction logic for EditDiet.xaml
    /// </summary>
    public partial class EditDiet : Page
    {
        List<Diet> listaDiet;
        public EditDiet()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = Properties.Settings.Default.diet_miasto;
            dieta.SelectedIndex = Properties.Settings.Default.diet_dieta;
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            if ( nazwa.Text != "" &&  energia.Text != "" &&  bialko.Text != "" &&  tluszcze.Text != "" &&  weglowodany.Text != "" &&  sod.Text != "" &&  ktn.Text != "" &&  przyswajalne.Text != "" &&  blonnik.Text != "")
            {
                try
                {
                    DAO.DietsDAO.Update(listaDiet[ dieta.SelectedIndex],  nazwa.Text,  miasto.SelectedValue.ToString(), Convert.ToDouble( energia.Text), Convert.ToDouble( bialko.Text), Convert.ToDouble( tluszcze.Text), Convert.ToDouble( weglowodany.Text), Convert.ToDouble( sod.Text), Convert.ToDouble( ktn.Text), Convert.ToDouble( przyswajalne.Text), Convert.ToDouble( blonnik.Text));
                    MessageBox.Show("Edytowano dietę");
                }
                catch
                {
                    MessageBox.Show("Błąd edytowania diety", "Błąd");

                }
            }
            else
                MessageBox.Show("Nie uzupełniono wszystkich danych", "Błąd");
            this.NavigationService.GoBack();
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDiet = DAO.DietsDAO.SelectAll(miasto.SelectedValue.ToString()).OrderBy(x => x.nazwa).ToList();
            string[] customOrder = { "Dieta podstawowa", "Dieta łatwostrawna", "Dieta z ograniczeniem łatwo przyswajalnych węglowodanów", "Dieta bogatobiałkowa", "Dieta łatwostrawna z ograniczeniem tłuszczu", "Dieta łatwostrawna z ograniczeniem substancji pobudzających wydzielanie soku żołądkowego", "Dieta łatwostrawna o zmienionej konsystencji - papkowata" };
            dieta.ItemsSource = listaDiet.OrderBy(x => Array.IndexOf(customOrder, x.nazwa)).Select(x => x.nazwa).ToList();
            dieta.SelectedIndex = 0;
        }

        private void dieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Diet wybrana = listaDiet[dieta.SelectedIndex];
            nazwa.Text = wybrana.nazwa;
            energia.Text = wybrana.wartosciOdzywcze.energia.ToString();
            bialko.Text = wybrana.wartosciOdzywcze.bialko.ToString();
            tluszcze.Text = wybrana.wartosciOdzywcze.tluszcze.ToString();
            ktn.Text = wybrana.wartosciOdzywcze.tluszcze_nn.ToString();
            weglowodany.Text = wybrana.wartosciOdzywcze.weglowodany.ToString();
            przyswajalne.Text = wybrana.wartosciOdzywcze.weglowodany_przyswajalne.ToString();
            blonnik.Text = wybrana.wartosciOdzywcze.blonnik.ToString();
            sod.Text = wybrana.wartosciOdzywcze.sod.ToString();
        }
    }
}
