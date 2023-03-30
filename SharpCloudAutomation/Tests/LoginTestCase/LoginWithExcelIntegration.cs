using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;


namespace SharpCloudAutomation.Tests.LoginTestCase
{
    public class LoginWithExcelIntegration:Base
    {        
        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void LoginToTheSystem(int rowNumber, string userColumnName, string passwordColumnName)
        {
            var dataReader = new Utilities.ExcelDataReader();
            dataReader.PopulateInCollection();

            LoginPage loginPage = new(GetDriver());
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            Assert.That(loginPage.GoButton.Displayed, Is.True);
            loginPage.UsernameText.SendKeys(dataReader.ReadData(rowNumber, userColumnName));
            loginPage.PasswordText.SendKeys(dataReader.ReadData(rowNumber, passwordColumnName));
            loginPage.GoButton.Click();
        }

        public static object[] GetTestData =
        {
            new object[] { 1,"Username", "Password" },
            new object[] { 2,"Username", "Password" },
        };
    }
}
