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
    public class UnitsDAO
    {
        public static void Insert(string miasto)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            DataTable dtProdukty = DataSet.Tables["Jednostka"];
            DataRow drProdukty = dtProdukty.NewRow();
            drProdukty["Miasto"] = miasto;
            dtProdukty.Rows.Add(drProdukty);
            DataSet.WriteXml(XML_Location);
        }

        public static void Update(Unit jednostka, string miasto)
        {
            Delete(jednostka);
            Insert(miasto);
        }

        public static void Delete(Unit jednostka)
        {
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Diety.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Jednostka.Rows.Count; i++)
                {
                    if (DataSet.Jednostka.Rows[i]["Miasto"].ToString() == jednostka.miasto)
                        DataSet.Jednostka.Rows[i].Delete();
                }
            }
            DataSet.WriteXml(XML_Location);
        }
        public static List<Unit> SelectAll()
        {
            List<Unit> listaJednostek = new List<Unit>();
            KalkulatorDietyDatabase DataSet = new KalkulatorDietyDatabase();
            String XML_Location = @"DataBase.xml";
            DataSet.ReadXml(XML_Location);
            if (DataSet.Jednostka.Rows.Count > 0)
            {
                for (int i = 0; i < DataSet.Jednostka.Rows.Count; i++)
                {
                    listaJednostek.Add(new Unit(DataSet.Jednostka.Rows[i]["Miasto"].ToString()));
                }
            }

            return listaJednostek;
        }


    }
  
}
