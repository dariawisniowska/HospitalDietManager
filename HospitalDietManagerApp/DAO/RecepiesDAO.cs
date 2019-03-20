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
    public class RecepiesDAO
    {
        public static void Insert(string nazwa, string sklad)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            DataTable dtProdukty = DataSet.Tables["Receptury"];
            DataRow drProdukty = dtProdukty.NewRow();
            drProdukty["Nazwa receptury"] = nazwa;
            drProdukty["Skład receptury"] = sklad;
            dtProdukty.Rows.Add(drProdukty);
            DataSet.WriteXml(XML_Location);
        }

        public static void Update(Recepie receptura, string nazwa, string sklad)
        {
            Delete(receptura);
            Insert(nazwa, sklad);
        }

        public static void Delete(Recepie receptura)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Receptury.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Receptury.Rows.Count; i++)
                {
                    if (DataSet.Receptury.Rows[i]["Nazwa receptury"].ToString() == receptura.nazwa && DataSet.Receptury.Rows[i]["Skład receptury"].ToString() == receptura.sklad)
                        DataSet.Receptury.Rows[i].Delete();
                }
            }
            DataSet.WriteXml(XML_Location);
        }

        public static List<Recepie> SelectAll()
        {
            List<Recepie> listaDiet = new List<Recepie>();
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Receptury.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Receptury.Rows.Count; i++)
                {
                    listaDiet.Add(new Recepie(DataSet.Receptury.Rows[i]["Nazwa receptury"].ToString(), DataSet.Receptury.Rows[i]["Skład receptury"].ToString()));
                }
            }

            return listaDiet;
        }
    }
}
