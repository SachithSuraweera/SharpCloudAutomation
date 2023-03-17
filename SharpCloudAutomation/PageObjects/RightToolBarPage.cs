using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


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

        [FindsBy(How = How.CssSelector, Using = ("#side-view-header-content-type-text"))]

        public IWebElement SideViewExpandText { get; set; }

        [FindsBy(How = How.CssSelector, Using = ("#side-view-button"))]
        public IWebElement SideViewButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[not(@disabled) and normalize-space()='Open text editor']"))]
        public IWebElement SideViewGuideButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[not(@disabled) and normalize-space()='Manage Forms']"))]
        public IWebElement SideViewManageFormsButton { get; set; }

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

        [FindsBy(How = How.XPath, Using = ("//textarea[@id='Name']"))]
        public IWebElement FormsNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//textarea[@id='Description']"))]
        public IWebElement FormsDescriptionTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[contains(text(),'Submit')]"))]
        public IWebElement FormsSubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@tabindex='1']"))]
        public IWebElement CreatedForm { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[@title='Delete item']//span[@class='ui-icon'][normalize-space()='remove_delete']"))]
        public IWebElement FormsDeleteButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ("div[id='user-info-14-Sign-out'] span[class='menu-item-text']"))]
        public IWebElement UserLogout { get; set; }

        [FindsBy(How = How.XPath, Using = ("//html"))]
        public IWebElement SideViewGuideExpandArea { get; set; }

        [FindsBy(How = How.XPath, Using = ("//body//h1"))]
        public IWebElement SideViewGuideExpandAddTextArea { get; set; }

        [FindsBy(How = How.XPath, Using = ("//iframe[@title='Editor, guide-editor']"))]
        public IWebElement IFrame { get; set; }

        [FindsBy(How = How.XPath, Using = ("//img[@aria-label='Delete the panel’s content. You can then leave it empty or choose new content.']"))]
        public IWebElement SideViewGuideExpandDeleteButton { get; set;}

        [FindsBy(How = How.XPath, Using = ("//img[@aria-label='Close side view']"))]
        public IWebElement SideViewCloseViewButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//body"))]
        public IWebElement SideViewGuideExpandReadText { get; set; }

        [FindsBy(How = How.XPath, Using = ("//select[@class='textInput ng-untouched ng-pristine ng-valid']"))]
        public IWebElement SideViewFormDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = ("//img[@aria-label='Delete the panel’s content. You can then leave it empty or choose new content.']"))]
        public IWebElement SideViewFormDeleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[@id='new-item-button']"))]
        public IWebElement EditCreateNewItemButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//textarea[@id='edit-item-panel-nameProperty']"))]
        public IWebElement EditItemNameTexBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//textarea[@id='edit-item-panel-descriptionProperty']"))]
        public IWebElement EditItemDescriptionTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[normalize-space()='Open']"))]
        public IWebElement EditItemOpenButtton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[normalize-space()='Duplicate']"))]
        public IWebElement EditITemDuplicateButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[normalize-space()='Delete']"))]
        public IWebElement EditItemDeleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@tabindex='1']"))]
        public IWebElement CreatedEditItem { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[normalize-space()='Un-publish']"))]
        public IWebElement EditItemUnPublishButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[normalize-space()='New Widget']"))]
        public IWebElement WidgetNewWidgetButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//img[@src='assets/images/arrow-left.png']"))]
        public IWebElement WidgetsAdvancedOptionsArrow { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[normalize-space()='Link to a view']"))]
        public IWebElement WidgetsLinkToViewButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@aria-label='View #2']"))]
        public IWebElement WidgetsSelectViewPopUpView2 { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[normalize-space()='OK']"))]
        public IWebElement WidgetsSelectViewPopupOKButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@class='flexbox flexbox-direction-column annotationInner']"))]
        public IWebElement WidgetsCreatedItem { get; set; }

        [FindsBy(How = How.XPath, Using = ("//view-chooser-item[@aria-label='Sample Wall view']"))]
        public IWebElement View1 { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[@id='delete-item-button']"))]
        public IWebElement WidgetsDeleteButton { get; set; }

        public void SignOut()
        {
            bool isUserProfileVisible = true;
            try
            {
                isUserProfileVisible = UserProfile.Displayed;
            }
            catch (NoSuchElementException e)
            {
                isUserProfileVisible = false;
            }
            if (isUserProfileVisible == true)
            {
                UserProfile.Click();
                UserLogout.Click();
            }
        }

    }
}
