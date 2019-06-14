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
            // Get input
            Tuple<string, string> inputs = Input.GetDataFromFile("config.txt");
            // Run startup
            Tuple<IData, IConverter> objs = Injector.Startup(inputs);
            // Get Canvas Json
            string canvasData = objs.Item1.GetData(inputs.Item1).Result; //Smelly
            // Parse to JThing
            JArray moreData = JArray.Parse(canvasData);
            // Convert back to string
            string convertedData = objs.Item2.Parse(moreData);
            // Write it to a file
            WriteFile(convertedData, objs.Item2);
        }

        public static void WriteFile(string data, IConverter obj)
        {
            File.WriteAllText(obj.GetPath(), data, Encoding.UTF8);
        }
    }
}
