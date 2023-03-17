using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SharpCloudAutomation.Utilities;
using System.Runtime.InteropServices;

namespace SharpCloudAutomation.PageObjects
{
    public class MainToolBarPage : Base
    {
        public MainToolBarPage(IWebDriver driver) => PageFactory.InitElements(driver, this);

        [FindsBy(How = How.XPath, Using = ("//div[@id='storyToolbar']"))]
        public IWebElement MtoolBar { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='undoDropdown']"))]
        public IWebElement UndoIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[contains(text(),'undo (CTRL+Z)')]"))]
        public IWebElement UndoSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[contains(text(),'redo (CTRL+Y)')]"))]
        public IWebElement RedoSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li[contains(text(),'Restore Story')]"))]
        public IWebElement RestoreSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li"))]
        public IList<IWebElement> UndoDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Undo menu' and @role='button']"))]
        public IWebElement UndoDropdownIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@tooltip='Story Setup']"))]
        public IWebElement StoryIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Story setup Menu']"))]
        public IWebElement StoryDropIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li"))]
        public IList<IWebElement> StoryDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Setup']"))]
        public IWebElement SetupSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Manage Presentations']"))]
        public IWebElement ManagePresentationSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Manage Forms']"))]
        public IWebElement ManageFormsSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li[text()='Download Story']"))]
        public IWebElement DownloadStorySubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@tooltip='Data Setup']"))]
        public IWebElement DataLabel { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Data setup Menu']"))]
        public IWebElement DataDropDownIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, dataSetupDropdown']//li[text()='Edit Data']"))]
        public IWebElement EditDataSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, dataSetupDropdown']//li[text()='Data Sources']"))]
        public IWebElement DataSourcesSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, dataSetupDropdown']//li"))]
        public IList<IWebElement> DataDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[text()='View']"))]
        public IWebElement ViewIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[text()='Reset View']"))]
        public IWebElement ResetIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[text()='Save View']"))]
        public IWebElement SaveLabel { get; set; }

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

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, viewSetupDropdown']//li"))]
        public IList<IWebElement> ViewSetupDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='relationshipsToggle']"))]
        public IWebElement RelationshipIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Relationship modes menu']"))]
        public IWebElement RelationshipDropDownIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li/label[contains(text(),'Show')]"))]
        public IWebElement ShowSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li/label[contains(text(),'Create/Edit')]"))]
        public IWebElement CreateSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li[contains(text(),'More options...')]"))]
        public IWebElement MoreOptionsSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, relationshipsToggle']//li"))]
        public IList<IWebElement> RelationshipDropDown { get; set; }


        [FindsBy(How = How.XPath, Using = ("//span[text()='Unlock']"))]
        public IWebElement UnlockIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//img[@alt='Search']"))]
        public IWebElement SearchIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//img[@alt='Fullscreen story button']"))]
        public IWebElement FullScreenIcon { get; set; }

    }
}
