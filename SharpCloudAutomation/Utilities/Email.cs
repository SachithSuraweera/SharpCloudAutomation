using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Utilities
{
    public class Email
    {
        public static void RunEmail()
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            MailjetClient client = new MailjetClient(ConfigurationManager.AppSettings["Email_API_Key"], ConfigurationManager.AppSettings["Email_Secret"])
            {
                //Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = SendV31.Resource,
            }
               .Property(Send.Messages, new JArray {
                new JObject {
                 {"From", new JObject {
                  {"Email", $"{ConfigurationManager.AppSettings["From_Email"]}"},
                  {"Name", "Automation Report"}
                  }},
                 {"To", new JArray {
                  new JObject {
                   {"Email", $"{ConfigurationManager.AppSettings["To_Email"]}"},
                   {"Name", "Client"}
                   },
                  new JObject {
                   {"Email", $"{ConfigurationManager.AppSettings["To_Email_1"]}"},
                   {"Name", "Client"}
                   },
                  new JObject {
                   {"Email", $"{ConfigurationManager.AppSettings["To_Email_2"]}"},
                   {"Name", "Client"}
                   }
                  }},
                 {"Subject", $"Airudi Automation Execution Report {DateTime.Now}"},
                 {"TextPart", "Hi, Please find the attached automation report"},
                 {"HTMLPart", $"<h3>Hi,<br /><br /> Please click on the link to download the automation report <a href=\"{Blobs.GetURL()}\">Airudi Automation Report</a>!</h3><br />Thank you!"},
                 }
                   });
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }

        static string Convert64()
        {
            byte[] AsBytes = File.ReadAllBytes(@"C:\Airudi Automation\AutomationUI\Output\index.html");
            String AsBase64String = Convert.ToBase64String(AsBytes);
            return AsBase64String;
        }
    }
}
