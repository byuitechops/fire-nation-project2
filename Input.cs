using System;

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

        static internal Tuple<string, string> GetDataFromArgs(string[] args)
        {
            
            string id = args[0];
            
            string output = args[1];

            return Tuple.Create(id, output);
            
        }

        static internal Tuple<string, string> GetDataFromFile(string path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            string id = file.ReadLine();
            string output = file.ReadLine();

            /* example textfile
            <<BEGINNING OF FILE>>
            98
            csv
            <<END OF FILE>>
             */

            file.Close();

            return Tuple.Create(id, output);
        }

        static internal Tuple<string, string> GetDataFromHardCode()
        {
            return Tuple.Create("96", "csv");
        }


    }
}