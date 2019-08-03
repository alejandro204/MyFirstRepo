using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectLibrary.Automation_Prractice.ContactUs;
using PageObjectLibrary.AutomationPractice.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTestSolution //crear desde un principio con un nombre
{
    //decorator - se refiere que existen test
    [TestClass]

    public class Class1
    {
        //framwork base: C#
        //ui framwork: Selenium webdriver
        //unit framework: MSTest

        IWebDriver webDriver;

        public Class1()
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDriver");
        }

        [TestMethod]

        public void MyFirstTest()
        {
            //navigate to automationpractice
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            MenuPage menuPage = new MenuPage(webDriver);
            menuPage.ClickContactUs();

            ContactUsPage contactUsPage = new ContactUsPage(webDriver);
            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "am.204.92@gmail.com", "1234", @"C:\txt.txt", "test message");
            string actualMessage = contactUsPage.GetConfirmationMessage();
            string expectedMessage = "Your message has been successfully sent to our team."; //expected

            Assert.AreEqual(expectedMessage, actualMessage);
        }


    }
}
