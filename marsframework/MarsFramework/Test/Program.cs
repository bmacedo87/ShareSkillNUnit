using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order (1)]
            public void Login_Test()
            {
                SignIn _loginAssertion = new SignIn();
                _loginAssertion.LoginAssertion();
            }

            [Test, Order (2)]
            public void ShareSkill_Test()
            {
                ShareSkill _shareSkillAssertion = new ShareSkill();
                _shareSkillAssertion.GoToShareSkill();
                _shareSkillAssertion.EnterShareSkill();
            }




        }
    }
}