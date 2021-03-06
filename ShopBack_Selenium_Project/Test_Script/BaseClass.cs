using System;
using System.Configuration;
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
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
        }

       
        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
