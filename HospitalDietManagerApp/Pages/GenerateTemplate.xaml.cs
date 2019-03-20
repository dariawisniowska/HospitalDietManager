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
    /// Interaction logic for GenerateTemplate.xaml
    /// </summary>
    public partial class GenerateTemplate : Page
    {
        List<Models.Template> listaDekadowek;
        public GenerateTemplate()
        {
            InitializeComponent();
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = 0;
            dekadowka.SelectedIndex = 0;
        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaDekadowek = DAO.TemplatesDAO.Select(miasto.SelectedValue.ToString());
            dekadowka.ItemsSource = listaDekadowek.Select(x => x.nazwa);
        }

        private void dekadowka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {            
            List<string> daty = new List<string>();
            string data_format_od = dataOd.SelectedDate.Value.Day + " " + GetMonth(dataOd.SelectedDate.Value.Month) + " " + dataOd.SelectedDate.Value.Year;
            string data_format_do = dataDo.SelectedDate.Value.Day + " " + GetMonth(dataDo.SelectedDate.Value.Month) + " " + dataDo.SelectedDate.Value.Year;
            int dni = (Convert.ToDateTime(data_format_od) - Convert.ToDateTime(data_format_do)).Days + 1;

            if (dni == listaDekadowek[dekadowka.SelectedIndex].dni)
            {
                DateTime data = Convert.ToDateTime(data_format_od);
                for (int i = 0; i < dni; i++)
                {
                    string aktualna_data = data.Day + " " + GetMonth(data.Month) + " " + data.Year;
                    List<Models.Menu> jadlospisyDanegoDnia = DAO.TemplateMenusDAO.SelectForDay(Convert.ToInt32(listaDekadowek[dekadowka.SelectedIndex].id), i + 1);
                    foreach (Models.Menu jadlospis in jadlospisyDanegoDnia)
                    {
                        if (jadlospis.dzien == i + 1)
                            DAO.MenusDAO.Insert(aktualna_data, jadlospis.dieta.nazwa, listaDekadowek[dekadowka.SelectedIndex].miasto, jadlospis.nazwa_sniadanie, jadlospis.nazwa_IIsniadanie, jadlospis.nazwa_obiad, jadlospis.nazwa_podwieczorek, jadlospis.nazwa_kolacja, jadlospis.sklad_sniadanie, jadlospis.sklad_IIsniadanie, jadlospis.sklad_obiad, jadlospis.sklad_podwieczorek, jadlospis.sklad_kolacja);
                    }
                    data = data.AddDays(1);
                }                
            }
            MessageBox.Show("Wygenerowano jadłospisy według szablonu");
            this.NavigationService.GoBack();
        }

        private string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "stycznia";
                case 2:
                    return "lutego";
                case 3:
                    return "marca";
                case 4:
                    return "kwietnia";
                case 5:
                    return "maja";
                case 6:
                    return "czerwca";
                case 7:
                    return "lipca";
                case 8:
                    return "siepnia";
                case 9:
                    return "września";
                case 10:
                    return "października";
                case 11:
                    return "listopada";
                case 12:
                    return "grudnia";
            }
            return "";
        }
    }
}
