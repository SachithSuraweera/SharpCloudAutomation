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
        public IList<IWebElement> viewChooserItems;

        public IList<IWebElement> GetView()
        {
            return viewChooserItems;
        }
        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']"))]
        private readonly IWebElement getTable;

        public IWebElement GetTableView() { return getTable; }

        [FindsBy(How = How.Id, Using = ("viewTitleContainer"))]
        private readonly IWebElement viewName;

        public IWebElement GetViewName() {  return viewName; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/thead/tr/th"))]
        private IList<IWebElement> tableColmCount;

        public IList<IWebElement> GetTableColmCount() { return tableColmCount; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/tbody/tr"))]
        private IList<IWebElement> rowsCount;

        public IList <IWebElement> GetRowsCount() {  return rowsCount; }

        [FindsBy(How = How.CssSelector, Using = ("#roadmapName"))]
        private IWebElement roadMapName;

        public IWebElement GetRoadMapName() { return roadMapName; }

        [FindsBy(How = How.CssSelector, Using = ("div[id='dashboardWelcome'] h1"))]
        private IWebElement dashboardTitle;

        public IWebElement GetDashboardTitle() {  return dashboardTitle; }


    }
}
