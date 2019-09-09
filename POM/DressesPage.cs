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

        [Test] // test with if
        public void VerifyDressesList()
        {
            var products = driver.FindElements(By.ClassName("ajax_block_product"));
            var productsCount = products.Count.ToString();

            var numberOfResults = driver.FindElement(By.ClassName("heading-counter"));
            var numberOfResultsText = numberOfResults.Text;

             Assert.IsTrue(numberOfResultsText.Contains(productsCount), "search number equals to number of items");
            
        }

        [Test]
        public void VerifyAllDressesHaveImage() //test with  foreach
        {
            var products = driver.FindElements(By.ClassName("ajax_block_product"));

            foreach(var product in products)
            {
                Assert.IsNotNull(product.FindElement(By.TagName("img")));
            }
        }

        [Test]
        public void VerifySortWorks() //test dropdown 
        {
            driver.FindElement(By.Id("selectProductSort")).Click();
            driver.FindElement(By.CssSelector("option[value='price:asc']")).Click();
            var firstProduct = driver.FindElements(By.ClassName("ajax_block_product"))[0];
            driver.FindElement(By.CssSelector("option[value='price:desc']")).Click();
            var secondProduct = driver.FindElements(By.ClassName("ajax_block_product"))[0];

            Assert.AreNotEqual(firstProduct, secondProduct);
        }
    }
}
