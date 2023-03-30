using AventStack.ExtentReports;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace SharpCloudAutomation.Utilities
{
    public class Base
    {
        public IConfiguration configuration;
        public static string env;
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string isHeadless = ConfigurationManager.AppSettings["headless"];

        public static ThreadLocal<ExtentTest> test = new();       
        public static IJavaScriptExecutor js;

        public ThreadLocal<IWebDriver> driver = new();
        private Reports reports = new();

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
                env = ConfigurationManager.AppSettings["env"] ?? "AutoInstance";

            test.Value = reports.Setup().CreateTest(TestContext.CurrentContext.Test.MethodName);

            browser = ConfigurationManager.AppSettings["browser"] ?? "";
            InitializeBrowser(browser);

            GetDriver().Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(20));
            GetDriver().Manage().Window.Maximize();

            ExtentTest node = CreateNode("Environment Selection");

            if (env == "AutoInstance")
            {
                GetDriver().Url = ConfigurationManager.AppSettings["AutoInstanceURL"];

                node.Log(Status.Info, "Auto Instance Environment");
                node.Log(Status.Pass, "Navigated to Auto Instance URL successfully");
            }

            if (env == "Beta")
            {
                GetDriver().Url = ConfigurationManager.AppSettings["BetaInstanceURL"];

                node.Log(Status.Info, "Beta Environment");
                node.Log(Status.Pass, "Navigated to Beta URL successfully");
            }

            AddConfiguarions();

        }

        public void InitializeBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        if (isHeadless == "Yes")
                        {
                            FirefoxOptions options = new();
                            options.AddArgument("--headless");
                            options.AddArguments("window-size=1920,1080");
                            driver.Value = new FirefoxDriver(options);
                        }
                        if (isHeadless == "No")
                        {
                            driver.Value = new FirefoxDriver();
                        }
                    }
                    break;
                case "Chrome":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions options = new();
                        options.SetLoggingPreference(LogType.Browser, LogLevel.All);
                       
                        if (isHeadless == "Yes")
                        {
                            options.AddArgument("--headless");
                            options.AddArguments("window-size=1920,1080");
                        }
                        options.AddArguments("use-fake-ui-for-media-stream");
                        driver.Value = new ChromeDriver(options);
                    }
                    break;
                case "Edge":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        if (isHeadless == "Yes")
                        {
                            EdgeOptions options = new();
                            options.AddArgument("--headless");
                            options.AddArguments("window-size=1920,1080");
                            driver.Value = new EdgeDriver(options);
                        }
                        if (isHeadless == "No")
                        {
                            driver.Value = new EdgeDriver();
                        }
                    }
                    break;
                case "Safari":
                    if (isHeadless == "No")
                    {
                        Dictionary<string, object> browserStackOptions = new()
                        {
                            { "userName", "aloka_6B71TW" },
                            { "accessKey", "ia5cPxyjeDYbp62qpq3s" },
                            { "os", "OS X" },
                            { "osVersion", "Monterey" },
                            { "browserVersion", "15.0" },
                            { "projectName", " SharpCloudAutomation" },
                            { "local", "false" },
                            { "seleniumVersion", "4.7.2" },
                            { "browserName", "Safari" }
                        };
                        SafariOptions options = new();
                        options.AddAdditionalOption("bstack:options", browserStackOptions);
                        driver.Value = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), options);
                        WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(10));
                    }
                    break;
            }

            ExtentTest node = CreateNode("Browser Selection");
            node.Log(Status.Pass, $"{browserName} browser started");
        }

        public static JsonReader GetJsonData()
        {
            return new JsonReader();
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
            ErrorLogs errLog = new(GetDriver());
            errLog.AddBrowserLogs();

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

        public void AddConfiguarions()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables() .Build();

            Config.EmailAPIKey = config["Email_API_Key"];
            Config.BlobConnectionString = config["BlobConnectionString"];
            Config.Email_Secret = config["Email_Secret"];
        }
    }

    public static class Config
    {
        public static string EmailAPIKey { get; set; }
        public static string BlobConnectionString { get; set; }
        public static string Email_Secret { get; set; }
    }
}