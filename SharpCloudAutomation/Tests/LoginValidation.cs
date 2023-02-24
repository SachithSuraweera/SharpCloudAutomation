using AventStack.ExtentReports;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Tests
{
    public class LoginValidation : Base
    {
        [Test]
        public void loginToTheSystem()
        {
            LoginPage loginPage = new LoginPage(GetDriver());
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            ExtentTest dasboardNode = CreateNode("User now in login page");
            Assert.IsTrue(loginPage.getGoBtn().Displayed);
            loginPage.getUserName().SendKeys(GetJsonData().ExtractInstanceDataJson("username"));
            dasboardNode.Log(Status.Info, "User send keys to the username field");
            loginPage.getPassword().SendKeys(GetJsonData().ExtractInstanceDataJson("password"));
            dasboardNode.Log(Status.Info, "User send keys to the password field");
            

            
        }
    }
}
