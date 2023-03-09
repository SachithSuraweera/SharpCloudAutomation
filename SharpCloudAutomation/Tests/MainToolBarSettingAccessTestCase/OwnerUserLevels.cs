using AventStack.ExtentReports;
using OpenQA.Selenium;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;


namespace SharpCloudAutomation.Tests.MainToolBarSettingAccessTestCase
{
    public class OwnerUserLevels : Base
    {
        [Test]
        public void CompareMainToolBarFeatures()
        {  
            MainToolBarPage mtoolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();
                           

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

                Assert.That(loginPage.GoButton.Displayed, Is.True);
                loginPage.GoButton.SendKeys(sc.Username);
                loginPage.GoButton.SendKeys(sc.Password);
                loginPage.GoButton.Click();
                Thread.Sleep(5000);
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                ExtentTest createNode = CreateNode("Owner Level Main Tool Bar Features");
                if (mtoolBarPage.MtoolBar.Displayed)
                {
                    createNode.Log(Status.Info, "Maintool Bar Element is Visible");
                }
                else {
                    createNode.Log(Status.Info, "Maintool Bar Element is not Visible");
                }
                //Undo Visibility
                if (mtoolBarPage.UndoIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Undo Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Undo Element is not Visible");
                }
                mtoolBarPage.UndoDropdownIcon.Click();

                int elementsCount = mtoolBarPage.UndoDropdown.Count;
                String[] uSubMenu = { "undo (CTRL+Z)", "redo (CTRL+Y)", "Restore Story" };
                for (int i = 1; i <= elementsCount; i++)
                {
                    if (i == 3) {
                        IWebElement subUndo = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//fieldset/li[" + i + "]"));
                        String subText = subUndo.Text;
                        if (uSubMenu[i - 1] == subText)
                        {
                            createNode.Log(Status.Info, subText + " Element is Visible");
                        }
                    }
                    else
                    {
                        IWebElement subUndo = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[" + i + "]"));
                        String subText = subUndo.Text;
                        if (uSubMenu[i - 1] == subText)
                        {
                            createNode.Log(Status.Info, subText + " Element is Visible");
                        }
                    }
                }
                //Story visibility
                if (mtoolBarPage.StoryIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Story Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Story Element is not Visible");
                }
                int storyelementsCount = mtoolBarPage.StoryDropdown.Count;
                String[] storySubMenu = { "Setup", "Manage Presentations", "Manage Forms", "Download Story" };
                for (int i = 1; i <= storyelementsCount; i++)
                {
                    IWebElement subStory = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//fieldset/li[]"));
                    String subText = subStory.Text;
                    if (storySubMenu[i - 1] == subText)
                    {
                        createNode.Log(Status.Info, subText + " Element is Visible");
                    }
                }
                //Data Visibility
                if (mtoolBarPage.DataIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Data Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Data Element is not Visible");
                }
                int dataelementsCount = mtoolBarPage.DataDropdown.Count;
                String[] dataSubMenu = { "Edit Data", "Data Sources" };
                for (int i = 1; i <= dataelementsCount; i++)
                {
                    IWebElement subData = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, dataSetupDropdown']//li[" + i + "]"));
                    String subText = subData.Text;
                    if (dataSubMenu[i - 1] == subText)
                    {
                        createNode.Log(Status.Info, subText + " Element is Visible");
                    }
                }
                //View Visibility
                if (mtoolBarPage.ViewIcon.Displayed)
                {
                    createNode.Log(Status.Info, "View Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "View Element is not Visible");
                }
                if (mtoolBarPage.ResetIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Reset View Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Reset View Element is not Visible");
                }
                if (mtoolBarPage.SaveIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Save View Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Save View Element is not Visible");
                }
                //View Sub menu visibility
                int viewSetUpelementsCount = mtoolBarPage.ViewSetupDropdown.Count;
                String[] viewSetUpSubMenu = { "Setup", "Filters", "Add new", "Save as new" };
                for (int i = 1; i <= viewSetUpelementsCount; i++)
                {
                    IWebElement subView = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, viewSetupDropdown']//li[" + i + "]"));
                    String subText = subView.Text;
                    if (viewSetUpSubMenu[i - 1] == subText)
                    {
                        createNode.Log(Status.Info, subText + " Element is Visible");
                    }
                }
                //Relationships Visibility
                if (mtoolBarPage.RelationshipIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Relationship Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Relationship Element is not Visible");
                }
                int relationshipelementsCount = mtoolBarPage.DataDropdown.Count;
                String[] relationshipSubMenu = { "Show", "Create/Edit", " More options..." };
                for (int i = 1; i <= relationshipelementsCount; i++)
                {
                    IWebElement subRelationship = GetDriver().FindElement(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li[" + i + "]"));
                    String subText = subRelationship.Text;
                    if (relationshipSubMenu[i - 1] == subText)
                    {
                        createNode.Log(Status.Info, subText + " Element is Visible");
                    }
                }
                //Unlock - visibility
                if (mtoolBarPage.UnlockIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Unlock Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Unlock Element is not Visible");
                }
                //Search - visibility
                if (mtoolBarPage.SearchIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Search Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Search Element is not Visible");
                }
                //Full screen - visibility
                if (mtoolBarPage.FullScreenIcon.Displayed)
                {
                    createNode.Log(Status.Info, "Full Screen Element is Visible");
                }
                else
                {
                    createNode.Log(Status.Info, "Full Screen Element is not Visible");
                }

            }
        }
    }
}
