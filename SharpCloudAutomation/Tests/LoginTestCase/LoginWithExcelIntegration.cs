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
            string _workingDirectory = Environment.CurrentDirectory;
            string _startupPath = Directory.GetParent(_workingDirectory).Parent.Parent.FullName;
            string fileName = _startupPath + "\\TestData\\Login_Data.xlsx";
            
            ExcelData.PopulateInCollection(fileName);

            LoginPage loginPage = new(GetDriver());
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            Assert.That(loginPage.GoButton.Displayed, Is.True);
            loginPage.UsernameText.SendKeys(ExcelData.ReadData(rowNumber, userColumnName));
            loginPage.PasswordText.SendKeys(ExcelData.ReadData(rowNumber, passwordColumnName));
            loginPage.GoButton.Click();
        }

        public static object[] GetTestData =
        {
            new object[] { 1,"Username", "Password" },
            new object[] { 2,"Username", "Password" },
        };
    }
}
