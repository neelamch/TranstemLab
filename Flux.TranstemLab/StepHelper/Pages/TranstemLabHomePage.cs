using Flux.Core;
using OpenQA.Selenium;

namespace Flux.TranstemLab.StepHelper.Pages
{
    public class TranstemLabHomePage : PageBase
    {
        public override string Url => "/Home";
        private readonly By _elementLogOutButton = By.Id("lnkLogout");

        public bool VerificationOfHomePage()
        {
            bool chkHomePage = false;
            if (Actions.IsDisplayed(_elementLogOutButton))
            {
                chkHomePage = true;
            }
            return chkHomePage;
        }
    }
}
