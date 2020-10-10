using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace MarsFramework.Pages
{
    internal class ManageListings : WaitHelpers
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //Click Edit icon
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]//div[1]/button[2]/i[1]")]
        private IWebElement editIcon { get; set; }

        //Click Delete icon
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]")]
        private IWebElement deleteIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement confirmDeleteButton { get; set; }

        //Find Skill Listing
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[3]")]
        private IWebElement findSkillListingElement { get; set; }

        //Popup
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Selenium Webdriver using CsharpEDITED has been deleted')]")]
        private IWebElement popup { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
        }

        internal void GoToManageListings()
        {
            manageListingsLink.Click();
            WaitHelpers.ElementIsVisible(driver, "Xpath", "//h2[contains(text(),'Manage Listings')]", 5);
        }

        internal void ClickEditButton()
        {
            WaitHelpers.ElementIsVisible(driver, "XPath", "//tbody/tr[1]//div[1]/button[2]/i[1]", 5);
            //Click edit icon
            editIcon.Click();
        }

        internal void ClickDeleteButton()
        {
            WaitHelpers.ElementIsVisible(driver, "XPath", "//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]", 5);
            //Click delete icon
            deleteIcon.Click();

            //Click to confirm 
            confirmDeleteButton.Click();
            WaitHelpers.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Selenium Webdriver using CsharpEDITED has been deleted')]", 5);
        }

        internal void FindSkillListing()
        {
            WaitHelpers.ElementIsVisible(driver, "XPath", "//table/tbody/tr[1]/td[3]", 5);
            if(findSkillListingElement.Text == "Selenium Webdriver using Csharp")
            {
                Assert.Pass("Listing created usccessfully, test passed!");
            }
            else
            {
                Assert.Fail("Listing not found, test failed!");
            }
        }

        internal void FindEditedSkillListing()
        {
            WaitHelpers.ElementIsVisible(driver, "XPath", "//table/tbody/tr[1]/td[3]", 5);
            if (findSkillListingElement.Text == "Selenium Webdriver using CsharpEDITED")
            {
                Assert.Pass("Listing record edited usccessfully, test passed!");
            }
            else
            {
                Assert.Fail("Listing not found, test failed!");
            }
        }

        internal void ConfirmDeleteSkillListing()
        {
            if (popup.Text == "Selenium Webdriver using CsharpEDITED has been deleted")
            {
                Assert.Pass("Listing record edited usccessfully, test passed!");
            }
            else
            {
                Assert.Fail("Listing not found, test failed!");
            }

        }
    }
}
