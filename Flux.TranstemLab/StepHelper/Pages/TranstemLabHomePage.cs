using Flux.Core;
using Flux.TranstemLab.StepHelper.Pages.Donors;
using OpenQA.Selenium;
using System;

namespace Flux.TranstemLab.StepHelper.Pages
{
    public class TranstemLabHomePage : PageBase
    {
        public override string Url => "/Home";
        private readonly By _elementLogOutButton = By.Id("lnkLogout");
        private readonly By _elementSerachButton = By.Id("ContentPlaceHolder1_btnSearch");
        private readonly By _elementIdentifier = By.LinkText("//*[text()='Last Name']");
        private readonly By _elementHeaderAddBirthEvent = By.XPath("//span[@id='ui-id-1'][text()='Add Birth Event']");


        public TranstemLabHomePage VerificationOfHomePage()
        {
            
            if (Actions.IsDisplayed(_elementLogOutButton))
            {
                Console.WriteLine("Transtem Lab Home Page is diaplyed");
            }

            return CreateInstance<TranstemLabHomePage>();
        }
        public DonorCollectionEventsPage ClickOnDonorLink(String LinkName)
        {
            By _elementDonorsLink = By.XPath("//div[@id='cssmenu']//li/a[text()='" + LinkName + "']");
            if (Actions.IsDisplayed(_elementDonorsLink))
            {
                Waits.WaitForElementToBeClickable(_elementDonorsLink, WaitType.Small);
                Actions.Click(_elementDonorsLink);
                if (Actions.IsDisplayed(_elementSerachButton))
                {
                    Console.WriteLine("Donor link is visible ======");
                }
            }
            return CreateInstance<DonorCollectionEventsPage>();
        }
        public DonorBirthEventPage ClickOnAddBirthEvent()
        {

            By _elementAddBirthEvent = By.Id("ContentPlaceHolder1_btnAddBirthEvent");

            if (Actions.IsEnabled(_elementAddBirthEvent))
            {
                Actions.Click(_elementAddBirthEvent);
            }
            Console.WriteLine("Clicked on Add Birth Event page successfully from the Donor Page");
            return CreateInstance<DonorBirthEventPage>();
        }










    }
}
