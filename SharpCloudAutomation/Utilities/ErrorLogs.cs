using OpenQA.Selenium.Firefox;
using System.Configuration;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace SharpCloudAutomation.Utilities
{
    public class ErrorLogs : Base
    {
        new readonly IWebDriver driver;

        public ErrorLogs(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddBorwserLogs()
        {
            var driverName = ConfigurationManager.AppSettings["browser"];
            //FIREFOX BROWSER
            if (driverName.Contains("Firefox"))
            {
                FirefoxOptions options = new();
                Thread.Sleep(5000);
                ILogs logs = driver.Manage().Logs;
                var logEntries = logs.GetLog(LogType.Browser);
                if (logEntries.Count != 0)
                {
                    var severeLogEntries = options.LogLevel = FirefoxDriverLogLevel.Trace;
                    if (severeLogEntries.Equals(FirefoxDriverLogLevel.Trace))
                    {
                        Console.WriteLine("FF error warn : " + severeLogEntries);
                        ExtentTest dasboardNode = CreateNode("FF error warn");
                        dasboardNode.Log(Status.Info, "FF error warn : " + severeLogEntries);
                    }
                }

            }

            //CHROME BROWSER
            else if (driverName.Contains("Chrome"))
            {
                ILogs logs = driver.Manage().Logs;
                var logEntries = logs.GetLog(LogType.Browser);
                if (logEntries.Count != 0)
                {
                    //SEVERE
                    Console.WriteLine("Severe Console Error Log Entries for Chrome:");
                    ExtentTest dasboardNode = CreateNode("Severe Console Error Log Entries for Chrome:");
                    var severeLogEntries = logEntries.Where(x => x.Level == LogLevel.Severe);
                    if (severeLogEntries.Any())
                    {
                        Console.WriteLine($"Severe Level Console Error Log Count: {severeLogEntries.Count()}");
                        dasboardNode.Log(Status.Info, "Severe Level Console Error Log Count : " + severeLogEntries.Count());
                        foreach (var logEntry in severeLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            dasboardNode.Log(Status.Info, "Severe Level Console Errors : " + logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                        dasboardNode.Log(Status.Info, "No logs tracked in Severe Level Console");
                    }
                    //WARNING
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Warning Level Console Error Log Entries for Chrome:");
                    ExtentTest dasboardNode1 = CreateNode("Warning Level Console Error Log Entries for Chrome:");
                    var warningLogEntries = logEntries.Where(x => x.Level == LogLevel.Warning);
                    if (warningLogEntries.Any())
                    {
                        Console.WriteLine($"Warning Console Error Log Count: {warningLogEntries.Count()}");
                        dasboardNode1.Log(Status.Info, "Warning Console Error Log Count : " + warningLogEntries.Count());
                        foreach (var logEntry in warningLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            dasboardNode1.Log(Status.Info, "Warning Console Error Log Count : " + logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                        dasboardNode1.Log(Status.Info, "No logs tracked");
                    }
                    //DEBUG
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Debug Console Error Log Entries for Chrome:");
                    ExtentTest dasboardNode2 = CreateNode("Debug Console Error Log Entries for Chrome:");
                    var debugEntries = logEntries.Where(x => x.Level == LogLevel.Debug);
                    if (debugEntries.Any())
                    {
                        Console.WriteLine($"Debug Level Console Error Log Count: {debugEntries.Count()}");
                        dasboardNode2.Log(Status.Info, "Debug Level Console Error Log Count : " + debugEntries.Count());
                        foreach (var logEntry in debugEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            dasboardNode2.Log(Status.Info, "Debug Level Console Error Logs : " + logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                        dasboardNode2.Log(Status.Info, "No logs tracked in Debug Level ");
                        //INFO
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Info Level Console Error Log Entries for Chrome:");
                        ExtentTest dasboardNode3 = CreateNode("Info Level Console Error Log Entries for Chrome:");
                        var infoLogEntries = logEntries.Where(x => x.Level == LogLevel.Info);
                        if (infoLogEntries.Any())
                        {
                            Console.WriteLine($"Info Console Error Log Count: {infoLogEntries.Count()}");
                            dasboardNode3.Log(Status.Info, "Info Console Error Log Count: " + infoLogEntries.Count());
                            foreach (var logEntry in infoLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                dasboardNode3.Log(Status.Info, "Info Console Error Log " + logEntry.ToString());
                                Console.WriteLine("\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dasboardNode3.Log(Status.Info, "No logs tracked");
                        }
                        Console.WriteLine($"\nTotal Number of browser error count for Chrome is: {logEntries.Count}");
                        dasboardNode3.Log(Status.Info, "Total Number of browser error count for Chrome is : " + logEntries.Count);
                    }

                }
                //EDGE BROWSER
                else if (driverName.Contains("Edge"))
                {
                    Thread.Sleep(5000);
                    ILogs logsedge = driver.Manage().Logs;
                    var logEntriesedge = logs.GetLog(LogType.Browser);
                    if (logEntriesedge.Count != 0)
                    {
                        //SEVERE
                        Console.WriteLine("Severe Console Error Log Entries for Edge:");
                        ExtentTest dasboardNode4 = CreateNode("Severe Console Error Log Entries for Edge:");
                        var severeLogEntries = logEntriesedge.Where(x => x.Level == LogLevel.Severe);
                        if (severeLogEntries.Any())
                        {
                            Console.WriteLine($"Severe Level Console Error Log Count: {severeLogEntries.Count()}");
                            dasboardNode4.Log(Status.Info, "Severe Level Console Error Log Count : " + severeLogEntries.Count());
                            foreach (var logEntry in severeLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dasboardNode4.Log(Status.Info, "Severe Level Console Error Log Count : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dasboardNode4.Log(Status.Info, "No logs tracked");
                        }
                        //WARNING
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Warning Level Console Error Log Entries for Edge:");
                        ExtentTest dasboardNode5 = CreateNode("Warning Level Console Error Log Entries for Edge:");
                        var warningLogEntries = logEntries.Where(x => x.Level == LogLevel.Warning);
                        if (warningLogEntries.Any())
                        {
                            Console.WriteLine($"Warning Console Error Log Count: {warningLogEntries.Count()}");
                            dasboardNode5.Log(Status.Info, "Warning Console Error Log Count: " + warningLogEntries.Count());
                            foreach (var logEntry in warningLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dasboardNode5.Log(Status.Info, "Warning Console Error Log : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dasboardNode5.Log(Status.Info, "No logs tracked");
                        }
                        //INFO
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Info Level Console Error Log Entries for Edge:");
                        ExtentTest dasboardNode6 = CreateNode("Info Level Console Error Log Entries for Edge:");
                        var infoLogEntries = logEntries.Where(x => x.Level == LogLevel.Info);
                        if (infoLogEntries.Any())
                        {
                            Console.WriteLine($"Info Console Error Log Count: {infoLogEntries.Count()}");
                            dasboardNode6.Log(Status.Info, "Info Console Error Log Count: " + infoLogEntries.Count());
                            foreach (var logEntry in infoLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dasboardNode6.Log(Status.Info, "Info Console Error Log : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dasboardNode6.Log(Status.Info, "No logs tracked");

                        }
                        //DEBUG
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Debug Level Console Error Log Entries for Edge:");
                        ExtentTest dasboardNode7 = CreateNode("Debug Level Console Error Log Entries for Edge:");
                        var debugLogEntries = logEntries.Where(x => x.Level == LogLevel.Debug);
                        if (debugLogEntries.Any())
                        {
                            Console.WriteLine($"Debug Console Error Log Count: {debugLogEntries.Count()}");
                            dasboardNode7.Log(Status.Info, "Debug Console Error Log Count: " + debugLogEntries.Count());
                            foreach (var logEntry in debugLogEntries)
                            {
                                Console.WriteLine(logEntry.ToString());
                                Console.WriteLine("\n");
                                dasboardNode7.Log(Status.Info, "Debug Console Error Log : " + logEntry.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No logs tracked");
                            dasboardNode7.Log(Status.Info, "No logs tracked");
                        }
                        Console.WriteLine($"\nTotal Number of browser error count for Edge is: {logEntries.Count}");
                        dasboardNode7.Log(Status.Info, "Total Number of browser error count for Edge is: " + logEntries.Count);
                    }
                }
            }
        }
    }
}
