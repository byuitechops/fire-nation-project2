using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Wololo;

namespace Wololo2
{
    class Csv : IConverter 
    {
        string data;
        readonly string path; 

        Csv()
        {
            path = "csv.csv";
        }

        public string Convert(JArray items)
        {
            var converter = new Converter();
            converter.jArray = items;
            return converter.CsvStringOut();
        }

        public JArray Format(JArray jArray)
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
                        try{item.Url = o.SelectToken("external_url").ToString();}
                        catch(Exception e2){item.Url = "null";}
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

            return jArr;
        }

        public void WriteFile(string data)
        {
            File.WriteAllText(path, data, Encoding.UTF8);
        }
    }
}