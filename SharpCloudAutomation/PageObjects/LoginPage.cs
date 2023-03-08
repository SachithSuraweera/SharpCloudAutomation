using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SharpCloudAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='Uzername']"))]
        private IWebElement username;

        public IWebElement getUserName()
        {
            return username;
        }
        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='Commence Hacking']"))]
        private IWebElement password;

        public IWebElement getPassword() { return password; }

        [FindsBy(How = How.XPath, Using = ("//button[text()='GO!']"))]
        private IWebElement goBtn;

        public IWebElement getGoBtn() { return goBtn;}

        public void validLogin(string user, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Uzername']")));
            getUserName().SendKeys(user);
            getPassword().SendKeys(password);
            getGoBtn().Click();
        }

    }
}
