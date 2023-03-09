using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using SharpCloudAutomation.Tests.LoginTestCase;
using OpenQA.Selenium;
using System.Collections;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;

namespace SharpCloudAutomation.Tests.CalculationStoryTestCase
{
    internal class CalculationStoryTest : Base
    {
        [Test]
        public void StoryTableViewResultColumnCheck()
        {
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(15));
            ArrayList arrayList = new();

            LoginPage loginPage = new(GetDriver());
            CalculatedStoryPage calculatedStoryPage = new(GetDriver());
            loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[id='dashboardWelcome'] h1")));

            var stories = new JsonReader().GetCalculatedStoryList();
            foreach (var story in stories)
            {
                GetDriver().Navigate().GoToUrl(story.StoryUrl);
                
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
                
                IList<IWebElement> viewChooserItems = calculatedStoryPage.GetView();
                viewChooserItems = viewChooserItems.Where(viewChooserItem => !viewChooserItem.Text.ToString().Contains("add_new")).ToList();
                
                foreach (IWebElement view in viewChooserItems)
                {
                    {
                        view.Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
                        Thread.Sleep(1000);
                        string viewName = calculatedStoryPage.GetViewName().Text;
                        IList<IWebElement> tableColmCount = calculatedStoryPage.GetTableColmCount();
                        IList<IWebElement> rowsCount = calculatedStoryPage.GetRowsCount();
                       
                        for (int i = 1; i <= rowsCount.Count; i++)
                        {
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[" + tableColmCount.Count + "]")));
                            string nameColm = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[1]")).Text;
                            string resultColm = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td["+ tableColmCount.Count +"]")).Text;
                            TestContext.Progress.WriteLine(resultColm);
                            if (resultColm == "FAIL" || resultColm == "Fail")
                            {
                                TestContext.Progress.WriteLine(viewName);
                                if (viewName == "")
                                {
                                    arrayList.Add(calculatedStoryPage.GetRoadMapName().Text + ": " + nameColm);
                                }
                                else
                                {
                                    arrayList.Add(calculatedStoryPage.GetRoadMapName().Text +": "+viewName + ": " + nameColm);
                                }
                            }
                        }
                    }
                }
            }
            ExtentTest storyNode = CreateNode("Calculation Related failed stories");
            for (int i = 0; i<arrayList.Count; i++)
            {
                storyNode.Log(Status.Info, arrayList[i].ToString());
            }
        }
    }
}
