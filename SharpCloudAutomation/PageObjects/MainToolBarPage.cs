using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SharpCloudAutomation.PageObjects
{
    public class MainToolBarPage
    {
        public MainToolBarPage(IWebDriver driver) => PageFactory.InitElements(driver, this);

        [FindsBy(How = How.XPath, Using = ("//div[@id='storyToolbar']"))]
        public IWebElement MtoolBar { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='undoDropdown']"))]
        public IWebElement UndoIcon { get; set; }        

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

        [FindsBy(How = How.XPath, Using = ("//div[@tooltip='Data Setup']"))]
        public IWebElement DataLabel { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Data setup Menu']"))]
        public IWebElement DataDropDownIcon{ get; set; }

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

        [FindsBy(How = How.XPath, Using = ("//div[@id='dropdownMenu' and @outsideifnot='dropdownMenu, viewSetupDropdown']//li"))]
        public IList<IWebElement> ViewSetupDropdown { get; set; }
   
        [FindsBy(How = How.XPath, Using = ("//div[@id='relationshipsToggle']"))]
        public IWebElement RelationshipIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@aria-label='Relationship modes menu']"))]
        public IWebElement RelationshipDropDownIcon { get; set; }

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
