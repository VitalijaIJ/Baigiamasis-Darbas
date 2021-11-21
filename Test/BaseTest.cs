using AutomatinisTestavimas.Drivers;
using AutomatinisTestavimas.Page;
using AutomatinisTestavimas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static CreateAccountPage _createAccountPage;
        public static SingInPage _singinPage;
        public static BurtonChartPage _burtonChartPage;
        public static AddToChart1Page _addToChart1Page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDrivers.GetChromeDriver();
            _createAccountPage = new CreateAccountPage(driver);
            _singinPage = new SingInPage(driver);
            _burtonChartPage = new BurtonChartPage(driver);
            _addToChart1Page = new AddToChart1Page(driver);
        }
        [TearDown]
        public static void TakeScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshots.MyScreenshot(driver);
        }
       

        [OneTimeTearDown]
        public static void TearDown()
        {
            //driver.Quit();
        }
    }
}
