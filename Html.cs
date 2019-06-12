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

        public string GetPath()
        {
            return path;
        }
    }
}