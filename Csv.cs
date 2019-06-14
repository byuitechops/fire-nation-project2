using System.Collections.Generic;
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

        public string Convert(List<dynamic> items)
        {
            var converter = new Converter();
            converter.ObjectIn(items);
            return converter.CsvStringOut();
        }

        public List<dynamic> Format(JArray jArray)
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

        public string GetPath()
        {
            return path;
        }
    }
}