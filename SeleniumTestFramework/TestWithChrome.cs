using System;
using System.Collections.Generic;
using System.IO;
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

            var projectPath = AppDomain.CurrentDomain.BaseDirectory;
            var chromeDriverPath = Path.GetDirectoryName(projectPath + "..//..//Automation//chromedriver//");

            driver = new ChromeDriver(chromeDriverPath);
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
