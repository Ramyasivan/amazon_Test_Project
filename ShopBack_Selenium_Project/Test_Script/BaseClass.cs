using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ShopBack_Selenium_Project.Test_Script
{

    /// <summary>
    /// Base Class for Driver initialization
    /// </summary>

    public class BaseClass
    {
       public static IWebDriver driver { get; private set; }


        [OneTimeSetUp]
        public void InitBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        

       
        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
