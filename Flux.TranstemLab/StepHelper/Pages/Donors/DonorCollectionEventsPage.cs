
using Flux.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public static By _elementDonorsLink = By.XPath("//div[@id='cssmenu']//li/a[text()='Donors']");
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




        public bool ClickOnDonorLink(String LinkName)
        {
            bool chkDonorLink = false;
            By _elementDonorsLink = By.XPath("//div[@id='cssmenu']//li/a[text()='" + LinkName + "']");
            if (Actions.IsDisplayed(_elementDonorsLink))
            {
                //Waits.WaitForElementToBeClickable(_elementDonorsLink, WaitType.Small);
                Actions.Click(_elementSerachButton);
                if (Actions.IsDisplayed(_elementSerachButton))
                {
                    chkDonorLink = true;

                }
                Console.WriteLine("Donor link is visible ======");
            }
            return chkDonorLink;
        }

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

        public void ClickOnIdentifier()
        {
            ReadOnlyCollection<IWebElement> lstIdentifier = Actions.FindElements(_elementListIdentifier);
            for (int i = 0; i < lstIdentifier.Count; i++)
            {
                if (i == 3)
                {
                    Thread.Sleep(8000);
                    String strelem = lstIdentifier[i].Text;
                    lstIdentifier[i].Click();
                    Thread.Sleep(8000);
                    Console.WriteLine("TEXT name is on first identifir here" + strelem);
                }
            }
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

        public List<object> mylist = new List<object> { "12345", "5/5/2018", "1011", "6/5/2018", "0521" };
        public string[] DrCeDDLOfCollectionData = new string[] { "TimeZone", "Collector", "ProductDescriptionCode", "DonationType" };
        public string[] DrCeTextFieldsOfCollectionData = new string[] { "CollectionID", "StartDate", "StartTime", "EndDate", "EndTime" };

        
        public void EnterValuesInCollectionDataFields()
        {
            Actions.Click(_elementDrCeCollDataPlusSign);

            Thread.Sleep(8000);
            Actions.Click(By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txtCollectionID_0"));
            Actions.FindElement(By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txtCollectionID_0")).SendKeys(mylist[0].ToString());


            for (int i = 0; i < DrCeTextFieldsOfCollectionData.Length - 1; i++)
            {
                By _elementDrCeTextFields = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txt" + DrCeTextFieldsOfCollectionData[i] + "_0");

                By _elementDrCeTextFieldsNext = By.Id("ContentPlaceHolder1_ctrlCollectionEvent_gvEventDate_txt" + DrCeTextFieldsOfCollectionData[i + 1] + "_0");

                Thread.Sleep(2000);
                if (Actions.FindElement(_elementDrCeTextFields).Displayed)
                {
                    Actions.FindElement(_elementDrCeTextFields).SendKeys(Keys.Tab);
                    Thread.Sleep(1000);
                    Actions.FindElement(_elementDrCeTextFieldsNext).SendKeys(mylist[i + 1].ToString());
                }
            }

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
            Actions.Click(_elementDrCeSaveBtn);


            if (Actions.IsDisplayed(_elementDrCeEditButton))
            {
                Console.WriteLine("Update Button is clicked successfully");
            }
            Actions.Click(_elementDrCeSaveButton);

        }

    }
}
