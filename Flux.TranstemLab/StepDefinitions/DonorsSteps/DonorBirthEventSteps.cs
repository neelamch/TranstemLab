using Flux.TranstemLab.StepHelper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Flux.TranstemLab.StepDefinitions.DonorsSteps
{
    [Binding]
    public  class DonorBirthEventSteps : TranstemLabTestBase
    {
        private readonly Pages pages;
        public DonorBirthEventSteps(Pages pages)
        {
            this.pages = pages;
        }

        [Then(@"I click on Add Birth Event link from the Donor Detail page and fill out the required fields (.*) (.*) (.*)")]
        public void ThenIClickOnAddBirthEventLinkFromTheDonorDetailPage(String OtherPhysician, String Location, String OtherReferralType)
        {
            pages.donorBirthEventPage = pages.transtemLabHomePage.ClickOnAddBirthEvent();
            pages.donorBirthEventPage.EnterDetailsInAddBirthEvent(OtherPhysician, Location, OtherReferralType);
        }
        [Then(@"I Click on Save button on Add Birth Event page")]
        public void ThenIClickOnSaveButtonOnAddBirthEventPage()
        {
            pages.donorBirthEventPage.DrBeClickOnSaveButton();
        }



    }
}
