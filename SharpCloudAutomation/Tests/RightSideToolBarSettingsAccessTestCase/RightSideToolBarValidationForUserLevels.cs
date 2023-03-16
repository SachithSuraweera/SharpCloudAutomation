using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;

namespace SharpCloudAutomation.Tests.RightSideToolBarSettingsAccessTestCase
{
    public class RightSideToolBarValidationForUserLevels : Base
    {
        [Test]
        public void CompareRightSideToolBar()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                ExtentTest createNode = CreateNode(sc.StorySharePermission+": Right Side Tool Bar visibility");
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));

                WriteToReport(sc.RightSideToolbarPermissions.RightSideToolBarVisiblility, rToolBarPage.RToolBar.Displayed, ":RightSide Tool Bar {0} visible", sc.StorySharePermission, createNode);

                //sign out
                bool isUserProfileVisible = true;
                try
                {
                    isUserProfileVisible = rToolBarPage.UserProfile.Displayed;
                } catch (NoSuchElementException e)
                {
                    isUserProfileVisible = false;
                }
                if (isUserProfileVisible == true)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }
            }
        }

        private void WriteToReport(bool expected, bool actual, string message, string role, ExtentTest node)
        {
            var record = string.Format(message, actual ? "is" : "is not");
            var status = actual== expected ? Status.Pass : Status.Fail;

            node.Log(status, $"{role} {record}");
        }

        [Test]
        public void CompareSideViewFeatures()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                ExtentTest createNode = CreateNode(sc.StorySharePermission + ": SideView Bar Features");
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                bool isSideViewViewVisible = true;
                try
                {
                    isSideViewViewVisible = rToolBarPage.SideViewVisibility.Displayed;
                }
                catch (NoSuchElementException)
                {
                    isSideViewViewVisible = false;
                }

                WriteToReport(sc.RightSideToolbarPermissions.SideViewEmptyVisibility, rToolBarPage.SideViewVisibility.Displayed, ":Side View Button {0} visible", sc.StorySharePermission, createNode);

                if (isSideViewViewVisible) 
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rToolBarPage.SideViewButton));
                    rToolBarPage.SideViewButton.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@aria-label='Close side view']")));

                    WriteToReport(sc.RightSideToolbarPermissions.SideViewEmptyExpand, rToolBarPage.SideViewExpandText.Displayed, ":Side View Expand {0} visible", sc.StorySharePermission, createNode);
                }
                bool isUserProfileVisible = true;
                try
                {
                    isUserProfileVisible = rToolBarPage.UserProfile.Displayed;
                }
                catch (NoSuchElementException)
                {
                    isUserProfileVisible = false;
                }
                if (isUserProfileVisible)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }
            }
        }

        [Test]
        public void ComapreCommentsFeatures()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                //GetDriver().Navigate().Refresh();
                ExtentTest createNode = CreateNode(sc.StorySharePermission + ": Right Side Tool Bar visibility");
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

                WriteToReport(sc.RightSideToolbarPermissions.CommentsVisibility, isCommentsButtonVisible, ":Comments {0} visible", sc.StorySharePermission, createNode);
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
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments can edit");
                    }
                    else
                    {
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments cannot edit");
                    }
                    
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                    Actions actions = new Actions(GetDriver());
                    rToolBarPage.commentTextBox.Click();
                    actions.MoveToElement(rToolBarPage.DeleteComment);
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rToolBarPage.DeleteComment));
                    actions.Click().Build().Perform();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                    rToolBarPage.CommentsButton.Click();
                }               
                //sign out
                bool isUserProfileVisible = true;
                try
                {
                    isUserProfileVisible = rToolBarPage.UserProfile.Displayed;
                }
                catch (NoSuchElementException e)
                {
                    isUserProfileVisible = false;
                }
                if (isUserProfileVisible == true)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }
            }
        }

        [Test]
        public void CompareEditFeatures()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                //GetDriver().Navigate().Refresh();
                ExtentTest createNode = CreateNode(sc.StorySharePermission + ": Edit features");
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
                WriteToReport(sc.RightSideToolbarPermissions.EditVisibility, isEditButtonVisible, ":Edit Button {0} visible", sc.StorySharePermission, createNode);

                //sign out
                bool isUserProfileVisible = true;
                try
                {
                    isUserProfileVisible = rToolBarPage.UserProfile.Displayed;
                }
                catch (NoSuchElementException e)
                {
                    isUserProfileVisible = false;
                }
                if (isUserProfileVisible == true)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }
            }
        }

        [Test]
        public void CompareWidgetsVisibility()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                //GetDriver().Navigate().Refresh();
                ExtentTest createNode = CreateNode(sc.StorySharePermission + ": Widget features");
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
                WriteToReport(sc.RightSideToolbarPermissions.WidgetsVisibility, isWidgetsButtonVisible, ": Widget Button {0} visible", sc.StorySharePermission, createNode);

                //sign out
                bool isUserProfileVisible = true;
                try
                {
                    isUserProfileVisible = rToolBarPage.UserProfile.Displayed;
                }
                catch (NoSuchElementException e)
                {
                    isUserProfileVisible = false;
                }
                if (isUserProfileVisible == true)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }
            }
        }

        [Test]
        public void CompareFormsFeatures()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                ExtentTest createNode = CreateNode(sc.StorySharePermission + ": Forms features");
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
                WriteToReport(sc.RightSideToolbarPermissions.FormsVisibility, isFormsButtonVisible, ":Forms Button {0} visible", sc.StorySharePermission, createNode);
                if (isFormsButtonVisible)
                {
                    rToolBarPage.FormsButton.Click();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(10));
                    //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//p[@class='outsideFormTitle'][normalize-space()='Restricted Access Form']")));
                    rToolBarPage.FormsNameTextBox.SendKeys("Test Automation");
                    rToolBarPage.FormsDescriptionTextBox.SendKeys("Test Description");
                    rToolBarPage.FormsSubmitButton.Click();
                    rToolBarPage.FormsButton.Click();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                    WriteToReport(sc.RightSideToolbarPermissions.FormsCanUse, rToolBarPage.CreatedForm.Displayed, ":Forms Button {0} editable", sc.StorySharePermission, createNode);

                    rToolBarPage.CreatedForm.Click();
                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    rToolBarPage.FormsDeleteButton.Click();
                }

                //sign out
                bool isUserProfileVisible = true;
                try
                {
                    isUserProfileVisible = rToolBarPage.UserProfile.Displayed;
                }
                catch (NoSuchElementException e)
                {
                    isUserProfileVisible = false;
                }
                if (isUserProfileVisible == true)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }
            }
        }

        [Test]
        public void CompareActivityFeatures()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist)
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                ExtentTest createNode = CreateNode(sc.StorySharePermission + ": Activity features");
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
                WriteToReport(sc.RightSideToolbarPermissions.ActivityCanUse, isActivityButtonVisible, ":Activity Button {0} visible", sc.StorySharePermission, createNode);

                //sign out
                bool isUserProfileVisible = true;
                try
                {
                    isUserProfileVisible = rToolBarPage.UserProfile.Displayed;
                }
                catch (NoSuchElementException e)
                {
                    isUserProfileVisible = false;
                }
                if (isUserProfileVisible == true)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }
            }
        }

        [Test]
        public void CompareRightSideToolBarFeatures()
        {
            RightToolBarPage rToolBarPage = new(GetDriver());
            var userlist = new JsonReader().GetUsersList();

            foreach (var sc in userlist) 
            {
                LoginPage loginPage = new(GetDriver());
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));

                if (sc.Username != "" && sc.Password != "")
                {
                    Assert.That(loginPage.GoButton.Displayed, Is.True);
                    loginPage.UsernameText.SendKeys(sc.Username);
                    loginPage.PasswordText.SendKeys(sc.Password);
                    loginPage.GoButton.Click();
                }
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                GetDriver().Navigate().Refresh();
                ExtentTest createNode = CreateNode("Owner Level:"+sc.StorySharePermission+ " Right Side Tool Bar Features");
                //right side toolbar - visibility
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                if (rToolBarPage.RToolBar.Displayed)
                {
                    createNode.Log(Status.Info, sc.StorySharePermission + " :RightSide Tool Bar is visible");
                }
                else
                {
                    createNode.Log(Status.Info, sc.StorySharePermission + " :RightSide Tool Bar is not visible");
                }
                //side view(empty) - visibility
                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                if (rToolBarPage.SideViewVisibility.Enabled)
                {
                    createNode.Log(Status.Info, sc.StorySharePermission + " :Side View Button is visibile");

                    SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rToolBarPage.SideViewButton));
                    rToolBarPage.SideViewButton.Click();

                    //check side view(empty) - expand 
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@aria-label='Close side view']")));
                    if (rToolBarPage.SideViewExpandText.Displayed) 
                    {
                        createNode.Log(Status.Info, sc.StorySharePermission + " :Side View Expand is visible");
                    }
                    else
                    {
                        createNode.Log(Status.Info, sc.StorySharePermission + " :Side View Expand is not visible");
                    }

                    //check side view(empty) - can edit
                    if (rToolBarPage.SideViewExpandTextEditorButton.Displayed)
                    {
                        createNode.Log(Status.Info, sc.StorySharePermission + " :Side View can be edited");
                    }
                    else
                    {
                        createNode.Log(Status.Info, sc.StorySharePermission + " :Side View can not be edited");
                    }
                    
                    //side view(guide) - visibility
                    if (rToolBarPage.SideViewExpandTextEditorButton.Displayed)
                    {
                        createNode.Log(Status.Info, sc.StorySharePermission + " :Side View(guide) is visible");

                        rToolBarPage.SideViewExpandTextEditorButton.Click();

                    }
                    else
                    {
                        createNode.Log(Status.Info, sc.StorySharePermission + " :Side View(guide) is not visible");
                    }
                }
                /*else if (rToolBarPage.SideviewVisibilityDisabled.Enabled)
                {
                    createNode.Log(Status.Info, sc.StorySharePermission + " :Side view Button is not visible");
                }*/
                else
                {
                    createNode.Log(Status.Info, sc.StorySharePermission + " :Side view Button is not visible");
                    createNode.Log(Status.Info, sc.StorySharePermission + " :Side view Expand is not visible");
                }


                //sign out
                if (rToolBarPage.UserProfile.Displayed)
                {
                    rToolBarPage.UserProfile.Click();
                    GetDriver().FindElement(By.CssSelector("div[id='user-info-14-Sign-out'] span[class='menu-item-text']")).Click();
                }


            }
        }
    }
}
