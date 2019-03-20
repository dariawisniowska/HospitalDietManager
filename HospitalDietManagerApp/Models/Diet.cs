using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDietManagerApp.Models
{
    public class Diet
    {
        public string nazwa;
        public string miasto;
        public NutritionalValues wartosciOdzywcze;

        public Diet(string nazwa, string miasto, double energia, double bialko, double tluszcze, double weglowodany, double sod, double tluszcze_nn, double weglowodany_przyswajalne, double blonnik)
        {
            this.nazwa = nazwa;
            this.miasto = miasto;
            this.wartosciOdzywcze = new NutritionalValues(energia, bialko, tluszcze, weglowodany, sod, tluszcze_nn, weglowodany_przyswajalne, blonnik);
        }
    }
}
