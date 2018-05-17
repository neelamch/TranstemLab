using Flux.TranstemLab.StepHelper.Base;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Flux.TranstemLab.StepDefinitions
{
    [Binding]
    public sealed class TranstemLabHomeSteps : TranstemLabTestBase
    {
        private readonly Pages pages;
        public TranstemLabHomeSteps(Pages pages)
        {
            this.pages = pages;
        }

        [Then(@"I should be navigated to TranstemLab home page")]
        public void ThenIShouldBeNavigatedToTranstemLabDashboardPage()
        {
            pages.transtemLabHomePage.VerificationOfHomePage();
        }

        [Then(@"I click on (.*) Link")]
        public void ThenIClickOnDonorsLink(string LinkName)
        {
            pages.donorCollectionEventsPage = pages.transtemLabHomePage.ClickOnDonorLink(LinkName);
            Console.WriteLine("Donor Page opened successfully");
        }


        
    }
}
