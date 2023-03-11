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
        public IList<IWebElement> ViewItems { get; set; }

        [FindsBy(How = How.Id, Using = ("viewTitleContainer"))]
        public IWebElement ViewTitleName { get; set; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/thead/tr/th"))]
        public IList<IWebElement> TableColumnCount { get; set; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/tbody/tr"))]
        public IList<IWebElement> TableRowsCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = ("#roadmapName"))]
        public IWebElement RoadMapName { get; set; }
    }
}
