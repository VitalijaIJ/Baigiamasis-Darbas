using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class SingInPage : BasePage
    {
        public SingInPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddressSingIn;
        }
        public SingInPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddressSingIn)
                Driver.Url = PageAddressSingIn;
            return this;
        }
        public const string PageAddressSingIn = "https://www.burton.com/us/en/sign-in?rurl=1";
        private const string TextToCheckEmail = "Please enter a valid email address.";
        private const string TextToCheckPaswEmail = "This field is required.";
        private IWebElement SingInPopUpButton => Driver.FindElement(By.CssSelector(".dialog-close"));
        private IWebElement SingInEmail => Driver.FindElement(By.Id("dwfrm_login_username"));
        private IWebElement SingInPasw => Driver.FindElement(By.Id("dwfrm_login_password"));
        private IWebElement SingInButton => Driver.FindElement(By.CssSelector("#dwfrm_login_login"));
        private IWebElement SingInErrorMessageEmail => Driver.FindElement(By.Id("dwfrm_login_username_error"));
        private IWebElement SingInErrorMessagePasw => Driver.FindElement(By.Id("dwfrm_login_password_error"));
        private IWebElement SingInButtonNotorrect => Driver.FindElement(By.CssSelector(".before-clicked"));
        public SingInPage SingInPopUpClose()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => SingInPopUpButton.Displayed);
            SingInPopUpButton.Click();
            return this;
        }      

        public SingInPage SingInEmailEnter(string text)
        {
            SingInEmail.Click();
            SingInEmail.Clear();            
            SingInEmail.SendKeys(text);
            return this;
        }
        
        public SingInPage SingInPaswEnter(string text)
        {
            SingInPasw.Click();
            SingInPasw.Clear();
            SingInPasw.SendKeys(text);
            return this;
        }
        public SingInPage SingInButtonClick(bool result)
        {
            if(!SingInButton.Selected)
            SingInButton.Click();
            return this;
        }
        
        public SingInPage CheckResulEmailtEmpty()
        {
            Assert.IsTrue(SingInErrorMessageEmail.Text.Equals(TextToCheckPaswEmail));
            return this;
        }
        public SingInPage CheckResulPaswEmpty()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => SingInErrorMessagePasw.Displayed);
            Assert.IsTrue(SingInErrorMessagePasw.Text.Equals(TextToCheckPaswEmail));
            return this;
        }
        public SingInPage CheckResultWrongEmail()
        {
            Assert.IsTrue(SingInErrorMessageEmail.Text.Equals(TextToCheckEmail));
            return this;
        }
       
        public SingInPage PressEnter()
        {
            Actions action = new Actions(Driver);
            action.KeyUp(Keys.Enter);
            action.Build().Perform();
            return this;
        }
    }
}
