using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sonic_delivery_unsuccessful
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Press Enter to start Execution");
            Console.ReadLine();
            Browser();
            Login();
            Arrival();
            DeliveryNote();
            DeliveryUnsuccess();
            Console.WriteLine("\n   Execution Completed");
            Console.ReadLine();
        }
        public static void Browser()
        {
            Properties.Driver = new ChromeDriver();
            Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            Properties.Driver.Navigate().GoToUrl("https://app.sonic.pk/admin/login");
            Properties.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        public static void Login()
        {
            DataTable table = Excelbook.PopulateInCollection(ConfigurationManager.AppSettings["data"]);

            SignInObject obj1 = new SignInObject();
            obj1.SignIn(Excelbook.ReadData(1, "PhoneNum"), Excelbook.ReadData(1, "Pin"));
        }
        public static void Arrival()
        {
            //First Mile Individual arrival
            FirstMile obj2 = new FirstMile();
            obj2.FM(Excelbook.ReadData(1, "Weight"));
        }
        public static void DeliveryNote()
        {
            //Last Mile Delivery Note
            LastMile delv = new LastMile();
            delv.LM();

        }
        public static void DeliveryUnsuccess()
        {
            //Shipment delivery unsuccessfull
            Delivery_Unsuccessful unsucess = new Delivery_Unsuccessful();
            unsucess.DeliveryUnSuccessful();
            unsucess.Verify();
        }
    }
}
