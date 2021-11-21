using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class BurtonChartPage : BasePage
    {
        public BurtonChartPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddressBurtonChart;
        }
        public BurtonChartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddressBurtonChart)
                Driver.Url = PageAddressBurtonChart;
            return this;
        }
        public const string PageAddressBurtonChart = "https://www.burton.com/us/en/cart";
        private IWebElement ItemTotal => Driver.FindElement(By.CssSelector(".item-total"));
        private IWebElement DropDownClick => Driver.FindElement(By.Id("dwfrm_cart_shipments_i0_items_i0_quantity"));
        private SelectElement ChangeQnt => new SelectElement(Driver.FindElement(By.Id("dwfrm_cart_shipments_i0_items_i0_quantity")));
        private IWebElement Result => Driver.FindElement(By.CssSelector("#dwfrm_cart > div > div > div.item-qty-summary > div.item-summary > p > span"));
        public BurtonChartPage ItemPrice()
        {
            Assert.IsTrue(ItemTotal.Text.Equals("$39.95"));
            return this;
        }
        public BurtonChartPage ChangeQntTo1o()
        {
            DropDownClick.Click();           
            return this;        
        }
       
        public BurtonChartPage CheckTotalSum(string text)
        {
            ChangeQnt.SelectByValue("10");
            return this;
        }
       /* public BurtonChartPage ChankeQntTo1oClick(string total) //$399.50
        {
            string correctSum = Result.Text.Replace(" ", "");
            string calculatetotal = correctSum;
            Assert.AreEqual(calculatetotal = total, "Wrong ammount");
            return this;
        }     */  
    }
}
