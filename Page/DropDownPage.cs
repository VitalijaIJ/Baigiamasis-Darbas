﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class DropDownPage : BasePage
    {
        public const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        public const string ResultText = "Day selected :- ";
        public const string ResultText2 = "First selected option is : ";
        public const string ResultText3 = "Options selected are : ";
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement SelectedValue => Driver.FindElement(By.CssSelector(".getall-selected"));
        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        public DropDownPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }       

        public DropDownPage SelectFromDropdownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public DropDownPage SelectFromDropdownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public DropDownPage SelectFromMultiDropDownByValue(string firstValue, string secondValue)
        {
            Actions action = new Actions(Driver);
            MultiDropDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }
        public DropDownPage SelectFromMultiDropDownByValueofThree(string firstValue, string secondValue, string thirdValue)
        {
            Actions action = new Actions(Driver);
            MultiDropDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            MultiDropDown.SelectByValue(thirdValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }
        public DropDownPage SelectFromMultiDropDownByValueofFour(string firstValue, string secondValue, string thirdValue, string fouthValue)
        {
            Actions action = new Actions(Driver);
            MultiDropDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            MultiDropDown.SelectByValue(thirdValue);
            action.KeyUp(Keys.Control);
            MultiDropDown.SelectByValue(fouthValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public DropDownPage ClickFirstSelectedButton()
        {
            FirstSelectedButton.Click();
            return this;
        }

        public DropDownPage ClickAllSelectedButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropDownPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(FirstSelectedButton);
            action.Build().Perform();
            return this;
        }

        public DropDownPage VerifyResult(string selectedDay)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public DropDownPage VerifyResultForFirstState(string state, string state2)
        {
            Assert.IsTrue(SelectedValue.Text.Equals(ResultText2 + state), $"Result is wrong, not {state}");
            return this;
        }
        public DropDownPage VerifyResultForTwotStates(string state, string state2)
        {
            Assert.IsTrue(SelectedValue.Text.Equals(ResultText3 + state + "," + state2), $"Result is wrong.");
            return this;
        }
        public DropDownPage VerifyResultForFirstStateofThree(string state, string state2, string state3)
        {
            Assert.IsTrue(SelectedValue.Text.Equals(ResultText2 + state), $"Result is wrong, not {state}");
            return this;
        }

        public DropDownPage VerifyResultForFourState(string state, string state2, string state3, string state4)
        {
            Assert.IsTrue(SelectedValue.Text.Equals(ResultText3 + state + "," + state2 + "," + state3 + "," + state4), $"Result is wrong.");
            return this;
        }
    }
}

