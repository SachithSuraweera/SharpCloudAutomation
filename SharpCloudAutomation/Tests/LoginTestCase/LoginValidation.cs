using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;

namespace SharpCloudAutomation.Tests.LoginTestCase
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
            ErrorLogs errLog = new ErrorLogs(GetDriver());
            errLog.AddBorwserLogs();
        }
    }
}
