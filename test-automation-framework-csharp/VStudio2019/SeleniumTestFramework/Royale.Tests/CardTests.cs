using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;

namespace Tests
{
    public class CardTests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(30)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            driver.Manage().Window.Maximize();
            driver.Url = "https://statsroyale.com/";
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            var cardsPage = new CardsPage(driver);
            var iceSpirit = cardsPage.GoTo().GetCardByName("Ice Spirit");
            
            Assert.That(iceSpirit.Displayed);
        }

        [Test]
        public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
        {
            new CardsPage(driver).GoTo().GetCardByName("Ice Spirit").Click();
            var cardDetails = new CardDetailsPage(driver);

            var (category, arena) = cardDetails.GetCardCategory();
            var cardName = cardDetails.Map.CardName.Text;
            var cardRarity = cardDetails.Map.CardRarity.Text;

            //    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(50));
            //    wait.Until(driver => driver.FindElement(By.LinkText("Cards"))).Click();
            //    wait.Until(driver => driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"))).Click();

            //    IWebElement cardElement = wait.Until(driver => driver.FindElement(By.CssSelector("[class*='ui__headerMedium card__cardName']")));
            //    IWebElement cardDetails = wait.Until(driver => driver.FindElement(By.CssSelector("[class*='card__rarity']")));
            //    String cardRarity = wait.Until(driver => driver.FindElement(By.CssSelector("[class*='card__common']"))).Text;

            //    var cardCategories = cardDetails.Text.Split(", ");
            //    var cardName = cardElement.Text;
            //    var cardType = cardCategories[0];
            //    var cardArena = cardCategories[1];

                Assert.AreEqual("Ice Spirit", cardName);
                Assert.AreEqual("Troop", category);
                Assert.AreEqual("Arena 8", arena);
                Assert.AreEqual("Common", cardRarity);
        }
    }
}