using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Wololo;

namespace Wololo2
{
    class Program
    {
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

            JArray jArray = JArray.Parse(data);

            List<dynamic> items = Format(jArray);

            var converter = new Converter();
            converter.ObjectIn(items);
            converter.JsonOut("json.json");
            converter.CsvOut("csv.csv");
            //LoopProperties(jArray.Children<JObject>());
        }

        private static List<dynamic> Format(JArray jArray)
        {
            var items = new List<dynamic>();
            var item = new Item();

            var modName = "";
            var courseID = "96";

            foreach (JObject obj in jArray.Children<JObject>())
                foreach (JProperty prop in obj.Properties())
                {
                    if (prop.Name == "name")
                        modName = prop.Value.ToString();
                    if (prop.Name == "items")
                        foreach (JObject o in prop.Value.Children<JObject>())
                            foreach (JProperty p in o.Properties())
                            {
                                if (p.Name == "id")
                                    item.ID = p.Value.ToString();
                                else if (p.Name == "title")
                                    item.Name = p.Value.ToString();
                                else if (p.Name == "type")
                                    item.Type = p.Value.ToString();
                                else if (p.Name == "url")
                                    item.Url = p.Value.ToString();
                                else if (p.Name == "published")
                                {
                                    item.Published = p.Value.ToString();
                                    item.CourseID = courseID;
                                    item.ModName = modName;
                                    items.Add(item);
                                    item = new Item();
                                }
                            }
                }

            return items;
        }
    }
}

