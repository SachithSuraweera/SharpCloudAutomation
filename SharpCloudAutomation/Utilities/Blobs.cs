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
        public static string? GetFileName()
        {
            Reports reports = new();
            string fileName = reports.Gettime();
            string name = $"{fileName}-{ConfigurationManager.AppSettings["browser"]}";
            Console.WriteLine(name);
            return name;
        }

        public void UploadBlob()
        {
            string filePath = $"{GetFolderInDirectory()}\\{GetTodayDate()}\\{GetFileName()}.html";
            string? connectionString = ConfigurationManager.AppSettings["BlobConnectionString"];
            BlobClient blobClient = new(connectionString: connectionString, blobContainerName: $"testreports/drop/SharpCloudAutomation/Output/{GetTodayDate()}", blobName: $"{GetFileName()}.html");
            blobClient.Upload(filePath, true);
        }

        public static string GetURL()
        {
            Reports reports = new();
            string? mainURL = ConfigurationManager.AppSettings["Blob_URL"];
            string date = reports.Gettime();
            return $"{mainURL}\\{GetTodayDate()}\\{date}-{ConfigurationManager.AppSettings["browser"]}.html";
        }

        public static string GetFolderInDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string? parentDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;
            return parentDirectory + "\\Output";
        }
    }
}