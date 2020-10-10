using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsFramework.Global
{
    class WaitHelpers : GlobalDefinitions
    {

        public static void ElementIsVisible(IWebDriver driver, string locator, string locatorValue, int seconds)
        {
            try
            {
                if (locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                }
                if (locator == "CssSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
                }
                if (locator == "ClassName")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
                }

            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed waiting for element to be visible", msg.Message);
            }
        }
    }
}
