using OpenQA.Selenium.Firefox;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Utilities
{
    internal class ErrorLogs
    {
        public void AddBorwserLogs()
        {
           var driverName = ConfigurationManager.AppSettings["browser"];

            //FIREFOX BROWSER
            if (driverName.Contains("Firefox"))
            {
                FirefoxOptions options = new FirefoxOptions();
                Thread.Sleep(5000);
                ILogs logs = GetDriver().Manage().Logs;
                var logEntries = logs.GetLog(LogType.Browser);
                if (logEntries.Count != 0)
                {
                    var severeLogEntries = options.LogLevel = FirefoxDriverLogLevel.Trace;
                    if (severeLogEntries.Equals(FirefoxDriverLogLevel.Trace))
                    {

                        Console.WriteLine("FF error warn : " + severeLogEntries);

                    }
                }

            }

            //CHROME BROWSER
            else if (driverName.Contains("Chrome"))
            {
                Thread.Sleep(7000);
                ILogs logs = GetDriver().Manage().Logs;
                var logEntries = logs.GetLog(LogType.Browser);
                if (logEntries.Count != 0)
                {
                    //SEVERE

                    Console.WriteLine("Severe Console Error Log Entries for Chrome:");
                    var severeLogEntries = logEntries.Where(x => x.Level == LogLevel.Severe);
                    if (severeLogEntries.Any())
                    {
                        Console.WriteLine($"Severe Level Console Error Log Count: {severeLogEntries.Count()}");
                        foreach (var logEntry in severeLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }

                    //WARNING
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Warning Level Console Error Log Entries for Chrome:");
                    var warningLogEntries = logEntries.Where(x => x.Level == LogLevel.Warning);
                    if (warningLogEntries.Any())
                    {
                        Console.WriteLine($"Warning Console Error Log Count: {warningLogEntries.Count()}");
                        foreach (var logEntry in warningLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }

                    //DEBUG
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Debug Console Error Log Entries for Chrome:");
                    var debugEntries = logEntries.Where(x => x.Level == LogLevel.Debug);
                    if (debugEntries.Any())
                    {
                        Console.WriteLine($"Debug Level Console Error Log Count: {debugEntries.Count()}");
                        foreach (var logEntry in debugEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }

                    //INFO
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Info Level Console Error Log Entries for Chrome:");
                    var infoLogEntries = logEntries.Where(x => x.Level == LogLevel.Info);
                    if (infoLogEntries.Any())
                    {
                        Console.WriteLine($"Info Console Error Log Count: {infoLogEntries.Count()}");
                        foreach (var logEntry in infoLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }
                    Console.WriteLine($"\nTotal Number of browser error count for Chrome is: {logEntries.Count}");
                }

            }

            //EDGE BROWSER
            else if (driverName.Contains("Edge"))
            {
                Thread.Sleep(5000);
                ILogs logs = GetDriver().Manage().Logs;
                var logEntries = logs.GetLog(LogType.Browser);
                if (logEntries.Count != 0)
                {
                    //SEVERE
                    Console.WriteLine("Severe Console Error Log Entries for Edge:");
                    var severeLogEntries = logEntries.Where(x => x.Level == LogLevel.Severe);
                    if (severeLogEntries.Any())
                    {
                        Console.WriteLine($"Severe Level Console Error Log Count: {severeLogEntries.Count()}");
                        foreach (var logEntry in severeLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }

                    //WARNING
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Warning Level Console Error Log Entries for Edge:");
                    var warningLogEntries = logEntries.Where(x => x.Level == LogLevel.Warning);
                    if (warningLogEntries.Any())
                    {
                        Console.WriteLine($"Warning Console Error Log Count: {warningLogEntries.Count()}");
                        foreach (var logEntry in warningLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }

                    //INFO
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Info Level Console Error Log Entries for Edge:");
                    var infoLogEntries = logEntries.Where(x => x.Level == LogLevel.Info);
                    if (infoLogEntries.Any())
                    {
                        Console.WriteLine($"Info Console Error Log Count: {infoLogEntries.Count()}");
                        foreach (var logEntry in infoLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }

                    //DEBUG
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Debug Level Console Error Log Entries for Edge:");
                    var debugLogEntries = logEntries.Where(x => x.Level == LogLevel.Debug);
                    if (debugLogEntries.Any())
                    {
                        Console.WriteLine($"Debug Console Error Log Count: {debugLogEntries.Count()}");
                        foreach (var logEntry in debugLogEntries)
                        {
                            Console.WriteLine(logEntry.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No logs tracked");
                    }


                    Console.WriteLine($"\nTotal Number of browser error count for Edge is: {logEntries.Count}");

                }
            }
        }
    }
}
