using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class AddToChart1Page : BasePage
    {
        public AddToChart1Page(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public AddToChart1Page NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public const string PageAddress = "https://www.burton.com/us/en/p/burton-low-maintenance-kit-5l-accessory-bag/W22-153011.html";
        private IWebElement AddToChartButton => Driver.FindElement(By.CssSelector(".add-to-cart-btn-wrap:nth-child(1) > .add-to-cart-btn"));        
        private IWebElement GoBackButton => Driver.FindElement(By.LinkText("Travel Accessories"));
        private IWebElement CheckOutNow => Driver.FindElement(By.CssSelector(".btn js-goes-to-checkout"));
        private IWebElement ContinueShopping => Driver.FindElement(By.CssSelector(".btn-secondary"));
        private IWebElement Chart2Item => Driver.FindElement(By.CssSelector(".cart-link:nth-child(5)"));


        public AddToChart1Page AddtoBasketFirstItem()
        {
            AddToChartButton.Click();
            ContinueShopping.Click();
            GoBackButton.Click();
            
            return this;
        }
        public AddToChart1Page SelectChart()
        {
            Thread.Sleep(5000);
            if (!Chart2Item.Selected)
                Chart2Item.Click();

            return this;
        }

    }
}
