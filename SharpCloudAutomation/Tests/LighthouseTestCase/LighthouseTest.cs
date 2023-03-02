using AngleSharp.Dom;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Tests.LoginTestCase;
using SharpCloudAutomation.Utilities;
using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Tests.LighthouseTestCase
{
    public class LighthouseTest : Base
    {
        [Test]
        public void CompareLightHousePerformanceValues()
        {
            LighthouseActualValues lighthouseActualValues;

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
                    GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

                    Assert.IsTrue(loginPage.getGoBtn().Displayed);
                    loginPage.getUserName().SendKeys(sc.Username);
                    loginPage.getPassword().SendKeys(sc.Password);
                }
                
                
                Thread.Sleep(5000);
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest performanceNode = CreateNode("Lighthouse performance values :" + sc.Scenario);
                performanceNode.Log(Status.Info, "Lighthouse Base value " + sc.Performance);
                performanceNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Performance);
                Assert.IsTrue(lighthouseActualValues.Performance >= sc.Performance);
                
                
                Assert.IsTrue(lighthouseActualValues.Accessibility >= sc.Accessibility);
                ExtentTest accessibilityNode = CreateNode("Lighthouse accessibility values :" + sc.Scenario);
                accessibilityNode.Log(Status.Info, "Lighthouse Base value " + sc.Accessibility);
                accessibilityNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Accessibility);

                Assert.IsTrue(lighthouseActualValues.Seo >= sc.Seo);
                ExtentTest seoNode = CreateNode("Lighthouse seo values :" + sc.Scenario);
                seoNode.Log(Status.Info, "Lighthouse Base value " + sc.Seo);
                seoNode.Log(Status.Info, "Lighthouse Actual value " + lighthouseActualValues.Seo);
            }
        }
    }
}
