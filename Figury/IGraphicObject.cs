using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    interface IGraphicObject
    {
        void Draw();
        void Move(double dx, double dy);
        void Scale(double factor);
    }
}
