namespace Wololo2
{
    class HtmlClass : IConverter 
    {
        string data;
        readonly string path; 

        HtmlClass()
        {
            path = "html.html";
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