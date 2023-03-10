using Azure.Storage.Blobs;
using System.Configuration;

namespace SharpCloudAutomation.Utilities
{
    public class Blobs
    {
         public static string GetTodayDate()
        {
            string TodaysDate = DateTime.Now.ToString("yyyy-MM-dd");
            return TodaysDate;
        }
        public string FileName()
        {
            Reports reports = new();
            string fileName = reports.Gettime();
            string name = $"{fileName}-{ConfigurationManager.AppSettings["browser"]}";
            Console.WriteLine(name);
            return name;
        }
        public void UploadBlob()
        {
            string filePath = $"{GetFolderInDirectory()}\\{GetTodayDate()}\\{FileName()}.html";
            var connectionString = ConfigurationManager.AppSettings["BlobConnectionString"];

            BlobClient blobClient = new(connectionString: connectionString, blobContainerName: $"testreports/drop/SharpCloudAutomation/Output/{GetTodayDate()}", blobName: $"{FileName()}.html");
            blobClient.Upload(filePath, true);
        }
        public static string GetURL()
        {
            Reports reports = new();
            var mainURL = ConfigurationManager.AppSettings["Blob_URL"];
            string date = reports.Gettime();
            string blobURL = $"{mainURL}\\{GetTodayDate()}\\{date}-{ConfigurationManager.AppSettings["browser"]}.html";
            return blobURL;
        }

        public static string GetFolderInDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string parentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string outputFolderPath = parentDirectory + "\\Output";
            return outputFolderPath;
        }
    }
}