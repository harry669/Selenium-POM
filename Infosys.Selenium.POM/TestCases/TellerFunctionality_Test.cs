using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using Infosys.Selenium.POM.Pages;
using Infosys.Selenium.POM.Setup;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Net;
using System.IO;
using System.Collections;

namespace Infosys.Selenium.POM.TestCases
{
    [TestFixture]
    public  class TellerFunctionality_Test:BaseTest
    {

      
        public void TextBoxChecker()
        {
            System.Console.WriteLine("hello");
            //TextBox_Page page = new TextBox_Page();
            //PageFactory.InitElements(driver, page);
            
            //page.FullName.SendKeys("asasas");

        }

        [Test,Order(1)]
        public void LoginIntoTwitter()
        {
            //hellher85848721
            //(Harry@Potter@china135

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            System.Console.WriteLine("hello");
            //TextBox_Page page = new TextBox_Page();
            //PageFactory.InitElements(driver, page);
            IWebElement userName = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='layers']/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[5]/label/div/div[2]/div/input")));
            userName.SendKeys("hellher85848721");

            IWebElement next = driver.FindElement(By.XPath("//*[@id='layers']/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[6]/div"));
            next.Click();
            

            IWebElement password = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='layers']/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div/div[3]/div/label/div/div[2]/div[1]/input")));
            password.SendKeys("(Harry@Potter@china135");


            IWebElement LogIn = driver.FindElement(By.XPath("//*[@id='layers']/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[2]/div/div[1]/div/div/div/div"));
            LogIn.Click();

