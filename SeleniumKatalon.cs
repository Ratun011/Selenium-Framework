using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Testing
{
    class SeleniumKatalon
    {
        [TestFixture]
        public class Test1
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
                driver = new ChromeDriver();
                baseURL = "https://www.google.com/";
                verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [Test]
            public void The1Test()
            {
                driver.Navigate().GoToUrl("http://localhost/Hotel/admin/index.php");
                driver.FindElement(By.Name("user")).Click();
                driver.FindElement(By.Name("user")).Clear();
                driver.FindElement(By.Name("user")).SendKeys("Admin");
                driver.FindElement(By.Name("pass")).Click();
                driver.FindElement(By.Name("pass")).Clear();
                driver.FindElement(By.Name("pass")).SendKeys("1234");
                driver.FindElement(By.Name("sub")).Click();
                driver.FindElement(By.LinkText("News Letters")).Click();
                driver.FindElement(By.LinkText("Payment")).Click();
                driver.FindElement(By.LinkText("Profit")).Click();
                driver.FindElement(By.XPath("(//a[contains(text(),'Logout')])[2]")).Click();
            }
            private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
    }
}
