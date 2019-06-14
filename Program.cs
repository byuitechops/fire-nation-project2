using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Wololo;
using System.IO;
using System.Text;

namespace Wololo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<string, string> tuple = Input.GetDataFromFile("config.txt");

            IData httpGet = new HttpGet(); // Dependancy inject
            string data = httpGet.GetData(tuple.Item1).Result; // Implement better params

            IConverter converter = new Json(); // Dependancy inject
            JArray moreData = JArray.Parse(data); // Put into some feature???
            data = doConvert(converter, moreData);
            WriteFile(data, converter);
        }

        static string Prompt(string str)
        {
            Console.WriteLine(str);
            return Console.ReadLine();
        }

        static string doConvert(IConverter obj, JArray data)
        {
            return obj.Parse(data);
        }

        public static void WriteFile(string data, IConverter obj)
        {
            File.WriteAllText(obj.GetPath(), data, Encoding.UTF8);
        }
    }
}
