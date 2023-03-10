using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpCloudAutomation.Utilities
{
    public class JsonReader
    {
        public String ExtractInstanceDataJson(String tokenName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string startupapth = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String loginJsonString = File.ReadAllText(startupapth +"\\TestData\\TestData_Instance.json");

            var jsonObject = JToken.Parse(loginJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public List<CalculatedStoryList> GetCalculatedStoryList()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string startupapth = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            //string BlankStoryJsonString = File.ReadAllText(startupapth + "\\TestData\\TestData_CalculationRelatedStory.json");
            string BlankStoryJsonString = File.ReadAllText(startupapth + "\\TestData\\testFile.json");
            List<CalculatedStoryList> calculatedStoryvalues = JsonConvert.DeserializeObject<List<CalculatedStoryList>>(BlankStoryJsonString);
            return calculatedStoryvalues;
        }

        public List<LightHouseBaseValue> GetScenarioes()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string startupapth = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string BlankStoryJsonString = File.ReadAllText(startupapth +"\\TestData\\TestData_LighthouseBaseValuesWithUserLevels.json");

            List<LightHouseBaseValue> lightHouseBasevalues = JsonConvert.DeserializeObject<List<LightHouseBaseValue>>(BlankStoryJsonString);
            return lightHouseBasevalues;
        }

    }
}
