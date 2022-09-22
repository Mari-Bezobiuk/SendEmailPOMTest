using OpenQA.Selenium;
using SendEmailPOMTest.ReadJsonData;

namespace SendEmailPOMTest.PageObjects
{
    public class MainPagePageObject
    {
        private readonly IWebDriver _webDriver;

        //For verifying user name
        private readonly By _userLogin = By.CssSelector(".login-button__user");

        //For sending email
        private readonly By _newEmailButton = By.CssSelector("#content > aside > button");
        private readonly By _sendToEmailInput = By.XPath("//input[@name=\"toFieldInput\"]");
        private readonly By _subjectInput = By.XPath("//input[@name=\"subject\"]");
        private readonly By _messageInput = By.CssSelector("#mce_0_ifr");

        private readonly By _sendButton = By.XPath("//button[@class=\"button primary send\"]");
        private readonly By _hasSentEmailMessage = By.XPath("//*[@class=\"sendmsg__ads-sending\"]");

        public MainPagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetUserLogin
        {
            get 
            {
                WaitUntill.WaitSomeInterval(1);
                return _webDriver.FindElement(_userLogin).Text; 
            }
        }

        public MainPagePageObject VerifyUserName(string email, out bool verifyUserName)
        {
            WaitUntill.WaitElement(_webDriver, _newEmailButton);
            var actualUserLogin = GetUserLogin;
            var expectedUserLogin = email;
            verifyUserName = actualUserLogin.Equals(expectedUserLogin);

            return new MainPagePageObject(_webDriver);
        }

        public MainPagePageObject CreateNewEmail()
        {
            WaitUntill.WaitElement(_webDriver, _newEmailButton);
            _webDriver.FindElement(_newEmailButton).Click();
            return  new MainPagePageObject(_webDriver);
        }

        
        public MainPagePageObject SendToEmailInput(string emailReciever)
        {
            _webDriver.FindElement(_sendToEmailInput).SendKeys(emailReciever);
            return new MainPagePageObject(_webDriver);
        }

        public MainPagePageObject SubjectInput(string subject)
        {
            _webDriver.FindElement(_subjectInput).SendKeys(subject);
            return new MainPagePageObject(_webDriver);
        }

        public MainPagePageObject MessageBodyInput(string message)
        {
            _webDriver.FindElement(_messageInput).Click();
            _webDriver.FindElement(_messageInput).SendKeys(message);
            return new MainPagePageObject(_webDriver);
        }

        public MainPagePageObject SendEmail (string emailTo, string subject, string messageBody)
        {
            _webDriver.FindElement(_sendButton).Click();
            return new MainPagePageObject(_webDriver);
        }

        public bool HasSentEmailMessage() 
        {
            WaitUntill.WaitElement(_webDriver, _hasSentEmailMessage);
            return _webDriver.FindElement(_hasSentEmailMessage).Displayed;
        }
    }
}
