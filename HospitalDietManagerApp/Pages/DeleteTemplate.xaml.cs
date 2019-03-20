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
    /// Interaction logic for DeleteTemplate.xaml
    /// </summary>
    public partial class DeleteTemplate : Page
    {
        List<Models.Template> listaDekadowek;
        public DeleteTemplate()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);

            miasto.SelectedIndex = Properties.Settings.Default.template_miasto;
            dekadowka.SelectedIndex = Properties.Settings.Default.template_dekadowka;
        }

        private void dekadowka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDekadowek = DAO.TemplatesDAO.Select(miasto.SelectedValue.ToString());
            dekadowka.ItemsSource = listaDekadowek.Select(x => x.nazwa);
        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Models.Template delete = new Models.Template(null, listaDekadowek[dekadowka.SelectedIndex].nazwa, listaDekadowek[dekadowka.SelectedIndex].miasto, listaDekadowek[dekadowka.SelectedIndex].dni, listaDekadowek[dekadowka.SelectedIndex].dzienStart, listaDekadowek[dekadowka.SelectedIndex].listaJadlospisow);
            DAO.TemplatesDAO.Delete(new Models.Template(DAO.TemplatesDAO.SelectId(delete), listaDekadowek[dekadowka.SelectedIndex].nazwa, listaDekadowek[dekadowka.SelectedIndex].miasto, listaDekadowek[dekadowka.SelectedIndex].dni, listaDekadowek[dekadowka.SelectedIndex].dzienStart, listaDekadowek[dekadowka.SelectedIndex].listaJadlospisow));
            MessageBox.Show("Usunięto szablon");
            this.NavigationService.GoBack();
        }
    }
}
