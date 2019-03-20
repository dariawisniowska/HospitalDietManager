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
    /// Interaction logic for ReadRecepie.xaml
    /// </summary>
    public partial class ReadRecepie : Page
    {
        List<Recepie> listaReceptur;
        public ReadRecepie()
        {
            InitializeComponent();
            listaReceptur = DAO.RecepiesDAO.SelectAll();
            receptura.ItemsSource = listaReceptur.Select(x => x.nazwa);
            receptura.SelectedIndex = 0;
        }

        private void receptura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.recepie_nazwa = "";
            Properties.Settings.Default.recepie_sklad = "";
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.recepie_nazwa = listaReceptur[receptura.SelectedIndex].nazwa;
            Properties.Settings.Default.recepie_sklad = listaReceptur[receptura.SelectedIndex].sklad;
            this.NavigationService.GoBack();
        }
    }
}
