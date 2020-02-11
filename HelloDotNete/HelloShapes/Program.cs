using HelloShapes.Shapes;
using HelloShapes.Shapes.ShapeTypes;
using System;
using System.Collections.Generic;
using System.IO;

namespace HelloShapes
{
    class Program
    {

        // Some assumptions are made about the input file. 
        // The first column will contain a defining feature, such as a shape name, the next set of columns will define the shape parameter

        static int Main(string[] args)
        {
            if (args.Length < 0 || args.Length != 1)
            {
                Help();
                return -1;
            }

            var fileInfo = new FileInfo(args[0]);

            if (fileInfo.Exists)
            {
                //Process the data
                return ProcessData(fileInfo);
            }
            return 0;
        }

        static int ProcessData(FileInfo dataFile)
        {
            string[] lines = File.ReadAllLines(dataFile.FullName);
            
            string results = string.Empty;
            List<Shape> shapes = new List<Shape>();

            for(int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');
                
                if(split[0] == "Triangle")
                {
                    if(Triangle.BuildFromStrings(out Triangle triangle, i,split[1], split[2]))
                    {
                        shapes.Add(triangle);
                        results += $"Added a triangle {Environment.NewLine}";
                    }
                    else
                    {
                        results += $"Failed to add triangle{Environment.NewLine}";
                    }
                }
                else if (split[0] == "Rectangle")
                {
                    if(Rectangle.BuildFromString(out Rectangle rect, i , split[1], split[2]))
                    {
                        shapes.Add(rect);
                        results += $"Successfully added Rectangle {Environment.NewLine}";
                    }
                    else
                    {
                        results += $"Failed to add rectangle{Environment.NewLine}";
                    }
                }
                else if(split[0] == "Circle")
                {
                    if(Circle.BuildFromStrings(out Circle circle, i, split[1]))
                    {
                        shapes.Add(circle);
                        results += $"Successfully added a circle{Environment.NewLine}";
                    }
                    else
                    {
                        results += $"Failed to add circle{Environment.NewLine}";
                    }
                }
                else
                {
                    results += $"Failed to add unknown item";
                }
            }

            if(shapes.Count < 0)
            {
                Console.WriteLine("There were no valid entries in the file, please review your data");
                return -1;
            }

            results += $"{Environment.NewLine}{Environment.NewLine}";

            double sum = 0;
            shapes.ForEach(x => 
            {
                double area = x.Area();
                sum += area;
                results += $"{x.ShapeName} , {x.ID} , AREA : {area}{Environment.NewLine}";
            });

            results += $"Total area is {sum}{Environment.NewLine}";

            WriteOutResults(results);

            return 0;
        }

        private static void WriteOutResults(string results)
        {
            File.WriteAllText("results.txt", results);
        }

        static void Help()
        {
            Console.WriteLine("This is a basic .Net Core Console Application. It takes a user input in the form of a file path and returns a report of the shapes inside." +
                $"The Input should look as follows:{Environment.NewLine}" +
                "HelloUserInput.exe <FilePath>");
        }
    }
}
