using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using AventStack.ExtentReports;

namespace SharpCloudAutomation.Tests.CalculationStoryTestCase
{
    public class CalculationStoryTest : Base
    {
        [Test]
        public void StoryTableViewResultColumnCheck()
        {
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            ArrayList arrayList = new();
            LoginPage loginPage = new(GetDriver());
            CalculatedStoryPage calculatedStoryPage = new(GetDriver());

            loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username") ?? "", GetJsonData().ExtractInstanceDataJson("password") ?? "");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[id='dashboardWelcome'] h1")));

            var stories = new JsonReader().GetCalculatedStoryList();

            foreach (var story in stories)
            {
                GetDriver().Navigate().GoToUrl(story.StoryUrl);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));

                var viewChooserItems = calculatedStoryPage.ChooserItems.Where(viewChooserItem => !viewChooserItem.Text.ToString().Contains("add_new")).ToList();

                foreach (IWebElement view in viewChooserItems)
                {
                    view.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));

                    Thread.Sleep(1000);

                    string roadMap = calculatedStoryPage.RoadMapName.Text;
                    string viewName = calculatedStoryPage.ViewName.Text;

                    for (int i = 1; i <= calculatedStoryPage.TableRows.Count; i++)
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[" + calculatedStoryPage.TableColumns.Count + "]")));
                        string nameColumn;
                        try
                        {
                            nameColumn = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[1]")).Text;
                        }
                        catch (StaleElementReferenceException)
                        {
                            nameColumn = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[1]")).Text;
                        }
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[" + calculatedStoryPage.TableColumns.Count + "]")));
                        string resultColumn;
                        try
                        {
                            resultColumn = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[" + calculatedStoryPage.TableColumns.Count + "]")).Text;
                        }
                        catch (StaleElementReferenceException)
                        {
                            resultColumn = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[" + calculatedStoryPage.TableColumns.Count + "]")).Text;
                        }
                        if (resultColumn == "FAIL" || resultColumn == "Fail")
                        {
                            TestContext.Progress.WriteLine(viewName);
                            if (viewName == "")
                            {
                                arrayList.Add(calculatedStoryPage.RoadMapName.Text + ": " + nameColumn);
                            }
                            else
                            {
                                arrayList.Add(calculatedStoryPage.RoadMapName.Text + ": " + viewName + ": " + nameColumn);
                            }
                        }
                    }
                }
            }

            ExtentTest storyNode = CreateNode("Calculation Related failed stories");
            for (int i = 0; i < arrayList.Count; i++)
            {
                storyNode.Log(Status.Info, arrayList[i].ToString());
            }
        }
    }
}
