using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PierwszyASP
{
    class Osoba : IComparable<Osoba>
    {
        public string Imie;
        public string Nazwisko;

        public string DataUr { private set; get; }
        public long Pesel { private set; get; }

        private long sortPesel; //potrzebne do sortowania

        public Osoba(string imie, string nazwisko, string dataUr, long pesel)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUr = dataUr;
            Pesel = pesel;

            //potrzebne do sortowania
            int _month0 = (int)((this.Pesel / 10000000L) % 100);
            this.sortPesel = this.Pesel;
            if (_month0 > 12)
            {
                this.sortPesel = 100000000000L;
            }
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
        // Tak nie mozna robic, bo sie wszystko rozleci
        //
        //Random rand = new Random();
        //public override int GetHashCode()
        //{
        //    return rand.Next();
        //}

        public int CompareTo([AllowNull] Osoba o) //od najmlodszego do najstarszego w peslu
        {
            /*
            int _month = (int)((o.Pesel / 10000000L) % 100);
            int _month0 = (int)((this.Pesel / 10000000L) % 100);
            //Console.WriteLine(_month); //DEBUG ONLY!!!

            long _pesel0 = this.Pesel;
            if (_month0 > 12)
            {
                _pesel0 = 100000000000L;
            }

            long _pesel = o.Pesel;
            if (_month > 12)
            {
                _pesel = 100000000000L;
            }

            //return 0; //DEBUG ONLY!!!
            */
            return Math.Sign(o.sortPesel - this.sortPesel);
        }

        /*public IComparer<Osoba> GetComparerByName()
        {
            return new IComparer<Osoba>() { 
                int Compare(Osoba x, Osoba y)
                {
                    return x.Nazwisko.CompareTo(y.Nazwisko);
                }
            }
        }*/
        public static IComparer<Osoba> GetComparerByName()
        {
            return new CompareBySurname();
        }

        class CompareBySurname : IComparer<Osoba>   //stworzone do porownywania nazwisk v2
        {
            public int Compare(Osoba x, Osoba y)
            {
                return x.Nazwisko.CompareTo(y.Nazwisko);
            }
        }
    }

    class CompareBySurname : IComparer<Osoba>   //stworzone do porownywania nazwisk
    {
        public int Compare(Osoba x, Osoba y)
        {
            return x.Nazwisko.CompareTo(y.Nazwisko);
        }
    }
}
