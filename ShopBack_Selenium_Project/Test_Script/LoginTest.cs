using NUnit.Framework;
using OpenQA.Selenium;
using ShopBack_Selenium_Project.TestDataAccess;

namespace ShopBack_Selenium_Project.Test_Script.Test_Script
{
    public class LoginTest : BaseClass
    {

        IWebElement accountList => driver.FindElement(By.Id("nav-link-accountList"));
        IWebElement userName => driver.FindElement(By.Id("ap_email"));
        IWebElement continueBtn => driver.FindElement(By.Id("continue"));
        IWebElement password => driver.FindElement(By.Id("ap_password"));
        IWebElement submit => driver.FindElement(By.Id("signInSubmit"));
        IWebElement userSignIn => driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));


        [Test]
        public void Login()
        {
            var userData = ExcelDataAccess.GetTestData("Login");

            accountList.Click();
            userName.SendKeys(userData.Username);
            continueBtn.Click();
            password.SendKeys(userData.Password);
            submit.Click();

            if (!userSignIn.Text.Contains("Sign in"))
            {
                Assert.Pass("Sign in Successful");
            }
            else
                Assert.Fail("Sign in Unsuccessful");
        }
    }
}