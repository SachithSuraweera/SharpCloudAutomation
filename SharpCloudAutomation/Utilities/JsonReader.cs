using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Utilities
{
    public class JsonReader
    {
        public String ExtractInstanceDataJson(String tokenName)
        {
            String loginJsonString = File.ReadAllText("TestData/TestData_Instance.json");

            var jsonObject = JToken.Parse(loginJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public String ExtractEnvironment(String tokenName)
        {
            String loginJsonString = File.ReadAllText("TestData/TestData_LighthouseBaseValuesWithUserLevels.json");

            var jsonObject = JToken.Parse(loginJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
}
