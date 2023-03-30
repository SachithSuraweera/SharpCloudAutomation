using AventStack.ExtentReports;
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
        public void VerifyRightSideToolBar(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rightToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();
            
                LoginWithRedirect(username, password, storyUrl);

                ExtentTest createNode = CreateNode(storySharePermission+": Right Side Tool Bar visibility");
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

                WriteToReport(rightSideToolBarVisiblility, rightToolBarPage.RToolBar.Displayed, ":RightSide Tool Bar {0} visible", storySharePermission, createNode);

                rightToolBarPage.SignOut();
        }

        private static void WriteToReport(bool expected, bool actual, string message, string role, ExtentTest node)
        {
            var record = string.Format(message, actual ? "is" : "is not");
            var status = actual== expected ? Status.Pass : Status.Fail;

            node.Log(status, $"{role} {record}");
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifySideViewFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rightToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username,password,storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": SideView Bar Features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            bool sideViewEmptyVisible = true;

            try
            {
                sideViewEmptyVisible = rightToolBarPage.SideViewVisibility.Displayed;
            }
            catch (NoSuchElementException)
            {
                sideViewEmptyVisible = false;
            }

            WriteToReport(sideViewEmptyVisitbility, sideViewEmptyVisible, ":Side View Button {0} visible", storySharePermission, createNode);

            if (sideViewEmptyVisible) 
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rightToolBarPage.SideViewButton));
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.SideViewButton.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@aria-label='Close side view']")));

                bool sideViewGuideButtonPresent = true;

                try
                {
                    sideViewGuideButtonPresent = rightToolBarPage.SideViewGuideButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    sideViewGuideButtonPresent = false;
                }

                bool sideViewManageFormsButtonPresent = true;
                    
                try
                {
                    sideViewManageFormsButtonPresent = rightToolBarPage.SideViewManageFormsButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    sideViewManageFormsButtonPresent = false;
                }

                WriteToReport(sideViewEmptyExpand, rightToolBarPage.SideViewExpandText.Displayed, ":Side View Expand {0} visible",storySharePermission, createNode);

                if (sideViewGuideButtonPresent || sideViewManageFormsButtonPresent || (sideViewGuideButtonPresent && sideViewManageFormsButtonPresent))
                    WriteToReport(sideViewGuideCanEdit, sideViewGuideButtonPresent, ":Side View empty can edit {0} visible", storySharePermission, createNode);
                else
                {
                    WriteToReport(sideViewGuideCanEdit, sideViewGuideButtonPresent, ":Side View empty can edit {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewGuideVisibility, rightToolBarPage.SideViewExpandText.Displayed, ":Side View Guide {0} visible", storySharePermission, createNode);                        
                }

                if (sideViewGuideButtonPresent)
                {
                    WriteToReport(sideViewGuideVisibility, rightToolBarPage.SideViewExpandText.Displayed, ":Side View Guide {0} visible", storySharePermission, createNode);

                    rightToolBarPage.SideViewGuideButton.Click();
                    GetDriver().SwitchTo().Frame(rightToolBarPage.IFrame);

                    if (rightToolBarPage.SideViewGuideExpandArea.Displayed)
                    {
                        WriteToReport(sideViewGuideExpand, rightToolBarPage.SideViewGuideExpandArea.Displayed, ":Side View Guide expand {0} visible", storySharePermission, createNode);

                        rightToolBarPage.SideViewGuideExpandAddTextArea.SendKeys("Test");
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));

                        if (rightToolBarPage.SideViewGuideExpandReadText.Text == "Test")
                            WriteToReport(sideViewGuideCanEdit, rightToolBarPage.SideViewGuideExpandReadText.Displayed, ":Side View Guide can edit {0} visible", storySharePermission, createNode);
                    
                        GetDriver().SwitchTo().DefaultContent();
                        GetDriver().ExecuteJavaScript("arguments[0].click();", GetDriver().FindElement(By.XPath("//div[@class='cdk-overlay-backdrop sc-modal-backdrop cdk-overlay-backdrop-showing']")));
                        GetDriver().SwitchTo().DefaultContent();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                        rightToolBarPage.SideViewButton.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                        rightToolBarPage.SideViewButton.Click();   
                    }

                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    rightToolBarPage.SideViewGuideExpandDeleteButton.Click();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    rightToolBarPage.SideViewCloseViewButton.Click();
                }
                else
                {
                    WriteToReport(sideViewGuideExpand, sideViewGuideButtonPresent, ":Side View Guide expand {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewGuideCanEdit, sideViewGuideButtonPresent, ":Side View Guide can edit {0} visible", storySharePermission, createNode);
                }

                if(sideViewManageFormsButtonPresent)
                {
                    WriteToReport(sideViewFormVisibility, sideViewManageFormsButtonPresent, ":Side View Form {0} visible", storySharePermission, createNode);

                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    rightToolBarPage.SideViewButton.Click();

                    rightToolBarPage.SideViewFormDropDown.Click();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    Actions actions = new(GetDriver());
                    actions.MoveToElement(rightToolBarPage.SideViewFormDropDown);
                    actions.Perform();

                    SelectElement se = new(rightToolBarPage.SideViewFormDropDown);

                    try
                    {
                        se.SelectByIndex(1);
                    }
                    catch(StaleElementReferenceException) 
                    {
                        se.SelectByIndex(1);
                    }

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Name']")));

                    if(rightToolBarPage.FormsNameTextBox.Displayed)
                    {
                        WriteToReport(sideViewFormExpand, rightToolBarPage.FormsNameTextBox.Displayed, ":Side View Form expand {0} visible", storySharePermission, createNode);

                        rightToolBarPage.FormsNameTextBox.SendKeys("Test Automation");
                        rightToolBarPage.FormsDescriptionTextBox.SendKeys("Test Description");
                        rightToolBarPage.FormsSubmitButton.Click();
                        rightToolBarPage.SideViewFormDeleteButton.Click();
                        rightToolBarPage.SideViewCloseViewButton.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
                        WriteToReport(sideViewFormCanUse, rightToolBarPage.CreatedForm.Displayed, ":Side View form {0} editable", storySharePermission, createNode);

                        rightToolBarPage.CreatedForm.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                        rightToolBarPage.FormsDeleteButton.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                    }

                }
                else 
                {
                    WriteToReport(sideViewFormVisibility, sideViewManageFormsButtonPresent, ":Side View Form {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewFormExpand, sideViewManageFormsButtonPresent, ":Side View Form expand {0} visible", storySharePermission, createNode);
                    WriteToReport(sideViewFormCanUse, sideViewManageFormsButtonPresent, ":Side View form {0} editable", storySharePermission, createNode);
                }                    
            }
            rightToolBarPage.SignOut();            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifyCommentsFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rightToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
              
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Right Side Tool Bar visibility");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool commentsButtonVisible = true;

            try
            {
                commentsButtonVisible = rightToolBarPage.CommentsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                commentsButtonVisible = false;
            }

            WriteToReport(commentsVisibility, commentsButtonVisible, ":Comments {0} visible", storySharePermission, createNode);
            if (commentsButtonVisible)
            {
                rightToolBarPage.CommentsButton.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='story-feed-comment-box']")));
                rightToolBarPage.AddCommentsTextBox.SendKeys("Test Comment");
                rightToolBarPage.AddCommentsTextButton.Click();
                rightToolBarPage.CommentsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.CommentsButton.Click();

                if (rightToolBarPage.CommentedText.Text == "Test Comment")
                    createNode.Log(Status.Pass, storySharePermission + " :Comments can edit");
                else
                    createNode.Log(Status.Fail, storySharePermission + " :Comments cannot edit");

                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                Actions actions = new(GetDriver());
                rightToolBarPage.commentTextBox.Click();
                actions.MoveToElement(rightToolBarPage.DeleteComment);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rightToolBarPage.DeleteComment));
                actions.Click().Build().Perform();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.CommentsButton.Click();
            }
            rightToolBarPage.SignOut();           
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifyEditFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rightToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersListWithoutEditor();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Edit features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool editButtonVisible = true;

            try
            {
                editButtonVisible = rightToolBarPage.EditButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                editButtonVisible = false;
            }

            WriteToReport(editVisibility, editButtonVisible, ":Edit Button {0} visible", storySharePermission, createNode);

            if (editButtonVisible)
            {
                rightToolBarPage.EditButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.EditCreateNewItemButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.EditItemNameTexBox.Clear();
                rightToolBarPage.EditItemNameTexBox.SendKeys("Test Automation");
                rightToolBarPage.EditItemDescriptionTextBox.SendKeys("Test Description");
                rightToolBarPage.EditITemDuplicateButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                bool isDeleteButtonOrUnpublishButtonDisplayed = false;

                try
                {
                    isDeleteButtonOrUnpublishButtonDisplayed = rightToolBarPage.EditItemDeleteButton.Displayed;
                }
                catch(NoSuchElementException) 
                {
                    isDeleteButtonOrUnpublishButtonDisplayed = rightToolBarPage.EditItemUnPublishButton.Displayed;
                }

                if (rightToolBarPage.EditItemOpenButtton.Displayed && rightToolBarPage.EditITemDuplicateButton.Displayed && (isDeleteButtonOrUnpublishButtonDisplayed))
                    WriteToReport(editCanEdit, editButtonVisible, ":Edit Button can edit {0} visible", storySharePermission, createNode);
                    
                try
                {
                    rightToolBarPage.EditItemDeleteButton.Click();
                }
                catch(NoSuchElementException)
                {
                    rightToolBarPage.EditItemUnPublishButton.Click();
                }

                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.EditButton.Click();
                GetDriver().Navigate().Refresh();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.CreatedEditItem.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                rightToolBarPage.FormsDeleteButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
            }
            rightToolBarPage.SignOut();            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifyWidgetsVisibility(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rightToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Widget features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool widgetsButtonVisible = true;

            try
            {
                widgetsButtonVisible = rightToolBarPage.WidgetsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                widgetsButtonVisible = false;
            }

            WriteToReport(widgetsVisibility, widgetsButtonVisible, ": Widget Button {0} visible", storySharePermission, createNode);

            if (widgetsButtonVisible) 
            {
                rightToolBarPage.WidgetsButton.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='New Widget']")));
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.WidgetNewWidgetButton.Click();
                rightToolBarPage.WidgetsAdvancedOptionsArrow.Click();

                Actions actions = new(GetDriver());
                actions.MoveToElement(rightToolBarPage.WidgetsLinkToViewButton);

                rightToolBarPage.WidgetsLinkToViewButton.Click();
                rightToolBarPage.WidgetsSelectViewPopUpView2.Click();
                rightToolBarPage.WidgetsSelectViewPopupOKButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.WidgetsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.WidgetsCreatedItem.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                rightToolBarPage.View1.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

                if (rightToolBarPage.WidgetsCreatedItem.Displayed)
                    WriteToReport(widgetsCanEdit, rightToolBarPage.WidgetsCreatedItem.Displayed, ": Widget Button can edit {0} visible", storySharePermission, createNode);
                    
                rightToolBarPage.WidgetsButton.Click();
                rightToolBarPage.WidgetsCreatedItem.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                rightToolBarPage.WidgetsDeleteButton.Click();
                rightToolBarPage.WidgetsButton.Click();
            }
            rightToolBarPage.SignOut();            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifyFormsFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rightToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersListWithoutEditor();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Forms features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool formsButtonVisible = true;

            try
            {
                formsButtonVisible = rightToolBarPage.FormsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                formsButtonVisible = false;
            }

            WriteToReport(formsVisibility, formsButtonVisible, ":Forms Button {0} visible", storySharePermission, createNode);

            if (formsButtonVisible)
            {
                rightToolBarPage.FormsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Name']")));
                rightToolBarPage.FormsNameTextBox.SendKeys("Test Automation");
                rightToolBarPage.FormsDescriptionTextBox.SendKeys("Test Description");
                rightToolBarPage.FormsSubmitButton.Click();
                rightToolBarPage.FormsButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
                WriteToReport(formsCanUse, rightToolBarPage.CreatedForm.Displayed, ":Forms Button {0} editable", storySharePermission, createNode);

                rightToolBarPage.CreatedForm.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                rightToolBarPage.FormsDeleteButton.Click();
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
            }

            rightToolBarPage.SignOut();            
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifyActivityFeatures(string username, string password, string storyUrl, string storySharePermission, bool rightSideToolBarVisiblility, bool sideViewEmptyVisitbility, bool sideViewEmptyExpand, bool sideViewEmptyCanEdit, bool sideViewGuideVisibility, bool sideViewGuideExpand, bool sideViewGuideCanEdit, bool sideViewFormVisibility, bool sideViewFormExpand, bool sideViewFormCanUse, bool commentsVisibility, bool commentsCanEditComment, bool editVisibility, bool editCanEdit, bool widgetsVisibility, bool widgetsCanEdit, bool formsVisibility, bool formsCanUse, bool activityCanUse)
        {
            RightToolBarPage rightToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            LoginWithRedirect(username, password, storyUrl);
            ExtentTest createNode = CreateNode(storySharePermission + ": Activity features");
            SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

            bool activityButtonVisible = true;

            try
            {
                activityButtonVisible = rightToolBarPage.FormsButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                activityButtonVisible = false;
            }

            WriteToReport(activityCanUse, activityButtonVisible, ":Activity Button {0} visible", storySharePermission, createNode);

            rightToolBarPage.SignOut();            
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
