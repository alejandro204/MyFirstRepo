using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrary.Automation_Prractice.ContactUs
{
    public class ContactUsPage
    {
        IWebDriver webDriver;

        public ContactUsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public enum Options
        {
            ByText,
            ByValue,
            ByIndex
        }

        public void SelectHeadingCombobox(Options option, string value)
        {
            IWebElement subjectHeading = webDriver.FindElement(By.Id("id_contact"));
            SelectElement subjectHeadingCombobox = new SelectElement(subjectHeading);

            switch (option)
            {
                case Options.ByText:
                    subjectHeadingCombobox.SelectByText(value);
                    break;
                case Options.ByValue:
                    subjectHeadingCombobox.SelectByValue(value);
                    break;
                case Options.ByIndex:
                    subjectHeadingCombobox.SelectByIndex(int.Parse(value));
                    break;
            }
        }


        public void SetemailAddress(string email)
        {
            IWebElement emailAddressInput = webDriver.FindElement(By.Name("from"));
            emailAddressInput.SendKeys(email);
        }

        public void SetOrderReference(string orderReference)
        {
            IWebElement orderReferenceInput = webDriver.FindElement(By.Name("id_order"));
            orderReferenceInput.SendKeys(orderReference);
        }

        public void SetattachFile(string filePath)
        {
            IWebElement attachedFile = webDriver.FindElement(By.Id("fileUpload"));
            attachedFile.SendKeys(filePath);
        }

        public void SetMessage(string message)
        {
            IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            messageInput.SendKeys(message);
        }

        public void ClickSend()
        {
            IWebElement SendButton = webDriver.FindElement(By.Id("submitMessage"));
            SendButton.Click();
        }

        public void FillContactUsForm(Options option, string value, string email, string orderReference, string filePath, string message)
        {
            SelectHeadingCombobox(option, value);
            SetemailAddress(email);
            SetOrderReference(orderReference);
            SetattachFile(filePath);
            SetMessage(message);
            ClickSend();

        }

        //funcion que va aretornar la cadena
        public string GetConfirmationMessage()
        {
            IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
            string message = confirmationLabel.Text;
            return message;
        }
    }
}
