using System;

namespace HelloUserInput
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length <= 0)
            {
                Help();
                return 0;
            }

            if (!string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine($"The user said : {args[0]}");
                return 0;
            }
            return -1;
        }

        static void Help()
        {
            Console.WriteLine("This is a basic .Net Core Console Application. It takes a user input in the form of one string parameter and returns it to the console." +
                $"The Input should look as follows:{Environment.NewLine}" +
                "HelloUserInput.exe <Param>");
        }
    }
}
