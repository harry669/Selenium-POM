using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Infosys.Selenium.POM.Pages
{
    public class UploadDownload_Page
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='uploadFile']")]

        public IWebElement Upload { get; set; }
    }
}
