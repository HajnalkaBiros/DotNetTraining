using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace DotNetTraining.POM
{
    class LandingPage
    {
        IWebDriver driver;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
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
    }
}
