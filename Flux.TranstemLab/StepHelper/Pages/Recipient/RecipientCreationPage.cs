
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flux.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Flux.TranstemLab.StepHelper.Pages.Recipient
{
   public  class RecipientCreationPage : PageBase
    {


        public override string Url => throw new NotImplementedException();
        private readonly By _elementRcpAddRecipientBtn = By.Id("ContentPlaceHolder1_btnAdd");
        private readonly By _elementRcpSaveBtn = By.Id("ContentPlaceHolder1_btnSave");
        private readonly By _elementRcpSaveSuccessfulMsg = By.Id("ContentPlaceHolder1_lblError");
        private readonly By _elementRcpTransplantAddButton = By.Id("ContentPlaceHolder1_btnTransplantAdd");
        private readonly By _elementSaveBtnFromEditTransplantEvent = By.XPath("//div[@id='dlgTransplantEvent']/following-sibling::div//span[text()='Save']");

        public void ClickOnAddRecipientBtn()
        {
            if (Actions.IsDisplayed(_elementRcpAddRecipientBtn))
            {
                Actions.Click(_elementRcpAddRecipientBtn);
            }

        }

        public void EnterAllFields(String RecipientID, String FirstName, String LastName, String MedicalRecord, String CRID, String RegistryID, String BirthDate)
        {
            ArrayList allFieldsName = new ArrayList();
            allFieldsName.Add(RecipientID);
            allFieldsName.Add(FirstName);
            allFieldsName.Add(LastName);
            allFieldsName.Add(MedicalRecord);
            allFieldsName.Add(CRID);
            allFieldsName.Add(RegistryID);
            allFieldsName.Add(BirthDate);
            int count = allFieldsName.Count;
            ArrayList allFieldsNameID = new ArrayList() { "PatientCode", "PatientFirstName", "PatientLastName", "MedRecordNum", "CRID", "RegistryId", "DOB" };
            for (int i = 0; i < allFieldsNameID.Count; i++)
            {
                By _elementFieldsName = By.Id("ContentPlaceHolder1_txt" + allFieldsNameID[i] + "");
                Thread.Sleep(2000);
                Actions.Click(_elementFieldsName);
                Actions.FindElement(_elementFieldsName).SendKeys(Convert.ToString(allFieldsName[i]));
                Console.WriteLine("Entered value : " + Convert.ToString(allFieldsName[i]) + " to " + allFieldsNameID[i] + " Field");
            }


            string[] dropDownListOptionsFromRecipient = new string[] { "Gender", "Ethnicity", "RecipientStatus" };

            for (int j = 0; j < dropDownListOptionsFromRecipient.Length; j++)
            {
                By _elementListOptionsFromRecipient = By.XPath("//select[@id='ContentPlaceHolder1_ddl" + dropDownListOptionsFromRecipient[j] + "']//option");
                ReadOnlyCollection<IWebElement> lstFromRecipient = Actions.FindElements(_elementListOptionsFromRecipient);
                IList<string> strList = new List<string>();

                for (int i = 0; i < lstFromRecipient.Count; i++)
                {
                    strList.Add(lstFromRecipient[i].Text);
                }

                String[] valuesFromDropDown = strList.ToArray();
                foreach (string strValues in valuesFromDropDown)
                {
                    Console.Write("Values present in drop drop list : " + strValues + ",");

                }
                Console.WriteLine();
                for (int i = 0; i < lstFromRecipient.Count; i++)
                {
                    if (lstFromRecipient.Count > 1)
                    {
                        Thread.Sleep(2000);
                        lstFromRecipient[2].Click();
                    }
                    else
                    {
                        Thread.Sleep(2000);
                        lstFromRecipient[1].Click();
                    }
                    Console.WriteLine(lstFromRecipient[i].Text + " is selected from the " + dropDownListOptionsFromRecipient[j] + " dropDown");
                }
            }
        }
        public void ClickOnSaveButton()
        {
            Actions.Click(_elementRcpSaveBtn);
            if (Actions.IsDisplayed(_elementRcpSaveSuccessfulMsg))
            {
                Console.WriteLine("Recipient created successfully");
            }
        }
        public void ClickOnAddaTransplantEvent()
        {
            Thread.Sleep(2000);
            if (Actions.IsEnabled(_elementRcpTransplantAddButton))
            {
                Actions.Click(_elementRcpTransplantAddButton);
                Console.WriteLine("Clicked on Add Transplant Event Button Successfully ");

            }
        }
        public string[] dropDownListOptionsFromAddaTransplantEventPage = new string[] { "transplantStatus", "ContentPlaceHolder1_ddlDonorType", "ddlTransplantABORh", "transplantCMVStatus", "transplantEBVStatus", "ContentPlaceHolder1_ddlTransplantDisease", "ContentPlaceHolder1_ddlSpecificDisease", "ContentPlaceHolder1_ddlDiseaseStatusAtTransplant" };



        public void EnterFieldsInAddaTransplantEvent()
        {

            for (int j = 0; j < dropDownListOptionsFromAddaTransplantEventPage.Length; j++)
            {
                Console.WriteLine("Performing the selection on : " + dropDownListOptionsFromAddaTransplantEventPage[j] + " drop down");
                By _elementListOptionsFromAddaTransplantEventPage = By.XPath("//select[@id='" + dropDownListOptionsFromAddaTransplantEventPage[j] + "']//option");
                Thread.Sleep(3000);
                ReadOnlyCollection<IWebElement> lstFromAddaTransplantEventPage = Actions.FindElements(_elementListOptionsFromAddaTransplantEventPage);
                IList<string> strList = new List<string>();

                for (int i = 0; i < lstFromAddaTransplantEventPage.Count; i++)
                {
                    strList.Add(lstFromAddaTransplantEventPage[i].Text);
                }
                Console.Write("Values present in drop drop list : " + strList + ",");

                String[] valuesFromDropDown = strList.ToArray();
                foreach (string strValues in valuesFromDropDown)
                {
                    Console.Write("Values present in drop drop list : " + strValues + ",");
                }
                Console.WriteLine();
                for (int i = 0; i < lstFromAddaTransplantEventPage.Count; i++)
                {
                    String strCheck = lstFromAddaTransplantEventPage[i].Text;
                    Thread.Sleep(1000);
                    if (strCheck == "-None-" || strCheck == "Unknown")
                    {
                        lstFromAddaTransplantEventPage[i + 1].Click();
                        Console.WriteLine(lstFromAddaTransplantEventPage[i + 1].Text + " is selected from the " + dropDownListOptionsFromAddaTransplantEventPage[j] + " dropDown");
                        break;
                    }
                    else
                    {
                        lstFromAddaTransplantEventPage[i].Click();
                        Console.WriteLine(lstFromAddaTransplantEventPage[i].Text + " is selected from the " + dropDownListOptionsFromAddaTransplantEventPage[j] + " dropDown");
                        break;

                    }
                }
            }
        }
        public void ClickOnSaveBtnFromEditTransplantEvent()
        {
            Actions.Click(_elementSaveBtnFromEditTransplantEvent);
            Console.WriteLine("Clicked on SAVE Button from Edit Transplant Event ");

        }

    }
}
