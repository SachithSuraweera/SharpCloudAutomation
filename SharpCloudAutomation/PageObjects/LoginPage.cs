using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SharpCloudAutomation.PageObjects
{
    public class LoginPage
    {
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='Uzername']"))]
        public IWebElement UsernameText { get; set; }

        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='Commence Hacking']"))]
        public IWebElement PasswordText { get; set; }

        [FindsBy(How = How.XPath, Using = ("//button[text()='GO!']"))]
        public IWebElement GoButton { get; set; }

        public void ValidLogin(string user, string password)
        {
            UsernameText.SendKeys(user);
            PasswordText.SendKeys(password);
            GoButton.Click();
        }
    }
}
