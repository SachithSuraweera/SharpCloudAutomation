using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SharpCloudAutomation.PageObjects
{
    internal class CalculatedStoryPage
    {
        public CalculatedStoryPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = (".view-chooser-item.ng-star-inserted"))]
        public IList<IWebElement> ChooserItems { get; set; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']"))]
        public IWebElement TableView { get; set; }

        [FindsBy(How = How.Id, Using = ("viewTitleContainer"))]
        public IWebElement ViewName { get; set; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/thead/tr/th"))]
        public IList<IWebElement> TableColumns;

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/tbody/tr"))]
        public IList<IWebElement> TableRows;

        [FindsBy(How = How.CssSelector, Using = ("#roadmapName"))]
        public IWebElement RoadMapName;

        [FindsBy(How = How.CssSelector, Using = ("div[id='dashboardWelcome'] h1"))]
        public IWebElement DashboardTitle;
    }
}
