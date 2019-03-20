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
    /// Interaction logic for Diets.xaml
    /// </summary>
    public partial class Diets : Page
    {
        List<Diet> listaDiet;
        public Diets()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = 0;
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

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDiet = DAO.DietsDAO.SelectAll(miasto.SelectedValue.ToString()).OrderBy(x => x.nazwa).ToList();
            dieta.ItemsSource = listaDiet.Select(x => x.nazwa).ToList();
            dieta.SelectedIndex = 0;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.diet_dieta = dieta.SelectedIndex;
            Properties.Settings.Default.diet_miasto = miasto.SelectedIndex;
        }
    }
}
