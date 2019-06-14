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
            string ID = Prompt("Enter a course ID:"); // Implement Input
            string Opt = Prompt("Output type: (CSV, HTML, JSON)?");

            IData httpGet = new HttpGet(); // Dependancy inject
            string data = httpGet.GetData("https://byui.instructure.com/api/v1/courses/" + ID + "/modules?include[]=items&per_page=32").Result; // Implement better params

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
