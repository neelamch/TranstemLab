using Flux.Core;
using Flux.TranstemLab.StepHelper.Base;
using Flux.TranstemLab.StepHelper.Pages;
using TechTalk.SpecFlow;

namespace Flux.TranstemLab.StepDefinitions
{
    [Binding]
    public  class TranstemLabLoginSteps : TranstemLabTestBase
    {
        private readonly Pages pages;
        public TranstemLabLoginSteps(Pages pages)
        {
            this.pages = pages;
        }

        [Given(@"I navigate to TranstemLab login page")]
        public void GivenINavigateToTranstemLabLoginpage()
        {
            pages.transtemLabLoginPage
                = Application.NewPage<TranstemLabLoginPage>()
                             .NavigateToLoginPage();
        }

        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            pages.transtemLabLoginPage
                 .EnterUsername(username);
        }

        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            pages.transtemLabLoginPage
                 .EnterPassword(password);
        }

        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            pages.transtemLabHomePage
                = pages.transtemLabLoginPage
                       .ClickLogin();
        }




        [Given(@"I navigate to TranstemLab application")]
        public void GivenINavigateToTranstemLabApplication()
        {

            string username = TestEnvironment.AppSettings["Username"];
            string password = TestEnvironment.AppSettings["Password"];


            pages.transtemLabLoginPage = Application.NewPage<TranstemLabLoginPage>().NavigateToLoginPage();

            pages.transtemLabLoginPage.EnterUsername(username);


            pages.transtemLabLoginPage .EnterPassword(password);


            pages.transtemLabHomePage = pages.transtemLabLoginPage .ClickLogin();

        }
    }
}
