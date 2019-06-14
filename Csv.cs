using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Wololo;

namespace Wololo2
{
    internal class Csv : IConverter 
    {
        readonly string path; 

        public Csv()
        {
            path = "csv.csv";
        }

        public string Parse(JArray jArray)
        {
            var items = new List<Item>();
            var item = new Item();

            var modName = "";
            var courseID = "96";

            foreach (JObject obj in jArray.Children<JObject>())
            {
                modName = (string)obj.SelectToken("name");
                foreach (JObject o in obj.SelectToken("items").Children<JObject>())
                {
                    item.CourseID = courseID;
                    item.ModName = modName;
                    item.ID = o.SelectToken("id").ToString();
                    item.Name = o.SelectToken("title").ToString();
                    item.Type = o.SelectToken("type").ToString();
                    try
                    {
                        item.Url = o.SelectToken("url").ToString();
                    }
                    catch (Exception e)
                    {
                        var z=e; // Just to get rid of warnings
                        try{item.Url = o.SelectToken("external_url").ToString();}
                        catch(Exception e2){var x=e2; item.Url = "null";}
                    }
                    item.Published = o.SelectToken("published").ToString();
                    items.Add(item);
                    item = new Item();
                }
            }

            JArray jArr = new JArray(); 
            foreach(Item i in items)
            {
                jArr.Add(i);
            }

            var converter = new Converter();
            converter.jArray = jArr;
            return converter.CsvStringOut();
        }

        public void WriteFile(string data)
        {
            File.WriteAllText(path, data, Encoding.UTF8);
        }

        public string GetPath()
        {
            return path;
        }
    }
}