using Azure.Storage.Blobs;
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
        public void UploadBlob()
        {
            var filePath = ConfigurationManager.AppSettings["BlobPath"];
            var connectionString = ConfigurationManager.AppSettings["BlobConnectionString"];

            string date = String.Format("{0}_{1:yyyy_MM_dd}", "index", DateTime.Now);
            BlobClient blobClient = new BlobClient(connectionString: connectionString, blobContainerName: "reports", blobName: $"{date}.html");
            blobClient.Upload(filePath, true);
        }

        public static string GetURL()
        {
            var mainURL = ConfigurationManager.AppSettings["Blob_URL"];
            string date = String.Format("{0}_{1:yyyy_MM_dd}", "index", DateTime.Now);
            string blobURL = $"{mainURL}{date}.html";
            return blobURL;
        }
    }
}
