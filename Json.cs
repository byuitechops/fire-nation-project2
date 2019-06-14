using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    internal class Json : IConverter 
    {
        readonly string path; 

        public Json()
        {
            path = "json.json";
        }

        public string ToString(JArray json)
        {
            return JsonConvert.SerializeObject(json.First);
        }

        public string Parse(JArray jArray)
        {
            var item = new Item();

            var modName = "";
            var courseID = "96";

            JArray myModArr = new JArray();
            JObject myModObj = new JObject();
            JArray myItemArr = new JArray();

            foreach (JObject obj in jArray.Children<JObject>())
            {
                //Console.WriteLine((string)obj.SelectToken("name"));
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
                        var x=e; // Just to get rid of warnings
                        try{item.Url = o.SelectToken("external_url").ToString();}
                        catch(Exception e2){var z=e2; item.Url = "null";}
                    }
                    item.Published = o.SelectToken("published").ToString();
                    myItemArr.Add(JObject.FromObject(item));
                    item = new Item();
                }
                
                myModObj.Add(new JProperty("name", obj.SelectToken("name")));
                myModObj.Add(new JProperty("items", myItemArr));
                myModArr.Add(myModObj);

                myModObj = new JObject();
                myItemArr = new JArray();
            }
            
            JArray courseArr = new JArray();
            JObject courseObj = new JObject();

            courseObj.Add(new JProperty("courseID", courseID));
            courseObj.Add(new JProperty("modules", myModArr));
            courseArr.Add(courseObj);

            return JsonConvert.SerializeObject(courseArr.First);
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