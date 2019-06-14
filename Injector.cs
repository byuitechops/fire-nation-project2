using System;
using System.Collections.Generic;

namespace Wololo2
{
    class Injector
    {
        static internal Tuple<IData, IConverter> Startup(Tuple<string, string> input)
        {
            IData getter = new HttpGet();
            IConverter setter;

            if (input.Item2 == "json")
            {
                setter = new Json();
            }
            else if (input.Item2 == "csv")
            {
                setter = new Csv();
            }
            else
            {
                setter = new Html();
            }
            
            return Tuple.Create(getter, setter);
        }
    }
}