            /*
            try
            {
                //if twitter detect selenium as a bot
                IWebElement bot = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/input[6]")));
                bot.Click();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("no bot detection");
            }
            */
            
        }

        [Test,Order(2)]
        public void SearchContest()
        {
            //contests keywords
            var list = new ArrayList();
            list.Add("contests");
            list.Add("sweepstakes");
            list.Add("giveaways");

              WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //find search bar
            string hashtag = (string)list[1];
            IWebElement explore = driver.FindElement(By.XPath("//a[@data-testid='AppTabBar_Explore_Link']"));
            explore.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement search = driver.FindElement(By.XPath("//input[@data-testid='SearchBox_Search_Input']"));
            search.SendKeys(hashtag);

            IWebElement listbox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='listbox']")));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(11);
            Thread.Sleep(10000);

            IList<IWebElement> searchList = driver.FindElements(By.XPath("//div[@data-testid='typeaheadResult']"));
            //click on first search
            if(searchList.Count>0)
            {
               
                Console.WriteLine(searchList.Count);
                foreach(IWebElement li in searchList)
                {
                    li.Click();
                    break;
                }

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                IList<IWebElement> presentation = driver.FindElements(By.XPath("//a[@role='tab']"));
                int index = 1;
                foreach(IWebElement pre in presentation)
                {
                    if(index==2)
                    {
                        pre.Click();
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Not found");
            }
          

        }

        //[Test,Order(3)]

        //like the tweet
        public void FetchLatestPostsByLinks()
        {
            ////article[@data-testid='tweet']
            ////div[@class='css-1dbjc4n r-16y2uox r-1wbh5a2 r-1ny4l3l']
            //css-1dbjc4n

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            IList<IWebElement> posts = driver.FindElements(By.XPath("//div[@data-testid='like']"));
            if(posts.Count > 0)
            {
                //like first element
                foreach(IWebElement post in posts)
                {
                    IWebElement like = post;
                    like.Click();
                    break;
                }
            }
        }

       // [Test,Order(4)]
        public void RtweetByPosts()
        {
            // //div[@class='css-1dbjc4n r-1ta3fxp r-18u37iz r-1wtj0ep r-1s2bzr4 r-1mdbhws']/div[2]//div[@data-testid='retweet']
            IList<IWebElement> posts = driver.FindElements(By.XPath("//div[@data-testid ='retweet']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            if (posts.Count > 0)
            {
                int index = 1;
                foreach(IWebElement post in posts)
                {
                    if(index%2!=0 && index<3)
                    {
                        post.Click();
                        Thread.Sleep(3000);
                        //direct retweet
                        IWebElement rtweet = post.FindElement(By.XPath("//*[@id='layers']/div[2]/div/div/div/div[2]/div[3]/div/div/div/div"));
                        rtweet.Click();
                        index++;
                    }
                    else
                    {
                        if(index<3)
                        {
                            post.Click();
                            Thread.Sleep(3000);
                            IWebElement rtweet = post.FindElement(By.XPath("//*[@id='layers']/div[2]/div/div/div/div[2]/div[3]/div/div/div/a"));
                            rtweet.Click();
                            IWebElement QuotRetwet = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='layers']/div[2]/div/div/div/div/div/div[2]/div[2]/div/div/div/div[3]/div/div[1]/div/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div/div/div/label/div[1]/div/div/div/div/div[2]/div")));
                            QuotRetwet.SendKeys("Ok");

                            IWebElement sendTweet = driver.FindElement(By.XPath("//div[@data-testid='tweetButton']"));
                            sendTweet.Click();
                            index++;
                        }
                        else
                        {
                            break;
                        }
                      
                    }
                 
                }
            }
        }

       [Test,Order(3)]
        public void participateInContest()
        {
            //store and participate in contest
            Thread.Sleep(2000);
            string link = "https://t.co/kkn1eMW5my";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement contest = driver.FindElement(By.XPath("//a[@dir='ltr']"));
        }


        
        // [Test,Order(2)] 
        public void CheckBoxChecker()
        {

        }

        //[Test,Order(3)]
        public void RadioButtonChecker()
        {
            //RadioButton_Page page = new RadioButton_Page();
            //PageFactory.InitElements(driver, page);
            //string id = "yesRadio";
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //IWebElement clickEle = page.radioList[0];
            //js.ExecuteScript("arguments[0].click();", clickEle);
            //System.Console.WriteLine(page.radioList[0]);
            
            //IWebElement Result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(clickEle));


        }

       // [Test,Order(4)]
        public void UploadDownload()
        {
           // UploadDownload_Page page = new UploadDownload_Page();
            //PageFactory.InitElements(driver, page);
            //IWebElement ele = page.Upload;
            //string filePath = "C:/cinqueterre.jpg";
            //ele.SendKeys(filePath);

        }

        //[Test,Order(5)]
        public void DynamicProperty()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //IWebElement ele= wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='visibleAfter']")));
            //if(ele!=null)
            //{
                //System.Console.WriteLine(ele.Text);
            //}
        }

        //[Test,Order(6)]
        public  void checkLinks()
        {
           // IWebElement linkWrapper = driver.FindElement(By.XPath("//div[@id='linkWrapper']"));
            //IList<IWebElement> linkCollection = linkWrapper.FindElements(By.TagName("a"));
            //IWebElement link = linkCollection[1];
            //string path= link.GetAttribute("href");
            //C# simple http request
            //WebRequest request= WebRequest.Create(path);
            //request.Method = "GET";
            //WebResponse response = request.GetResponse();
            //Console.WriteLine(((HttpWebResponse)response).StatusCode);
            //response.Close();

        }

        //[Test,Order(7)]
        public void checkBrokenLinks()
        {

        }

        /*
        [Test,Order(8)]
        public void checkMenu()
        {
            //react dropdown menus: class  css-yt9ioa-option
            IWebElement dropdown = driver.FindElement(By.XPath("//*[@id='withOptGroup']/div/div[2]/div"));
            dropdown.Click();
            //wait for dropdown container to be displyed
            // css-11unzgr
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class=' css-26l3qy-menu']")));
            //System.Console.WriteLine(ele);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("arguments[0].click();", dropdown);
            //IList<IWebElement> optionList = driver.FindElements(By.XPath("//*[starts-with(@id,'react - select - 2 - option')]"));
            IList<IWebElement> optionList = ele.FindElements(By.XPath("//div[starts-with(@id,'react-select-2-option')]"));
            
            foreach(IWebElement option in optionList)
            {
                System.Console.WriteLine(option.Text);
            }
            

        }
        */
       
        public void MultiSelect()
        {
            //select 2
            int counter = 0;
           

                IWebElement multiSelect = driver.FindElement(By.XPath("//*[@id='selectMenuContainer']/div[7]/div/div/div/div[2]/div"));
                multiSelect.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class=' css-26l3qy-menu']")));
                 IList<IWebElement> optionList = ele.FindElements(By.XPath("//div[starts-with(@id,'react-select-4-option')]"));
                 while (counter<2)
                 {
                   IWebElement val = optionList[counter];
                   val.Click();
                   counter++;
                 }
            //css-12jo7m5
            IList<IWebElement> check = driver.FindElements(By.XPath("//div[@class='css-12jo7m5']"));
            if(check.Count==2)
            {
                System.Console.WriteLine("test pass");
            }
            else
            {
                System.Console.WriteLine("test failed");
            }



            //react-select-4-option-0
            // css-26l3qy-menu
        }

       // [Test,Order(1)]
        public void AutoComplete()
        {
            IWebElement search = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            search.SendKeys("b");
            string searchString = "Black";
            // listContainer = driver.FindElement(By.XPath("//div[@class='auto-complete__menu-list auto-complete__menu-list--is-multi css-11unzgr']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement  listConatainer = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='auto-complete__menu-list auto-complete__menu-list--is-multi css-11unzgr']")));
            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class='auto-complete__menu-list auto-complete__menu-list--is-multi css-11unzgr']/div"));
            if(list.Count>0)
            {
                foreach(IWebElement ele in list)
                {
                     if(ele.Text == searchString)
                    {
                        System.Console.WriteLine("test passed");
                        break;
                    }
                       
                }
            }
            //System.Console.WriteLine(search);
        }


       
        public void DynamicXpath()
        {
            IWebElement ele = driver.FindElement(By.XPath("//input[@id='firstName']//following::input"));
            System.Console.WriteLine(ele);
        }

    }
}
