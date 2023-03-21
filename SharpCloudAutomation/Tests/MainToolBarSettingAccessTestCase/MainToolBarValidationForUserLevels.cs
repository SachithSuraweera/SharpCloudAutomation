using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;

namespace SharpCloudAutomation.Tests.MainToolBarSettingAccessTestCase
{
    public class MainToolBarValidationForUserLevels : Base
    {
        public void LoginWithRedirect(string username, string password, string storyUrl)
        {
            LoginPage loginPage = new(GetDriver());

            Assert.That(loginPage.GoButton.Displayed, Is.True);
            
            if (username != "")
            {
                loginPage.UsernameText.SendKeys(username);
                loginPage.PasswordText.SendKeys(password);
                loginPage.GoButton.Click();
            }
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            GetDriver().Navigate().GoToUrl(storyUrl);
        }
        public bool ElementExists(By by)
        {
            if (GetDriver().FindElements(by).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifyMainToolBarFeatures(string username, string password, string storyUrl, string storySharePermission, bool mainToolbarvisibility, bool UndoVisibility, bool UndoSubMenu, bool RedoSubMenu, bool RestoreStorySubMenu, bool StoryVisibility, bool SetupSubMenu, bool ManagePresentationsSubMenu, bool ManageFormsSubMenu, bool DownloadStorySubMenu, bool DataVisibility, bool EditDataSubMenu, bool DataConnectorsSubMenu, bool ViewVisibility, bool ResetViewVisibility, bool SaveViewVisibility, bool ViewSetupSubMenu, bool FiltersSubMenu, bool AddNewSubMenu, bool SaveAsNewSubMenu, bool RelationshipsVisibility, bool ShowSubMenu, bool CreateOrEditSubMenu, bool MoreOptionsSubMenu, bool UnlockVisibility, bool SearchVisibility, bool FullScreenVisibility)
        {
            MainToolBarPage maintoolBarPage = new(GetDriver());
            LoginPage loginPage = new(GetDriver());
            LoginWithRedirect(username, password, storyUrl);

            ExtentTest createNode = CreateNode(storySharePermission + " Level Main Tool Bar Features");
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(50));            

            bool isMainToolBarDisplayed = ElementExists(By.XPath("//div[@id='storyToolbar']"));
            WriteToReport(mainToolbarvisibility, isMainToolBarDisplayed, ":Main Tool Bar {0} visible", storySharePermission, createNode);

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isUndoIconDisplayed = ElementExists(By.XPath("//div[@id='undoDropdown']"));           
            if (isUndoIconDisplayed)
            {
                WriteToReport(UndoVisibility, isUndoIconDisplayed, ":Undo Element {0} visible", storySharePermission, createNode);
                maintoolBarPage.UndoDropdownIcon.Click();
                WriteToReport(UndoSubMenu, maintoolBarPage.UndoSubMenu.Displayed, ":Undo Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(RedoSubMenu, maintoolBarPage.RedoSubMenu.Displayed, ":Redo Sub Menu {0} visible", storySharePermission, createNode);
                bool isRestoreSubMenuDisplayed = ElementExists(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[contains(text(),'Restore Story')]"));
                {
                    WriteToReport(RestoreStorySubMenu, isRestoreSubMenuDisplayed, ":Restore Story sub menu {0} visible", storySharePermission, createNode);
                }
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isStoryIconDisplayed = ElementExists(By.XPath("//div[@tooltip='Story Setup']"));
            if (isStoryIconDisplayed)
            {
                WriteToReport(StoryVisibility, isStoryIconDisplayed, ":Story Element {0} visible", storySharePermission, createNode);
                maintoolBarPage.StoryDropIcon.Click();
                WriteToReport(SetupSubMenu, maintoolBarPage.SetupSubMenu.Displayed, ":Setup Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(ManagePresentationsSubMenu, maintoolBarPage.ManagePresentationSubMenu.Displayed, ":Manage Presentations Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(ManageFormsSubMenu, maintoolBarPage.ManageFormsSubMenu.Displayed, ":Manage Forms sub menu {0} visible", storySharePermission, createNode);
                WriteToReport(DownloadStorySubMenu, maintoolBarPage.DownloadStorySubMenu.Displayed, ":Download Story sub menu {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isDataIconDisplayed = ElementExists(By.XPath("//div[@tooltip='Data Setup']"));
            if (isDataIconDisplayed)
            {
                WriteToReport(DataVisibility, isDataIconDisplayed, ":Data Element {0} visible", storySharePermission, createNode);
                maintoolBarPage.DataDropDownIcon.Click();
                WriteToReport(EditDataSubMenu, maintoolBarPage.EditDataSubMenu.Displayed, ":Edit Data Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(DataConnectorsSubMenu, maintoolBarPage.DataSourcesSubMenu.Displayed, ":Data Connectors Sub Menu {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isViewDisplayed = ElementExists(By.XPath("//span[text()='View']"));
            if (isViewDisplayed)
            {
                WriteToReport(ViewVisibility, isViewDisplayed, ":View Element {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isResetDisplayed = ElementExists(By.XPath("//button[text()='Reset View']"));
            if (isResetDisplayed)
            {
                WriteToReport(ResetViewVisibility, isResetDisplayed, ":Reset View Element {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isSaveDisplayed = ElementExists(By.XPath("//span[@aria-label='View setup menu']"));
            if (isSaveDisplayed)
            {
                WriteToReport(SaveViewVisibility, isSaveDisplayed, ":Save View Element {0} visible", storySharePermission, createNode);
                maintoolBarPage.SaveDropDownIcon.Click();
                WriteToReport(ViewSetupSubMenu, maintoolBarPage.ViewSetUpSubMenu.Displayed, ":View Setup Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(FiltersSubMenu, maintoolBarPage.FiltersSubMenu.Displayed, ":Filters Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(AddNewSubMenu, maintoolBarPage.AddNewSubMenu.Displayed, ":Add New Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(SaveAsNewSubMenu, maintoolBarPage.SaveAsNewSubMenu.Displayed, ":Save As New Sub Menu {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isRelationshipDisplayed = ElementExists(By.XPath("//div[@id='relationshipsToggle']"));
            bool isCreateSubMenupDisplayed = ElementExists(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li/label[contains(text(),'Create/Edit')]"));
            if (isRelationshipDisplayed)
            {
                WriteToReport(RelationshipsVisibility, isRelationshipDisplayed, ":Relationship Element {0} visible", storySharePermission, createNode);
                maintoolBarPage.RelationshipDropDownIcon.Click();
                WriteToReport(ShowSubMenu, maintoolBarPage.ShowSubMenu.Displayed, ":Show Sub Menu {0} visible", storySharePermission, createNode);
                if (isCreateSubMenupDisplayed)
                {
                    WriteToReport(CreateOrEditSubMenu, isCreateSubMenupDisplayed, ":Create/Edit Sub Menu {0} visible", storySharePermission, createNode);
                    WriteToReport(MoreOptionsSubMenu, maintoolBarPage.MoreOptionsSubMenu.Displayed, ":More Options Sub Menu {0} visible", storySharePermission, createNode);
                }
            }

            bool isUnlockDisplayed = ElementExists(By.XPath("//span[text()='Unlock']"));
            if (isUnlockDisplayed)
            {
                WriteToReport(UnlockVisibility, isUnlockDisplayed, ":Unlock Element {0} visible", storySharePermission, createNode);
            }

            bool isSearchDisplayed = ElementExists(By.XPath("//img[@alt='Search']"));
            if (isSearchDisplayed)
            {
                WriteToReport(SearchVisibility, isSearchDisplayed, ":Search Element {0} visible", storySharePermission, createNode);
            }

            bool isFScreenDisplayed = ElementExists(By.XPath("//img[@alt='Fullscreen story button']"));
            if (isFScreenDisplayed)
            {
                WriteToReport(FullScreenVisibility, isFScreenDisplayed, ":Full Screen Element {0} visible", storySharePermission, createNode);
            }
        }

        private void WriteToReport(bool expected, bool actual, string message, string role, ExtentTest node)
        {
            var record = string.Format(message, actual ? "is" : "is not");
            var status = actual == expected ? Status.Pass : Status.Fail;

            node.Log(status, $"{role} {record}");
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                yield return new TestCaseData(sc.Username, sc.Password, sc.StoryUrl, sc.StorySharePermission, sc.MainToolBarPermissions.MainToolbarvisibility, sc.MainToolBarPermissions.UndoVisibility, sc.MainToolBarPermissions.UndoSubMenu, sc.MainToolBarPermissions.RedoSubMenu, sc.MainToolBarPermissions.RestoreStorySubMenu, sc.MainToolBarPermissions.StoryVisibility, sc.MainToolBarPermissions.SetupSubMenu, sc.MainToolBarPermissions.ManagePresentationsSubMenu, sc.MainToolBarPermissions.ManageFormsSubMenu, sc.MainToolBarPermissions.DownloadStorySubMenu, sc.MainToolBarPermissions.DataVisibility, sc.MainToolBarPermissions.EditDataSubMenu, sc.MainToolBarPermissions.DataConnectorsSubMenu, sc.MainToolBarPermissions.ViewVisibility, sc.MainToolBarPermissions.ResetViewVisibility, sc.MainToolBarPermissions.SaveViewVisibility, sc.MainToolBarPermissions.ViewSetupSubMenu, sc.MainToolBarPermissions.FiltersSubMenu, sc.MainToolBarPermissions.AddNewSubMenu, sc.MainToolBarPermissions.SaveAsNewSubMenu, sc.MainToolBarPermissions.RelationshipsVisibility, sc.MainToolBarPermissions.ShowSubMenu, sc.MainToolBarPermissions.CreateOrEditSubMenu, sc.MainToolBarPermissions.MoreOptionsSubMenu, sc.MainToolBarPermissions.UnlockVisibility, sc.MainToolBarPermissions.SearchVisibility, sc.MainToolBarPermissions.FullScreenVisibility);
            }
        }
    }
}
