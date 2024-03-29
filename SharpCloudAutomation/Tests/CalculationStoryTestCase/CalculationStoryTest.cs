using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using AventStack.ExtentReports;
using System.Text.RegularExpressions;

namespace SharpCloudAutomation.Tests.CalculationStoryTestCase
{
    public class CalculationStoryTest : Base
    {
        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void StoryTableViewResultColumnCheck(string storyUrl)
        {
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new(GetDriver(), TimeSpan.FromSeconds(60));
            ArrayList arrayList = new();
            LoginPage loginPage = new(GetDriver());
            CalculatedStoryPage calculatedStoryPage = new(GetDriver());

            loginPage.ValidLogin(GetJsonData().ExtractInstanceDataJson("username") ?? "", GetJsonData().ExtractInstanceDataJson("password") ?? "");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[id='dashboardWelcome'] h1")));

            GetDriver().Navigate().GoToUrl(storyUrl);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));

            var viewChooserItems = calculatedStoryPage.ChooserItems.Where(viewChooserItem => !viewChooserItem.Text.ToString().Contains("add_new")).ToList();

            foreach (IWebElement view in viewChooserItems)
            {
                view.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));

                SpinWait.SpinUntil(() => false, TimeSpan.FromSeconds(3));

                string roadMap = calculatedStoryPage.RoadMapName.Text;
                string viewName = calculatedStoryPage.ViewName.Text;
                string viewNameForMethod = Regex.Replace(viewName, "/","",RegexOptions.Compiled);
                viewNameForMethod = viewNameForMethod.Replace('"', ' ').Trim();
                string imageComparisonName = System.Reflection.MethodBase.GetCurrentMethod().Name + roadMap + viewNameForMethod;
                CheckImageDifferences(imageComparisonName);
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

            ExtentTest storyNode = CreateNode("Calculation Related failed stories");
            for (int i = 0; i < arrayList.Count; i++)
            {
                storyNode.Log(Status.Fail, arrayList[i].ToString());
            }
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {
            var stories = new JsonReader().GetCalculatedStoryList();

            foreach (var story in stories)
            {
                yield return new TestCaseData(story.StoryUrl);
            }
        }
    }
}
