using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SharpCloudAutomation.Utilities;

namespace SharpCloudAutomation.PageObjects
{
    public class MainToolBarPage : Base
    {
        public MainToolBarPage(IWebDriver driver) => PageFactory.InitElements(driver, this);

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[contains(text(),'undo (CTRL+Z)')]"))]
        public IWebElement UndoSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[contains(text(),'redo (CTRL+Y)')]"))]
        public IWebElement RedoSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Undo menu' and @role='button']"))]
        public IWebElement UndoDropdownIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Story setup Menu']"))]
        public IWebElement StoryDropIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Setup']"))]
        public IWebElement SetupSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Manage Presentations']"))]
        public IWebElement ManagePresentationSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Manage Forms']"))]
        public IWebElement ManageFormsSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Download Story']"))]
        public IWebElement DownloadStorySubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Data setup Menu']"))]
        public IWebElement DataDropDownIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, dataSetupDropdown']//li[text()='Edit Data']"))]
        public IWebElement EditDataSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, dataSetupDropdown']//li[text()='Data Sources']"))]
        public IWebElement DataSourcesSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='View setup menu']"))]
        public IWebElement SaveDropDownIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, viewSetupDropdown']//li[contains(text(),'Setup')]"))]
        public IWebElement ViewSetUpSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, viewSetupDropdown']//li[contains(text(),'Filters')]"))]
        public IWebElement FiltersSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, viewSetupDropdown']//li[contains(text(),'Add new')]"))]
        public IWebElement AddNewSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, viewSetupDropdown']//li[contains(text(),'Save as new')]"))]
        public IWebElement SaveAsNewSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Relationship modes menu']"))]
        public IWebElement RelationshipDropDownIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li/label[contains(text(),'Show')]"))]
        public IWebElement ShowSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li[contains(text(),'More options...')]"))]
        public IWebElement MoreOptionsSubMenu { get; set; }
    }
}
