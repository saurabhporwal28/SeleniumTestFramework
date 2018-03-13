using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace SeleniumTestFramework
{
    class TestWithChrome
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("..\\Automation\\chromedriver");
        }

        [Test]
        public void TestRun()
        {
            driver.Url = "http://www.google.co.in";
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
