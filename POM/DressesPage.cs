using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace DotNetTraining.POM
{
    class DressesPage
    {
        IWebDriver driver;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=search&orderby=position&orderway=desc&search_query=dress&submit_search=");
        }

        [Test]
        public void VerifyDressesList()
        {
            var products = driver.FindElements(By.ClassName("ajax_block_product"));
            var productsCount = products.Count.ToString();

            var numberOfResults = driver.FindElement(By.ClassName("heading-counter"));
            var numberOfResultsText = numberOfResults.Text;
          
             Assert.IsTrue(numberOfResultsText.Contains(productsCount), "search number equals to number of items");
            
        }
    }
}
