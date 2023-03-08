using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.PageObjects
{
    public class MainToolBarPage
    {
        private IWebDriver driver;
        public MainToolBarPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='storyToolbar']"))]
        private IWebElement mtoolBar;
        public IWebElement getMtoolBar()
        {
            return mtoolBar;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='undoDropdown']"))]
        private IWebElement undoIcon;
        public IWebElement getUndoIcon()
        {
            return undoIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, undoDropdown']//li"))]
        public IList<IWebElement> undoDropdown;
        public IList<IWebElement> getUndoDropDown()
        {
            return undoDropdown;
        }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Undo menu' and @role='button']"))]
        public IWebElement undoDropdownIcon;
        public IWebElement getUndoDropDownIcon()
        {
            return undoDropdownIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@tooltip='Story Setup']"))]
        private IWebElement storyIcon;
        public IWebElement getStoryIcon()
        {
            return storyIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, storySetupDropdown']//li"))]
        public IList<IWebElement> storyDropdown;
        public IList<IWebElement> getStoryDropDown()
        {
            return storyDropdown;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@tooltip='Data Setup']"))]
        private IWebElement dataIcon;
        public IWebElement DataIcon()
        {
            return dataIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, dataSetupDropdown']//li"))]
        private IWebElement dataDropdown;
        public IWebElement DataDropdown()
        {
            return dataDropdown;
        }

        [FindsBy(How = How.XPath, Using = ("//span[text()='View']"))]
        private IWebElement viewIcon;
        public IWebElement ViewIcon()
        {
            return viewIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//button[text()='Reset View']"))]
        private IWebElement resetIcon;
        public IWebElement ResetIcon()
        {
            return resetIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//button[text()='Save View']"))]
        private IWebElement saveIcon;
        public IWebElement SaveIcon()
        {
            return saveIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='viewSetupDropdown']//li"))]
        private IWebElement viewSetupDropdown;
        public IWebElement ViewSetupDropdown()
        {
            return viewSetupDropdown;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='relationshipsToggle']"))]
        private IWebElement relationshipIcon;
        public IWebElement RelationshipIcon()
        {
            return relationshipIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//div[@id='relationshipsToggle']//li"))]
        private IWebElement relationshipDropDown;
        public IWebElement RelationshipDropDown()
        {
            return relationshipDropDown;
        }

        [FindsBy(How = How.XPath, Using = ("//span[text()='Unlock']"))]
        private IWebElement unlockIcon;
        public IWebElement UnlockIcon()
        {
            return unlockIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//img[@alt='Search']"))]
        private IWebElement searchIcon;
        public IWebElement SearchIcon()
        {
            return searchIcon;
        }

        [FindsBy(How = How.XPath, Using = ("//img[@alt='Fullscreen story button']"))]
        private IWebElement fullScreenIcon;
        public IWebElement FullScreenIcon()
        {
            return fullScreenIcon;
        }
    }
}
