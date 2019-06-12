using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    class Program
    {
        class ModItem
        {
            string CourseName;
            string ModuleName;
            string ModuleItemName;
        }

        static public void LoopProperties(JEnumerable<JObject> jEnum)
        {
            foreach(JObject obj in jEnum)
                foreach(JProperty prop in obj.Properties())
                {
                    if(prop.Name == "title")
                        Console.WriteLine(prop.Value);
                    else if(prop.Name == "items")
                        LoopProperties(prop.Value.Children<JObject>());
                }
        }

        static void Main(string[] args)
        {
            var httpGet = new HttpGet();
            string data = httpGet.GetData("https://byui.instructure.com/api/v1/courses/96/modules?include[]=items&per_page=32").Result;

            byte counter = 0;
            JArray jArray = JArray.Parse(data);
            Console.WriteLine(jArray.Count);

            var modItems = new List<ModItem>();

            
            foreach(JObject obj in jArray.Children<JObject>())
                foreach(JProperty prop in obj.Properties())
                {
                    if(prop.Name == "name")
                        modItems.Add(prop.Value.ToString());
                    if(prop.Name == "items")
                        foreach(JObject o in prop.Value.Children<JObject>())
                            foreach(JProperty p in o.Properties())
                                if(p.Name == "title")
                                    Console.WriteLine(p.Value);
                    counter++;
                }
            
            //LoopProperties(jArray.Children<JObject>());
        }
    }
}

