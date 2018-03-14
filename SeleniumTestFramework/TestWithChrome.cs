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
using OpenQA.Selenium.Support.UI;

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
            driver.Url = "http://cgross.github.io/angular-busy/demo/";
            //Validating that correct page loads 
            var title = driver.Title;
            Assert.AreEqual("Angular Busy Demo", title);
            
            //7.1 - Validating Acceptance Criteria 7 -> Step 1
            //click Demo Button
            IWebElement demoButton = driver.FindElement(By.CssSelector("button.btn"));
            demoButton.Click();
            //assert Please Wait displays
            IWebElement waitModal = driver.FindElement(By.CssSelector("div.cg-busy-animation"));
            WebDriverWait driverWait = new WebDriverWait(driver, new TimeSpan(0,0,1));
            driverWait.Until(d => waitModal.Displayed);
            string modalText = driver.FindElement(By.CssSelector("div.cg-busy-default-text")).Text;
            Assert.AreEqual("Please Wait...", modalText);

            //7.2 - Validating Acceptance Criteria 7 -> Step 2
            IWebElement inputMessage = driver.FindElement(By.CssSelector("input#message"));
            inputMessage.Clear();
            inputMessage.SendKeys("Waiting");
            demoButton.Click();
            driverWait.Until(d => waitModal.Displayed);
            Assert.AreEqual("Waiting", driver.FindElement(By.CssSelector("div.cg-busy-default-text")).Text);

            //7.3 - Validating Acceptance Criteria 7 -> Step 3
            IWebElement inputDuration = driver.FindElement(By.CssSelector("input#durationInput"));
            inputDuration.Clear();
            inputDuration.SendKeys("1000");
            demoButton.Click();
            driverWait.Until(d => waitModal.Displayed);
            Assert.AreEqual("Waiting", driver.FindElement(By.CssSelector("div.cg-busy-default-text")).Text);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
