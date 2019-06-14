using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    class Html : IConverter
    {
        readonly string path;

        public Html()
        {
            path = "report.html";
        }

    public string Parse(JArray jArray)
        {
            var item = new Item();

            var modName = "";
            var courseID = "96";
            var modID = "";

            JArray myModArr = new JArray();
            JObject myModObj = new JObject();
            JArray myItemArr = new JArray();

            foreach (JObject obj in jArray.Children<JObject>())
            {
                //Console.WriteLine((string)obj.SelectToken("name"));
                modName = (string)obj.SelectToken("name");
                modID = (string)obj.SelectToken("id");
                foreach (JObject o in obj.SelectToken("items").Children<JObject>())
                {
                    item.CourseID = courseID;
                    item.ModName = modName;
                    item.ModuleID = modID;
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
            

            string htmlString = htmlConverter(courseArr);


            return htmlString;
        }

        public string htmlConverter(JArray course)
        {
            string courseID = (string)course.First.SelectToken("name");

            string html = "<body><h1>Module Items for course " + courseID + "</h1><div class=\"report\">";

            foreach (var module in course.First.SelectToken("modules"))
            {
                string modName = (string)module.SelectToken("name");
                html += $"<div class=\"card\" style=\"width: 50rem;\"><div class=\"card-header\">{modName}</div><ul class=\"list-group list-group-flush\">";

                JArray items = (JArray)module.SelectToken("items");
                foreach (var item in items.Children<JObject>())
                {
                    //Console.WriteLine((string)item.SelectToken("Type"));
                    string name = (string)item.SelectToken("Name");
                    string type = (string)item.SelectToken("Type");
                    string published = (string)item.SelectToken("Published");
                    string url = (string)item.SelectToken("Url");
                    string pub = "";
                    string subStyle = "";
                    if (type == "ExternalUrl") type = "send";
                    if (type == "File") type = "file_copy";
                    if (type == "Discussion") type = "forum";
                    if (type == "Quiz") type = "help";
                    if (type == "Assignment") type = "assignment";
                    if (type == "Page") type = "receipt";
                    if (type == "SubHeader") subStyle = "subheader";
                    if (type == "SubHeader") type="" ;
                    if (url == "") url = "#";
                    if (published == "True")
                    {
                        pub = "published";
                        //Console.WriteLine(pub);
                    }
                    html += $"<li class=\"list-group-item {subStyle}\"><a href=\"{url}\">{name}<i class=\"material-icons {pub}\">{type}</i></a></li>\n";
                }

                html += "</ul></div>";

            }

            html += "</div></body><script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script><script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js\" integrity=\"sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1\" crossorigin=\"anonymous\"></script><script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js\" integrity=\"sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM\" crossorigin=\"anonymous\"></script></html>";
            string template = "./template_report.html";


            string readHTML = File.ReadAllText(template);

            //Console.WriteLine(readHTML);

            readHTML += html;

            //Console.WriteLine(readHTML);
            return readHTML;
        }

        public string GetPath()
        {
            return path;
        }
    }
}
