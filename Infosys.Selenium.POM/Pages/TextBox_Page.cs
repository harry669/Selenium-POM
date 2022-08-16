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
    public class TextBox_Page
    {
        public string testUrl = "https://demoqa.com/text-box";
        [FindsBy(How = How.Id, Using = "userName")]

        public IWebElement FullName { get; set; }
    }
}
