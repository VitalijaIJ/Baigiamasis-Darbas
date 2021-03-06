using AutomatinisTestavimas.Drivers;
using AutomatinisTestavimas.Page;
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
    public class BurtonPageTest : BaseTest
    {     
        [Order (2)]
        [TestCase("123456", "2435*(", "VSC.com", "2021/13/13", "Vi11111111111111111111111111111111137", false, TestName = "False Name, Surname, email, BirthDay, Pasw.")]
        [TestCase("Vitalija", "Jankeviciene", "vitalija0117@gmail.com", "1919.04.20", "Vitalija123", false, TestName = "Email already used")]
        [TestCase("Ona", "Ona", "vitalija0117@gmai.com", "19190420", "Vitalija123", false, TestName = "Wrong email, BDay format")]
        [TestCase("!!!!!!", "Jankeviciene", "vitalija@.com", "18/4/2003", "Vi311111", false, TestName = "Wrong Name, email, BDay format.")]
        [TestCase("Žžžžžž", "Jankevičienė", "Žitalija@gmail.com", "a18.04.20", "ii33333333", false, TestName = "Not Italic letters, wrong email, BDay, Pasw.")]
        [TestCase("", "", "vitalija@gmail.com", "5.12.1919", "Viiiiiiiii", false, TestName = "Email already used, wrong Name, Surname, Pasw, BDay format.")]
        [TestCase("Vitalija", "Jankeviciene", "@gmail.com", "15.3.1919", "Vi1111111111111111111111111111111136", false, TestName = "Email already used, wrong Pasw, BDay format.")]
        //[TestCase("Vitalija", "Jankeviciene", "vitalija0117@gmail.com", "04/20/1988", "Vitalija123", true, TestName = "correct")]

        public void TestCreateAccount(string name, string lastName, string email, string birthDay, string pasw, bool result)
        {
            CreateAccountPage page = _createAccountPage;
            page.NavigateToDefaultPage()
            .CreateFirstNameEnter(name)
            .CreateLastNameEnter(lastName)
            .CreateEmailEnter(email)
            .CreateDateOfBirthddmmyyyyeEnter(birthDay)
            .CreatePasswEnter(pasw)
            .RegisterButtonClick(result);
        }
        [Order(1)]
        [Test]
        public void Checkbox()
        {
            _createAccountPage.NavigateToDefaultPage()
                .CheckBoxClick()
                .CheckBoxUnclick()
                .ConfirmCheckBox1Unclicked()
                .ConfirmCheckBox2Unclicked();
        }
        [Order(5)]
        [TestCase("", "2435*(", false, TestName = "No Email")]
        [TestCase("vitalija0117@gmail.com", "", false, TestName = "No Pasw")]
        [TestCase("7@gmail.com", "fhh", false, TestName = "Wrong Pasw")]
        [TestCase("7@gma", "fhh", false, TestName = "Wrong email")]       
        public void SingIn(string email, string pasw, bool result)
        {
            _singinPage.NavigateToDefaultPage()
                .SingInEmailEnter(email)
            .SingInPaswEnter(pasw)
            .SingInButtonClick(result);
        }
        [Order(6)]
        [TestCase("vitalija0117@gmail.com", "Vitalija123", true, TestName = "correct")]
        public void SingInOutCorrect(string email, string pasw, bool result)
        {
            _singinPage.NavigateToDefaultPage()
                .SingInEmailEnter(email)
            .SingInPaswEnter(pasw)
            .SingInButtonClick(result)
            .SingOutClick();
        }

        [Order(4)]
        [Test]
        public void CheckErrorMessage()
        {
            _singinPage.NavigateToDefaultPage()
                .SingInButtonClick(false)
                .CheckResulEmailtEmpty()
                .CheckResulPaswEmpty();

        }
        [Order(3)]
        [Test]
        public void AddToBasket()
        {
            _addToChart1Page.NavigateToDefaultPage()
                .AddtoBasketFirstItem()
            .SelectChart();
            _burtonChartPage.ItemPrice()
                .ChangeQntTo1o()
                .ChangeQntTo1oClick("10");
           // .CheckItemTotalAmount("$399.50");
        }        
    }
}
