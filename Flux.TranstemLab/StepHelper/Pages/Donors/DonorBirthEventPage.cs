using Flux.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flux.TranstemLab.StepHelper.Pages.Donors
{
    public class DonorBirthEventPage : PageBase
    {
        public override string Url => "/Home";
        private readonly By _elementAddBirthEventHeader = By.XPath("//span[@id='ui-id-1'][text()='Add Birth Event']");
        private readonly By _elementDrBeSaveButton = By.XPath("//div[@class='ui-dialog-buttonset']//button//span[text()='Save']");

        //This method is for getting Future Date
        public string GetFutureDate(int noOfDays)
        {
            DateTime today = DateTime.Now;
            DateTime futureDate = today.AddDays(noOfDays);
            string strDate = futureDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Date is " + strDate);
            return strDate;
        }

        //This method is for Enter details in Add Birth Event Page
        public string[] dropDownListOptionsFromAddBirthEventPage = new string[] { "Hospital", "Survey", "Physician", "ReferralType" };
        public void EnterDetailsInAddBirthEvent(String OtherPhysician, String Location, String OtherReferralType)
        {
            Thread.Sleep(8000);
            if (Actions.IsEnabled(_elementAddBirthEventHeader))
            {
                Console.WriteLine("Navigated to Add Birth Event Page successfully");
            }

            //This method is for selcting value from DDL from Add Birth Event Page for "Hospital", "Survey", "Physician", "ReferralType" 
            for (int i = 0; i < dropDownListOptionsFromAddBirthEventPage.Length; i++)
            {
                By _elementsDDLFromAddBirthEventPage = By.XPath("//select[@id='ContentPlaceHolder1_ddl" + dropDownListOptionsFromAddBirthEventPage[i] + "']//option");
                Console.WriteLine("Now clicking on Drop Down List of : " + dropDownListOptionsFromAddBirthEventPage[i] + "======");

                ReadOnlyCollection<IWebElement> ListDrBeDDLOfAddBirthEventPage = Actions.FindElements(_elementsDDLFromAddBirthEventPage);
                IList<string> strList = new List<string>();

                for (int j = 0; j < ListDrBeDDLOfAddBirthEventPage.Count(); j++)
                {
                    strList.Add(ListDrBeDDLOfAddBirthEventPage[j].Text);

                }
                String[] valuesFromDropDown = strList.ToArray();
                Console.WriteLine("Values present in drop drop list are :");
                foreach (string strValues in valuesFromDropDown)
                {
                    Console.Write(strValues + " , ");
                }
                for (int j = 0; j < ListDrBeDDLOfAddBirthEventPage.Count; j++)
                {
                    if (j == 1)
                    {
                        Thread.Sleep(2000);
                        ListDrBeDDLOfAddBirthEventPage[j].Click();
                        Console.WriteLine(ListDrBeDDLOfAddBirthEventPage[j].Text + " is selected from the " + dropDownListOptionsFromAddBirthEventPage[i] + " dropDown");
                    }
                }
            }
            //This method is for Entering the value from DDL from Add Birth Event Page for "DueDate", "DeliveryDate","OtherPhysician","Location","OtherReferralType"
            IList<string> strFields = new List<string>();
            strFields.Add("DueDate");
            strFields.Add("DeliveryDate");
            strFields.Add("OtherPhysician");
            strFields.Add("Location");
            strFields.Add("OtherReferralType");

            String strDueDate = GetFutureDate(1);
            String strDeliveryDate = GetFutureDate(10);

            List<object> mylist = new List<object> { strDueDate, strDeliveryDate, OtherPhysician, Location, OtherReferralType };

            for (int j = 0; j < strFields.Count; j++)
            {
                By _elementFileds = By.XPath("//input[@id='txt" + strFields[j] + "']");
                Thread.Sleep(2000);
                if (Actions.IsDisplayed(_elementFileds))
                {
                    Actions.FindElement(_elementFileds).SendKeys(mylist[j].ToString());

                    if (strFields[j] == "DueDate" || strFields[j] == "DeliveryDate")
                    {
                        Actions.FindElement(_elementFileds).SendKeys(Keys.Enter);
                       
                    }
                }
            }
        }
        public void DrBeClickOnSaveButton()
        {
            if (Actions.IsEnabled(_elementDrBeSaveButton))
            {
                Actions.Click(_elementDrBeSaveButton);
            }
            Console.WriteLine("Clicked on Save button succesfully");

        }

     }
}

