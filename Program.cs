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

            JArray items = Format(jArray);

            var converter = new Converter();
            converter.jArray = items;
            converter.JsonOut("json.json");
            //LoopProperties(jArray.Children<JObject>());
        }

        private static JArray Format(JArray jArray)
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
                        try{item.Url = o.SelectToken("external_url").ToString();}
                        catch(Exception e2){item.Url = "null";}
                    }
                    item.Published = o.SelectToken("published").ToString();
                    myItemArr.Add(JObject.FromObject(item));
                    item = new Item();
                }
                
                myModObj.Add(new JProperty("name", obj.SelectToken("name")));
                myModObj.Add(new JProperty("itmes", myItemArr));
                myModArr.Add(myModObj);
                Console.WriteLine(myModArr);

                myModObj = new JObject();
                myItemArr = new JArray();
            }
            
            JArray courseArr = new JArray();
            JObject courseObj = new JObject();

            courseObj.Add(new JProperty("name", courseID));
            courseObj.Add(new JProperty("modules", myModArr));
            courseArr.Add(courseObj);
            
            return courseArr;
        }
    }
}
