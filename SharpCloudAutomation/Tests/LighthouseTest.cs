using AngleSharp.Dom;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Tests
{
    
    public class LighthouseTest : Base
    {
        [Test]
        public void CompareLightHouse()
        {
            LighthouseActualValues lighthouseActualValues;
            string userLoginIsRequired = GetJsonData().ExtractEnvironment("IsLogin");
            string[] values = { "Performance", "Accessibility", "Seo" };

            if (userLoginIsRequired == "True")
            {
                LoginValidation loginTest = new LoginValidation();
                loginTest.loginToTheSystem();
            }

            string storyUrl = GetJsonData().ExtractEnvironment("storyUrl");
            GetDriver().Navigate().GoToUrl(storyUrl);
            lighthouseActualValues = new LighthouseActualValues();
            for (int i = 0; i < values.Length; i++)
            {
                String typeOfValue = values[i];
                string baseValue = GetJsonData().ExtractEnvironment("performance");
                decimal decimalBaseValue = Convert.ToDecimal(baseValue);
                var lighthouseValue = (decimal)lighthouseActualValues.GetType().GetProperty(typeOfValue).GetValue(lighthouseActualValues, null);
                Console.WriteLine("Actual value " + lighthouseValue);
                Console.WriteLine("Base value " + baseValue);
                Assert.IsTrue(lighthouseValue >= decimalBaseValue);
            }

        }

    }
}
