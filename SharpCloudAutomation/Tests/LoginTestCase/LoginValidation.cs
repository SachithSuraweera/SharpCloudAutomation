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
            loginPage.UsernameText.SendKeys(GetJsonData().ExtractInstanceDataJson("username"));
            loginPage.PasswordText.SendKeys(GetJsonData().ExtractInstanceDataJson("password"));
            CheckImageDifferences(System.Reflection.MethodBase.GetCurrentMethod().Name);
            loginPage.GoButton.Click();

            ErrorLogs errLog = new(GetDriver());
            errLog.AddBrowserLogs();
        }
    }
}