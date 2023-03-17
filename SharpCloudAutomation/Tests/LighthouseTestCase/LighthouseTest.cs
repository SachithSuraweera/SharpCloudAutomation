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
        [TestCaseSource(nameof(GetTestData))]
        public void CompareLightHousePerformanceValues(string scenario, bool isLogin, string username, string password, decimal performance, decimal accessibility, decimal seo, string storyUrl)
        {
            LighthouseActualValues lighthouseActualValues;

        var softAssert = new SoftAssert();
        var scenarios = new JsonReader().GetScenarios();
        GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

            if (isLogin)
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
                loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username") ?? "", GetJsonData().ExtractInstanceDataJson("password") ?? "");
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            }
            GetDriver().Navigate().GoToUrl(storyUrl);
            GetDriver().Navigate().Refresh();
            lighthouseActualValues = new LighthouseActualValues(storyUrl ?? "");

            ExtentTest performanceNode = CreateNode("Lighthouse performance values :" + scenario);
            performanceNode.Log(Status.Info, "Lighthouse Base value " + performance);
            performanceNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Performance);
            softAssert.IsTrue(lighthouseActualValues.Performance >= performance);
            
            softAssert.VerifyAll();
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareLightHouseAccessibilityValues(string scenario, bool isLogin, string username, string password, decimal performance, decimal accessibility, decimal seo, string storyUrl)
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

            var scenarios = new JsonReader().GetScenarios();

            if (isLogin)
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
                loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username") ?? "", GetJsonData().ExtractInstanceDataJson("password") ?? "");
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            }
            GetDriver().Navigate().GoToUrl(storyUrl);
            GetDriver().Navigate().Refresh();
            lighthouseActualValues = new LighthouseActualValues(storyUrl ?? "");
            ExtentTest accessibilityNode = CreateNode("Lighthouse accessibility values : " + scenario);
            accessibilityNode.Log(Status.Info, "Lighthouse Base value : " + accessibility);
            accessibilityNode.Log(Status.Info, "Lighthouse Actual value : " + lighthouseActualValues.Accessibility);
            softAssert.IsTrue(lighthouseActualValues.Accessibility >= accessibility);
            
            softAssert.VerifyAll();
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareLightHouseSeoValues(string scenario, bool isLogin, string username, string password, decimal performance, decimal accessibility, decimal seo, string storyUrl)
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

            var scenarios = new JsonReader().GetScenarios();

            if (isLogin)
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
                loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username") ?? "", GetJsonData().ExtractInstanceDataJson("password") ?? "");
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            }
            GetDriver().Navigate().GoToUrl(storyUrl);
            GetDriver().Navigate().Refresh();
            lighthouseActualValues = new LighthouseActualValues(storyUrl ?? "");
            ExtentTest seoNode = CreateNode("Lighthouse seo values : " + scenario);
            seoNode.Log(Status.Info, "Lighthouse Base value : " + seo);
            seoNode.Log(Status.Info, "Lighthouse Actual value : " + lighthouseActualValues.Seo);
            softAssert.IsTrue(lighthouseActualValues.Seo >= seo);
            
            softAssert.VerifyAll();
        }
        public static IEnumerable<TestCaseData> GetTestData()
        {
            var scenarios = new JsonReader().GetScenarios();

            foreach (var sc in scenarios)
            {
                yield return new TestCaseData(sc.Scenario, sc.IsLogin, sc.Username, sc.Password, sc.Performance, sc.Accessibility, sc.Seo, sc.StoryUrl);
            }
        }
    }
}
