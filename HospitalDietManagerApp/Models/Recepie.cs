using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDietManagerApp.Models
{
    public class Recepie
    {
        public string nazwa;
        public string sklad;

        public Recepie(string nazwa, string sklad)
        {
            this.nazwa = nazwa;
            this.sklad = sklad;
        }
    }
}
