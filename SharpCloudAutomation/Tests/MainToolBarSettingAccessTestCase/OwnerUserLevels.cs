using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;


namespace SharpCloudAutomation.Tests.MainToolBarSettingAccessTestCase
{
    public class OwnerUserLevels : Base
    {
        [Test]
        public void CompareMainToolBarFeatures()
        {  
            MainToolBarPage mtoolBarPage = new MainToolBarPage(GetDriver());
            var userlist = new JsonReader().GetUsersList();
                           

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new LoginPage(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

                Assert.IsTrue(loginPage.getGoBtn().Displayed);
                loginPage.getUserName().SendKeys(sc.Username);
                loginPage.getPassword().SendKeys(sc.Password);
                loginPage.getGoBtn().Click();
                Thread.Sleep(5000);
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                ExtentTest createNode = CreateNode("Owner Level Main Tool Bar Features");
                if (mtoolBarPage.getMtoolBar().Displayed)
                {
                    createNode.Log(Status.Info, "Maintool Bar Element is Visible");
                }
                else {
                    createNode.Log(Status.Info, "Maintool Bar Element is not Visible");
                }
                //Undo Visibility
                if (mtoolBarPage.getUndoIcon().Displayed)
                {
                    createNode.Log(Status.Info, "Undo Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Undo Element is not Visible");
                }
                mtoolBarPage.getUndoDropDownIcon().Click();

                int elementsCount = mtoolBarPage.getUndoDropDown().Count();
                String[] uSubMenu = { "undo (CTRL+Z)", "redo (CTRL+Y)", "Restore Story" };
                for (int i = 1; i <= elementsCount; i++)
                {
                    IWebElement subUndo = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li["+ i +"]"));
                    String subText = subUndo.Text;
                    if (uSubMenu[i-1]==subText)
                    {
                        createNode.Log(Status.Info, subText+" Element is Visible");
                    }
                }
                //Story visibility
                if (mtoolBarPage.getStoryIcon().Displayed)
                {
                    createNode.Log(Status.Info, "Story Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Story Element is not Visible");
                }
                int storyelementsCount = mtoolBarPage.getStoryDropDown().Count();
                String[] storySubMenu = { "Setup", "Manage Presentations", "Manage Forms", "Download Story" };
                for (int i = 1; i <= storyelementsCount; i++)
                {
                    IWebElement subStory = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[" + i + "]"));
                    String subText = subStory.Text;
                    if (storySubMenu[i - 1] == subText)
                    {
                        createNode.Log(Status.Info, subText + " Element is Visible");
                    }
                }
            }
        }
    }
}
