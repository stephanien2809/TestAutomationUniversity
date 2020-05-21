using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;
        WebDriverWait wait;
        IWebElement cardElement;
        IWebElement iceSpirit;

    
        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../_drivers"));
            
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(30)).Until(
            d => ((IJavaScriptExecutor) d).ExecuteScript("return document.readyState").Equals("complete"));

        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

       [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            driver.Url = "https://statsroyale.com";
            //driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            driver.FindElement(By.LinkText("Cards")).Click();
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(3));
            //var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            iceSpirit = wait.Until(driver => driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")));
           
            Assert.That(iceSpirit.Displayed);
        } 

        [Test]
        public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
        {
            driver.Url = "https://statsroyale.com";
            driver.FindElement(By.LinkText("Cards")).Click();

             wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(3));
            //var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            iceSpirit = wait.Until(driver => driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")));
            iceSpirit.Click();
            //driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")).Click();

          /*   Option Wait for element to be visible on screen*/

            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(3));
            cardElement = wait.Until(driver => driver.FindElement(By.CssSelector("[class*='ui__headerMedium card__cardName']")));
            var cardName = cardElement.Text; 
            
            //var cardName = driver.FindElement(By.CssSelector("[class*='ui__headerMedium card__cardName']")).Text;
            var cardCategories = driver.FindElement(By.CssSelector("[class*='card__rarity']")).Text.Split(", ");
            var cardType = cardCategories[0];
            var cardArena = cardCategories[1];
            var cardRarity = driver.FindElement(By.CssSelector("[class*='card__common']")).Text;

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", cardType);
            Assert.AreEqual("Arena 8", cardArena);
            Assert.AreEqual("Common", cardRarity);
        }
    }
}