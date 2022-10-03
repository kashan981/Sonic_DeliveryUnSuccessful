using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace Sonic_delivery_unsuccessful
{
    class LastMile
    {
        public LastMile()
        {
            PageFactory.InitElements(Properties.Driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[@id='sidebar_menu']")]
        public IWebElement BtnLastMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class= 'la la-motorcycle']/parent::span[contains(text(), 'Last Mile')]")]
        public IWebElement BtnLastMile { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Delivery')]")]
        public IWebElement BtnDelivery { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href = 'https://app.sonic.pk/admin/delivery/note']")]
        public IWebElement BtnCreateNote { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Select Category*')]")]
        public IWebElement BtnCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(text(), 'Hold In Operations')]")]
        public IWebElement BtnCategSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Select Rider*')]")]
        public IWebElement BtnRider { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(text(), 'Danish Danish - Trax03097 - Karachi')]")]
        public IWebElement BtnRiderSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Select Route*')]")]
        public IWebElement BtnRoute { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(text(), 'COMPLETE PECHS AND DHA HEAVY PICKUP AND HEAVY DELIVERIES - (TRAX Office  to  DHA)')]")]
        public IWebElement BtnRouteSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[@class = 'mb-1']")]
        public IWebElement BtnFakeClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'scan_tracking']")]
        public IWebElement TxttrackingDN { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id = 'deliveryNoteSubmitBtn']")]
        public IWebElement BtnSubmitPrint { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()= 'Yes']")]
        public IWebElement BtnYes { get; set; }

        public void LM()
        {
            try
            {
                if (BtnLastMenu.Displayed)
                {
                    //button menu
                    BtnLastMenu.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //button LastMie
                    BtnLastMile.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //button Delivery
                    BtnDelivery.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //Button Create Note
                    BtnCreateNote.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
            }
            catch (Exception c)
            {
                Console.WriteLine("Exception is : " + c.Message);
            }
            try
            {
                //button category
                WebDriverWait w1 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w1.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Select Category*')]")));

                BtnCategory.Click();

                //button category select                
                WebDriverWait w2 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(), 'Hold In Operations')]")));
                BtnCategSelect.Click();

                //Fake Click
                BtnFakeClick.Click();

                //button Rider
                WebDriverWait w3 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w3.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Select Rider*')]")));
                Actions doubleclick = new Actions(Properties.Driver);
                doubleclick.DoubleClick(BtnRider).Perform();

                //Fake Click
                BtnFakeClick.Click();

                //button Rider
                WebDriverWait w31 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w31.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Select Rider*')]")));
                BtnRider.Click();

                //button Rider Select
                WebDriverWait w4 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w4.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(), 'Danish Danish - Trax03097 - Karachi')]")));
                BtnRiderSelect.Click();

                //Fake Click
                BtnFakeClick.Click();

                //button Route
                WebDriverWait w5 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(100));
                w5.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Select Route*')]")));

                BtnRoute.Click();

                //Fake Click
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                BtnFakeClick.Click();

                //button Route
                WebDriverWait w51 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(100));
                w51.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Select Route*')]")));
                Actions doubleclick3 = new Actions(Properties.Driver);
                doubleclick3.DoubleClick(BtnRoute).Perform();

                //Fake Click
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                BtnFakeClick.Click();

                //button route
                Thread.Sleep(2000);
                BtnRoute.Click();

                //button Route select
                WebDriverWait w6 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w6.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(), 'COMPLETE PECHS AND DHA HEAVY PICKUP AND HEAVY DELIVERIES - (TRAX Office  to  DHA)')]")));
                BtnRouteSelect.Click();

                //tracking number
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                WebDriverWait w7 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w7.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id = 'scan_tracking']")));
                Database TrackDN = new Database();
                TrackDN.Tracking_Number();

                TxttrackingDN.Click();
                TxttrackingDN.SendKeys(TrackDN.num);

                TxttrackingDN.SendKeys(Keys.Enter);

                //button Submit
                WebDriverWait w8 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(120));
                w8.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id = 'deliveryNoteSubmitBtn']")));

                IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.Driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", BtnSubmitPrint);

                WebDriverWait w9 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(120));
                w9.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id = 'deliveryNoteSubmitBtn']")));
                Actions twoclick = new Actions(Properties.Driver);
                twoclick.DoubleClick(BtnSubmitPrint).Perform();

                BtnSubmitPrint.Submit();

                //Button Yes
                WebDriverWait w10 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                w10.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()= 'Yes']")));

                BtnYes.Submit();

                //Delivery Note Done

                //Cancel Print Box
                Thread.Sleep(5000);
                Properties.Driver.SwitchTo().Window(Properties.Driver.WindowHandles[1]);
                IWebElement element = Properties.Driver.FindElement(By.TagName("body"));
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                element.SendKeys(Keys.Tab + Keys.Enter);
                Thread.Sleep(5000);
                Properties.Driver.SwitchTo().Window(Properties.Driver.WindowHandles[0]);

            }
            catch (Exception x)
            {
                Console.WriteLine("Exception is : " + x.Message);
            }
        }
    }
}
