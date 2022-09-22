using OpenQA.Selenium;
using SendEmailPOMTest.PageObjects;
using SendEmailPOMTest.ReadJsonData;


namespace SendEmailPOMTest.Tests
{
    public class Tests : BaseTest
    {


        [Test]
        public void AuthorizationTest()
        {
            loginPage
                .EmailInput(environmentConstants.Email)
                .PasswordInput(environmentConstants.Password)
                .ClickCheckboxRememberMe()
                .SignIn();

            mainPage.VerifyUserName(environmentConstants.Email, out bool verify);
            Assert.That(verify, Is.True);
        }

        [Test]
        public void SendEmailTest()
        { 
            mainPage
                .CreateNewEmail()
                .SendToEmailInput(environmentConstants.EmailReciever)
                .SubjectInput(environmentConstants.subject)
                .MessageBodyInput(environmentConstants.MessageBody);

            mainPage.SendEmail(environmentConstants.EmailReciever,
                environmentConstants.subject,
                environmentConstants.MessageBody);

            Assert.IsTrue(mainPage.HasSentEmailMessage());
        }
    }
}