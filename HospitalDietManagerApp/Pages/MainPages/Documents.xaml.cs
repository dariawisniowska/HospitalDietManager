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
    /// Interaction logic for Documents.xaml
    /// </summary>
    public partial class Documents : Page
    {
        public Documents()
        {
            InitializeComponent();
            dokument.SelectedIndex = 0;
            miasto.ItemsSource = DAO.UnitsDAO.SelectAll().Select(x => x.miasto);
            miasto.SelectedIndex = 0;
        }

        private void dokument_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void miasto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            string data_od_format = data_od.SelectedDate.Value.Day + " " + GetMonth(data_od.SelectedDate.Value.Month) + " " + data_od.SelectedDate.Value.Year;
            string data_do_format = data_do.SelectedDate.Value.Day + " " + GetMonth(data_do.SelectedDate.Value.Month) + " " + data_do.SelectedDate.Value.Year;

            switch (dokument.SelectedIndex)
            {
                case 0:
                    Printer.Dekadowka(miasto.SelectedValue.ToString(), data_od_format, data_do_format, DAO.MenusDAO.SelectAll(data_od_format,data_do_format));
                    MessageBox.Show("Wygenerowano dekadówkę");
                    break;
                case 1:
                    DateTime dateFrom = Convert.ToDateTime(data_od_format);
                    DateTime dateTo = Convert.ToDateTime(data_do_format);
                    for (DateTime data = dateFrom; data <= dateTo; data = data.AddDays(1))
                    {
                        string dt = (data.Day + " " + GetMonth(data.Month) + " " + data.Year).ToString();
                        List<Models.Menu> jad = DAO.MenusDAO.Select(dt, miasto.SelectedValue.ToString());
                        foreach (Models.Menu j in jad)
                            Printer.Jadlospis(j);
                    }
                    MessageBox.Show("Wygenerowano jadłospisy diety w wybranym okresie");
                    break;
                case 2:
                    DateTime dateFrom2 = Convert.ToDateTime(data_od_format);
                    DateTime dateTo2 = Convert.ToDateTime(data_do_format);
                    for (DateTime data = dateFrom2; data <= dateTo2; data = data.AddDays(1))
                    {
                        string dt = (data.Day + " " + GetMonth(data.Month) + " " + data.Year).ToString();
                        Printer.JadlospisDzienny(DAO.MenusDAO.Select(dt, miasto.SelectedValue.ToString()));
                    }
                    MessageBox.Show("Wygenerowano jadłospisy dzienne w wybranym okresie");
                    break;
            }
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
