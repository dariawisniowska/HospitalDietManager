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
    public class MenusDAO
    {
        public static void Insert(string data, string dieta, string miasto, string nazwa_sniadanie, string nazwa_IIsniadanie, string nazwa_obiad, string nazwa_podwieczorek, string nazwa_kolacja, string sklad_sniadanie, string sklad_IIsniadanie, string sklad_obiad, string sklad_podwieczorek, string sklad_kolacja)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            DataTable dataTable = DataSet.Tables["Jadłospisy"];
            DataRow dataRow = dataTable.NewRow();
            dataRow["Data"] = data;
            dataRow["Dieta"] = dieta;
            dataRow["Miasto"] = miasto;
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

        }

        public static void Update(Menu jadlospis, string data, string dieta, string miasto, string nazwa_sniadanie, string nazwa_IIsniadanie, string nazwa_obiad, string nazwa_podwieczorek, string nazwa_kolacja, string sklad_sniadanie, string sklad_IIsniadanie, string sklad_obiad, string sklad_podwieczorek, string sklad_kolacja)
        {
            Delete(data, dieta, miasto);
            Insert(data, dieta, miasto, nazwa_sniadanie, nazwa_IIsniadanie, nazwa_obiad, nazwa_podwieczorek, nazwa_kolacja, sklad_sniadanie, sklad_IIsniadanie, sklad_obiad, sklad_podwieczorek, sklad_kolacja);
        }

        public static void Delete(string data, string miasto, string dieta)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            for (int i = 0; i < DataSet.Jadłospisy.Rows.Count; i++)
            {

                if (DataSet.Tables["Jadłospisy"].Rows[i]["Data"].ToString() == data && DataSet.Tables["Jadłospisy"].Rows[i]["Dieta"].ToString() == dieta && DataSet.Tables["Jadłospisy"].Rows[i]["Miasto"].ToString() == miasto)
                {
                    DataSet.Tables["Jadłospisy"].Rows[i].Delete();
                }

            }
            DataSet.WriteXml(XML_Location);
        }

        public static Menu SelectAll(string data, string miasto, string dieta)
        {
            Menu jadlospis = null;
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Jadłospisy.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Jadłospisy.Rows.Count; i++)
                {
                    if (DataSet.Jadłospisy.Rows[i]["Data"].ToString() == data && DataSet.Jadłospisy.Rows[i]["Dieta"].ToString() == dieta && DataSet.Jadłospisy.Rows[i]["Miasto"].ToString() == miasto)
                        jadlospis = new Menu(DataSet.Jadłospisy.Rows[i]["Data"].ToString(), DAO.DietsDAO.Select(DataSet.Jadłospisy.Rows[i]["Dieta"].ToString(), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString()), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Kolacja"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Kolacja"].ToString());
                }
            }

            return jadlospis;
        }

        public static List<Menu> SelectAll(string dataOd, string dataDo)
        {
            List<Menu> jadlospis = new List<Menu>();
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Jadłospisy.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Jadłospisy.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(DataSet.Jadłospisy.Rows[i]["Data"].ToString()) >= Convert.ToDateTime(dataOd) && Convert.ToDateTime(DataSet.Jadłospisy.Rows[i]["Data"].ToString()) <= Convert.ToDateTime(dataDo))
                        jadlospis.Add(new Menu(DataSet.Jadłospisy.Rows[i]["Data"].ToString(), DAO.DietsDAO.Select(DataSet.Jadłospisy.Rows[i]["Dieta"].ToString(), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString()), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Kolacja"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Kolacja"].ToString()));
                }
            }

            return jadlospis;
        }

        public static List<Menu> Select(string data, string miasto)
        {
            List<Menu> jadlospis = new List<Menu>();
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Jadłospisy.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Jadłospisy.Rows.Count; i++)
                {
                    if (DataSet.Jadłospisy.Rows[i]["Data"].ToString() == data && DataSet.Jadłospisy.Rows[i]["Miasto"].ToString() == miasto)
                    {
                        int? j = Check(jadlospis, DataSet.Jadłospisy.Rows[i]["Dieta"].ToString());
                        if (j != null)
                        {
                            jadlospis.RemoveAt(Convert.ToInt32(j));
                        }
                        jadlospis.Add(new Menu(DataSet.Jadłospisy.Rows[i]["Data"].ToString(), DAO.DietsDAO.Select(DataSet.Jadłospisy.Rows[i]["Dieta"].ToString(), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString()), DataSet.Jadłospisy.Rows[i]["Miasto"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Nazwa-Kolacja"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Śniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-IIŚniadanie"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Obiad"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Podwieczorek"].ToString(), DataSet.Jadłospisy.Rows[i]["Skład-Kolacja"].ToString()));
                    }
                }
            }

            return jadlospis;
        }

        public static int? Check(List<Menu> lista, string dieta)
        {
            int i = 0;
            foreach (Menu j in lista)
            {
                if (j.dieta.nazwa == dieta)
                {
                    //Delete(j.data, j.miasto, dieta);
                    return i;
                }
                i++;
            }
            return null;
        }

    }
}
