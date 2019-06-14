using Newtonsoft.Json.Linq;

namespace Wololo2
{
    interface IConverter
    {
        string Parse(JArray jArray);
    }
}