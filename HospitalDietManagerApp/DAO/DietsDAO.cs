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
    public class DietsDAO
    {
        public static void Insert(string nazwa, string miasto, double energia, double bialko, double tluszcze, double weglowodany, double sod, double tluszcze_nn, double weglowodany_przyswajalne, double blonnik)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            DataTable dtProdukty = DataSet.Tables["Diety"];
            DataRow drProdukty = dtProdukty.NewRow();
            drProdukty["Nazwa diety"] = nazwa;
            drProdukty["Miasto"] = miasto;
            drProdukty["Energia"] = energia;
            drProdukty["Białko"] = bialko;
            drProdukty["Tłuszcze"] = tluszcze;
            drProdukty["Węglowodany"] = weglowodany;
            drProdukty["Węglowodany przyswajalne"] = weglowodany_przyswajalne;
            drProdukty["Błonnik"] = blonnik;
            drProdukty["Sód"] = sod;
            drProdukty["Kwasy tłuszczowe nasycone"] = tluszcze_nn;
            dtProdukty.Rows.Add(drProdukty);
            DataSet.WriteXml(XML_Location);
        }

        public static void Update(Diet dieta, string nazwa, string miasto, double energia, double bialko, double tluszcze, double weglowodany, double sod, double tluszcze_nn, double weglowodany_przyswajalne, double blonnik)
        {
            Delete(dieta);
            Insert(nazwa, miasto, energia, bialko, tluszcze, weglowodany, sod, tluszcze_nn, weglowodany_przyswajalne, blonnik);
        }

        public static void Delete(Diet dieta)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Diety.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Diety.Rows.Count; i++)
                {
                    if (DataSet.Diety.Rows[i]["Nazwa diety"].ToString() == dieta.nazwa && DataSet.Diety.Rows[i]["Miasto"].ToString() == dieta.miasto)
                        DataSet.Diety.Rows[i].Delete();
                }
            }
            DataSet.WriteXml(XML_Location);
        }

        public static List<Diet> SelectAll(string miasto)
        {
            List<Diet> listaDiet = new List<Diet>();
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Diety.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Diety.Rows.Count; i++)
                {
                    if (DataSet.Diety.Rows[i]["Miasto"].ToString() == miasto)
                        listaDiet.Add(new Diet(DataSet.Diety.Rows[i]["Nazwa diety"].ToString(), DataSet.Diety.Rows[i]["Miasto"].ToString(), Convert.ToDouble(DataSet.Diety.Rows[i]["Energia"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Białko"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Tłuszcze"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Węglowodany"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Sód"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Kwasy tłuszczowe nasycone"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Węglowodany przyswajalne"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Błonnik"])));
                }
            }

            return listaDiet;
        }

        public static Diet Select(string nazwa, string miasto)
        {
            Diet dieta = null;
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Diety.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Diety.Rows.Count; i++)
                {
                    if (DataSet.Diety.Rows[i]["Nazwa diety"].ToString() == nazwa && DataSet.Diety.Rows[i]["Miasto"].ToString() == miasto)
                    {
                        try
                        {
                            dieta = new Diet(DataSet.Diety.Rows[i]["Nazwa diety"].ToString(), DataSet.Diety.Rows[i]["Miasto"].ToString(), Convert.ToDouble(DataSet.Diety.Rows[i]["Energia"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Białko"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Tłuszcze"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Węglowodany"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Sód"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Kwasy tłuszczowe nasycone"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Węglowodany przyswajalne"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Błonnik"]));
                        }
                        catch
                        {
                            dieta = new Diet(DataSet.Diety.Rows[i]["Nazwa diety"].ToString(), DataSet.Diety.Rows[i]["Miasto"].ToString(), Convert.ToDouble(DataSet.Diety.Rows[i]["Energia"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Białko"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Tłuszcze"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Węglowodany"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Sód"]), Convert.ToDouble(DataSet.Diety.Rows[i]["Kwasy tłuszczowe nasycone"]), 0, 0);
                        }
                    }
                }
            }

            return dieta;
        }
    }
}
