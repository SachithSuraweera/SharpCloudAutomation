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

            if (username != "" && password != "")
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

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool MainToolBarPrsent = ElementExists(By.XPath("//div[contains(@class,'hide-for-presentation transitioning min-width') and @id='storyToolbar']"));
            WriteToReport(mainToolbarvisibility, MainToolBarPrsent, ":Main Tool Bar {0} visible", storySharePermission, createNode);

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool undoIconPresent = ElementExists(By.XPath("//div[@id='undoDropdown']"));
            WriteToReport(UndoVisibility, undoIconPresent, ":Undo Element {0} visible", storySharePermission, createNode);
            if (undoIconPresent)
            {
                maintoolBarPage.UndoDropdownIcon.Click();
                WriteToReport(UndoSubMenu, maintoolBarPage.UndoSubMenu.Displayed, ":Undo Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(RedoSubMenu, maintoolBarPage.RedoSubMenu.Displayed, ":Redo Sub Menu {0} visible", storySharePermission, createNode);
                bool RestoreSubMenuPresent = ElementExists(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[contains(text(),'Restore Story')]"));
                {
                    WriteToReport(RestoreStorySubMenu, RestoreSubMenuPresent, ":Restore Story sub menu {0} visible", storySharePermission, createNode);
                }
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool storyIconPresent = ElementExists(By.XPath("//div[@tooltip='Story Setup']"));

            WriteToReport(StoryVisibility, storyIconPresent, ":Story Element {0} visible", storySharePermission, createNode);
            if (storyIconPresent)
            {
                maintoolBarPage.StoryDropIcon.Click();
                WriteToReport(SetupSubMenu, maintoolBarPage.SetupSubMenu.Displayed, ":Setup Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(ManagePresentationsSubMenu, maintoolBarPage.ManagePresentationSubMenu.Displayed, ":Manage Presentations Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(ManageFormsSubMenu, maintoolBarPage.ManageFormsSubMenu.Displayed, ":Manage Forms sub menu {0} visible", storySharePermission, createNode);
                WriteToReport(DownloadStorySubMenu, maintoolBarPage.DownloadStorySubMenu.Displayed, ":Download Story sub menu {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool dataIconPresent = ElementExists(By.XPath("//div[@tooltip='Data Setup']"));
            WriteToReport(DataVisibility, dataIconPresent, ":Data Element {0} visible", storySharePermission, createNode);
            if (dataIconPresent)
            {
                maintoolBarPage.DataDropDownIcon.Click();
                WriteToReport(EditDataSubMenu, maintoolBarPage.EditDataSubMenu.Displayed, ":Edit Data Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(DataConnectorsSubMenu, maintoolBarPage.DataSourcesSubMenu.Displayed, ":Data Connectors Sub Menu {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool viewPresent = ElementExists(By.XPath("//span[text()='View']"));
            if (viewPresent)
            {
                WriteToReport(ViewVisibility, viewPresent, ":View Element {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool resetPresent = ElementExists(By.XPath("//button[text()='Reset View']"));
            if (resetPresent)
            {
                WriteToReport(ResetViewVisibility, resetPresent, ":Reset View Element {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool savePresent = ElementExists(By.XPath("//span[@aria-label='View setup menu']"));
            if (savePresent)
            {
                WriteToReport(SaveViewVisibility, savePresent, ":Save View Element {0} visible", storySharePermission, createNode);
                maintoolBarPage.SaveDropDownIcon.Click();
                WriteToReport(ViewSetupSubMenu, maintoolBarPage.ViewSetUpSubMenu.Displayed, ":View Setup Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(FiltersSubMenu, maintoolBarPage.FiltersSubMenu.Displayed, ":Filters Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(AddNewSubMenu, maintoolBarPage.AddNewSubMenu.Displayed, ":Add New Sub Menu {0} visible", storySharePermission, createNode);
                WriteToReport(SaveAsNewSubMenu, maintoolBarPage.SaveAsNewSubMenu.Displayed, ":Save As New Sub Menu {0} visible", storySharePermission, createNode);
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool relationshipPresent = ElementExists(By.XPath("//div[@id='storyToolbar' and contains(@class,'hide-for-presentation transitioning min-width')]//div[@id='relationshipsToggle']"));
            bool createSubMenupPresent = ElementExists(By.XPath("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li/label[contains(text(),'Create/Edit')]"));
            if (relationshipPresent)
            {
                WriteToReport(RelationshipsVisibility, relationshipPresent, ":Relationship Element {0} visible", storySharePermission, createNode);
                maintoolBarPage.RelationshipDropDownIcon.Click();
                WriteToReport(ShowSubMenu, maintoolBarPage.ShowSubMenu.Displayed, ":Show Sub Menu {0} visible", storySharePermission, createNode);
                if (createSubMenupPresent)
                {
                    WriteToReport(CreateOrEditSubMenu, createSubMenupPresent, ":Create/Edit Sub Menu {0} visible", storySharePermission, createNode);
                    WriteToReport(MoreOptionsSubMenu, maintoolBarPage.MoreOptionsSubMenu.Displayed, ":More Options Sub Menu {0} visible", storySharePermission, createNode);
                }
            }

            bool unlockPresent = ElementExists(By.XPath("//span[text()='Unlock']"));
            WriteToReport(UnlockVisibility, unlockPresent, ":Unlock Element {0} visible", storySharePermission, createNode);

            bool searchPresent = ElementExists(By.XPath("//img[@alt='Search']"));
            WriteToReport(SearchVisibility, searchPresent, ":Search Element {0} visible", storySharePermission, createNode);

            bool fullScreenPrsent = ElementExists(By.XPath("//div[@id='storyToolbar' and contains(@class,'hide-for-presentation transitioning min-width')]//img[@alt='Fullscreen story button']"));
            WriteToReport(FullScreenVisibility, fullScreenPrsent, ":Full Screen Element {0} visible", storySharePermission, createNode);

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
