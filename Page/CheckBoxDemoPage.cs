using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    class CheckBoxDemoPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private const string TextToCheck = "Success - Check box is checked";
        private IWebElement _singleCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _Text => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> MultipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement _Button => Driver.FindElement(By.Id("check1"));

        public CheckBoxDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public CheckBoxDemoPage CheckSingleCheckbox()
        {
            if (!_singleCheckbox.Selected)
                _singleCheckbox.Click();
            return this;
        }

        public CheckBoxDemoPage CheckResult()
        {
            Assert.IsTrue(_Text.Text.Equals(TextToCheck));
            return this;
        }


        private void UncheckFirstBlockCheckbox()
        {
            if (_singleCheckbox.Selected)
                _singleCheckbox.Click();
        }

        public CheckBoxDemoPage CheckAllCheckboxes()
        {
            UncheckFirstBlockCheckbox();
            foreach (IWebElement element in MultipleCheckboxList)
            {
                if (!element.Selected)
                    element.Click();
            }
            return this;
        }

        public CheckBoxDemoPage CheckButtonValue(string value)
        {
            // GetWait().Until(ExpectedConditions.TextToBePresentInElement(_Button, "Uncheck All"));
            // DefaultWait.Until(ExpectedConditions.TextToBePresentInElementValue(_Button, "Uncheck All"));
            Assert.IsTrue(_Button.GetAttribute("value").Equals(value), "Second is wrong");
            return this;
        }

        public CheckBoxDemoPage ClickButton()
        {
            _Button.Click();
            return this;
        }

        public CheckBoxDemoPage VerifyThatAllCheckboxesAreUnchecked()
        {
            foreach (IWebElement element in MultipleCheckboxList)
            {
                Assert.False(element.Selected, "Checkbox is still checked");
                //Assert.IsTrue(!element.Selected, "Checkbox is still checked");
                //Assert.That(!element.Selected, "Checkbox is still checked");
            }
            return this;
        }
    }
}
