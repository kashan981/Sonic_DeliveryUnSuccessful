using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Sonic_delivery_unsuccessful
{
    class SignInObject
    {
        public SignInObject()
        {
            PageFactory.InitElements(Properties.Driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@id='phone_number']")]
        public IWebElement TxtPhoneNum { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='pin']")]
        public IWebElement TxtPin { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='login_button']")]
        public IWebElement BtnLogin { get; set; }

        public void SignIn(string PhoneNum, string Pin)
        {
            //Phone number
            Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Actions DoubleClick = new Actions(Properties.Driver);
            DoubleClick.DoubleClick(TxtPhoneNum).Perform();
            Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            TxtPhoneNum.SendKeys(PhoneNum);
            //Pin
            Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            TxtPin.SendKeys(Pin);
            //LoginButton
            Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            BtnLogin.Submit();

        }
    }
}
