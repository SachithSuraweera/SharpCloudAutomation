using AngleSharp.Dom;
using AventStack.ExtentReports;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Tests.LoginTestCase;
using SharpCloudAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Tests.LighthouseTestCase
{

    public class LighthouseTest : Base
    {
        [Test]
        public void CompareLightHouseValues()
        {
            LighthouseActualValues lighthouseActualValues;
            string userLoginIsRequired = GetJsonData().ExtractEnvironment("IsLogin");
            string[] values = { "Performance", "Accessibility", "Seo" };
            string[] baseValues = { "performance", "accessibility", "seo" };


            if (userLoginIsRequired == "True")
            {
                LoginValidation loginTest = new LoginValidation();
                loginTest.loginToTheSystem();
            }

            string storyUrl = GetJsonData().ExtractEnvironment("storyUrl");
            Thread.Sleep(5000);
            GetDriver().Navigate().GoToUrl(storyUrl);
            lighthouseActualValues = new LighthouseActualValues();
            for (int i = 0; i < values.Length; i++)
            {
                string typeOfValue = values[i];
                string baseValue = GetJsonData().ExtractEnvironment(baseValues[i]);
                decimal decimalBaseValue = Convert.ToDecimal(baseValue);
                var lighthouseValue = (decimal)lighthouseActualValues.GetType().GetProperty(typeOfValue).GetValue(lighthouseActualValues, null);
                Console.WriteLine("Actual value " + lighthouseValue);
                Console.WriteLine("Base value " + baseValue);
                Assert.IsTrue(lighthouseValue >= decimalBaseValue);
                ExtentTest dasboardNode = CreateNode("Lighthouse " + typeOfValue + " values");
                dasboardNode.Log(Status.Info, "Lighthouse Base value " + baseValue);
                dasboardNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseValue);

            }

        }

    }
}
