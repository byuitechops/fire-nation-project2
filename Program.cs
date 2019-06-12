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

            var myModObj = new JObject();
            var myItemObj = new JObject();

            foreach (JObject obj in jArray.Children<JObject>())
            {
                //Console.WriteLine((string)obj.SelectToken("name"));
                myModObj = new JObject();
                myModObj.Add(new JProperty("name", obj.SelectToken("name")));
                
                foreach (JObject o in obj.SelectToken("items").Children<JObject>())
                {
                    item.ID = o.SelectToken("id").ToString();
                    item.Name = o.SelectToken("title").ToString();
                    item.Type = o.SelectToken("type").ToString();
                    try
                    {
                        item.Url = o.SelectToken("url").ToString();
                    }
                    catch (Exception e)
                    {
                        try{item.Url = o.SelectToken("external_url").ToString();}
                        catch(Exception e2){item.Url = "null";}
                    }
                    item.Published = o.SelectToken("published").ToString();
                    items.Add(item);
                    item = new Item();
                }
            }
                
            
            return items;
        }
    }
}

