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
            //Retrieve username and password
            var userData = ExcelDataAccess.GetTestData("Login");

            //Click on Account List
            accountList.Click();

            //Input user name and continue
            userName.SendKeys(userData.Username);
            continueBtn.Click();

            //Input password
            password.SendKeys(userData.Password);
            submit.Click();

            //Verify login is successful
            if (userSignIn.Text.Contains("Sign in"))
                Assert.Fail("Sign in Unsuccessful");
        }
    }
}