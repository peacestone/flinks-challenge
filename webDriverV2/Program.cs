using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace webDriverV2
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://challenge.flinks.io/Authorize/1839410332");

            IWebElement username = driver.FindElement(By.Name("username"));
            username.SendKeys("1234");

            IWebElement password = driver.FindElement(By.Name("password"));
            password.SendKeys("1234");


            //query.Submit();
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.Title.StartsWith("chesse", StringComparison.OrdinalIgnoreCase));
            //Console.WriteLine("page tile is: " + driver.Title);


        }
        
    }

}
  