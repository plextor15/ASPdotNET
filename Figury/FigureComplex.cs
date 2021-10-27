using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    class FigureComplex : IFigure, IGraphicObject
    {
        private List<Object> positiveElements; //dodaja sie do calkowitego pola
        private List<Object> negativeElements; //odejmuja sie do calkowitego pola

        public void Draw()
        {
            //throw new NotImplementedException();
            foreach (Object o in positiveElements)
            {
                ((IGraphicObject)o).Draw();
            }
            foreach (Object o in negativeElements)
            {
                ((IGraphicObject)o).Draw();
            }
        }
        public double Field()
        {
            //throw new NotImplementedException();
            double per = 0;

            foreach (Object o in positiveElements)
            {
                per += ((IFigure)o).Field();
            }
            foreach (Object o in negativeElements)
            {
                per -= ((IFigure)o).Field();
            }

            return per;
        }
        public void Move(double dx, double dy)
        {
            throw new NotImplementedException();
        }
        public double Perimeter()
        {
            throw new NotImplementedException();
        }
        public void Scale(double factor)
        {
            throw new NotImplementedException();
        }

        public void AddPositiveElement(Object o)
        {
            if (o is IFigure && o is IGraphicObject) 
            {
                positiveElements.Add(o); //wywala error
            }
        }
        public void AddNegativeElement(Object o)
        {
            if (o is IFigure && o is IGraphicObject)
            {
                negativeElements.Add(o);
            }
        }
    }
}
