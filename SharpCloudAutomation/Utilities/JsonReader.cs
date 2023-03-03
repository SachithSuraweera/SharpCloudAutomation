using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public List<CalculatedStoryList> GetCalculatedStoryList()
        {
            string calulatedStoryJsonString = File.ReadAllText("TestData/TestData_CalculationRelatedStory.json");

            List<CalculatedStoryList> calculatedStoryList = JsonConvert.DeserializeObject<List<CalculatedStoryList>>(calulatedStoryJsonString);
            return calculatedStoryList;
        }

        public List<LightHouseBaseValue> GetScenarioes()
        {
            string BlankStoryJsonString = File.ReadAllText("TestData/TestData_LighthouseBaseValuesWithUserLevels.json");

            List<LightHouseBaseValue> lightHouseBasevalues = JsonConvert.DeserializeObject<List<LightHouseBaseValue>>(BlankStoryJsonString);
            return lightHouseBasevalues;
        }
    }
}
