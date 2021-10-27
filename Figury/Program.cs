using System;

namespace Figury
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Moj ogrodek:\n");

            FigureComplex garden = new FigureComplex();
            garden.AddPositiveElement(new Rectangle(20, 20, 150, 60));
            garden.AddNegativeElement(new Rectangle(100, 40, 70, 20));

            Circle c = new Circle(10,10,1.5); //debug
            garden.AddNegativeElement(c);

            garden.Draw();
            Console.WriteLine("\nPole ogrodu: " + garden.Field());
            Console.WriteLine("Obwod ogrodu: " + garden.Perimeter());

            Console.WriteLine("\nZmiana rozmiaru kolka");
            c.Scale(0.75);

            garden.Draw();
            Console.WriteLine("\nPole ogrodu: " + garden.Field());
            Console.WriteLine("Obwod ogrodu: " + garden.Perimeter());
        }
    }
}
