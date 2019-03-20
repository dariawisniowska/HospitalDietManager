using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDietManagerApp.Models
{
    public class Product
    {
        public string nazwa { get; set; }
        public char kategoria { get; set; }
        public NutritionalValues wartosciOdzywcze { get; set; }
        public double energia { get; set; }
        public double bialko { get; set; }
        public double weglowodany { get; set; }
        public double tluszcze { get; set; }
        public double tluszcze_nn { get; set; }
        public double sod { get; set; }
        public double weglowodany_przyswajalne { get; set; }
        public double blonnik { get; set; }
        public double masa { get; set; }

        public Product(char kategoria, string nazwa, double energia, double bialko, double tluszcze, double weglowodany, double sod, double tluszcze_nn, double weglowodany_przyswajalne, double blonnik)
        {
            this.kategoria = kategoria;
            this.nazwa = nazwa;
            this.wartosciOdzywcze = new NutritionalValues(energia, bialko, tluszcze, weglowodany, sod, tluszcze_nn, weglowodany_przyswajalne, blonnik);
            this.energia = energia;
            this.bialko = bialko;
            this.weglowodany = weglowodany;
            this.sod = sod;
            this.tluszcze = tluszcze;
            this.tluszcze_nn = tluszcze_nn;
            this.blonnik = blonnik;
            this.weglowodany_przyswajalne = weglowodany_przyswajalne;
        }
        public Product(double masa, string nazwa, double energia, double bialko, double tluszcze, double weglowodany, double sod, double tluszcze_nn, double weglowodany_przyswajalne, double blonnik)
        {
            this.kategoria = kategoria;
            this.nazwa = nazwa;
            this.wartosciOdzywcze = new NutritionalValues(energia, bialko, tluszcze, weglowodany, sod, tluszcze_nn, weglowodany_przyswajalne, blonnik);
            this.energia = energia;
            this.bialko = bialko;
            this.weglowodany = weglowodany;
            this.sod = sod;
            this.tluszcze = tluszcze;
            this.tluszcze_nn = tluszcze_nn;
            this.blonnik = blonnik;
            this.weglowodany_przyswajalne = weglowodany_przyswajalne;
            this.masa = masa;
        }
    }
    public enum TypyProduktow
    {
        B,
        M,
        P,
        N,
        O,
        W,
        R,
        T,
        S,
        D,
        Z,
        A //WSZYSTKIE
    }

}
