using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        public BasePage(IWebDriver webDeiver)
        {
            Driver = webDeiver;
        }
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
