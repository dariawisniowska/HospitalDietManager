using HospitalDietManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace HospitalDietManagerApp.DAO
{
    class TemplateMenusDAO
    {
        public static void Insert(int identyfikatorDekadowki, int dzien, Diet dieta, string nazwa_sniadanie, string nazwa_IIsniadanie, string nazwa_obiad, string nazwa_podwieczorek, string nazwa_kolacja, string sklad_sniadanie, string sklad_IIsniadanie, string sklad_obiad, string sklad_podwieczorek, string sklad_kolacja)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            DataTable dataTable = DataSet.Tables["Jadlospis"];
            DataRow dataRow = dataTable.NewRow();
            dataRow["Dieta"] = dieta.nazwa;
            dataRow["Nazwa-Śniadanie"] = nazwa_sniadanie;
            dataRow["Skład-Śniadanie"] = sklad_sniadanie;
            dataRow["Nazwa-IIŚniadanie"] = nazwa_IIsniadanie;
            dataRow["Skład-IIŚniadanie"] = sklad_IIsniadanie;
            dataRow["Nazwa-Obiad"] = nazwa_obiad;
            dataRow["Skład-Obiad"] = sklad_obiad;
            dataRow["Nazwa-Podwieczorek"] = nazwa_podwieczorek;
            dataRow["Skład-Podwieczorek"] = sklad_podwieczorek;
            dataRow["Nazwa-Kolacja"] = nazwa_kolacja;
            dataRow["Skład-Kolacja"] = sklad_kolacja;
            dataTable.Rows.Add(dataRow);
            DataSet.WriteXml(XML_Location);

            int identyfikatorJadlospisu = SelectId(new Menu(null, dzien, dieta, nazwa_sniadanie, nazwa_IIsniadanie, nazwa_obiad, nazwa_podwieczorek, nazwa_kolacja, sklad_sniadanie, sklad_IIsniadanie, sklad_obiad, sklad_podwieczorek, sklad_kolacja));

            Check(identyfikatorDekadowki, dzien, dieta.nazwa);

            DataSet = new KalkulatorDietyDatabase();
            DataSet.ReadXml(XML_Location);
            dataTable = DataSet.Tables["JadlsopisDekadowki"];
            dataRow = dataTable.NewRow();
            dataRow["IdentyfikatorDekadowki"] = identyfikatorDekadowki;
            dataRow["IdentyfikatorJadlospisu"] = identyfikatorJadlospisu;
            dataRow["Dzien"] = dzien;
            dataTable.Rows.Add(dataRow);
            DataSet.WriteXml(XML_Location);
        }

        public static void Check(int identyfikatorDekadowki, int dzien, string dieta)
        {
            List<int> listaIdentyfikatorowJadlospisowDekadowki = new List<int>();
            List<int> listaIndexow = new List<int>();
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);

            for (int i = 0; i < DataSet.JadlsopisDekadowki.Rows.Count; i++)
            {
                if (DataSet.Tables["JadlsopisDekadowki"].Rows[i]["IdentyfikatorDekadowki"].ToString() == identyfikatorDekadowki.ToString() && DataSet.Tables["JadlsopisDekadowki"].Rows[i]["Dzien"].ToString() == dzien.ToString())
                {
                    listaIdentyfikatorowJadlospisowDekadowki.Add(Convert.ToInt32(DataSet.Tables["JadlsopisDekadowki"].Rows[i]["IdentyfikatorJadlospisu"]));
                    listaIndexow.Add(i);
                }
            }


            for (int i = 0; i < DataSet.Jadlospis.Rows.Count; i++)
            {
                if (listaIdentyfikatorowJadlospisowDekadowki.Contains(Convert.ToInt32(DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"].ToString())))
                {
                    if (DataSet.Tables["Jadlospis"].Rows[i]["Dieta"].ToString() == dieta)
                    {

                        for (int j = 0; j < DataSet.JadlsopisDekadowki.Rows.Count; j++)
                        {
                            if (DataSet.Tables["JadlsopisDekadowki"].Rows[j]["IdentyfikatorDekadowki"].ToString() == identyfikatorDekadowki.ToString() && DataSet.Tables["JadlsopisDekadowki"].Rows[j]["IdentyfikatorJadlospisu"].ToString() == DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"].ToString())
                            {
                                DataSet.JadlsopisDekadowki.Rows.RemoveAt(j);
                                Delete(Convert.ToInt32(DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"].ToString()));
                            }
                        }
                    }
                }
            }
        }

        public static void Delete(int identyfikatorJadlospisu)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            for (int i = 0; i < DataSet.Jadlospis.Rows.Count; i++)
            {
                if (DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"].ToString() == identyfikatorJadlospisu.ToString())
                {
                    DataSet.Tables["Jadlospis"].Rows[i].Delete();
                }
            }

            for (int i = 0; i < DataSet.JadlsopisDekadowki.Rows.Count; i++)
            {
                if (DataSet.Tables["JadlsopisDekadowki"].Rows[i]["IdentyfikatorJadlospisu"].ToString() == identyfikatorJadlospisu.ToString())
                {
                    DataSet.Tables["JadlsopisDekadowki"].Rows[i].Delete();
                }
            }
            DataSet.WriteXml(XML_Location);
        }

        public static int SelectId(Menu jadlospis)
        {
            int identyfikatorJadlospisu = 0;
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            for (int i = 0; i < DataSet.Jadlospis.Rows.Count; i++)
            {
                if (DataSet.Tables["Jadlospis"].Rows[i]["Dieta"].ToString() == jadlospis.dieta.nazwa && DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Śniadanie"].ToString() == jadlospis.nazwa_sniadanie && DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-IIŚniadanie"].ToString() == jadlospis.nazwa_IIsniadanie && DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Obiad"].ToString() == jadlospis.nazwa_obiad && DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Podwieczorek"].ToString() == jadlospis.nazwa_podwieczorek && DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Kolacja"].ToString() == jadlospis.nazwa_kolacja && DataSet.Tables["Jadlospis"].Rows[i]["Skład-Śniadanie"].ToString() == jadlospis.sklad_sniadanie && DataSet.Tables["Jadlospis"].Rows[i]["Skład-IIŚniadanie"].ToString() == jadlospis.sklad_IIsniadanie && DataSet.Tables["Jadlospis"].Rows[i]["Skład-Obiad"].ToString() == jadlospis.sklad_obiad && DataSet.Tables["Jadlospis"].Rows[i]["Skład-Podwieczorek"].ToString() == jadlospis.sklad_podwieczorek && DataSet.Tables["Jadlospis"].Rows[i]["Skład-Kolacja"].ToString() == jadlospis.sklad_kolacja)
                {
                    identyfikatorJadlospisu = Convert.ToInt32(DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"]);
                }
            }
            return identyfikatorJadlospisu;
        }

        public static Menu SelectFromId(int id)
        {
            Menu jadlospis = null;
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            for (int i = 0; i < DataSet.Jadlospis.Rows.Count; i++)
            {
                if (DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"].ToString() == id.ToString())
                {
                    jadlospis = new Menu(DataSet.Jadłospisy.Rows[i]["Data"].ToString(), DAO.DietsDAO.Select(DataSet.Jadłospisy.Rows[i]["Dieta"].ToString(), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString()), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Kolacja"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Kolacja"].ToString());
                }
            }
            return jadlospis;
        }

        public static List<Menu> SelectForDay(int identyfikatorDekadowki, int dzien)
        {
            List<Menu> listaJadlospisow = new List<Menu>();
            List<int> listaIdentyfikatorowJadlospisowDekadowki = new List<int>();
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);

            Template dekadowka = TemplatesDAO.SelectFromId(identyfikatorDekadowki);
            //for (int i = 0; i < DataSet.JadlsopisDekadowki.Rows.Count; i++)
            //{
            //    if (DataSet.Tables["JadlsopisDekadowki"].Rows[i]["IdentyfikatorDekadowki"].ToString() == identyfikatorDekadowki.ToString() && DataSet.Tables["JadlsopisDekadowki"].Rows[i]["Dzien"].ToString() == dzien.ToString())
            //    {
            //        listaIdentyfikatorowJadlospisowDekadowki.Add(Convert.ToInt32(DataSet.Tables["JadlsopisDekadowki"].Rows[i]["IdentyfikatorJadlospisu"]));
            //    }
            //}
           System.Data.EnumerableRowCollection<string> rowCollection = DataSet.JadlsopisDekadowki.Where(x => x.IdentyfikatorDekadowki == identyfikatorDekadowki.ToString() && x.Dzien == dzien.ToString()).Select(x=>x.IdentyfikatorJadlospisu);
            
            for (int i = 0; i < rowCollection.Count(); i++)
            {
                 System.Data.EnumerableRowCollection<KalkulatorDietyDatabase.JadlospisRow> s = DataSet.Jadlospis.Where(x => x.Identyfikator.ToString() == rowCollection.ElementAt(i));
                listaJadlospisow.Add(new Menu(Convert.ToInt32(s.ElementAt(0).Identyfikator), dzien, DietsDAO.Select(s.ElementAt(0).Dieta.ToString(), dekadowka.miasto), s.ElementAt(0)._Nazwa_Śniadanie.ToString(), s.ElementAt(0)._Nazwa_IIŚniadanie.ToString(), s.ElementAt(0)._Nazwa_Obiad.ToString(), s.ElementAt(0)._Nazwa_Podwieczorek.ToString(), s.ElementAt(0)._Nazwa_Kolacja.ToString(), s.ElementAt(0)._Skład_Śniadanie.ToString(), s.ElementAt(0)._Skład_IIŚniadanie.ToString(), s.ElementAt(0)._Skład_Obiad.ToString(), s.ElementAt(0)._Skład_Podwieczorek.ToString(), s.ElementAt(0)._Skład_Kolacja.ToString()));

            }

           //Template dekadowka = TemplatesDAO.SelectFromId(identyfikatorDekadowki);
           // for (int i = 0; i < DataSet.Jadlospis.Rows.Count; i++)
           // {
           //     //if (listaIdentyfikatorowJadlospisowDekadowki.Contains(Convert.ToInt32(DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"].ToString())))
           //     if(rowCollection.Contains(DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"].ToString()))
           //     {
           //         listaJadlospisow.Add(new Menu(Convert.ToInt32(DataSet.Tables["Jadlospis"].Rows[i]["Identyfikator"]), dzien, DietsDAO.Select(DataSet.Tables["Jadlospis"].Rows[i]["Dieta"].ToString(), dekadowka.miasto), DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Śniadanie"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-IIŚniadanie"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Obiad"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Podwieczorek"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Nazwa-Kolacja"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Skład-Śniadanie"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Skład-IIŚniadanie"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Skład-Obiad"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Skład-Podwieczorek"].ToString(), DataSet.Tables["Jadlospis"].Rows[i]["Skład-Kolacja"].ToString()));
           //     }
           // }

            return listaJadlospisow;
        }
    }
}
