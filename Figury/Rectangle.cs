using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    class Rectangle : IGraphicObject, IFigure
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double x, double y, double w, double h) 
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        public void Draw()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Rysuje prostokat w: " + X + "," + Y); //DEBUG ONLY!!!
        }

        public double Field()
        {
            //throw new NotImplementedException();
            return Width * Height;
        }

        public double Perimeter()
        {
            //throw new NotImplementedException();
            return 2 * (Width + Height);
        }

        public void Scale(double factor)
        {
            //throw new NotImplementedException();
            Width *= factor;
            Height *= factor;
        }

        public void Move(double dx, double dy)
        {
            //throw new NotImplementedException();
            X += dx;
            Y += dy;
        }
    }
}
