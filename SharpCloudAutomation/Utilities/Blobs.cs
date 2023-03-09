using Azure.Storage.Blobs;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Utilities
{
    public class Blobs
    {
        private string blobDate;

        public static string getTodayDate()
        {
            string TodaysDate = DateTime.Now.ToString("yyyy-MM-dd");
            return TodaysDate;
        }

        public string fileName()
        {
            Reports reports = new Reports();
            string fileName = reports.getDateandTime();
            string name = $"{fileName}-{ConfigurationManager.AppSettings["browser"]}";
            Console.WriteLine(name);
            return name;

        }
        public void UploadBlob()
        {
            //string filePath = $"C:\\SharpCloudAutomation\\SharpCloudAutomation\\SharpCloudAutomation\\Output\\{getTodayDate()}\\{fileName()}.html";
            string filePath = $"{getFolderInDirectory()}\\{getTodayDate()}\\{fileName()}.html";
            var connectionString = ConfigurationManager.AppSettings["BlobConnectionString"];

            BlobClient blobClient = new BlobClient(connectionString: connectionString, blobContainerName: $"testreports/drop/SharpCloudAutomation/Output/{getTodayDate()}", blobName: $"{fileName()}.html");
            blobClient.Upload(filePath, true);
        }

        public static string GetURL()
        {
            Reports reports = new Reports();
            var mainURL = ConfigurationManager.AppSettings["Blob_URL"];
            string date = reports.getDateandTime();
            string blobURL = $"{mainURL}\\{getTodayDate()}\\{date}.html";
            return blobURL;
        }

        public static string getFolderInDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string parentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string outputFolderPath = parentDirectory + "\\Output";
            return outputFolderPath;
        }
    }
}