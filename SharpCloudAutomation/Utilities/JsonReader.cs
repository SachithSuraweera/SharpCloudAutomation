using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpCloudAutomation.Utilities
{
    public class JsonReader
    {
        private readonly string _workingDirectory;
        private readonly string _startupPath;

        public JsonReader() {
            _workingDirectory = Environment.CurrentDirectory;
            _startupPath = Directory.GetParent(_workingDirectory).Parent.Parent.FullName;
        }

        public string? ExtractInstanceDataJson(String tokenName)
        {
            string loginJsonString = File.ReadAllText(_startupPath + "\\TestData\\TestData_Instance.json");
            var jsonObject = JToken.Parse(loginJsonString);
            return jsonObject?.SelectToken(tokenName)?.Value<string>();
        }

        public List<CalculatedStoryList>? GetCalculatedStoryList()
        {           
            string BlankStoryJsonString = File.ReadAllText(_startupPath + "\\TestData\\testFile.json");
            return JsonConvert.DeserializeObject<List<CalculatedStoryList>>(BlankStoryJsonString);
        }

        public List<LightHouseBaseValue>? GetScenarios()
        {           
            string BlankStoryJsonString = File.ReadAllText(_startupPath + "\\TestData\\TestData_LighthouseBaseValuesWithUserLevels.json");
            return JsonConvert.DeserializeObject<List<LightHouseBaseValue>>(BlankStoryJsonString);
        }
    }
}
