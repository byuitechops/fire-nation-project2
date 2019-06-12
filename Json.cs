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

        public string Convert()
        {
            string str = "";
            return str;
        }

        public string GetPath()
        {
            return path;
        }
    }
}