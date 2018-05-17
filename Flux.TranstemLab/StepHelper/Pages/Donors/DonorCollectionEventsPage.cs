
using Flux.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
  public  class DonorCollectionEventsPage : PageBase
    {
        public override string Url => "/Home";


        private readonly By _elementSerachBlock = By.Name("ctl00$searchBlock1$ctl03");
        private readonly By _elementDonorsLink = By.XPath("//div[@id='cssmenu']//li/a[text()='Donors']");
        private readonly By _elementSerachButton = By.Id("ContentPlaceHolder1_btnSearch");
        private readonly By _elementIdentifier = By.LinkText("//*[text()='Last Name']");
        private readonly By _elementListIdentifier = By.XPath("((//table[@id='ContentPlaceHolder1_gv1']//tbody//tr)//td[1]//a[text()])");
        private readonly By _elementAddCollectionEvent = By.Id("ContentPlaceHolder1_btnAddCollectionEvent");
        private readonly By _elementDonorID = By.Id("ContentPlaceHolder1_lblDonorId");
        private readonly By _elementDrCollEvntsHeader = By.XPath("//div[@class='ui-dialog-title']");
        private readonly By _elementDrCEHospitalArrowBtn = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_ddlHostpitalCE");
        private readonly By _elementDrCeCollDataPlusSign = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_btnAddCollectionDate");
        private readonly By _elementDrCeSaveBtn = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_lnkUpdate_0");
        private readonly By _elementDrCeSaveButton = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_btnSave");
        private readonly By _elementDrCeEditButton = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_lnkEdit_0");
        private readonly By _elementDrCeDonorIDText = By.XPath("//span[@id='ContentPlaceHolder1_spnDonorId'][text()]");
       
        

        public bool ClickOnSerachButtonFromDonorPage()
        {
            bool chkSearchButton = false;

            Actions.Click(_elementSerachButton);

            if (Actions.IsDisplayed(_elementSerachButton))
            {
                chkSearchButton = true;
                Console.WriteLine("Identifier link is visible ======");
            }
            return chkSearchButton;
        }
       public  String donorIDText;
        public string ClickOnIdentifier()
        {
            ReadOnlyCollection<IWebElement> lstIdentifier = Actions.FindElements(_elementListIdentifier);
            for (int i = 0; i < lstIdentifier.Count; i++)
            {
                if (i == 2)
                {
                    Thread.Sleep(2000);
                   String strelem = lstIdentifier[i].Text;
                    lstIdentifier[i].Click();
                   Thread.Sleep(1000);
                    if(Actions.IsDisplayed(_elementDrCeDonorIDText))
                    {
                        donorIDText = Actions.GetText(_elementDrCeDonorIDText);
                    }
                    Console.WriteLine("TEXT name is on first identifir here" + strelem);
                }
            }

            return donorIDText;
        }
       


        public bool ClickOnAddCollectionEvent()
        {   
        bool chkAddCollEvnts = false;
            //Thread.Sleep(2000);

            if (Actions.IsDisplayed(_elementDonorID))
            {
                Waits.WaitForElementToBeClickable(_elementDonorID, WaitType.Small);
                Actions.Click(_elementAddCollectionEvent);
                chkAddCollEvnts = true;
            }
            if (Actions.IsDisplayed(_elementDrCollEvntsHeader))
            {
                Console.WriteLine("Verifcation of Add Collection Event page is successful");
            }
            return chkAddCollEvnts;
        }

        //Below method is for selecting values from Add Collection Event page for "HostpitalCE", "DonorType", "StemCellSource"
        public string[] dropDownListOptionsFromDrCe = new string[] { "ddlHostpitalCE", "ddlDonorType", "ddlStemCellSource" };
        public void ClickOnDropDownOptionsFromDrCe()
        {
            for (int j = 0; j < dropDownListOptionsFromDrCe.Length; j++)
            {

                Console.WriteLine("Now clicking on Drop Down List of : " + dropDownListOptionsFromDrCe[j] + "======");
                By _elementDrCeHospitalDDList = By.XPath("//select[@id='ContentPlaceHolder1_ctrlCollectionEvent_" + dropDownListOptionsFromDrCe[j] + "']//option[text()]");
                Thread.Sleep(1000);
                Console.WriteLine(dropDownListOptionsFromDrCe[j] + "Drop Down Arrow is expaneded for clicking the value");
                ReadOnlyCollection<IWebElement> lstHospital = Actions.FindElements(_elementDrCeHospitalDDList);
                IList<string> strList = new List<string>();

                for (int i = 0; i < lstHospital.Count; i++)
                {
                    strList.Add(lstHospital[i].Text);
                }

                String[] valuesFromDropDown = strList.ToArray();
                foreach (string strValues in valuesFromDropDown)
                {
                    Console.Write("Values present in drop drop list : " + strValues + ",");
                    Console.WriteLine();
                }
                for (int i = 0; i < lstHospital.Count; i++)
                {
                    if (i == 0)
                    {
                        lstHospital[i].Click();
                        Console.WriteLine(lstHospital[i].Text + " is selected from the " + dropDownListOptionsFromDrCe[j] + " dropDown");
                    }

                }
            }
        }
        //This method is for getting Future Date
        public string GetFutureDate(int noOfDays)
        {
            DateTime today = DateTime.Now;
            DateTime futureDate = today.AddDays(noOfDays);
            string strDate = futureDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Date is " + strDate);
            return strDate;
        }

        public string[] DrCeDDLOfCollectionData = new string[] { "TimeZone", "Collector", "ProductDescriptionCode", "DonationType" };
        public string[] DrCeTextFieldsOfCollectionData = new string[] { "CollectionID", "StartDate", "StartTime", "EndDate", "EndTime" };
        
        public void EnterValuesInCollectionDataFields()
        {
            String strdonorIDText = donorIDText + "-1";
            String StartDate = GetFutureDate(1);
            String EndDate = GetFutureDate(2);

            List<object> mylist = new List<object> { strdonorIDText, StartDate, "0000", EndDate, "0001" };
            Actions.Click(_elementDrCeCollDataPlusSign);

            Thread.Sleep(4000);
            Actions.Click(By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txtCollectionID_0"));
            Actions.FindElement(By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txtCollectionID_0")).SendKeys(mylist[0].ToString());

            //Below method is for selecting values from Add Collection Event page for "CollectionID", "StartDate", "StartTime", "EndDate", "EndTime"
            for (int i = 0; i < DrCeTextFieldsOfCollectionData.Length - 1; i++)
            {
                By _elementDrCeTextFields = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txt" + DrCeTextFieldsOfCollectionData[i] + "_0");

                By _elementDrCeTextFieldsNext = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txt" + DrCeTextFieldsOfCollectionData[i + 1] + "_0");

                Thread.Sleep(2000);
                if (Actions.FindElement(_elementDrCeTextFields).Displayed)
                {
                    Actions.FindElement(_elementDrCeTextFields).SendKeys(Keys.Tab);
                    Waits.WaitForElementToBeVisible(_elementDrCeTextFields, WaitType.Small);
                    Thread.Sleep(1000);
                    Actions.FindElement(_elementDrCeTextFieldsNext).SendKeys(mylist[i + 1].ToString());
                }
            }

            //Below method is for selecting values from Add Collection Event page for "TimeZone", "Collector", "ProductDescriptionCode", "DonationType"
            for (int j = 0; j < DrCeDDLOfCollectionData.Length; j++)
            {

                Console.WriteLine("Now clicking on Drop Down List of : " + DrCeDDLOfCollectionData[j] + "======");
                By _elementDrCeDDLOfCollectionDataFields = By.XPath("//select[@id='ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_ddl" + DrCeDDLOfCollectionData[j] + "_0']//option[text()]");

                ReadOnlyCollection<IWebElement> ListDrCeDDLOfCollectionDataFields = Actions.FindElements(_elementDrCeDDLOfCollectionDataFields);
                IList<string> strList = new List<string>();
                Thread.Sleep(1000);
                for (int i = 0; i < ListDrCeDDLOfCollectionDataFields.Count; i++)
                {
                    strList.Add(ListDrCeDDLOfCollectionDataFields[i].Text);
                }
                String[] valuesFromDropDown = strList.ToArray();
                foreach (string strValues in valuesFromDropDown)
                {
                    Console.Write("Values present in drop drop list : " + strValues + ",");
                    Console.WriteLine();
                }
                for (int i = 0; i < ListDrCeDDLOfCollectionDataFields.Count; i++)
                {
                    if (i == 0)
                    {
                        ListDrCeDDLOfCollectionDataFields[i].Click();
                        Console.WriteLine(ListDrCeDDLOfCollectionDataFields[i].Text + " is selected from the " + DrCeDDLOfCollectionData[j] + " dropDown");
                    }
                }
            }
        }
        //This method is for click on Save Button
        public void ClickOnSaveButton()
        {
            Actions.Click(_elementDrCeSaveBtn);
            if (Actions.IsDisplayed(_elementDrCeEditButton))
            {
                Console.WriteLine("Update Button is clicked successfully");
            }
            
        }



    }
}
