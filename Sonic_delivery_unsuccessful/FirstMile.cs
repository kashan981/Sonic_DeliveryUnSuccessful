using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic_delivery_unsuccessful
{
    class FirstMile
    {
        public FirstMile()
        {
            PageFactory.InitElements(Properties.Driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[@id='sidebar_menu']")]
        public IWebElement BtnMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class= 'la la-cubes']/parent::span[contains(text(), 'First Mile')]")]
        public IWebElement BtnFirstMile { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='#']/child::span[contains(@class, 'menu-title') and contains(text(), 'Pickups')]")]
        public IWebElement BtnPickups { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'https://app.sonic.pk/admin/v2_pickups/arrival/individual') and contains(text(), 'Individual Arrival')]")]
        public IWebElement BtnIndividualArrival { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder= 'Tracking Number*']")]
        public IWebElement Txttrackingnum { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group ']/child::input[contains(@name, 'weight') and contains(@placeholder, 'Weight (kg)*')]")]
        public IWebElement Txtweight { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id = 'add']")]
        public IWebElement BtnAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name = 'confirm']")]
        public IWebElement BtnConfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(@id, 'select2-rider_select-container') and contains(text(), 'Danish Zahid')]")]
        public IWebElement BtnRider { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'select2-search__field']")]
        public IWebElement TxtRider { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[text() ='Ali Rider - Trax04877']")]
        public IWebElement BtnRiderAli { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id = 'rider_selection_form']/child::div[@class = 'form-group']/child::button[contains(text(), 'Confirm')]")]
        public IWebElement BtnRiderConfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'swal-button-container']/child::button[contains(text(), 'Yes')]")]
        public IWebElement BtnYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[contains(text(), 'Rider')]")]
        public IWebElement BtnHeading { get; set; }

        public void FM(string Weight)
        {
            try
            {
                if (BtnMenu.Displayed)
                {
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    //button menu
                    BtnMenu.Click();
                    //button FirstMile
                    BtnFirstMile.Click();
                    //button Pickups
                    BtnPickups.Click();
                    //button IndividualArrival
                    BtnIndividualArrival.Click();
                    Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                }
                else
                {
                    Console.WriteLine("Button Menu Not Found");
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine("Exception is : " + exe.Message);
            }
            try
            {
                //tracking number
                Database obj3 = new Database();
                obj3.Tracking_Number();
                Txttrackingnum.Click();
                Txttrackingnum.SendKeys(obj3.num);

                //Weight
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                Actions DoubleClick = new Actions(Properties.Driver);
                DoubleClick.DoubleClick(Txtweight).Perform();
                Txtweight.SendKeys(Weight);

                //Add
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                BtnAdd.Submit();

                //Confirm
                WebDriverWait Wait = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@name = 'confirm']")));
                BtnConfirm.Submit();

                //Rider Selection Confirm
                WebDriverWait Wait1 = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(60));
                Wait1.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@id, 'select2-rider_select-container') and contains(text(), 'Danish Zahid')]")));
                BtnRider.Click();

                //rider details
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                TxtRider.SendKeys("Ali Rider - Trax04877");

                //rider select
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                BtnRiderAli.Click();

                //rider confirm
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                BtnRiderConfirm.Submit();


                //Yes Button
                Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
                BtnYes.Submit();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is : " + ex.Message);
            }
        }
    }
}
