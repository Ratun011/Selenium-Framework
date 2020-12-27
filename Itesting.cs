using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Integration_Testing
{
    class Itesting
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void TestLogin()
        {
            driver.Url = "http://localhost/Hotel/admin/";
            IWebElement element = driver.FindElement(By.Name("user"));
            element.SendKeys("Admin");

            IWebElement password = driver.FindElement(By.Name("pass"));
            password.SendKeys("1234");
            driver.FindElement(By.Name("sub")).Click();

            String title=driver.Title;
            String et = "Administrator";
            if (title==et)
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.Write("Unsuccessful");
            }
        }
        [Test]
        public void TestMessage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "http://localhost/Hotel/admin/";
            IWebElement element = driver.FindElement(By.Name("user"));
            element.SendKeys("Admin");

            IWebElement password = driver.FindElement(By.Name("pass"));
            password.SendKeys("1234");
            driver.FindElement(By.Name("sub")).Click();
            IWebElement element1 = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/div/div[2]/div/div[2]/div[1]/h4/a/button"));
            element1.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            element1.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/div/div[2]/div/div[2]/div[2]/div/div/div/div[2]/a/button")).Click();

    
            String title = driver.Title;
            String et = "Details of Book key";
            if (title == et)
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.WriteLine("Unsuccesful");
            }

        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
