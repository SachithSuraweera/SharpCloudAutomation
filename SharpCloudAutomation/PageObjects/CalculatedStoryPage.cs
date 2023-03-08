using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SharpCloudAutomation.PageObjects
{
    internal class CalculatedStoryPage
    {
        private IWebDriver driver;
        public CalculatedStoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = (".view-chooser-item.ng-star-inserted"))]
        public IList<IWebElement> viewChooserItems;

        public IList<IWebElement> getView()
        {
            return viewChooserItems;
        }
        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']"))]
        private IWebElement getTable;

        public IWebElement getTableView() { return getTable; }

        [FindsBy(How = How.Id, Using = ("viewTitleContainer"))]
        private IWebElement viewName;

        public IWebElement getViewName() {  return viewName; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/thead/tr/th"))]
        private IList<IWebElement> tableColmCount;

        public IList<IWebElement> getTableColmCount() { return tableColmCount; }

        [FindsBy(How = How.XPath, Using = ("//table[@id='table-view']/tbody/tr"))]
        private IList<IWebElement> rowsCount;

        public IList <IWebElement> getRowsCount() {  return rowsCount; }

        [FindsBy(How = How.CssSelector, Using = ("#roadmapName"))]
        private IWebElement roadMapName;

        public IWebElement getRoadMapName() { return roadMapName; }

        [FindsBy(How = How.CssSelector, Using = ("div[id='dashboardWelcome'] h1"))]
        private IWebElement dashboardTitle;

        public IWebElement getDashboardTitle() {  return dashboardTitle; }


    }
}
