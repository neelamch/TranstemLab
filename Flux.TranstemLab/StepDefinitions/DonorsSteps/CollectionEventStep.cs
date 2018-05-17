using Flux.TranstemLab.StepHelper.Base;
using Flux.TranstemLab.StepHelper.Pages;
using Flux.TranstemLab.StepHelper.Pages.Donors;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Flux.TranstemLab.StepDefinitions.Donors
{
    [Binding]
    public  class CollectionEventStep : TranstemLabTestBase
    {
        private readonly Pages pages;
        public CollectionEventStep(Pages pages)
        {
            this.pages = pages;
        }

        [Then(@"I click on search button from the Donor Serach Page and I select a identifier")]
        public void ThenIClickOnSearchButtonFromTheDonorSerachPageAndISelectAIdentifier()
        {
            bool chkSerachBtnClk = pages.donorCollectionEventsPage.ClickOnSerachButtonFromDonorPage();
            Assert.True(chkSerachBtnClk, "Not clicked on SEARCH Button, Please try again");
            Console.WriteLine("Clicked on SEARCH button successfully");
            
            pages.donorCollectionEventsPage.ClickOnIdentifier();
        }

        [Then(@"I click on Add collection Event link from the Donor Detail page and fill out the required fields")]
        public void ThenIClickOnAddCollectionEventLinkFromTheDonorDetailPage()
        {
            bool chkDrAddCollEvents = pages.donorCollectionEventsPage.ClickOnAddCollectionEvent();
            Assert.True(chkDrAddCollEvents, "Verifcation of Add Collection Event page is successful");
            Console.WriteLine("Clicked on Add Collection Event page is successful");

            pages.donorCollectionEventsPage.ClickOnDropDownOptionsFromDrCe();
            pages.donorCollectionEventsPage.EnterValuesInCollectionDataFields();
        }

        [Then(@"I Click on Save button")]
        public void ThenIClickOnSaveButton()
        {
            pages.donorCollectionEventsPage.ClickOnSaveButton();
        }



    }
}
