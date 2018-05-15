using Flux.Core;
using OpenQA.Selenium;

namespace Flux.TranstemLab.StepHelper.Pages
{
    public class TranstemLabLoginPage : PageBase
    {
        public override string Url => "/Home";
        private readonly By _elementUsername = By.Id("crtlLogInOut_lgnMain_UserName");
        private readonly By _elementPassword = By.Id("crtlLogInOut_lgnMain_Password");
        private readonly By _elementLogInButton = By.Id("crtlLogInOut_lgnMain_LoginButton");

        public TranstemLabLoginPage NavigateToLoginPage()
        {
            Driver.Url = TestEnvironment.AppSettings["AppUrl"];
            return this;
        }

        public TranstemLabLoginPage EnterUsername(string username)
        {
            Actions.SendKeys(_elementUsername, username);
            return this;
        }

        public TranstemLabLoginPage EnterPassword(string password)
        {
            Actions.SendKeys(_elementPassword, password);
            return this;
        }

        public TranstemLabHomePage ClickLogin()
        {
            Actions.Click(_elementLogInButton);
            return NewPage<TranstemLabHomePage>();
        }

        public TranstemLabHomePage LoginToTranstemApplication()
        {
            return NavigateToLoginPage()
                                        .EnterUsername(TestEnvironment.AppSettings["Username"])
                                        .EnterPassword(TestEnvironment.AppSettings["Password"])
                                        .ClickLogin();
        }
    }
}