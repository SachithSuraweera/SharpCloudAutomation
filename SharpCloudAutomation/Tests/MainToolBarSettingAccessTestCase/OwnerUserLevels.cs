using AventStack.ExtentReports;
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
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                ExtentTest createNode = CreateNode("Owner Level Main Tool Bar Features");
                if (mtoolBarPage.getMtoolBar().Displayed)
                {
                    createNode.Log(Status.Info, "Maintool Bar Element is Visible");
                }
                else {
                    createNode.Log(Status.Info, "Maintool Bar Element is not Visible");
                }

                if (mtoolBarPage.getUndoIcon().Displayed)
                {
                    createNode.Log(Status.Info, "Undo Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Undo Element is not Visible");
                }
            }
        }
    }
}
