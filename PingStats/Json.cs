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

        internal static void CreateNewJsonFile(string json)
        {
            // write the formatted JSON to a created file.
            FileWriter writer = new FileWriter();

            string writeFile = writer.CreateFileName();
            writer.WriteToFile(writeFile, json);

            // change the file to JSON format
            writer.ChangeFileExten(writeFile, ".json");
            
        }
    }
}
