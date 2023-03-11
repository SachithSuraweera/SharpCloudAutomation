using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace SharpCloudAutomation.Utilities
{
    public class ErrorLogs : Base
    {
        private readonly IWebDriver _driver;

        public ErrorLogs(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddBrowserLogs()
        {
            string? driverName = ConfigurationManager.AppSettings["browser"];

            if (driverName.Contains("Firefox"))
            {
                FirefoxOptions options = new();
                Thread.Sleep(5000);
                ILogs logs = _driver.Manage().Logs;
                var logEntries = logs.GetLog(LogType.Browser);
                if (logEntries.Count != 0)
                {
                    var severeLogEntries = options.LogLevel = FirefoxDriverLogLevel.Trace;
                    if (severeLogEntries.Equals(FirefoxDriverLogLevel.Trace))
                    {
                        Console.WriteLine("FF error warn : " + severeLogEntries);
                        ExtentTest dashboardNode = CreateNode("FF error warn");
                        dashboardNode.Log(Status.Info, "FF error warn : " + severeLogEntries);
                    }
                }
            }
            else if (driverName.Contains("Chrome"))
            {
                ILogs logs = _driver.Manage().Logs;
                var logEntries = logs.GetLog(LogType.Browser);
                if (logEntries.Count != 0)
                {
                    Console.WriteLine("Severe Console Error Log Entries for Chrome:");
                    ExtentTest dashboardNode = CreateNode("Severe Console Error Log Entries for Chrome:");
                    var severeLogEntries = logEntries.Where(x => x.Level == LogLevel.Severe);
                    if (severeLogEntries.Any())
                    {
                        Console.WriteLine($"Severe Level Console Error Log Count: {severeLogEntries.Count()}");
                        dashboardNode.Log(Status.Info, "Severe Level Console Error Log Count : " + severeLogEntries.Count());
                        foreach (var logEntry in severeLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            dashboardNode.Log(Status.Info, "Severe Level Console Errors : " + logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                        dashboardNode.Log(Status.Info, "No logs tracked in Severe Level Console");
                    }

                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Warning Level Console Error Log Entries for Chrome:");
                    ExtentTest dashboardNode1 = CreateNode("Warning Level Console Error Log Entries for Chrome:");
                    var warningLogEntries = logEntries.Where(x => x.Level == LogLevel.Warning);
                    if (warningLogEntries.Any())
                    {
                        Console.WriteLine($"Warning Console Error Log Count: {warningLogEntries.Count()}");
                        dashboardNode1.Log(Status.Info, "Warning Console Error Log Count : " + warningLogEntries.Count());
                        foreach (var logEntry in warningLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            dashboardNode1.Log(Status.Info, "Warning Console Error Log Count : " + logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                        dashboardNode1.Log(Status.Info, "No logs tracked");
                    }
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Debug Console Error Log Entries for Chrome:");
                    ExtentTest dashboardNode2 = CreateNode("Debug Console Error Log Entries for Chrome:");
                    var debugEntries = logEntries.Where(x => x.Level == LogLevel.Debug);
                    if (debugEntries.Any())
                    {
                        Console.WriteLine($"Debug Level Console Error Log Count: {debugEntries.Count()}");
                        dashboardNode2.Log(Status.Info, "Debug Level Console Error Log Count : " + debugEntries.Count());
                        foreach (var logEntry in debugEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            dashboardNode2.Log(Status.Info, "Debug Level Console Error Logs : " + logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                        dashboardNode2.Log(Status.Info, "No logs tracked in Debug Level ");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Info Level Console Error Log Entries for Chrome:");
                        ExtentTest dashboardNode3 = CreateNode("Info Level Console Error Log Entries for Chrome:");
                        var infoLogEntries = logEntries.Where(x => x.Level == LogLevel.Info);
                        if (infoLogEntries.Any())
                        {
                            Console.WriteLine($"Info Console Error Log Count: {infoLogEntries.Count()}");
                            dashboardNode3.Log(Status.Info, "Info Console Error Log Count: " + infoLogEntries.Count());
                            foreach (var logEntry in infoLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                dashboardNode3.Log(Status.Info, "Info Console Error Log " + logEntry.ToString());
                                Console.WriteLine("\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dashboardNode3.Log(Status.Info, "No logs tracked");
                        }
                        Console.WriteLine($"\nTotal Number of browser error count for Chrome is: {logEntries.Count}");
                        dashboardNode3.Log(Status.Info, "Total Number of browser error count for Chrome is : " + logEntries.Count);
                    }
                }
                else if (driverName.Contains("Edge"))
                {
                    Thread.Sleep(5000);
                    ILogs logsEdge = _driver.Manage().Logs;
                    var logEntriesEdge = logs.GetLog(LogType.Browser);
                    if (logEntriesEdge.Count != 0)
                    {
                        Console.WriteLine("Severe Console Error Log Entries for Edge:");
                        ExtentTest dashboardNode4 = CreateNode("Severe Console Error Log Entries for Edge:");
                        var severeLogEntries = logEntriesEdge.Where(x => x.Level == LogLevel.Severe);
                        if (severeLogEntries.Any())
                        {
                            Console.WriteLine($"Severe Level Console Error Log Count: {severeLogEntries.Count()}");
                            dashboardNode4.Log(Status.Info, "Severe Level Console Error Log Count : " + severeLogEntries.Count());
                            foreach (var logEntry in severeLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dashboardNode4.Log(Status.Info, "Severe Level Console Error Log Count : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dashboardNode4.Log(Status.Info, "No logs tracked");
                        }

                        Console.WriteLine("Warning Level Console Error Log Entries for Edge:");
                        ExtentTest dashboardNode5 = CreateNode("Warning Level Console Error Log Entries for Edge:");
                        var warningLogEntries = logEntries.Where(x => x.Level == LogLevel.Warning);
                        if (warningLogEntries.Any())
                        {
                            Console.WriteLine($"Warning Console Error Log Count: {warningLogEntries.Count()}");
                            dashboardNode5.Log(Status.Info, "Warning Console Error Log Count: " + warningLogEntries.Count());
                            foreach (var logEntry in warningLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dashboardNode5.Log(Status.Info, "Warning Console Error Log : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dashboardNode5.Log(Status.Info, "No logs tracked");
                        }

                        Console.WriteLine("Info Level Console Error Log Entries for Edge:");
                        ExtentTest dashboardNode6 = CreateNode("Info Level Console Error Log Entries for Edge:");
                        var infoLogEntries = logEntries.Where(x => x.Level == LogLevel.Info);
                        if (infoLogEntries.Any())
                        {
                            Console.WriteLine($"Info Console Error Log Count: {infoLogEntries.Count()}");
                            dashboardNode6.Log(Status.Info, "Info Console Error Log Count: " + infoLogEntries.Count());
                            foreach (var logEntry in infoLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dashboardNode6.Log(Status.Info, "Info Console Error Log : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dashboardNode6.Log(Status.Info, "No logs tracked");

                        }

                        Console.WriteLine("Debug Level Console Error Log Entries for Edge:");
                        ExtentTest dashboardNode7 = CreateNode("Debug Level Console Error Log Entries for Edge:");
                        var debugLogEntries = logEntries.Where(x => x.Level == LogLevel.Debug);
                        if (debugLogEntries.Any())
                        {
                            Console.WriteLine($"Debug Console Error Log Count: {debugLogEntries.Count()}");
                            dashboardNode7.Log(Status.Info, "Debug Console Error Log Count: " + debugLogEntries.Count());
                            foreach (var logEntry in debugLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dashboardNode7.Log(Status.Info, "Debug Console Error Log : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dashboardNode7.Log(Status.Info, "No logs tracked");
                        }
                        Console.WriteLine($"\nTotal Number of browser error count for Edge is: {logEntries.Count}");
                        dashboardNode7.Log(Status.Info, "Total Number of browser error count for Edge is: " + logEntries.Count);
                    }
                }
            }
        }
    }
}
