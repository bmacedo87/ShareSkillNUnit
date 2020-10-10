using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn : GlobalDefinitions
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            //Initiate Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Click sign in button
            SignIntab.Click();

            //Type in username
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            //Type in password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click login button
            LoginBtn.Click();

            WaitHelpers.ElementIsVisible(driver, "XPath", "//a[contains(text(),'Mars Logo')]", 5);

        }

        internal void LoginAssertion()
        {
            IWebElement findMarsLogo = driver.FindElement(By.XPath("//a[contains(text(),'Mars Logo')]"));

            if (findMarsLogo.Text == "Mars Logo")
            {
                Assert.Pass("Login successfull, test passed!");
            }
            else
            {
                Assert.Fail("Login unsuccessfull, tes failed!");
            }
        }
    }
}