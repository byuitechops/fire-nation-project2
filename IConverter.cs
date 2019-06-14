using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Wololo2
{
    interface IConverter
    {
         string Convert(JArray items);
         JArray Format(JArray jArray);
         string GetPath();
    }
}