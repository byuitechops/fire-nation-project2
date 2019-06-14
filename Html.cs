using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    class Html : IConverter
    {
        string data;
        readonly string path;

        public Html()
        {
            path = "html.html";
        }

        public string Convert(JArray course)
        {
            string currID = "";

            string courseID = (string)course.First.SelectToken("name");

            string html = "<body><h1>Module Items for course " + courseID + "</h1><div class=\"report\">";

            foreach (var module in course.First.SelectToken("modules"))
            {
                string modName = (string)module.SelectToken("name");
                html += "<div class=\"card\" style=\"width: 50rem;\"><div class=\"card-header\">" + modName + "</div><ul class=\"list-group list-group-flush\">";

                //Console.WriteLine(module);



                JArray items = (JArray)module.SelectToken("items");
                foreach (var item in items.Children<JObject>())
                {
                    //Console.WriteLine(item);

                    //Console.WriteLine((string)item.SelectToken("Type"));
                    string name = (string)item.SelectToken("Name");
                    string type = (string)item.SelectToken("Type");
                    string published = (string)item.SelectToken("Published");
                    string url = (string)item.SelectToken("Url");
                    string pub = "style=\"color: black\"";
                    string subStyle = "style=\"background-color: white\"";
                    if (type == "ExternalUrl") type = "send";
                    if (type == "File") type = "file_copy";
                    if (type == "Discussion") type = "forum";
                    if (type == "Quiz") type = "help";
                    if (type == "Assignment") type = "assignment";
                    if (type == "Page") type = "receipt";
                    if (type == "SubHeader") subStyle = "style=\"background-color: #a3a3a3\"";
                    if (type == "SubHeader") type="" ;
                    if (url == "") url = "#";
                    if (published == "True")
                    {
                        pub = "style=\"color: green\"";
                        //Console.WriteLine(pub);
                    }
                    html += "<li class=\"list-group-item\"" + subStyle +"><a href=\"" + url + "\" target=\"_blank\">" + name + "</a><span id=\"type\"" + pub + ">" + "<i class=\"material-icons\">" + type + "</i></span></li>\n";
                }

                html += "</ul></div>";

            }

            html += "</div></body><script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script><script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js\" integrity=\"sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1\" crossorigin=\"anonymous\"></script><script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js\" integrity=\"sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM\" crossorigin=\"anonymous\"></script></html>";
            string template = "./template_report.html";


            string readHTML = File.ReadAllText(template);

            //Console.WriteLine(readHTML);

            readHTML += html;

            //Console.WriteLine(readHTML);

            string report = "./report.html";

            File.WriteAllText(report, readHTML, Encoding.UTF8);

            /* string id = "96";
            

            string[] modules = new string[5] { "Taco", "Bell", "Apple", "Cat", "Dog" };
            string[] moduleItems = new string[5] { "cameron", "Jake", "Matt", "Jim", "Dwight" };
            string[] types = new string[5] { "externalTool", "file", "discussion", "quiz", "assignment" };
            string[] published = new string[5] { "true", "false", "true", "true", "false" };


            //Console.WriteLine(items);
            foreach (var idnum in items)
            {
                currID = idnum.ModuleID;


                


                foreach (var item in items)
                {
                    if (currID == item.ModuleID)
                    {

                        Console.WriteLine(item.ModuleID);

                        string pub = "style=\"color: black\"";
                        if (item.Type == "ExternalUrl") item.Type = "send";
                        if (item.Type == "File") item.Type = "file_copy";
                        if (item.Type == "Discussion") item.Type = "forum";
                        if (item.Type == "Quiz") item.Type = "help";
                        if (item.Type == "Assignment") item.Type = "assignment";
                        if (item.Type == "Page") item.Type = "receipt";
                        if (item.Type == "SubHeader") item.Type = "";
                        if (item.Url == "") item.Url = "#";
                        if (item.Published == "True")
                        {
                            pub = "style=\"color: green\"";
                            Console.WriteLine(pub);
                        }
                        html += "<li class=\"list-group-item\"><a href=\"" + item.Url + "\" target=\"_blank\">" + item.Name + "</a><span id=\"type\"" + pub + ">" + "<i class=\"material-icons\">" + item.Type + "</i></span></li>\n";
                    }
                }
                html += "</ul></div>";
            }
            html += "</div></body><script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script><script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js\" integrity=\"sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1\" crossorigin=\"anonymous\"></script><script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js\" integrity=\"sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM\" crossorigin=\"anonymous\"></script></html>";

            //Console.WriteLine(html);

            string template = "./template_report.html";


            string readHTML = File.ReadAllText(template);

            //Console.WriteLine(readHTML);

            readHTML += html;

            //Console.WriteLine(readHTML);
 */
            //string report = "./report.html";

            //File.WriteAllText(report, readHTML, Encoding.UTF8);



            string str = report;
            return str;
        }

        public JArray Format(JArray jArray)
        {
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            return path;
        }
    }
}
