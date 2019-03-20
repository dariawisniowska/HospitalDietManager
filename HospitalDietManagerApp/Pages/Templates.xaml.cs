using HospitalDietManagerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Templates.xaml
    /// </summary>
    public partial class Templates : Page
    {
        List<Models.Template> listaDekadowek;
        //private BackgroundWorker bw = new BackgroundWorker();
        //public event PropertyChangedEventHandler propertyChanged;
        //private int workerState { get { return workerState; } set {
        //        workerState = value;
        //        if (propertyChanged != null)
        //            propertyChanged(null, new PropertyChangedEventArgs("WorkerState"));
        //    } }
        public Templates()
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
            ZmienWybor(); 
        }

        public void ZmienWybor()
        {

            if (miasto.SelectedIndex > -1 && dekadowka.SelectedIndex > -1)
            {
                mainPanel.Children.Clear();
                dniPanel.Children.Clear();

                double width = mainPanel.ActualWidth / listaDekadowek[dekadowka.SelectedIndex].dni;
                double height = mainPanel.ActualHeight;

                //bw.DoWork += (s, e) =>
                // {

                     for (int j = 0; j < listaDekadowek[dekadowka.SelectedIndex].dni; j++)
                     {
                         StackPanel dayOfWeek = new StackPanel
                         {
                             Background = Brushes.White,
                             CanVerticallyScroll = true,
                             CanHorizontallyScroll = true,
                             Width = 140,
                             Margin = new Thickness(5, 0, 0, 0)
                         };

                         string day = GetDay(listaDekadowek[dekadowka.SelectedIndex].dzienStart, j + 1);
                         Label myDay = new Label
                         {
                             Content = day,
                             Margin = new Thickness(10, 10, 10, 10),
                             Width = 140
                         };
                         dniPanel.Children.Add(myDay);

                         List<Models.Menu> jadlospisyDanegoDnia = DAO.TemplateMenusDAO.SelectForDay(Convert.ToInt32(listaDekadowek[dekadowka.SelectedIndex].id), j + 1).OrderBy(x => x.dieta.nazwa).ToList();

                         string[] customOrder = { "Dieta podstawowa", "Dieta łatwostrawna", "Dieta z ograniczeniem łatwo przyswajalnych węglowodanów", "Dieta bogatobiałkowa", "Dieta łatwostrawna z ograniczeniem tłuszczu", "Dieta łatwostrawna z ograniczeniem substancji pobudzających wydzielanie soku żołądkowego", "Dieta łatwostrawna o zmienionej konsystencji - papkowata" };
                         jadlospisyDanegoDnia = jadlospisyDanegoDnia.OrderBy(x => Array.IndexOf(customOrder, x.dieta.nazwa)).ToList();

                         foreach (Models.Menu jadlospis in jadlospisyDanegoDnia)
                         {
                             StackPanel myPanel = new StackPanel
                             {
                                 Background = Brushes.LightBlue,
                                 CanVerticallyScroll = false,
                                 CanHorizontallyScroll = true,
                                 Margin = new Thickness(10, 10, 10, 10)
                             };

                             TextBlock diet = new TextBlock
                             {
                                 TextWrapping = TextWrapping.WrapWithOverflow,
                                 Margin = new Thickness(5, 0, 5, 0),
                                 IsEnabled = false
                             };
                             diet.Inlines.Add(new Bold(new Run(jadlospis.dieta.nazwa)));
                             myPanel.Children.Add(diet);

                             TextBlock meal_content = new TextBlock();

                             meal_content = new TextBlock
                             {
                                 Margin = new Thickness(5, 5, 5, 0),
                                 TextWrapping = TextWrapping.WrapWithOverflow,
                                 IsEnabled = false
                             };

                             if (jadlospis.nazwa_sniadanie != "")
                                 meal_content.Text = "Śniadanie: " + jadlospis.nazwa_sniadanie;
                             else
                                 meal_content.Text = "Śniadanie: -";
                             myPanel.Children.Add(meal_content);

                             meal_content = new TextBlock
                             {
                                 Margin = new Thickness(5, 5, 5, 0),
                                 TextWrapping = TextWrapping.WrapWithOverflow,
                                 IsEnabled = false
                             };
                             if (jadlospis.nazwa_IIsniadanie != "")
                                 meal_content.Text = "II śniadanie: " + jadlospis.nazwa_IIsniadanie;
                             else
                                 meal_content.Text = "II śniadanie: -";
                             myPanel.Children.Add(meal_content);

                             meal_content = new TextBlock
                             {
                                 Margin = new Thickness(5, 5, 5, 0),
                                 TextWrapping = TextWrapping.WrapWithOverflow,
                                 IsEnabled = false
                             };
                             if (jadlospis.nazwa_obiad != "")
                                 meal_content.Text = "Obiad: " + jadlospis.nazwa_obiad;
                             else
                                 meal_content.Text = "Obiad: -";
                             myPanel.Children.Add(meal_content);

                             meal_content = new TextBlock
                             {
                                 Margin = new Thickness(5, 5, 5, 0),
                                 TextWrapping = TextWrapping.WrapWithOverflow,
                                 IsEnabled = false
                             };
                             if (jadlospis.nazwa_podwieczorek != "")
                                 meal_content.Text = "Podwieczorek: " + jadlospis.nazwa_podwieczorek;
                             else
                                 meal_content.Text = "Podwieczorek: -";
                             myPanel.Children.Add(meal_content);

                             meal_content = new TextBlock
                             {
                                 Margin = new Thickness(5, 5, 5, 0),
                                 TextWrapping = TextWrapping.WrapWithOverflow,
                                 IsEnabled = false
                             };
                             if (jadlospis.nazwa_kolacja != "")
                                 meal_content.Text = "Kolacja: " + jadlospis.nazwa_kolacja;
                             else
                                 meal_content.Text = "Kolacja: -";
                             myPanel.Children.Add(meal_content);



                             dayOfWeek.Children.Add(myPanel);
                         }

                         ScrollViewer scroll = new ScrollViewer
                         {
                             Content = dayOfWeek
                         };
                         mainPanel.Children.Add(scroll);

                //         workerState = j;
                     }
              //   };
            //    bw.RunWorkerAsync();
            }
        }

        public string GetDay(string dzien, int licznik)
        {
            if (licznik > 1)
            {
                string[] dni = new string[7] { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };
                int licz = 0;
                for (int i = 0; i < dni.Length; i++)
                {
                    if (dni[i] == dzien)
                        licz = i;
                }

                int j = 0;
                int odliczanie = 1;
                for (int i = 0; i < dni.Length; i++)
                {
                    if (j > licz)
                    {
                        string kolejnyDzien = dni[i];

                        if (odliczanie == licznik - 1)
                            return kolejnyDzien;

                        odliczanie++;
                    }
                    j++;

                    if (i == 6)
                        i = -1;
                }

                return "";
            }
            else
                return dzien;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.template_miasto = miasto.SelectedIndex;
            Properties.Settings.Default.template_dekadowka = dekadowka.SelectedIndex;

            Properties.Settings.Default.Save();
        }
    }
}
