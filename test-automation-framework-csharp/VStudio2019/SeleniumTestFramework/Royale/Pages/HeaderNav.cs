using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Royale.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav(IWebDriver driver)
        {
             Map = new HeaderNavMap(driver);
        }
        public void GoToCardsPage()
        {
            Map.CardsTabLink.Click();
        }
    }

    public class HeaderNavMap
    {
        private IWebDriver _driver;
        private WebDriverWait wait; 

        public HeaderNavMap(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(30));
        }
        //public IWebElement CardsTabLink => wait.Until(driver => driver.FindElement(By.LinkText("Cards")));
        public IWebElement CardsTabLink => _driver.FindElement(By.LinkText("Cards"));

    }
}
