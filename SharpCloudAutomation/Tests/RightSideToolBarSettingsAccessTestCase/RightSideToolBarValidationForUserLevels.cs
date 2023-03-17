using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;

namespace SharpCloudAutomation.Tests.RightSideToolBarSettingsAccessTestCase
{
    public class RightSideToolBarValidationForUserLevels : Base
    {
        private void LoginWithRedirect(string username, string password, string storyUrl)
        {
            LoginPage loginPage = new(GetDriver());
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

            if (username != "" && password != "")
            {
                Assert.That(loginPage.GoButton.Displayed, Is.True);
                loginPage.UsernameText.SendKeys(username);
                loginPage.PasswordText.SendKeys(password);
                loginPage.GoButton.Click();
            }

            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            GetDriver().Navigate().GoToUrl(storyUrl);
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareRightSideToolBar(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            
                LoginWithRedirect(username, password, storyUrl);

                ExtentTest createNode = CreateNode(storySharePermission+": Right Side Tool Bar visibility");
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

                WriteToReport(rightSideToolBarVisiblility, rToolBarPage.RToolBar.Displayed, ":RightSide Tool Bar {0} visible", storySharePermission, createNode);

                rToolBarPage.SignOut();

        }

        private static void WriteToReport(bool expected, bool actual, string message, string role, ExtentTest node)
        {
            var record = string.Format(message, actual ? "is" : "is not");
            var status = actual== expected ? Status.Pass : Status.Fail;

            node.Log(status, $"{role} {record}");
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareSideViewFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username,password,storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": SideView Bar Features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool isSideViewEmptyVisible = true;

            try
            {
                isSideViewEmptyVisible = rToolBarPage.SideViewVisibility.Displayed;
            }
            catch (NoSuchElementException)
            {
                isSideViewEmptyVisible = false;
            }

            WriteToReport(sideViewEmptyVisitbility, isSideViewEmptyVisible, ":Side View Button {0} visible", storySharePermission, createNode);

            if (isSideViewEmptyVisible) 
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rToolBarPage.SideViewButton));
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.SideViewButton.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@aria-label='Close side view']")));

                bool isSideViewGuideButtonDisplayed = true;

                try
                {
                    isSideViewGuideButtonDisplayed = rToolBarPage.SideViewGuideButton.Displayed;
                }
                catch(NoSuchElementException e)
                {
                    isSideViewGuideButtonDisplayed = false;
                }

                bool isSideViewManageFormsButtonDisaplayed = true;
                    
                try
                {
                    isSideViewManageFormsButtonDisaplayed = rToolBarPage.SideViewManageFormsButton.Displayed;
                }
                catch(NoSuchElementException e)
                {
                    isSideViewManageFormsButtonDisaplayed =false;
                }

                WriteToReport(sideViewEmptyExpand, rToolBarPage.SideViewExpandText.Displayed, ":Side View Expand {0} visible",storySharePermission, createNode);

