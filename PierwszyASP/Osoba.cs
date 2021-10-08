using System;
using System.Collections.Generic;
using System.Text;

namespace PierwszyASP
{
    class Osoba
    {
        public string Imie;
        public string Nazwisko;

        public string DataUr { private set; get; }
        public long Pesel { private set; get; }

        public Osoba(string imie, string nazwisko, string dataUr, long pesel)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUr = dataUr;
            Pesel = pesel;
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko + ", PESEL: " + Pesel;
        }

        public override bool Equals(object obj)
        {
            return obj is Osoba osoba &&
                   Pesel == osoba.Pesel;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Pesel);
        }
    }
}
