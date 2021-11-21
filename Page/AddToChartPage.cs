using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class AddToChartPage : BasePage
    {
        public AddToChartPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddressAddToChart;
        }
        public AddToChartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddressAddToChart)
                Driver.Url = PageAddressAddToChart;
            return this;
        }
        public const string PageAddressAddToChart = "https://www.burton.com/us/en/c/travel-accessories";
        private IReadOnlyCollection<IWebElement> ItemAddPrice => Driver.FindElements(By.CssSelector(".standard-price"));
        private IWebElement FirstItemAddLink => Driver.FindElement(By.CssSelector(".product-tile-wrap:nth-child(1) .product-image"));
        private IWebElement FirstItemAddPrice => Driver.FindElement(By.CssSelector(".standard-price"));
        private IWebElement AddToChartButton => Driver.FindElement(By.CssSelector("add-to-cart-btn"));
        private IWebElement SecondItemAddLink => Driver.FindElement(By.LinkText("https://www.burton.com/static/product/W22/11022108401_1.png?impolicy=bglt&imwidth=246"));
        private IWebElement SecondItemAddPrice => Driver.FindElement(By.CssSelector(".standard-price"));
        private IWebElement ThirdItemAddLink => Driver.FindElement(By.LinkText("https://www.burton.com/static/product/W22/20764105402_1.png?impolicy=bglt&imwidth=246"));
        private IWebElement ThirdItemAddPrice => Driver.FindElement(By.CssSelector(".standard-pricel"));
        private IWebElement FourthItemAddLink => Driver.FindElement(By.LinkText("https://www.burton.com/static/product/W22/226191_LML.png?impolicy=bglt&imwidth=246"));
        private IWebElement FourthItemAddPrice => Driver.FindElement(By.CssSelector(".standard-price"));
        private IWebElement FifthItemAddLink => Driver.FindElement(By.LinkText("https://www.burton.com/static/product/W22/21348103960_1.png?impolicy=bglt&imwidth=246"));
        private IWebElement FifthItemAddPrice => Driver.FindElement(By.CssSelector(".standard-price"));
        private IWebElement GoBackButton => Driver.FindElement(By.LinkText("https://www.burton.com/us/en/c/travel-accessories"));
        private IWebElement CheckOutNow => Driver.FindElement(By.CssSelector(".btn js-goes-to-checkout"));
        private IWebElement ContinueShopping => Driver.FindElement(By.CssSelector(".btn-secondary"));

        
        public AddToChartPage CheckItemAddPrice()
        {
            FirstItemAddLink.Click();            
            string firstprice = FirstItemAddPrice.Text;            
            return this;
        }

        public AddToChartPage TakeFirstPrice()
        {
            FirstItemAddLink.Click();
            string firstprice = FirstItemAddPrice.Text;
            return this;
        }
        public AddToChartPage TakeSecondPrice()
        {
            SecondItemAddLink.Click();
            string secondprice = SecondItemAddPrice.Text;
            return this;
        }
        public AddToChartPage TakeThirdPrice()
        {
            ThirdItemAddLink.Click();
            string thirdprice = ThirdItemAddPrice.Text;
            return this;
        }
        public AddToChartPage TakeFourthPrice()
        {
            FourthItemAddLink.Click();
            string fourthprice = FourthItemAddPrice.Text;
            return this;
        }
        public AddToChartPage TakeFifthPrice()
        {
            FifthItemAddLink.Click();
            string pricetocheck1 = "439.95";
            string fifthprice = FifthItemAddPrice.Text;
            Assert.IsTrue(fifthprice.Equals(pricetocheck1));
            return this;
        }
        ///////////////////////////////////////
        public AddToChartPage AddtoBasketFirstItem()
        {
            FirstItemAddLink.Click();
            AddToChartButton.Click();
            ContinueShopping.Click();
            GoBackButton.Click();
            return this;
        }
    public AddToChartPage AddtoBasketSecondItem()
    {
            SecondItemAddLink.Click();
            AddToChartButton.Click();
            ContinueShopping.Click();
            GoBackButton.Click();
            return this;
    }
    public AddToChartPage AddtoBasketThirdItem()
    {
            ThirdItemAddLink.Click();
            AddToChartButton.Click();
            ContinueShopping.Click();
            GoBackButton.Click();
            return this;
    }
    public AddToChartPage AddtoBasketFourthItem()
    {
            FourthItemAddLink.Click();
            AddToChartButton.Click();
            ContinueShopping.Click();
            GoBackButton.Click();
            return this;
    }
    public AddToChartPage AddtoBasketFifthItem()
    {
            FifthItemAddLink.Click();
            AddToChartButton.Click();
            CheckOutNow.Click();
            return this;
    }
    /*FirstBootsAddLink.Click();
    IReadOnlyCollection<IWebElement> multipleCheckBoxList = _driver.FindElements(By.CssSelector(".cb1-element"));
    foreach (IWebElement element in multipleCheckBoxList)
    {
        element.Click();
    }
    Thread.Sleep(5000);
    IWebElement button = _driver.FindElement(By.Id("check1"));
    button.GetProperty("value");
    Assert.IsTrue(button.GetProperty("value").Equals("Uncheck All"));*/

}
}



   
