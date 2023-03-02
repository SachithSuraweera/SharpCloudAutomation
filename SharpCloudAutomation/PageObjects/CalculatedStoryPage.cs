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

        [FindsBy(How = How.XPath, Using = ("//div[contains(@class, 'view-chooser-item') and not(@id='viewnew-view')]"))]
        public IList<IWebElement> viewChooserItems;

        public IList<IWebElement> getView()
        {
            return viewChooserItems;
        }

        [FindsBy(How = How.XPath, Using = ("//*[@id='table - view']"))]
        private IWebElement getTable;

        public IWebElement getTableView() { return getTable; }
    }
}
