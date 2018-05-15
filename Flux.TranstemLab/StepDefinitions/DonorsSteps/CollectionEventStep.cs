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
        protected DonorCollectionEventsPage donorCollectionEventsPage;
        protected TranstemLabHomePage transtemLabHomePage;

        private readonly TrasLabContext trasLabContext;
        public CollectionEventStep(TrasLabContext trasLabContext)
        {
            this.trasLabContext = trasLabContext;
        }

        [Then(@"I click on (.*) Link")]
        public void ThenIClickOnDonorsLink(String LinkName)
        {
            
            bool chkDonorLinkOpned = donorCollectionEventsPage.ClickOnDonorLink(LinkName);
            Assert.True(chkDonorLinkOpned, "Donor Link is NOT opened successfully");
            Console.WriteLine("Donor Page opened successfully");
        }

        [Then(@"I click on search button from the Donor Serach Page and I select a identifier")]
        public void ThenIClickOnSearchButtonFromTheDonorSerachPageAndISelectAIdentifier()
        {
            bool chkSerachBtnClk = donorCollectionEventsPage.ClickOnSerachButtonFromDonorPage();
            Assert.True(chkSerachBtnClk, "Not clicked on SEARCH Button, Please try again");
            Console.WriteLine("Clicked on SEARCH button successfully");
            Thread.Sleep(5000);
            donorCollectionEventsPage.ClickOnIdentifier();
        }

        [Then(@"I click on Add collection Event link from the Donor Detail page")]
        public void ThenIClickOnAddCollectionEventLinkFromTheDonorDetailPage()
        {
            bool chkDrAddCollEvents = donorCollectionEventsPage.ClickOnAddCollectionEvent();
            Assert.True(chkDrAddCollEvents, "Verifcation of Add Collection Event page is successful");
            Console.WriteLine("Clicked on Add Collection Event page is successful");

            donorCollectionEventsPage.ClickOnDropDownOptionsFromDrCe();
            donorCollectionEventsPage.EnterValuesInCollectionDataFields();
        }

        [Then(@"I click on Add Birth Event link from the Donor Detail page")]
        public void ThenIClickOnAddBirthEventLinkFromTheDonorDetailPage()
        {
            
        }

    }
}
