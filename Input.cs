using System;
using System.Threading.Tasks;

namespace Wololo2
{
    static class Input
    {
        
        static internal Tuple<string, string> GetDataFromConsole()
        {
            Console.WriteLine("Please enter a course ID:"); 
            string id = System.Console.ReadLine();
            
            Console.WriteLine("Please enter the output method: ");
            string output = System.Console.ReadLine();


            return Tuple.Create(id, output);
        }

        static Tuple<string, string> GetDataFromArgs(string[] args)
        {
            
            string id = args[0];
            
            string output = args[1];

            return Tuple.Create(id, output);
            
        }

        static string GetDataFromServer(string where)
        {
            return where;
        }

        static string GetDataFromHardCode(string where)
        {
            return where;
        }


    }
}