using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.PageObjects
{
    public class RightToolBarPage
    {
        public RightToolBarPage(IWebDriver driver) => PageFactory.InitElements(driver, this);

        [FindsBy(How = How.XPath, Using = ("//div[@id='storyToolbar-right']"))]
        public IWebElement RToolBar { get; set; }

        [FindsBy(How = How.CssSelector, Using =("#header-user-image"))]
        public IWebElement UserProfile { get; set; }

        [FindsBy(How = How.XPath, Using =("//img[@src='assets/images/sidePanel/SidePanel.png']"))]
        public IWebElement SideViewVisibility { get; set; }

        [FindsBy(How = How.XPath, Using = ("//img[@src='assets/images/sidePanel/block.png']"))]
                                            
        public IWebElement SideviewVisibilityDisabled { get; set; }

        [FindsBy(How = How.CssSelector, Using = ("#side-view-header-content-type-text"))]

        public IWebElement SideViewExpandText { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[.='SIDE VIEW']"))]
        public IWebElement SideViewExpandTextEditorButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ("#side-view-button"))]
        public IWebElement SideViewButton { get; set; }
    }
}
