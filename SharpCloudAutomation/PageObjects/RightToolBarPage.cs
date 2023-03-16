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

        [FindsBy(How = How.XPath, Using = ("//button[.=' Open text editor ']"))]
        public IWebElement SideViewGuideButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='feed-button']//div[@class='flexbox-center flexbox-direction-column']"))]
        public IWebElement CommentsButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='story-feed-comment-box']"))]
        public IWebElement AddCommentsTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[@id='story-feed-comment-button']"))]
        public IWebElement AddCommentsTextButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//p[@class='info-text']"))]
        public IWebElement CommentedText { get; set; }

        [FindsBy(How = How.CssSelector, Using = (".feed-item.ng-star-inserted"))]
        public IWebElement commentTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//p[@aria-label='Delete comment']"))]
        public IWebElement DeleteComment { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='editItemPanelToggle']"))]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='editAnnotatonPanelToggle']"))]
        public IWebElement WidgetsButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='story-forms-button']"))]
        public IWebElement FormsButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='activity-feed-button']"))]
        public IWebElement ActivityButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//textarea[@id='Name']"))]
        public IWebElement FormsNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//textarea[@id='Description']"))]
        public IWebElement FormsDescriptionTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[contains(text(),'Submit')]"))]
        public IWebElement FormsSubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@title='Test Automation']"))]
        public IWebElement CreatedForm { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[@title='Delete item']//span[@class='ui-icon'][normalize-space()='remove_delete']"))]
        public IWebElement FormsDeleteButton { get; set; }
    }
}
