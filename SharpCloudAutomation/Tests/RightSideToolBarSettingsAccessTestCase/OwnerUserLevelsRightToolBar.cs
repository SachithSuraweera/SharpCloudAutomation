using AventStack.ExtentReports;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Tests.RightSideToolBarSettingsAccessTestCase
{
    public class OwnerUserLevelsRightToolBar : Base
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

                /*var visibilityStatus = rToolBarPage.RToolBar.Displayed ? "is" : "is not";
                var status = Status.Fail;

                if (sc.Permissions.RightSideToolBarVisiblility == rToolBarPage.RToolBar.Displayed)
                    status = Status.Pass;
                
                createNode.Log(status, sc.StorySharePermission + $" :RightSide Tool Bar {visibilityStatus} visible");*/

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
                //GetDriver().Navigate().Refresh();
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

                if (sc.StorySharePermission == "Owner")
                {
                    if (isSideViewViewVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is visible");

                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rToolBarPage.SideViewButton));
                        rToolBarPage.SideViewButton.Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@aria-label='Close side view']")));

                        if (rToolBarPage.SideViewExpandText.Displayed)
                        {
                            createNode.Log(Status.Pass, sc.StorySharePermission + " :Side view Expand is visible");

                            if (rToolBarPage.SideViewGuideButton.Displayed) 
                            {
                                createNode.Log(Status.Pass, sc.StorySharePermission + " :Side view Guide is visible");
                            }
                            else
                            {
                                createNode.Log(Status.Fail, sc.StorySharePermission + " :Side view Guide is not visible");
                            }
                        }
                        else
                            createNode.Log(Status.Fail, sc.StorySharePermission + " :Side view expand is not visible");
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is not visible");
                }
                else if (sc.StorySharePermission == "Co-Owner")
                {
                    if (isSideViewViewVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is not visible");
                }
                else if (sc.StorySharePermission == "Admin")
                {
                    if (isSideViewViewVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is not visible");
                }
                else if (sc.StorySharePermission == "Editor")
                {
                    if (isSideViewViewVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is not visible");
                }
                else if (sc.StorySharePermission == "Viewer")
                {
                    if (isSideViewViewVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is not visible");
                }
                else if (sc.StorySharePermission == "Individual Viewer")
                {
                    if (!isSideViewViewVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is not visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is visible");
                }
                else if (sc.StorySharePermission == "Directory Viewer")
                {
                    if (!isSideViewViewVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is not visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is visible");
                }
                else if (sc.StorySharePermission == "Anonymous")
                {
                    if (!isSideViewViewVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Side View Button is not visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Side View Button is visible");
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
                if (sc.StorySharePermission == "Owner")
                {
                    if (isCommentsButtonVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is visible");

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
                        //rToolBarPage.DeleteComment.Click();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                        Actions actions = new Actions(GetDriver());
                        rToolBarPage.commentTextBox.Click();
                        actions.MoveToElement(rToolBarPage.DeleteComment);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rToolBarPage.DeleteComment));
                        actions.Click().Build().Perform();
                        SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(6));
                        rToolBarPage.CommentsButton.Click();
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is not visible");
                }
                else if (sc.StorySharePermission == "Co-Owner")
                {
                    if (isCommentsButtonVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is visible");
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is not visible");
                }
                else if (sc.StorySharePermission == "Admin")
                {
                    if (isCommentsButtonVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is visible");
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is not visible");
                }
                else if (sc.StorySharePermission == "Editor")
                {
                    if (isCommentsButtonVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is visible");
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is not visible");
                }
                else if (sc.StorySharePermission == "Viewer")
                {
                    if (isCommentsButtonVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is visible");
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is not visible");
                }
                else if (sc.StorySharePermission == "Individual Viewer")
                {
                    if (isCommentsButtonVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is visible");
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is not visible");
                }
                else if (sc.StorySharePermission == "Directory Viewer")
                {
                    if (isCommentsButtonVisible)
                    {
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is visible");
                    }
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is not visible");
                }
                else if (sc.StorySharePermission == "Anonymous")
                {
                    if (!isCommentsButtonVisible)
                        createNode.Log(Status.Pass, sc.StorySharePermission + " :Comments is not visible");
                    else
                        createNode.Log(Status.Fail, sc.StorySharePermission + " :Comments is visible");
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
