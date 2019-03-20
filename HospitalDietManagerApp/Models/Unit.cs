using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDietManagerApp.Models
{
    public class Unit
    {
        public string miasto { get; set; }
        public Unit(string miasto)
        {
            this.miasto = miasto;
        }
    }
}
