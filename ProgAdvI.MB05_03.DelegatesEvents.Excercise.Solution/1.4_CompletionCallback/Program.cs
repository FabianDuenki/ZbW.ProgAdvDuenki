using System;

namespace _1._4_CompletionCallback
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReaderClient myApp = new FileReaderClient();

            myApp.ActionRequiringFile(@"..\..\HelloWorld1.txt");
            myApp.ActionRequiringFile(@"..\..\HelloWorld2.txt");
            myApp.ActionRequiring2Files(@"..\..\HelloWorld1.txt", @"..\..\HelloWorld2.txt");

            Console.ReadKey();
        }
    }
}
