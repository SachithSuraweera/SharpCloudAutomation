using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.Configuration;

namespace SharpCloudAutomation.Utilities
{
    public class Reports
    {
        private static ExtentReports? _extent;
        private static string? _date;

        public ExtentReports Setup()
        {
            if (_extent == null)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string? parentDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;
                string? browserName = ConfigurationManager.AppSettings["browser"];
                string todaysDate = DateTime.Now.ToString("yyyy-MM-dd");
                string todaysFolder = (parentDirectory + "//Output//" + todaysDate);

                if (!Directory.Exists(todaysFolder))
                {
                    Directory.CreateDirectory(todaysFolder);
                }

                _date = $"index_{DateTime.Now:yyyy_MM_dd_HH_mm}";

                string reportPath = $"{todaysFolder}//{_date}-{browserName}.html";
                var htmlReporter = new ExtentV3HtmlReporter(reportPath);
                htmlReporter.Config.Theme = Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
                _extent.AddSystemInfo("Project Name", "SharpCloudAutomation");
                _extent.AddSystemInfo("Environment", Base.env);
                _extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                _extent.AddSystemInfo("Browser", Base.browser);
            }
            return _extent;
        }

        public void EndReport()
        {
            _extent?.Flush();
        }

        public string? GetTime()
        {
            return _date;
        }
    }
}
