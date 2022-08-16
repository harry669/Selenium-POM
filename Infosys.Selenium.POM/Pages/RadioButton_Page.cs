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
    public class RadioButton_Page
    {
        //class custom-control custom-radio custom-control-inline
        [FindsBy(How = How.XPath, Using = "//input[@type='radio']")]

        public IList<IWebElement> radioList { get; set; }
    }
}
