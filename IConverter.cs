using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    interface IConverter
    {
         string Convert(List<dynamic> items);
         List<dynamic> Format(JArray jArray);
         string GetPath();
    }
}