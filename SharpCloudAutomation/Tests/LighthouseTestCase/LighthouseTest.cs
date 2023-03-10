using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using SoftAssertion;
using System.Configuration;

namespace SharpCloudAutomation.Tests.LighthouseTestCase
{
    public class LighthouseTest : Base
    {
        [Test]
        public void CompareLightHousePerformanceValues()
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new SoftAssert();
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

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
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
                }
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest performanceNode = CreateNode("Lighthouse performance values :" + sc.Scenario);
                performanceNode.Log(Status.Info, "Lighthouse Base value " + sc.Performance);
                performanceNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Performance);
                softAssert.IsTrue(lighthouseActualValues.Performance >= sc.Performance);
            }
            softAssert.VerifyAll();
        }

        [Test]
        public void CompareLightHouseAccessibilityValues()
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new();
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

            var scenarios = new JsonReader().GetScenarioes();

            foreach (var sc in scenarios)
            {
                if (sc.IsLogin)
                {
                    if (ConfigurationManager.AppSettings["env"] == "AutoInstance")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["AutoInstanceURL"]);
                    }
                    else if (ConfigurationManager.AppSettings["env"] == "Beta")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["BetaInstanceURL"]);
                    }
                    LoginPage loginPage = new(GetDriver());
                    loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
                }
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest accessibilityNode = CreateNode("Lighthouse accessibility values : " + sc.Scenario);
                accessibilityNode.Log(Status.Info, "Lighthouse Base value : " + sc.Accessibility);
                accessibilityNode.Log(Status.Info, "Lighthouse Actual value : " + lighthouseActualValues.Accessibility);
                softAssert.IsTrue(lighthouseActualValues.Accessibility >= sc.Accessibility);
            }
            softAssert.VerifyAll();
        }

        [Test]
        public void CompareLightHouseSeoValues()
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new();
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

            var scenarios = new JsonReader().GetScenarioes();

            foreach (var sc in scenarios)
            {
                if (sc.IsLogin)
                {
                    if (ConfigurationManager.AppSettings["env"] == "AutoInstance")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["AutoInstanceURL"]);
                    }
                    else if (ConfigurationManager.AppSettings["env"] == "Beta")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["BetaInstanceURL"]);
                    }
                    LoginPage loginPage = new(GetDriver());
                    loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
                }
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest seoNode = CreateNode("Lighthouse seo values : " + sc.Scenario);
                seoNode.Log(Status.Info, "Lighthouse Base value : " + sc.Seo);
                seoNode.Log(Status.Info, "Lighthouse Actual value : " + lighthouseActualValues.Seo);
                softAssert.IsTrue(lighthouseActualValues.Seo >= sc.Seo);
            }
            softAssert.VerifyAll();
        }
    }
}
