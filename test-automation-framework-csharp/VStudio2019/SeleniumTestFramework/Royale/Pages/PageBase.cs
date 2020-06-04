using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public abstract class PageBase
    {
        public readonly HeaderNav HeaderNav;

        public PageBase(IWebDriver driver)
        {
             HeaderNav = new HeaderNav(driver);
        }
    }
}
