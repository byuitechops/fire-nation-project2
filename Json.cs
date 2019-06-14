using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            return path;
        }
    }
}