using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Newtonsoft.Json.Linq;

namespace Wololo
{
    class In
    {

      

        /// <summary>
        /// A method in the <c>In</c> class. Takes a CSV file path, 
        /// opens the file and takes the contents
        /// and creates a JArray for the user to use
        /// </summary>
        /// <param name="path">The path to your CSV File</param>
        internal static JArray jarrFromCSVFile(string path)
        {
            JArray jarr = new JArray();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                // read records in as a dynamic object
                var records = csv.GetRecords<dynamic>();

                foreach (dynamic rec in records)
                {
                    JObject job = JObject.FromObject(rec);
                    jarr.Add(job);
                }

            }
            return jarr;
        }

        // Convert JSON file to JArray 
        ///<summary>
        /// A method in the <c>In</c> class. Takes a JSON file path, 
        /// opens the file and takes the contents
        /// and creates a JArray for the user to use
        ///</summary>
        ///
        ///<param name="path">The path to your JSON File</param>
        internal static JArray jarrFromJSONFile(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            JArray jarr = JArray.Parse(json);
            return jarr;
        }

        // Convert C# OBJ to JArray 
        /// <summary>
        /// A method in the <c>In</c> class. Takes an object and
        /// creates a JArray for the user.
        /// </summary>
        ///
        /// <param name="objects">A list of dynamic type objects</param>
        internal static JArray jarrFromObj(List<dynamic> objects)
        {
            // loop through the list of objects and add them to the array.
            JArray jarr = new JArray();

            foreach (dynamic obj in objects)
            {
                JObject job = JObject.FromObject(obj);
                jarr.Add(job);
            }
            return jarr;
        }
    }
}