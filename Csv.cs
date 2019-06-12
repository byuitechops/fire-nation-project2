namespace Wololo2
{
    class Csv : IConverter 
    {
        string data;
        readonly string path; 

        Csv()
        {
            path = "csv.csv";
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