using System;
using System.Collections.Generic;

namespace PierwszyASP
{
    class Program
    {
        static void Main_1(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Osoba o1 = new Osoba("Andrzej", "Kownacki", "1998/02/15", 98021526123);
            Console.Write("O1 = " + o1 + ",");
            Osoba o1v2 = new Osoba("Andrzej", "Kownacki", "1998/02/15", 98021526123);

            Osoba o2 = new Osoba("Marcin", "Blendowski", "1995/04/27", 95042726157);
            Console.WriteLine("O2 = " + o2 + ",");

            if (o1 == o1v2)
            {
                Console.WriteLine("Ta sama osoba");
            }
            else 
            {
                Console.WriteLine("Nie ta sama");
            }

            if (o1.Equals(o1v2))
            {
                Console.WriteLine("Ta sama osoba");
            }
            else
            {
                Console.WriteLine("Nie ta sama");
            }
        }

        static void Main(string[] args) 
        {
            List<Osoba> osoby = new List<Osoba>();
            osoby.Add(new Osoba("Andrzej", "Kownacki", "1998/02/15", 98021526123L));
            osoby.Add(new Osoba("Andrzej", "Kownacki", "1998/02/15", 98021526123L));
            osoby.Add(new Osoba("Marcin", "Blendowski", "1995/04/27", 95042726157L));

            for (int i = 0; i < osoby.Count; i++)
            {
                Console.WriteLine(osoby[i]);
            }

            Console.WriteLine("---------------");

            foreach (Osoba o in osoby)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("---------------");

            osoby.Remove(new Osoba("A", "K", "1998", 98021526123));
            foreach (Osoba o in osoby)
            {
                Console.WriteLine(o);
            }
            osoby.Add(new Osoba("Andrzej", "Kownacki", "1998/02/15", 98021526123));




            Console.WriteLine("\n\n\n==========  SET  ==========");

            HashSet<Osoba> osobyHash = new HashSet<Osoba>();
            foreach(Osoba o in osoby)
            {
                osobyHash.Add(o);
                Console.Write("\nDodano " + o + "    stan/ilosc: " + osobyHash.Count);
            }




            Console.WriteLine("\n\n\n==========  DICTIONARY  ==========");

            Dictionary<Osoba, double> zarobki = new Dictionary<Osoba, double>();
            zarobki[osoby[0]] = 4600.20;
            zarobki[osoby[1]] = 75000.50;
            zarobki[osoby[2]] = 10000000.00;

            foreach (Osoba o in zarobki.Keys)
            {
                Console.WriteLine(o.Imie + " " + o.Nazwisko + " - zarobki: " + zarobki[o]);
            }



            Console.WriteLine("\n\n\n==========  SORTOWANIE - COMPARETO  ==========");

            osoby.Add(new Osoba("Anna", "Wilczynska", "1995/04/27", 95122726157L));

            osoby.Sort();
            foreach (Osoba o in osoby)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("\n\n");
            osoby.Sort(new CompareBySurname());
            foreach (Osoba o in osoby)
            {
                Console.WriteLine(o.Imie + " " + o.Nazwisko);
            }

            Console.WriteLine("\n\n");
            osoby.Sort(); //"wymieszanie"
            osoby.Sort(Osoba.GetComparerByName());
            foreach (Osoba o in osoby)
            {
                Console.WriteLine(o.Imie + " " + o.Nazwisko);
            }

            /*foreach (Osoba o in osoby)
            {
                Console.WriteLine(o.Pesel);
                osoby[0].CompareTo(o);
            }*/
        }

        //static void Main(string[] args){}
    }
}
