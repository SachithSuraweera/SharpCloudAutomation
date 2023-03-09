using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Configuration;

namespace SharpCloudAutomation.Utilities
{
    public class Reports
    {
        public static ExtentReports extent;
        public static string date;

        public ExtentReports Setup()
        {
            if (Base.browser == null && Base.env == null)
            {
                if (extent == null)
                {
                    string workingDirectory = Environment.CurrentDirectory;
                    string parentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string browserName = ConfigurationManager.AppSettings["browser"];
                    string TodaysDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string TodaysFolder = (parentDirectory + "//Output//" + TodaysDate);

                    if (!Directory.Exists(TodaysFolder))
                    {
                        Directory.CreateDirectory(TodaysFolder);
                    }
                    date = String.Format("{0}_{1:yyyy_MM_dd_HH_mm}", "index", DateTime.Now);
                    string reportPath = $"{TodaysFolder}//{date}-{browserName}.html";
                    var htmlReporter = new ExtentV3HtmlReporter(reportPath);
                    htmlReporter.Config.Theme = Theme.Dark;
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Project Name", "SharpCloudAutomation");
                    extent.AddSystemInfo("Environment", Base.env);
                    extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                    extent.AddSystemInfo("Browser", Base.browser);
                }

            }

            else
            {
                if (extent == null)
                {
                    string workingDirectory = Environment.CurrentDirectory;
                    string parentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string browserName = ConfigurationManager.AppSettings["browser"];
                    string TodaysDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string TodaysFolder = (parentDirectory + "//Output//" + TodaysDate);

                    if (!Directory.Exists(TodaysFolder))
                    {
                        Directory.CreateDirectory(TodaysFolder);
                    }
                    date = String.Format("{0}_{1:yyyy_MM_dd_HH_mm}", "index", DateTime.Now);
                    string reportPath = $"{TodaysFolder}//{date}-{browserName}.html";
                    var htmlReporter = new ExtentV3HtmlReporter(reportPath);
                    htmlReporter.Config.Theme = Theme.Dark;
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Project Name", "SharpCloudAutomation");
                    extent.AddSystemInfo("Environment", Base.env);
                    extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                    extent.AddSystemInfo("Browser", Base.browser);
                }
            }
            return extent;
        }
        public string getDateandTime()
        {
            return date;
        }
        public void EndReport()
        {
            extent.Flush();
        }
    }
}
