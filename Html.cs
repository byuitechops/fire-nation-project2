using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    class Html : IConverter 
    {
        string data;
        readonly string path; 

        Html()
        {
            path = "html.html";
        }

        public string Convert()
        {
            string str = "";
            return str;
        }

        public List<dynamic> Format(JArray jArray)
        {
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            return path;
        }
    }
}