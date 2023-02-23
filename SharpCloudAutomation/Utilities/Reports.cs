using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SharpCloudAutomation.Utilities
{
    public class Reports
    {
        public static ExtentReports extent;

        public ExtentReports Setup()
        {
            if (Base.browser == null && Base.env == null)
            {
                if (extent == null)
                {
                    string workingDirectory = Environment.CurrentDirectory;
                    string parentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string reportPath = parentDirectory + "//Output//index.html";
                    var htmlReporter = new ExtentHtmlReporter(reportPath);
                    htmlReporter.Config.Theme = Theme.Dark;
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Project Name", "Airudi");
                    extent.AddSystemInfo("Environment", ConfigurationManager.AppSettings["env"]);
                    extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                    extent.AddSystemInfo("Browser", ConfigurationManager.AppSettings["browser"]);
                }

            }

            else
            {
                if (extent == null)
                {
                    string workingDirectory = Environment.CurrentDirectory;
                    string parentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    string reportPath = parentDirectory + "//Output//index.html";
                    var htmlReporter = new ExtentHtmlReporter(reportPath);
                    htmlReporter.Config.Theme = Theme.Dark;
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Project Name", "Airudi");
                    extent.AddSystemInfo("Environment", Base.env);
                    extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                    extent.AddSystemInfo("Browser", Base.browser);
                }
            }
            return extent;
        }
        public void EndReport()
        {
            extent.Flush();
        }
    }
}
