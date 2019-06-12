using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    class Program
    {
        class ModItem
        {
            public string CourseID {get;set;}
            public string ModName {get;set;}
            public string ModItemName {get;set;}
            public string ModID {get;set;}
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

            var modItems = new List<ModItem>();
            var modItem = new ModItem();
            var modName = "";
            var courseID = "96";

            foreach(JObject obj in jArray.Children<JObject>())
                foreach(JProperty prop in obj.Properties())
                {
                    if(prop.Name == "name")
                    {
                        modName = prop.Value.ToString();
                    }
                    if(prop.Name == "items")
                        foreach(JObject o in prop.Value.Children<JObject>())
                            foreach(JProperty p in o.Properties())
                                if(p.Name == "title")
                                {
                                    modItem.CourseID = courseID;
                                    modItem.ModName = modName;
                                    modItem.ModItemName = p.Value.ToString();
                                    modItem.ModID = "Not Implemented";
                                    modItems.Add(modItem);
                                    modItem = new ModItem();
                                }
                    counter++;
                }
            foreach(ModItem m in modItems)
            {
                Console.WriteLine("{");
                Console.WriteLine("   CourseID = {0}", m.CourseID);
                Console.WriteLine("   Module Name = {0}", m.ModName);
                Console.WriteLine("   Item Name = {0}", m.ModItemName);
                Console.WriteLine("   Item ID = {0}", m.ModID);
                Console.WriteLine("}");
            }
            //LoopProperties(jArray.Children<JObject>());
        }
    }
}

