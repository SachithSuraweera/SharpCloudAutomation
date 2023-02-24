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
                    //string date = String.Format("{0}_{1:yyyy_MM_dd}", "test", DateTime.Now);
                    //string reportPath = parentDirectory + "//Output//"+date+".html";
                    //string reportPath = parentDirectory + "//Output//test.html";
                    //var htmlReporter = new ExtentHtmlReporter(reportPath);
                    string date = String.Format("{0}_{1:yyyy_MM_dd_HH_mm}", "index", DateTime.Now);
                    string reportPath = $"{parentDirectory}//Output//{date}.html";
                    var htmlReporter = new ExtentV3HtmlReporter(reportPath);
                    htmlReporter.Config.Theme = Theme.Dark;
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Project Name", "SharpCloudAutomation");
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
                    string browserName = ConfigurationManager.AppSettings["browser"];
                    string TodaysDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string TodaysFolder = (parentDirectory + "//Output//" + TodaysDate);
                    //Directory.CreateDirectory(parentDirectory + "//Output/Test"+ TodaysDate);
                    string date = String.Format("{0}_{1:yyyy_MM_dd_HH_mm}", "index", DateTime.Now);
                    string reportPath = $"{parentDirectory}//Output//{date}.html";
                    //string reportPath = parentDirectory + "//Output//test.html";
                    /*var htmlReporter = new ExtentV3HtmlReporter(reportPath);
                    htmlReporter.Config.Theme = Theme.Dark;
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Project Name", "SharpCloudAutomation");
                    extent.AddSystemInfo("Environment", Base.env);
                    extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                    extent.AddSystemInfo("Browser", Base.browser);*/

                    if (!Directory.Exists(TodaysFolder))
                    {
                        Directory.CreateDirectory(TodaysFolder);
                    }
                    string date1 = String.Format("{0}_{1:yyyy_MM_dd_HH_mm}", "index", DateTime.Now);
                    string reportTestPath = $"{TodaysFolder}//{date1}-{browserName}.html";
                    var htmlReporter = new ExtentV3HtmlReporter(reportTestPath);
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
        public void EndReport()
        {
            extent.Flush();
        }
    }
}
