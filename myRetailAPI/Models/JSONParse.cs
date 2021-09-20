using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Product.Models
{
    public class JSONParse
    {
        public JSONParse()
        {

        }
        //recursive function to deserialize JSON
        public Dictionary<string,string> deserializeJSONSelect(string jsonString, Dictionary<string,string> recursivePairsFound, string parentString = "")
        {
            

            
            //edge case
            if (jsonString.EndsWith("}]}]}"))
            {
                jsonString = jsonString.Replace("}]", "}").Replace("[{", "{"); 
            }
            
            //edge case
            if(jsonString.StartsWith("[{"))
            {
                string[] splitRec;
                splitRec = jsonString.Split("},");

                foreach(string s in splitRec)
                {
                    Dictionary<string, string> returnRecursionSplit = deserializeJSONSelect(s.Replace("}", "").Replace("{", "").Replace("[",""), recursivePairsFound, parentString);
                    returnRecursionSplit.ToList().ForEach(x => recursivePairsFound[x.Key] = x.Value);

                    return recursivePairsFound;
                }

                
            }

            if(!jsonString.Contains("{") && !jsonString.Contains("}"))
            {
                jsonString = "{" + jsonString + "}";
            }

            Dictionary<string, object> jsonPairs = new Dictionary<string, object>();

            try
            {
                jsonPairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            }
            catch(Exception ex)
            {
                Dictionary<string, string> errorPairs = new Dictionary<string, string>();
                errorPairs.Add("invalid", "incorrectly formatted json");
                return errorPairs;
            }
            
            

            foreach(string s in jsonPairs.Keys)
            {
                object retrievedObjectValue = "";
                jsonPairs.TryGetValue(s, out retrievedObjectValue);

                    

                if(!retrievedObjectValue.ToString().Contains("{\""))
                {
                    if(!recursivePairsFound.ContainsKey(s))
                    recursivePairsFound.Add(s + "_" + parentString, retrievedObjectValue.ToString());
                }
                else
                {
                    
                    Dictionary<string,string> returnRecursion = deserializeJSONSelect(retrievedObjectValue.ToString(), recursivePairsFound, s + "_" + parentString);

                    returnRecursion.ToList().ForEach(x => recursivePairsFound[x.Key] = x.Value);
                }

                
            }

            

            return recursivePairsFound;
        }
    }
}
