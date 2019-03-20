﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDietManagerApp.Models
{
    public class Template
    {
        public int? id;
        public string nazwa;
        public string miasto;
        public int dni;
        public string dzienStart;
        public List<Menu> listaJadlospisow;

        public Template(int? id, string nazwa, string miasto, int dni, string dzienStart, List<Menu> listaJadlospisow)
        {
            this.id = id;
            this.nazwa = nazwa;
            this.miasto = miasto;
            this.dni = dni;
            this.dzienStart = dzienStart;
            this.listaJadlospisow = listaJadlospisow;

        }
    }
}
