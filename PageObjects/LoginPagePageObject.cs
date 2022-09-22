using OpenQA.Selenium;
using SendEmailPOMTest.Tests;
using SendEmailPOMTest.ReadJsonData;

namespace SendEmailPOMTest.PageObjects
{
    public class LoginPagePageObject
    {
        private readonly IWebDriver _webDriver;

        private readonly By _emailInput = By.CssSelector("[name=\"login\"]");
        private readonly By _passwordInput = By.XPath("//input[@name=\"password\"]");
        private readonly By _checkboxRemember = By.XPath("//*[@type=\"checkbox\"]");
        private readonly By _submitButton = By.CssSelector("[type=\"submit\"]");
        
        public LoginPagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public LoginPagePageObject EmailInput(string email)
        {
            WaitUntill.WaitElement(_webDriver, _emailInput);
            _webDriver.FindElement(_emailInput).SendKeys(email);
            return new LoginPagePageObject(_webDriver);
        }

        public LoginPagePageObject PasswordInput(string password)
        {
            _webDriver.FindElement(_passwordInput).SendKeys(password);
            return new LoginPagePageObject(_webDriver);
        }

        public LoginPagePageObject ClickCheckboxRememberMe()
        {
            _webDriver.FindElement(_checkboxRemember).Click();
            return new LoginPagePageObject(_webDriver);
        }

        public MainPagePageObject SignIn()
        {
            _webDriver.FindElement(_submitButton).Click();
            return new MainPagePageObject(_webDriver);
        }
    }
}
