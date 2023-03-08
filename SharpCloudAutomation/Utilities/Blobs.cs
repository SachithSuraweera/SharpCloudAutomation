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
            //index_2023_03_07_17_16_34-Chrome
            string fileName = String.Format("{0}_{1:yyyy_MM_dd_HH_mm}", "index", DateTime.Now);
            string name = $"{fileName}-{ConfigurationManager.AppSettings["browser"]}";
            Console.WriteLine(name);
            return name;

        }
        public void UploadBlob()
        {
            string filePath = $"C:\\SharpCloudAutomation\\SharpCloudAutomation\\SharpCloudAutomation\\Output\\{getTodayDate()}\\{fileName()}.html";
            var connectionString = ConfigurationManager.AppSettings["BlobConnectionString"];

            //string date = String.Format("{0}_{1:yyyy_MM_dd}", "index", DateTime.Now);
            BlobClient blobClient = new BlobClient(connectionString: connectionString, blobContainerName: $"testreports/drop/SharpCloudAutomation/Output/{getTodayDate()}", blobName: $"{fileName()}.html");
            blobClient.Upload(filePath, true);
        }

        public static string GetURL()
        {
            var mainURL = ConfigurationManager.AppSettings["Blob_URL"];
            string date = String.Format("{0}_{1:yyyy_MM_dd_HH_mm}", "index", DateTime.Now);
            string blobURL = $"{mainURL}\\{getTodayDate()}\\{date}.html";
            return blobURL;
        }
    }
}