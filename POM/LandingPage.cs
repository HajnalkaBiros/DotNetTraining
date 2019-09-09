using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Interactions;

namespace DotNetTraining.POM
{
    class LandingPage
    {
        IWebDriver driver;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [Test] // search for dress in search bar
        public void CheckSearchWorks()
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys("dress");
            driver.FindElement(By.Name("submit_search")).Click();
            Assert.IsNotNull(driver.FindElement(By.ClassName("page-heading")), "it worked!!");
            driver.Close();
        }

        [Test]
        public void CheckTimeoutworks() // check item with wait
        {
            
            
            Actions builder = new Actions(driver);
            var element = driver.FindElement(By.ClassName("ajax_block_product"));
            builder.MoveToElement(element).Build().Perform();
            driver.FindElement(By.ClassName("quick-view")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsNotNull(driver.FindElement(By.TagName("iframe")), "found the item");

            driver.Close();
        }
    }
}
