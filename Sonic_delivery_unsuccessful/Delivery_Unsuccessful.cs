using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Sonic_delivery_unsuccessful
{
    class Delivery_Unsuccessful
    {
        public Delivery_Unsuccessful()
        {
            PageFactory.InitElements(Properties.Driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[@id='sidebar_menu']")]
        public IWebElement BtnMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class= 'la la-motorcycle']/parent::span[contains(text(), 'Last Mile')]")]
        public IWebElement BtnLastMile { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Delivery')]")]
        public IWebElement BtnDelivery { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href = 'https://app.sonic.pk/admin/delivery/receive']")]
        public IWebElement BtnReceive { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'search_tracking']")]
        public IWebElement TxtTrack { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Actions')]")]
        public IWebElement BtnActions { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'dropdown-menu dropdown-menu-sm show']/child::a[contains(text(), 'Receive')]")]
        public IWebElement BtnPlusReceive { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@class=' text-center align-middle select select-checkbox p-1']")]
        public IWebElement BtncheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[starts-with(@id,  'select2-statusDrop')]")]
        public IWebElement BtnSelectStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[text() = 'Shipment - Delivery Unsuccessful']")]
        public IWebElement BtnStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[starts-with(@id,  'select2-reasonDrop')]")]
        public IWebElement BtnSelectReason { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[text()= 'Cash Unavailable']")]
        public IWebElement BtnReason { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id = 'statusSubmit']")]
        public IWebElement BtnUpdateStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'swal-button-container']/child::button[contains(text(), 'Yes')]")]
        public IWebElement BtnYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), ' Verify Statuses')]")]
        public IWebElement BtnVerify { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id = 'statusVerifySubmit']")]
        public IWebElement BtnVerifyStatus { get; set; }


        public void DeliveryUnSuccessful()
        {
            try
            {
                if (BtnMenu.Displayed)
                {
                    //button menu
                    BtnMenu.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //button LastMie
                    BtnLastMile.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //button Delivery                    
                    BtnDelivery.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //Button Receive
                    IJavaScriptExecutor jsx = (IJavaScriptExecutor)Properties.Driver;
                    jsx.ExecuteScript("arguments[0].scrollIntoView();", BtnReceive);
                    BtnReceive.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is : " + ex.Message);
            }
            //Receive Screen
            try
            {
                //enter tracking number
                WebDriverWait wait = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'search_tracking']")));
                Database Enter = new Database();
                Enter.Tracking_Number();
                TxtTrack.Click();
                TxtTrack.SendKeys(Enter.num);

                //scroll to actions
                IJavaScriptExecutor jss = (IJavaScriptExecutor)Properties.Driver;
                jss.ExecuteScript("window.scrollBy(500,0);", BtnActions);
                BtnActions.Click();

                //Receive
                WebDriverWait wait1 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                wait1.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class = 'dropdown-menu dropdown-menu-sm show']/child::a[contains(text(), 'Receive')]")));
                BtnPlusReceive.Click();

                //CheckBox
                WebDriverWait wait2 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(50));
                wait2.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@class=' text-center align-middle select select-checkbox p-1']")));
                BtncheckBox.Click();

                //Select Status
                WebDriverWait wait3 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(50));
                wait3.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[starts-with(@id,  'select2-statusDrop')]")));
                BtnSelectStatus.Click();

                //Status Delivery Unsuccessful
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                BtnStatus.Click();

                //Select Reason
                WebDriverWait wait4 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(50));
                wait4.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[starts-with(@id,  'select2-reasonDrop')]")));
                BtnSelectReason.Click();
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                BtnReason.Click();

                //Update Status
                WebDriverWait wait5 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(50));
                wait5.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id = 'statusSubmit']")));
                BtnUpdateStatus.Submit();

                //Button Yes
                WebDriverWait wait6 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(50));
                wait6.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'swal-button-container']/child::button[contains(text(), 'Yes')]")));
                BtnYes.Submit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is : " + e.Message);
            }
        }
        public void Verify()
        {
            try
            {
                if (BtnMenu.Displayed)
                {
                    //button menu
                    BtnMenu.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //button LastMie
                    BtnLastMile.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //button Delivery                    
                    BtnDelivery.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //Button Receive
                    IJavaScriptExecutor jsx = (IJavaScriptExecutor)Properties.Driver;
                    jsx.ExecuteScript("arguments[0].scrollIntoView();", BtnReceive);
                    BtnReceive.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is : " + ex.Message);
            }
            //Receive Screen
            try
            {
                //enter tracking number
                WebDriverWait wait = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id = 'search_tracking']")));
                Database Enter = new Database();
                Enter.Tracking_Number();
                TxtTrack.Click();
                TxtTrack.SendKeys(Enter.num);

                //scroll to actions
                IJavaScriptExecutor jss = (IJavaScriptExecutor)Properties.Driver;
                jss.ExecuteScript("window.scrollBy(500,0);", BtnActions);
                BtnActions.Click();

                //Verify statuses
                WebDriverWait wait1 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), ' Verify Statuses')]")));
                BtnVerify.Click();

                //Verify Single Status
                WebDriverWait wait2 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id = 'statusVerifySubmit']")));
                BtnVerifyStatus.Submit();

                //Button Yes
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                BtnYes.Submit();

            }
            catch (Exception n)
            {
                Console.WriteLine("Exception is : " + n.Message);
            }
        }
    }
}

