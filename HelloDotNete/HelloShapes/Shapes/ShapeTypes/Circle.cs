using System;
using System.Collections.Generic;
using System.Text;

namespace HelloShapes.Shapes.ShapeTypes
{
    class Circle : Shape
    {

        public double Radius { get; set; }
        public override string ShapeName { get; set; }
        public override int ID { get; set; }

        public static bool BuildFromStrings(out Circle circle, int ID, params string[] inputs)
        {
            circle = new Circle();
            if (inputs.Length == 0 || inputs.Length > 2) return false;
            if (double.TryParse(inputs[0], out double value))
            {
                circle.Radius = value;
                circle.ShapeName = "Circle";
                circle.ID = ID;
                return true;
            }
            return false;
        }

        public override double Area()
        {
            return Math.Pow(Radius, 2.0) * Math.PI;
        }
    }
}
