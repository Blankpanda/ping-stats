using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PingStats
{
    // handles all of the JSON creating and seralizing within the application, inherits FileWriter
    class Json : FileWriter
    {
        // todo : make the inputed list dynamic
        internal static string FormatJson(List<long> items)
        {
            string json = JsonConvert.SerializeObject(items.ToArray() , Formatting.Indented);
                return json;
        }
        internal static string FormatJson(List<string> items)
        {
            string json = JsonConvert.SerializeObject(items.ToArray(), Formatting.Indented);
                return json;
        }

        internal static void CreateNewJsonFile(string filename, string json)
        {
            // write the formatted JSON to a created file.
            FileWriter writer = new FileWriter();

            string writeFile = writer.CreateFileName(filename); // new filename
            writer.WriteToFile(writeFile, json); // writes the contents of the the json string to a file.

            // change the file to JSON format
            writer.ChangeFileExten(writeFile, ".json");  // the file starts off as a .txt but we convert it to a json file.
            
        }

 
    }
}
