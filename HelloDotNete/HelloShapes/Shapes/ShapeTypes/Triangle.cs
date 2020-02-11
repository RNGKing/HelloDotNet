using System;
using System.Collections.Generic;
using System.Text;

namespace HelloShapes.Shapes.ShapeTypes
{
    class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public override string ShapeName { get; set; }
        public override int ID { get; set; }

        public static bool BuildFromStrings(out Triangle triangle, int ID ,params string[] input)
        {
            triangle = new Triangle();
            if (input.Length == 0 || input.Length > 3) return false;

            if(double.TryParse(input[0], out double baseLength))
            {
                if(double.TryParse(input[1], out double heightLength))
                {
                    triangle.Height = heightLength;
                    triangle.Base = baseLength;
                    triangle.ShapeName = "Triangle";
                    triangle.ID = ID;
                    return true;
                }
            }
            return false;
        }

        public override double Area()
        {
            return 0.5 * (Base * Height);
        }
    }
}
