using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Repo_Inpatient_Care.GenericUtilitys
{
    public class JsonUtility
    {
        public static string GetJsonKeyValue(string key,string path)
        {
           string jsonContent= File.ReadAllText(path);
            JToken jtoken=JToken.Parse(jsonContent);

            //  string keyValue= jtoken.SelectToken(key).ToString();

            string keyValue = jtoken[key].ToString();
            return keyValue;
        }

        public static IEnumerable<GetJsonData> JsonDataSet(string path)
        {
            string jsonContent = File.ReadAllText(path);
            GetJsonData commonData = JsonConvert.DeserializeObject<GetJsonData>(jsonContent);
           yield return commonData;
        }
    }
}
