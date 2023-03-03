using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using SharpCloudAutomation.Tests.LoginTestCase;
using OpenQA.Selenium;

namespace SharpCloudAutomation.Tests.CalculationStoryTestCase
{
    internal class CalculationStoryTest : Base
    {
        [Test]
        public void storyTableViewResultColumnCheck()
        {
            /*LoginPage loginPage = new LoginPage(GetDriver());
           // LoginValidation loginValidation = new LoginValidation();
            loginValidation.loginToTheSystem();*/

            LoginPage loginPage = new LoginPage(GetDriver());
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            Assert.IsTrue(loginPage.getGoBtn().Displayed);
            loginPage.getUserName().SendKeys(GetJsonData().ExtractInstanceDataJson("username"));
            loginPage.getPassword().SendKeys(GetJsonData().ExtractInstanceDataJson("password"));
            loginPage.getGoBtn().Click();

            CalculatedStoryPage calculatedStoryPage = new CalculatedStoryPage(GetDriver());
            // Json get one story{}

            IList<IWebElement> viewChooserItems = calculatedStoryPage.getView();
            for (int i = 0; i <= viewChooserItems.Count; i++)
            {
                {
                    viewChooserItems[i].Click();
                    IWebElement tableView = calculatedStoryPage.getTableView();
                    Assert.IsTrue(tableView.Displayed, "Table view is not displayed");
                    //if fail > arraylist > story name , view
                    Assert.Contains("fail", tableView.Text.Split('\n'));
                    //if fail >arrylist
                    //report // storyname , view , pass, fail
                }
            }
        }
    }
}
