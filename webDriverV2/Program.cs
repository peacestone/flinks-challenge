using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace webDriverV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            //chromeDriverService.HideCommandPromptWindow = true;

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://challenge.flinks.io/Authorize/1839410332");


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            //IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("password")));


            IWebElement username = driver.FindElement(By.Name("username"));
            username.SendKeys("1234");

            IWebElement password = driver.FindElement(By.Name("password"));
            password.SendKeys("1234");


            Actions builder = new Actions(driver);

            builder.MoveByOffset(15, 15).Perform();
            //Actions moveMouse = builder
            //.MoveToElement(username);
            //.MoveByOffset(10, 25);
            //moveMouse.Build().Perform();
            //password.Submit();
            //driver.Quit();



            //query.Submit();
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.Title.StartsWith("chesse", StringComparison.OrdinalIgnoreCase));
            //Console.WriteLine("page tile is: " + driver.Title);


        }

    }

}
  