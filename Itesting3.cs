using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Testing
{
    class Itesting3
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void test4()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Url = "http://localhost/Hotel/";
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[5]/div[1]/a"));
            Console.WriteLine(element.Displayed);
            element.Click();
            Assert.AreEqual("RESERVATION SUNRISE HOTEL", driver.Title);
        }

        [Test]
        public void test5()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Url = "http://localhost/Hotel/admin/reservation.php";
            IWebElement element = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div[2]/form/div[1]/select"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("Miss.");
            IWebElement element1 = select.SelectedOption;
            Assert.AreEqual(element1.Text, "Miss.");
        }

        [Test]
        public void test6()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Url = "http://localhost/Hotel/admin/reservation.php";
            IWebElement element = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div[2]/form/div[1]/select"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("Miss.");

            IWebElement element1 = driver.FindElement(By.Name("fname"));
            element1.SendKeys("Maliha");

            IWebElement element2 = driver.FindElement(By.Name("lname"));
            element2.SendKeys("Raida");

            IWebElement element3 = driver.FindElement(By.Name("email"));
            element3.SendKeys("malihanoushin@iut-dhaka.edu");

            IWebElement element4 = driver.FindElement(By.Name("country"));
            SelectElement select2 = new SelectElement(element4);
            select2.SelectByText("Bangladesh");

            IWebElement element5 = driver.FindElement(By.Name("phone"));
            element5.SendKeys("0159362784");

            IWebElement element6 = driver.FindElement(By.Name("troom"));
            SelectElement select3 = new SelectElement(element6);
            select3.SelectByValue("Superior Room");

            IWebElement element7 = driver.FindElement(By.Name("bed"));
            SelectElement select4 = new SelectElement(element7);
            select4.SelectByValue("Single");

            IWebElement element8 = driver.FindElement(By.Name("nroom"));
            SelectElement select5 = new SelectElement(element8);
            select5.SelectByValue("2");

            IWebElement element9 = driver.FindElement(By.Name("meal"));
            SelectElement select6 = new SelectElement(element9);
            select6.SelectByValue("Breakfast");

            IWebElement element10 = driver.FindElement(By.Name("cin"));
            element10.SendKeys("01-Mar-2020");

            IWebElement element11 = driver.FindElement(By.Name("cout"));
            element11.SendKeys("06-Mar-2020");

            IWebElement element12 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[2]/div/p[1]"));
            String code = element12.Text;
            String number=code.Remove(0, "Type Below this code".Length);

            IWebElement element13 = driver.FindElement(By.Name("code1"));
            element13.SendKeys(number);

            driver.FindElement(By.Name("submit")).Click();

        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