                if (isSideViewGuideButtonDisplayed || isSideViewManageFormsButtonDisaplayed || (isSideViewGuideButtonDisplayed && isSideViewManageFormsButtonDisaplayed))
                    WriteToReport(sideViewGuideCanEdit, isSideViewGuideButtonDisplayed, ":Side View empty can edit {0} visible", storySharePermission, createNode);
                else
                {
                    WriteToReport(sideViewGuideCanEdit, isSideViewGuideButtonDisplayed, ":Side View empty can edit {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewGuideVisibility, rToolBarPage.SideViewExpandText.Displayed, ":Side View Guide {0} visible", storySharePermission, createNode);
                        
                }

                if (isSideViewGuideButtonDisplayed)
                {
                    WriteToReport(sideViewGuideVisibility, rToolBarPage.SideViewExpandText.Displayed, ":Side View Guide {0} visible", storySharePermission, createNode);

                    rToolBarPage.SideViewGuideButton.Click();
                    GetDriver().SwitchTo().Frame(rToolBarPage.IFrame);

                    if (rToolBarPage.SideViewGuideExpandArea.Displayed)
                    {
                        WriteToReport(sideViewGuideExpand, rToolBarPage.SideViewGuideExpandArea.Displayed, ":Side View Guide expand {0} visible", storySharePermission, createNode);

                        rToolBarPage.SideViewGuideExpandAddTextArea.SendKeys("Test");
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                        if (rToolBarPage.SideViewGuideExpandReadText.Text == "Test")
                            WriteToReport(sideViewGuideCanEdit, rToolBarPage.SideViewGuideExpandReadText.Displayed, ":Side View Guide can edit {0} visible", storySharePermission, createNode);
                    
                        GetDriver().SwitchTo().DefaultContent();
                        GetDriver().ExecuteJavaScript("arguments[0].click();", GetDriver().FindElement(By.XPath("//div[@class='cdk-overlay-backdrop sc-modal-backdrop cdk-overlay-backdrop-showing']")));
                        GetDriver().SwitchTo().DefaultContent();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                        rToolBarPage.SideViewButton.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                        rToolBarPage.SideViewButton.Click();   
                    }
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    rToolBarPage.SideViewGuideExpandDeleteButton.Click();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    rToolBarPage.SideViewCloseViewButton.Click();
                }
                else
                {
                    WriteToReport(sideViewGuideExpand, isSideViewGuideButtonDisplayed, ":Side View Guide expand {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewGuideCanEdit, isSideViewGuideButtonDisplayed, ":Side View Guide can edit {0} visible", storySharePermission, createNode);
                }

                if(isSideViewManageFormsButtonDisaplayed)
                {
                    WriteToReport(sideViewFormVisibility, isSideViewManageFormsButtonDisaplayed, ":Side View Form {0} visible", storySharePermission, createNode);

                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    rToolBarPage.SideViewButton.Click();

                    rToolBarPage.SideViewFormDropDown.Click();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    Actions actions = new(GetDriver());
                    actions.MoveToElement(rToolBarPage.SideViewFormDropDown);
                    actions.Perform();

                    SelectElement se = new(rToolBarPage.SideViewFormDropDown);

                    try
                    {
                        se.SelectByIndex(1);
                    }
                    catch(StaleElementReferenceException) 
                    {
                        se.SelectByIndex(1);
                    }

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Name']")));

                    if(rToolBarPage.FormsNameTextBox.Displayed)
                    {
                        WriteToReport(sideViewFormExpand, rToolBarPage.FormsNameTextBox.Displayed, ":Side View Form expand {0} visible", storySharePermission, createNode);

                        rToolBarPage.FormsNameTextBox.SendKeys("Test Automation");
                        rToolBarPage.FormsDescriptionTextBox.SendKeys("Test Description");
                        rToolBarPage.FormsSubmitButton.Click();
                        rToolBarPage.SideViewFormDeleteButton.Click();
                        rToolBarPage.SideViewCloseViewButton.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
                        WriteToReport(sideViewFormCanUse, rToolBarPage.CreatedForm.Displayed, ":Side View form {0} editable", storySharePermission, createNode);

                        rToolBarPage.CreatedForm.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                        rToolBarPage.FormsDeleteButton.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                    }

                }
                else 
                {
                    WriteToReport(sideViewFormVisibility, isSideViewManageFormsButtonDisaplayed, ":Side View Form {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewFormExpand, isSideViewManageFormsButtonDisaplayed, ":Side View Form expand {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewFormCanUse, isSideViewManageFormsButtonDisaplayed, ":Side View form {0} editable", storySharePermission, createNode);
                }
                    
            }
            rToolBarPage.SignOut();
            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void ComapreCommentsFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
              
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Right Side Tool Bar visibility");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool isCommentsButtonVisible = true;

            try
            {
                isCommentsButtonVisible = rToolBarPage.CommentsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                isCommentsButtonVisible = false;
            }

            WriteToReport(commentsVisibility, isCommentsButtonVisible, ":Comments {0} visible", storySharePermission, createNode);
            if (isCommentsButtonVisible)
            {
                rToolBarPage.CommentsButton.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='story-feed-comment-box']")));
                rToolBarPage.AddCommentsTextBox.SendKeys("Test Comment");
                rToolBarPage.AddCommentsTextButton.Click();
                rToolBarPage.CommentsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.CommentsButton.Click();

                if (rToolBarPage.CommentedText.Text == "Test Comment")
                    createNode.Log(Status.Pass, storySharePermission + " :Comments can edit");
                else
                    createNode.Log(Status.Fail, storySharePermission + " :Comments cannot edit");

                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                Actions actions = new(GetDriver());
                rToolBarPage.commentTextBox.Click();
                actions.MoveToElement(rToolBarPage.DeleteComment);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rToolBarPage.DeleteComment));
                actions.Click().Build().Perform();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.CommentsButton.Click();
            }
            rToolBarPage.SignOut();
            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareEditFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersListWithoutEditor();


            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Edit features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool isEditButtonVisible = true;

            try
            {
                isEditButtonVisible = rToolBarPage.EditButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                isEditButtonVisible = false;
            }

            WriteToReport(editVisibility, isEditButtonVisible, ":Edit Button {0} visible", storySharePermission, createNode);

            if (isEditButtonVisible)
            {
                rToolBarPage.EditButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.EditCreateNewItemButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.EditItemNameTexBox.Clear();
                rToolBarPage.EditItemNameTexBox.SendKeys("Test Automation");
                rToolBarPage.EditItemDescriptionTextBox.SendKeys("Test Description");
                rToolBarPage.EditITemDuplicateButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                bool isDeleteButtonOrUnpublishButtonDisplayed = false;

                try
                {
                    isDeleteButtonOrUnpublishButtonDisplayed = rToolBarPage.EditItemDeleteButton.Displayed;
                }
                catch(NoSuchElementException) 
                {
                    isDeleteButtonOrUnpublishButtonDisplayed = rToolBarPage.EditItemUnPublishButton.Displayed;
                }

                if (rToolBarPage.EditItemOpenButtton.Displayed && rToolBarPage.EditITemDuplicateButton.Displayed && (isDeleteButtonOrUnpublishButtonDisplayed))
                    WriteToReport(editCanEdit, isEditButtonVisible, ":Edit Button can edit {0} visible", storySharePermission, createNode);
                    
                try
                {
                    rToolBarPage.EditItemDeleteButton.Click();
                }
                catch(NoSuchElementException)
                {
                    rToolBarPage.EditItemUnPublishButton.Click();
                }

                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.EditButton.Click();
                GetDriver().Navigate().Refresh();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.CreatedEditItem.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                rToolBarPage.FormsDeleteButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            }
            rToolBarPage.SignOut();
            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareWidgetsVisibility(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Widget features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool isWidgetsButtonVisible = true;

            try
            {
                isWidgetsButtonVisible = rToolBarPage.WidgetsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                isWidgetsButtonVisible = false;
            }

            WriteToReport(widgetsVisibility, isWidgetsButtonVisible, ": Widget Button {0} visible", storySharePermission, createNode);

            if (isWidgetsButtonVisible) 
            {
                rToolBarPage.WidgetsButton.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='New Widget']")));
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.WidgetNewWidgetButton.Click();
                rToolBarPage.WidgetsAdvancedOptionsArrow.Click();

                Actions actions = new(GetDriver());
                actions.MoveToElement(rToolBarPage.WidgetsLinkToViewButton);

                rToolBarPage.WidgetsLinkToViewButton.Click();
                rToolBarPage.WidgetsSelectViewPopUpView2.Click();
                rToolBarPage.WidgetsSelectViewPopupOKButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.WidgetsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.WidgetsCreatedItem.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rToolBarPage.View1.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

                if (rToolBarPage.WidgetsCreatedItem.Displayed)
                    WriteToReport(widgetsCanEdit, rToolBarPage.WidgetsCreatedItem.Displayed, ": Widget Button can edit {0} visible", storySharePermission, createNode);
                    
                rToolBarPage.WidgetsButton.Click();
                rToolBarPage.WidgetsCreatedItem.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                rToolBarPage.WidgetsDeleteButton.Click();
                rToolBarPage.WidgetsButton.Click();
            }
            rToolBarPage.SignOut();
            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareFormsFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersListWithoutEditor();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Forms features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool isFormsButtonVisible = true;

            try
            {
                isFormsButtonVisible = rToolBarPage.FormsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                isFormsButtonVisible = false;
            }

            WriteToReport(formsVisibility, isFormsButtonVisible, ":Forms Button {0} visible", storySharePermission, createNode);

            if (isFormsButtonVisible)
            {
                rToolBarPage.FormsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Name']")));
                rToolBarPage.FormsNameTextBox.SendKeys("Test Automation");
                rToolBarPage.FormsDescriptionTextBox.SendKeys("Test Description");
                rToolBarPage.FormsSubmitButton.Click();
                rToolBarPage.FormsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
                WriteToReport(formsCanUse, rToolBarPage.CreatedForm.Displayed, ":Forms Button {0} editable", storySharePermission, createNode);

                rToolBarPage.CreatedForm.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                rToolBarPage.FormsDeleteButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
            }

            rToolBarPage.SignOut();
            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void CompareActivityFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Activity features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool isActivityButtonVisible = true;

            try
            {
                isActivityButtonVisible = rToolBarPage.FormsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                isActivityButtonVisible = false;
            }

            WriteToReport(activityCanUse, isActivityButtonVisible, ":Activity Button {0} visible", storySharePermission, createNode);

            rToolBarPage.SignOut();
            
        }
        public static IEnumerable<TestCaseData> GetTestData()
        {
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                yield return new TestCaseData(sc.Username, sc.Password, sc.StoryUrl, sc.StorySharePermission,
                    sc.RightSideToolbarPermissions.RightSideToolBarVisiblility, sc.RightSideToolbarPermissions.SideViewEmptyVisitbility, sc.RightSideToolbarPermissions.SideViewEmptyExpand, sc.RightSideToolbarPermissions.SideViewEmptyCanEdit, sc.RightSideToolbarPermissions.SideViewGuideVisibility, sc.RightSideToolbarPermissions.SideViewGuideExpand, sc.RightSideToolbarPermissions.SideViewGuideCanEdit,
                    sc.RightSideToolbarPermissions.SideViewFormVisibility, sc.RightSideToolbarPermissions.SideViewFormExpand, sc.RightSideToolbarPermissions.SideViewFormCanUse, sc.RightSideToolbarPermissions.CommentsVisibility, sc.RightSideToolbarPermissions.CommentsCanEditComment, sc.RightSideToolbarPermissions.EditVisibility, sc.RightSideToolbarPermissions.EditCanEdit, sc.RightSideToolbarPermissions.WidgetsVisibility,
                    sc.RightSideToolbarPermissions.WidgetsCanEdit, sc.RightSideToolbarPermissions.FormsVisibility, sc.RightSideToolbarPermissions.FormsCanUse, sc.RightSideToolbarPermissions.ActivityCanUse);
            }
        }
    }
}
