using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;

namespace SharpCloudAutomation.Tests.LoginTestCase
{
    public class LoginValidation : Base
    {
        [Test]
        public void LoginToTheSystem()
        {
            LoginPage loginPage = new(GetDriver());
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            Assert.That(loginPage.GoButton.Displayed, Is.True);
            loginPage.GoButton.SendKeys(GetJsonData().ExtractInstanceDataJson("username"));
            loginPage.GoButton.SendKeys(GetJsonData().ExtractInstanceDataJson("password"));
            ErrorLogs errLog = new(GetDriver());
            errLog.AddBorwserLogs();
        }
    }
}