using System.Threading.Tasks;

namespace Wololo2
{
    class Input
    {
        Input()
        {
            
        }
        
        static Tuple<string, string> GetDataFromConsole()
        {
            Console.WriteLine("Please enter a course ID:"); 
            string id = System.Console.ReadLine();
            
            Console.WriteLine("Please enter the output method: ");
            string output = System.Console.ReadLine();


            return Tuple.Create(id, output);
        }

        static Tuple<string> GetDataFromArgs(string[] args)
        {
            
            string id = args[0];
            
            string output = args[1];

            return Tuple.Create(id, output);
            
        }

        Task<string> GetDataFromServer(string where)
        {

        }

        Task<string> GetDataFromHardCode(string where)
        {

        }


    }
}