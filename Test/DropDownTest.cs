﻿using AutomatinisTestavimas.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Test
{
    public class DropDownTest
    {
        private static DropDownPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropDownPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [Test]
        public void TestDropDown()
        {
            _page.SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }

        [Test]
        public void TestMultiDropDown()
        {
            _page.SelectFromMultiDropDownByValue("Ohio", "Florida")
                .ClickFirstSelectedButton();

        }
        [Test]
        public void Select2AndCheckResultForFirst()
        {
            _page.SelectFromMultiDropDownByValue("Florida", "Ohio")
                .ClickFirstSelectedButton()
                .VerifyResultForFirstState("Ohio", "Florida");
        }
        [Test]
        public void Select2AndCheckResultForAll()
        {
            _page.SelectFromMultiDropDownByValue("Ohio", "Florida")
                .ClickAllSelectedButton()
                .VerifyResultForTwotStates("Ohio", "Florida"); //Suspaude gerai bet atsakyma ismete Options selected are : Florida
        }
        [Test]
        public void Select3AndCheckResultForFirst()
        {
            _page.SelectFromMultiDropDownByValueofThree("Ohio", "Florida", "Texas")
                .ClickFirstSelectedButton()
                .VerifyResultForFirstStateofThree("Texas", "Florida", "Ohio");
        }
        [Test]
        public void Select4AndCheckResultForAll()
        {
            _page.SelectFromMultiDropDownByValueofFour("Ohio", "Florida", "Texas", "California")
                .ClickAllSelectedButton()
                .VerifyResultForFourState("Ohio", "Florida", "Texas", "California"); // Suspaude gerai, bet rezultate Options selected are : California
        }
    }
}
    

