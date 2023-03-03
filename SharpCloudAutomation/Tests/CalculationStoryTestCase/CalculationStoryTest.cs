using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Utilities;
using SharpCloudAutomation.Tests.LoginTestCase;
using OpenQA.Selenium;
using System.Collections;

namespace SharpCloudAutomation.Tests.CalculationStoryTestCase
{
    internal class CalculationStoryTest : Base
    {
        [Test]
        public void storyTableViewResultColumnCheck()
        {
            LoginPage loginPage = new LoginPage(GetDriver());
            CalculatedStoryPage calculatedStoryPage = new CalculatedStoryPage(GetDriver());
            loginPage.validLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));
            ArrayList arrayList = new ArrayList();

            Thread.Sleep(5000);
            // Json get one story{}

            var stories = new JsonReader().GetCalculatedStoryList();
            foreach (var story in stories)
            {
                GetDriver().Navigate().GoToUrl(story.StoryUrl);
                Thread.Sleep(5000);

                IList<IWebElement> viewChooserItems = calculatedStoryPage.getView();
                viewChooserItems = viewChooserItems.Where(viewChooserItem => !viewChooserItem.Text.ToString().Contains("add_new")).ToList();
                viewChooserItems = viewChooserItems.Where(viewChooserItem => !viewChooserItem.Text.ToString().Contains("Blank View")).ToList();
                foreach (IWebElement view in viewChooserItems)
                {
                    {
                        view.Click();
                        Thread.Sleep(3000);
                        IWebElement viewName = calculatedStoryPage.getViewName();
                        IList<IWebElement> tableColmCount = calculatedStoryPage.getTableColmCount();
                        IList<IWebElement> rowsCount = calculatedStoryPage.getRowsCount();
                        Thread.Sleep(2000);
                        if(tableColmCount.Count == 5)
                        {
                            for (int i = 1; i <= rowsCount.Count; i++)
                            {
                                string nameColm = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr["+ i +"]/td[1]")).Text;
                                string resultColm = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[5]")).Text;
                                TestContext.Progress.WriteLine(resultColm);
                                if(resultColm == "FAIL")
                                {
                                    arrayList.Add(viewName.Text+ ": " + nameColm);
                                }
                            }
                        }
                        else if(tableColmCount.Count == 6)
                        {
                            for (int i = 1; i <= rowsCount.Count; i++)
                            {
                                string nameColm = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[1]")).Text;
                                string resultColm = GetDriver().FindElement(By.XPath("//table[@id='table-view']/tbody/tr[" + i + "]/td[6]")).Text;
                                TestContext.Progress.WriteLine(resultColm);
                                if (resultColm == "FAIL")
                                {
                                    arrayList.Add(viewName.Text + ": " + nameColm);
                                }
                            }
                        }
                    }
                }
            }

            
        }
    }
}
