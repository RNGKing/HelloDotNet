using System;
using System.Collections.Generic;
using System.Text;

namespace HelloShapes.Shapes
{
    public abstract class Shape
    {
        public abstract string ShapeName { get; set; }
        public abstract int ID { get; set; }

        public abstract double Area();
        
    }
}
