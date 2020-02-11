using System;
using System.IO;

namespace HelloFileInput
{
    class Program
    {
        static int Main(string[] args)
        {

            if(args.Length <= 0 || args.Length != 1)
            {
                Help();
                return -1;
            }

            var fileInfo = new FileInfo(args[0]);

            if (fileInfo.Exists)
            {
                string values = File.ReadAllText(fileInfo.FullName);
                Console.WriteLine(values);

                string container = string.Empty;
                foreach (var c in values)
                {
                    if(c == 'A')
                    {
                        container += c;
                    }
                }

                File.WriteAllText("example.txt", container);

                return 0;
            }
            else
            {
                Console.WriteLine($"{fileInfo.FullName} is not a valid path, please input a valid path");
                return -1;
            }
        }

        static void Help()
        {
            Console.WriteLine("This is a basic .Net Core Console Application. It takes a user input in the form of a file path and returns the values inside." +
                $"The Input should look as follows:{Environment.NewLine}" +
                "HelloUserInput.exe <FilePath>");
        }
    }
}
