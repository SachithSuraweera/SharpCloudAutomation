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

            Assert.IsTrue(loginPage.getGoBtn().Displayed);
            loginPage.getUserName().SendKeys(GetJsonData().ExtractInstanceDataJson("username"));
            loginPage.getPassword().SendKeys(GetJsonData().ExtractInstanceDataJson("password"));
            

            
        }
    }
}
