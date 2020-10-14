using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace MarsFramework
{
    public class ShareSkillTest
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order (1)]
            public void Login_Test()
            {
                test = extent.StartTest("Login_Test"); 
                SignIn _loginAssertion = new SignIn();
                _loginAssertion.LoginAssertion();
            }

            [Test, Order (2)]
            public void AddShareSkill_Test()
            {
                test = extent.StartTest("AddShareSkill_Test");
                //Test
                ShareSkill _shareSkill = new ShareSkill();
                _shareSkill.GoToShareSkill();
                _shareSkill.EnterShareSkill();
                
                //Assertion
                ManageListings _skillAssertion = new ManageListings();
                _skillAssertion.GoToManageListings();
                _skillAssertion.FindSkillListing();

            }
            [Test, Order(3)]
            public void EditShareSkill_Test()
            {
                test = extent.StartTest("EditShareSkill_Test");
                //Go to Manage Listings
                ManageListings _listings = new ManageListings();
                _listings.GoToManageListings();
                _listings.ClickEditButton();

                //Test
                ShareSkill _editSkill = new ShareSkill();
                _editSkill.EditShareSkill();

                //Assertion
                _listings.FindEditedSkillListing();
            }

            [Test, Order(4)]
            public void DeleteShareSkill_Test()
            {
                test = extent.StartTest("DeleteShareSkill_Test");
                //Go to Manage Listings
                ManageListings _listings = new ManageListings();
                _listings.GoToManageListings();
                _listings.ClickDeleteButton();
               
                //Assertion
                _listings.ConfirmDeleteSkillListing();

            }
        }
    }
}