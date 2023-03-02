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
            // LoginPage loginPage = new LoginPage(GetDriver());
            LoginValidation loginValidation = new LoginValidation();
            loginValidation.loginToTheSystem();

            CalculatedStoryPage calculatedStoryPage = new CalculatedStoryPage(GetDriver());

            IList<IWebElement> viewChooserItems = calculatedStoryPage.getView();
            for (int i = 0; i <= viewChooserItems.Count; i++)
            {
                {
                    viewChooserItems[i].Click();
                    IWebElement tableView = calculatedStoryPage.getTableView();
                    Assert.IsTrue(tableView.Displayed, "Table view is not displayed");
                    Assert.Contains("fail", tableView.Text.Split('\n'));
                }


            }
        }
    }
}
