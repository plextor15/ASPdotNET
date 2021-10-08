using System;

namespace PierwszyASP
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
