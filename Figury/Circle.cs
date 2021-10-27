using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    class Circle : IFigure, IGraphicObject
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Radius { get; private set; }

        public Circle(double x, double y, double r) 
        {
            X = x;
            Y = y;
            Radius = r;
        }

        public void Draw()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Rysuje kolko w: " + X + "," + Y); //DEBUG ONLY!!!
            Console.WriteLine("Kolko ma promien: " + Radius); //DEBUG ONLY!!!
        }
        public double Field()
        {
            //throw new NotImplementedException();
            return 3.14159 * Radius * Radius;
        }
        public void Move(double dx, double dy)
        {
            //throw new NotImplementedException();
            X += dx;
            Y += dy;
        }
        public double Perimeter()
        {
            //throw new NotImplementedException();
            return 2 * 3.14159 * Radius;
        }
        public void Scale(double factor)
        {
            //throw new NotImplementedException();
            Radius *= factor;
        }
    }
}
