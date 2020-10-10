using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Pages
{
    internal class ShareSkill : WaitHelpers
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
        }

        //Share Skill button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //one-off service type
        [FindsBy(How = How.CssSelector, Using = "input[name='serviceType'][value='1']")]
        private IWebElement OneOff { get; set; }

        //hourly basis service type
        [FindsBy(How = How.CssSelector, Using = "input[name='serviceType'][value='0']")]
        private IWebElement hourlyBasis { get; set; }

        //On-site Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0']")]
        private IWebElement onSite { get; set; }

        //Online Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='1']")]
        private IWebElement onLine { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Select day = Sunday
        [FindsBy(How = How.XPath, Using = ".//input[@index='0'][@type='checkbox']")]
        private IWebElement daySunday { get; set; }

        //Select start time
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='0']")]
        private IWebElement startTime { get; set; }

        //Select end time
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='0']")]
        private IWebElement endTime { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.CssSelector, Using = "input[name='skillTrades'][value='true']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement skillExchangeTag { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.CssSelector, Using = "input[name='isActive'][value='true']")]
        private IWebElement activeOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement saveButton { get; set; }

        //Function to navigate Shareskill Page
        internal void GoToShareSkill()
        {
            ShareSkillButton.Click();
        }

        internal void EnterShareSkill()
        {

            WaitHelpers.ElementIsVisible(driver, "XPath", "//h3[contains(text(),'Title')]", 5);
            //Type in Title and Description
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            
            //Select Category and Subcategory dropdown list
            new SelectElement(CategoryDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            new SelectElement(SubCategoryDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            
            // Type in Tag and click enter
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Select Service Type 
            ServiceType();

            //Select Location Type
            LocationType();

            //Select start date
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            //Select end date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //Select day
            daySunday.Click();

            //Type in Start time and End time
            startTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            endTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            //Select Skill trade option
            SkillTradeOption.Click();

            //Skill-Exchange tag
            skillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            skillExchangeTag.SendKeys(Keys.Enter);

            //Select Active
            activeOption.Click();

            //Click save button
            saveButton.Click(); 
        }

        internal void ServiceType()
        {
            //entering the service type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "Hourly basis service")
            {
                hourlyBasis.Click();
            }
            else
            {
                OneOff.Click();
            }
        }

        internal void LocationType()
        {
            //entering the location type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "Online")
            {
                onLine.Click();
            }
            else
            {
                onSite.Click();
            }
        }

        internal void EditShareSkill()
        {
            //Type in Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //Click save button
            saveButton.Click();
            WaitHelpers.ElementIsVisible(driver, "XPath", "//h2[contains(text(),'Manage Listings')]", 5);
        }
    }
}
