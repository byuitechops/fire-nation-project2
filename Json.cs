using System;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    class Json : IConverter 
    {
        string data;
        readonly string path; 

        Json()
        {
            path = "json.json";
        }

        public string Convert(JArray items)
        {
            string str = "";
            return str;
        }

        public JArray Format(JArray jArray)
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

        public string GetPath()
        {
            return path;
        }
    }

}