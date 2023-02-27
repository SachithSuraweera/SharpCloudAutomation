using AventStack.ExtentReports;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;



namespace SharpCloudAutomation.Utilities
{
    public class Base
    {
        public static ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        Reports reports = new Reports();
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string env = ConfigurationManager.AppSettings["env"];
        public static string isHeadless = ConfigurationManager.AppSettings["headless"];
        public static IJavaScriptExecutor js;

        public IWebDriver GetDriver()
        {
            return driver.Value;
        }
        public ExtentTest GetTest()
        {
            return test.Value;
        }

        public ExtentTest CreateNode(string value)
        {
            ExtentTest node = GetTest().CreateNode(value);
            return node;
        }


        [SetUp]
        public void StartBrowser()
        {
            if (env == null)
            {
                if (ConfigurationManager.AppSettings["env"] == "AutoInstance")
                {
                    test.Value = reports.Setup().CreateTest(TestContext.CurrentContext.Test.Name);
                    if (browser == null)
                    {
                        browser = ConfigurationManager.AppSettings["browser"];
                    }
                    InitializeBrowser(browser);

                    GetDriver().Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(20));
                    GetDriver().Manage().Window.Maximize();
                    GetDriver().Url = ConfigurationManager.AppSettings["AutoInstanceURL"];
                    ExtentTest node = CreateNode("Environment Selection");
                    node.Log(Status.Pass, "Navigated to Staging URL successfully");
                }
            }

            else
            {
                if (env == "AutoInstance")
                {
                    test.Value = reports.Setup().CreateTest(TestContext.CurrentContext.Test.Name);
                    if (browser == null)
                    {
                        browser = ConfigurationManager.AppSettings["browser"];
                    }
                    InitializeBrowser(browser);

                    GetDriver().Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(20));
                    GetDriver().Manage().Window.Maximize();
                    GetDriver().Url = ConfigurationManager.AppSettings["AutoInstanceURL"];
                    ExtentTest node = CreateNode("Environment Selection");
                    node.Log(Status.Info, "Auto Instance Environment");
                    node.Log(Status.Pass, "Navigated to Auto Instance URL successfully");
                }

                if (env == "Beta")
                {
                    test.Value = reports.Setup().CreateTest(TestContext.CurrentContext.Test.Name);
                    if (browser == null)
                    {
                        browser = ConfigurationManager.AppSettings["browser"];
                    }
                    InitializeBrowser(browser);

                    GetDriver().Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(20));
                    GetDriver().Manage().Window.Maximize();
                    GetDriver().Url = ConfigurationManager.AppSettings["BetaInstanceURL"];
                    ExtentTest node = CreateNode("Environment Selection");
                    node.Log(Status.Info, "Beta Environment");
                    node.Log(Status.Pass, "Navigated to Beta URL successfully");
                }
            }

        }

        public void InitializeBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (isHeadless == "Yes")
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddArgument("--headless");
                        options.AddArguments("window-size=1920,1080");
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver.Value = new FirefoxDriver(options);
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Firefox browser started");
                    }
                    if (isHeadless == "No")
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver.Value = new FirefoxDriver();
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Firefox browser started");
                    }
                    break;

                case "Chrome":
                    if (isHeadless == "Yes")
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        options.AddArguments("window-size=1920,1080");
                        options.AddArguments("use-fake-ui-for-media-stream");
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver.Value = new ChromeDriver(options);
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Chrome browser started");
                    }
                    if (isHeadless == "No")
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("use-fake-ui-for-media-stream");
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver.Value = new ChromeDriver(options);
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Chrome browser started");
                    }

                    break;

                case "Edge":
                    if (isHeadless == "Yes")
                    {
                        EdgeOptions options = new EdgeOptions();
                        options.AddArgument("--headless");
                        options.AddArguments("window-size=1920,1080");
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver.Value = new EdgeDriver(options);
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Edge browser started");
                    }

                    if (isHeadless == "No")
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver.Value = new EdgeDriver();
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Edge browser started");
                    }

                    break;

                /*case "Safari":
                    if (isHeadless == "Yes")
                    {
                        SafariOptions options = new SafariOptions();
                        options.AddArgument("--headless");
                        options.AddArguments("window-size=1920,1080");
                        new WebDriverManager.DriverManager().SetUpDriver(new SafariConfig());
                        driver.Value = new SafariDriver(options);
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Safari browser started");
                    }

                    if (isHeadless == "No")
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new SafariDriverService());
                        driver.Value = new SafariDriver();
                        ExtentTest node = CreateNode("Browser Selection");
                        node.Log(Status.Pass, "Safari browser started");
                    }

                    break;*/
            }
        }

        public static JsonReader GetJsonData()
        {
            return new JsonReader();
        }
        public void SetLocalStorage(IWebDriver driver, string key, string value)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("localStorage.setItem('" + key + "','" + value + "');");
        }

        public string GetStorage(string key)
        {
            string value = (string)js.ExecuteScript($"return localStorage.getItem('{key}')");
            js.ExecuteScript("console.log('Wooo')");
            return value;
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshots = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshots, screenShotName).Build();
        }

        [TearDown]
        public void AfterTest()
        {
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            if (status == TestStatus.Failed)
            {
                ExtentTest node = CreateNode("Test Case Failed");
                node.Fail("Test Case Failed", CaptureScreenshot(GetDriver(), fileName));
                node.Log(Status.Fail, stackTrace);
            }
            else if (status == TestStatus.Passed)
            {
                ExtentTest node = CreateNode("Test Case Passed");
                node.Pass("Test Case Passed");
            }
            GetDriver().Quit();
            reports.EndReport();
        }
    }
}
