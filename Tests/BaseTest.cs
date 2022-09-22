using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SendEmailPOMTest.PageObjects;
using SendEmailPOMTest.ReadJsonData;

namespace SendEmailPOMTest.Tests
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;
        protected LoginPagePageObject loginPage;
        protected MainPagePageObject mainPage;
        protected EnvironmentConstants environmentConstants;
        private const string _url = "https://accounts.ukr.net/login";

        [OneTimeSetUp]
        public void DoBeforeAllTheTests()
        {
            _webDriver = new FirefoxDriver();
            loginPage = new LoginPagePageObject(_webDriver);
            mainPage = new MainPagePageObject(_webDriver);

            InitializeData();
        }

        [SetUp]
        public void DoBeforeEach()
        {
            _webDriver.Navigate().GoToUrl(_url);

            WaitUntill.ShouldLocate(_webDriver, _url);
        }


        public void InitializeData()
        {
            new EnvironmentConstantsProvider().Provide(out EnvironmentConstants environmentConsantsObject);
            environmentConstants = environmentConsantsObject;
        }

        [OneTimeTearDown]
        public void DoAfterAllTests()
        {
            _webDriver.Quit();
        }
    }
}
