using AventStack.ExtentReports;
using OpenQA.Selenium;
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
                if (rToolBarPage.SideViewVisibility.Displayed)
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
