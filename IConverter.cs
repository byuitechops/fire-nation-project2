using Newtonsoft.Json.Linq;

namespace Wololo2
{
    interface IConverter
    {
         string ToString(JArray items);
         JArray Parse(JArray jArray);
         void WriteFile(string data);
    }
}