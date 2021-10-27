using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    interface IFigure
    {
        double Field();
        double Perimeter(); //obwod
        void Scale(double factor);
    }
}
