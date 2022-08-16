using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Infosys.Selenium.POM.Setup
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string url;
        public string driverPath;



        [OneTimeSetUp]
        public void Setup1()
        {
            url = "https://twitter.com/i/flow/login";
            driverPath = @"E:\";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy();
            //chromeOptions.AddArgument("--proxy-server=5.188.136.52:8080");
            //string pro_server = "103.120.153.58:84";


            //proxy.HttpProxy = pro_server;
            //proxy.SslProxy = pro_server;

            //chromeOptions.Proxy = proxy;

            // proxy.setSslProxy(proxyadd);

            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");

            driver = new ChromeDriver(driverPath,chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [OneTimeTearDown]
        public void TearDown1()
        {
            //driver.Quit();
        }
    }
}
