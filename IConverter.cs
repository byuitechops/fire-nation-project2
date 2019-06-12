using Newtonsoft.Json.Linq;

namespace Wololo2
{
    interface IConverter
    {
         string Convert();
         //JObject Format();
         string GetPath();
    }
}