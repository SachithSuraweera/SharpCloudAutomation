using AventStack.ExtentReports;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using SoftAssertion;
using System.Configuration;


namespace SharpCloudAutomation.Tests.LighthouseTestCase
{
    public class LighthouseTest : Base
    {
        [Test]
        public void CompareLightHouseValues()
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new SoftAssert();

            var scenarios = new JsonReader().GetScenarioes();

            foreach (var sc in scenarios ) 
            {
                if(sc.IsLogin)
                {
                    if(ConfigurationManager.AppSettings["env"] == "AutoInstance")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["AutoInstanceURL"]);
                    }
                    else if(ConfigurationManager.AppSettings["env"] == "Beta")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["BetaInstanceURL"]);
                    }
                    LoginPage loginPage = new LoginPage(GetDriver());
                    loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));
                }
                Thread.Sleep(5000);
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest performanceNode = CreateNode("Lighthouse performance values :" + sc.Scenario);
                performanceNode.Log(Status.Info, "Lighthouse Base value " + sc.Performance);
                performanceNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Performance);
                softAssert.IsTrue(lighthouseActualValues.Performance >= sc.Performance);

                ExtentTest accessibilityNode = CreateNode("Lighthouse accessibility values :" + sc.Scenario);
                accessibilityNode.Log(Status.Info, "Lighthouse Base value " + sc.Accessibility);
                accessibilityNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Accessibility);
                softAssert.IsTrue(lighthouseActualValues.Accessibility >= sc.Accessibility);

                ExtentTest seoNode = CreateNode("Lighthouse seo values :" + sc.Scenario);
                seoNode.Log(Status.Info, "Lighthouse Base value " + sc.Seo);
                seoNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Seo);
                softAssert.IsTrue(lighthouseActualValues.Seo >= sc.Seo);
            }
            softAssert.VerifyAll();
        }
    }
}
