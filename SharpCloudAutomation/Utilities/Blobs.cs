using Azure.Storage.Blobs;
using System.Configuration;

namespace SharpCloudAutomation.Utilities
{
    public class Blobs
    {
        public static string GetTodayDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string? GetFileName()
        {
            Reports reports = new();
            string fileName = reports.GetTime() ?? "";
            string name = $"{fileName}-{ConfigurationManager.AppSettings["browser"]}";
            Console.WriteLine(name);

            return name;
        }

        public void UploadBlob()
        {
            string filePath = $"{GetFolderInDirectory()}\\{GetTodayDate()}\\{GetFileName()}.html";
            string? connectionString = Config.BlobConnectionString;
            BlobClient blobClient = new(connectionString: connectionString, blobContainerName: $"testreports/drop/SharpCloudAutomation/Output/{GetTodayDate()}", blobName: $"{GetFileName()}.html");
            blobClient.Upload(filePath, true);
        }

        public static string GetURL()
        {
            Reports reports = new();
            string? mainURL = ConfigurationManager.AppSettings["Blob_URL"];
            string date = reports.GetTime() ?? "";

            return $"{mainURL}{GetTodayDate()}\\{date}-{ConfigurationManager.AppSettings["browser"]}.html";
        }

        public static string GetFolderInDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string? parentDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;

            return parentDirectory + "\\Output";
        }
    }
}