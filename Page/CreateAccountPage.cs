using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class CreateAccountPage : BasePage
    {
        public CreateAccountPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public CreateAccountPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public const string PageAddress = "https://www.burton.com/lt/en/create-account";
        private IWebElement CreateFirstName => Driver.FindElement(By.Id("dwfrm_profile_customer_firstname"));
        private IWebElement CreateLastName => Driver.FindElement(By.Id("dwfrm_profile_customer_lastname"));
        private IWebElement CreateEmail => Driver.FindElement(By.Id("dwfrm_profile_customer_email"));
        //private IWebElement CreateEmailMessage => Driver.FindElement(By.Id("dwfrm_profile_customer_email_error"));
        private IWebElement CreateDateOfBirthddmmyyyy => Driver.FindElement(By.Id("dwfrm_profile_customer_birthday"));
        //private IWebElement CreateDateOfBirthMessage => Driver.FindElement(By.Id("dwfrm_profile_customer_birthday_error"));
        private IWebElement CreatePassw => Driver.FindElement(By.Id("dwfrm_profile_login_password"));
       // private IWebElement CreatePasswMessage => Driver.FindElement(By.Id("dwfrm_profile_login_password_error"));
        private IWebElement RegisterButton => Driver.FindElement(By.Id("dwfrm_profile_customer_createprofile"));
        private IWebElement SingInOption => Driver.FindElement(By.CssSelector("#main-content > div > div > div > span > a"));
        private IWebElement PopUp => Driver.FindElement(By.CssSelector("#onetrust-close-btn-container > button"));
        private IWebElement MultipleCheckboxList1 => Driver.FindElement(By.CssSelector(".addtoemaillist .check-svg"));
        private IWebElement MultipleCheckboxList2 => Driver.FindElement(By.CssSelector(".loyaltyoptin .check-svg"));
        public CreateAccountPage CreateFirstNameEnter(string text)
        {
            CreateFirstName.Clear();
            CreateFirstName.SendKeys(text);
            return this;
        }
        public CreateAccountPage CreateLastNameEnter(string text)
        {
            CreateLastName.Clear();
            CreateLastName.SendKeys(text);
            return this;
        }
        public CreateAccountPage CreateEmailEnter(string text)
        {
            CreateEmail.Clear();
            CreateEmail.SendKeys(text);
            return this;
        }
        public CreateAccountPage CreateDateOfBirthddmmyyyyeEnter(string text)
        {
            CreateDateOfBirthddmmyyyy.Clear();
            CreateDateOfBirthddmmyyyy.SendKeys(text);
            return this;
        }
        public CreateAccountPage CreatePasswEnter(string text)
        {
            CreatePassw.Clear();
            CreatePassw.SendKeys(text);
            return this;
        }
        public CreateAccountPage RegisterButtonClick(bool shouldBeAvailable)
        {
            if (shouldBeAvailable != RegisterButton.Selected)            
                RegisterButton.Click();
                return this;    
        }
        public CreateAccountPage SingInOptionClick()
        {
            SingInOption.Click();
            return this;
        }
        public CreateAccountPage PopUpClick()
        {
            PopUp.Click();
            return this;
        }
        public CreateAccountPage CheckBoxClick()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => MultipleCheckboxList1.Displayed);
            if ((!MultipleCheckboxList1.Selected) && (!MultipleCheckboxList2.Selected))
                MultipleCheckboxList1.Click();
            MultipleCheckboxList2.Click();
            return this;
        }
        public CreateAccountPage CheckBoxUnclick()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => MultipleCheckboxList1.Displayed);
            if ((MultipleCheckboxList1.Selected) && (MultipleCheckboxList2.Selected))
                MultipleCheckboxList1.Click();
            MultipleCheckboxList2.Click();
            return this;
        }
        public CreateAccountPage ConfirmCheckBox1Unclicked()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => MultipleCheckboxList1.Displayed);
            Assert.False(MultipleCheckboxList1.Selected, "Checkbox 1 is still checked");
            return this;
        }
        public CreateAccountPage ConfirmCheckBox2Unclicked()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => MultipleCheckboxList2.Displayed);
            Assert.False(MultipleCheckboxList2.Selected, "Checkbox 2 is still checked");
            return this;
        }
        
    }

}

