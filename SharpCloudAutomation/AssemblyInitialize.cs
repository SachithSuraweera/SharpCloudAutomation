using NUnit.Framework;
using SharpCloudAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        Blobs blobs = new Blobs();

        [OneTimeTearDown]
        public void UploadBlobtoAzure()
        {
            //blobs.UploadBlob();
            //Email.RunEmail();
        }
    }
}
