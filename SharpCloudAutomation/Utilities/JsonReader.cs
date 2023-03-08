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

        public List<LightHouseBaseValue> GetCalculatedStoryList()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string startupapth = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string BlankStoryJsonString = File.ReadAllText(startupapth + "\\TestData\\TestData_CalculationRelatedStory.json");

            List<LightHouseBaseValue> lightHouseBasevalues = JsonConvert.DeserializeObject<List<LightHouseBaseValue>>(BlankStoryJsonString);
            return lightHouseBasevalues;
        }

        public List<LightHouseBaseValue> GetScenarioes()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string startupapth = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string BlankStoryJsonString = File.ReadAllText(startupapth +"\\TestData\\TestData_LighthouseBaseValuesWithUserLevels.json");

            List<LightHouseBaseValue> lightHouseBasevalues = JsonConvert.DeserializeObject<List<LightHouseBaseValue>>(BlankStoryJsonString);
            return lightHouseBasevalues;
        }

        public List<UserLevelsValue> GetUsersList()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string startupapth = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string UserLevelStoryJsonString = File.ReadAllText(startupapth+"\\TestData\\TestData_UserLevels.json");

            List<UserLevelsValue> UserLevelsValues = JsonConvert.DeserializeObject<List<UserLevelsValue>>(UserLevelStoryJsonString);
            return UserLevelsValues;
        }
    }
}
