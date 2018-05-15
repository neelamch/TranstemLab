using Flux.TranstemLab.StepHelper.Base;
using Flux.TranstemLab.StepHelper.Pages.Donors;
using Flux.TranstemLab.StepHelper.Pages.Recipient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Flux.TranstemLab.StepDefinitions
{
    [Binding]
    public class RecipientCreationSteps : TranstemLabTestBase
    {

        protected RecipientCreationPage recipientCreationPage;
        protected DonorCollectionEventsPage donorCollectionEventsPage;

        //[Then(@"I click on (.*) Link")]
        //public void ThenIClickOnRecipientsLink(String LinkName)
        //{
        //    bool chkDonorLinkOpned = donorCollectionEventsPage.ClickOnDonorLink(LinkName);
        //        Assert.IsTrue(chkDonorLinkOpned, "Donor Link is NOT opened successfully");
        //        Console.WriteLine("Donor Page opened successfully");
        //}

        [Then(@"I click on Add Recipient button from the Recipient Search Page")]
        public void ThenIClickOnAddRecipientButtonFromTheRecipientSearchPage()
        {
            recipientCreationPage.ClickOnAddRecipientBtn();
        }
        
        [Then(@"I have entered all the required details Test(.*) TestCheck(.*) T(.*) AM(.*)ABC PO(.*)/(.*) Gender Ethnicity and Client Status from the page")]
        public void ThenIHaveEnteredAllTheRequiredDetailsTestTestCheckTAMABCPOGenderEthnicityAndClientStatusFromThePage(string RecipientID, string FirstName, string LastName, string MedicalRecord, string CRID, string RegistryID, string BirthDate)
        {
            recipientCreationPage.EnterAllFields(RecipientID, FirstName, LastName, MedicalRecord, CRID, RegistryID, BirthDate);
        }
        
        [Then(@"I click on Save button")]
        public void ThenIClickOnSaveButton()
        {
            recipientCreationPage.ClickOnSaveButton();
        }
        
        [Then(@"I Click on Add a transplant event for this patient from RecipientDetail page")]
        public void ThenIClickOnAddATransplantEventForThisPatientFromRecipientDetailPage()
        {
            Thread.Sleep(9000);
            recipientCreationPage.ClickOnAddaTransplantEvent();
        }
        
        [Then(@"I enter value for all the fields in Add Transplant Event page")]
        public void ThenIEnterValueForAllTheFieldsInAddTransplantEventPage()
        {
            recipientCreationPage.EnterFieldsInAddaTransplantEvent();
        }
        
        [Then(@"I click on Save button from Add Tranplant Event Page")]
        public void ThenIClickOnSaveButtonFromAddTranplantEventPage()
        {
            recipientCreationPage.ClickOnSaveBtnFromEditTransplantEvent();
        }
    }
}
