using System;
using System.Collections.Generic;
using System.Text;

namespace HelloShapes.Shapes.ShapeTypes
{
    public class Rectangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public override string ShapeName { get; set; }
        public override int ID { get; set; }

        public static bool BuildFromString(out Rectangle rectangle, int ID,params string[] input)
        {
            rectangle = new Rectangle();
            if (input.Length == 0 || input.Length > 3) return false;

            if(double.TryParse(input[0], out double baseLength))
            {
                if(double.TryParse(input[1], out double heightLength))
                {
                    rectangle.Base = baseLength;
                    rectangle.Height = heightLength;
                    rectangle.ShapeName = "Rectangle";
                    rectangle.ID = ID;
                    return true;
                }
            }

            return false;
        }

        public override double Area()
        {
            return Base * Height;
        }
    }
}
