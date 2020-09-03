using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.BussinessLib
{
    class OutBoundCustomerContactLib : BaseTestClass
    {
        public static OutBoundCustomerContactPage outBoundCustomerContactPage;
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;


        /**
         * Metod to set up pre condition for test case.
         **/
        public void SetUpPreCondition()
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            log.Info("Test method setup started");
            InitialisePageObjects();
            comFunc = new CommonFunctions();

        }

        public void InitialisePageObjects()
        {
            outBoundCustomerContactPage = new OutBoundCustomerContactPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        public void FillOutBoundCustomerContactForm(string DialedNumber, string ContactName, string ContactNumber, string OutBoundCallOutCome, bool scheduleCallback, string NameOfPersonToCall, string TelePhNumToCall, string DateOfFollowUpToCall, string TimeOfFollowUpToCall, string EmailForFollowup, string AgentNote)
        {

            seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.DialedNumbers[0], DialedNumber);
            seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.ContactName, ContactName);
            seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.PreferredNumber, ContactNumber);
            seleniumFunc.SelectValueFromDropDwn(outBoundCustomerContactPage.OutBondCallOutcomeDropdwon, OutBoundCallOutCome);

            // Schedule Call back Yes section details
            if (scheduleCallback)
            {
                seleniumFunc.WaitAndClickOnElement(outBoundCustomerContactPage.ScheduleCallbackRadiobtns[0]);
                seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.NameOfPersonToCallTextBox, NameOfPersonToCall);

                seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.TelePhNumToCallTextBox, TelePhNumToCall);
                comFunc.SelectDateFromDatePicker(outBoundCustomerContactPage.DateOfFollowUpToCall[0], DateOfFollowUpToCall);

                seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.TimeOfFollowUpToCallTextbox, TimeOfFollowUpToCall);

            }
            else
                seleniumFunc.WaitAndClickOnElement(outBoundCustomerContactPage.ScheduleCallbackRadiobtns[1]);

            seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.EmailForFollowup, EmailForFollowup);

            seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.AgentNotesTextArea, AgentNote);

        }

        public void AddNewUploadDocument(string UploadFileName, string description)
        {
            seleniumFunc.WaitAndClickOnElement(outBoundCustomerContactPage.AddBtn);
            comFunc.UploadDocuments(UploadFileName, outBoundCustomerContactPage.UploadFile[0]);
            seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.DescriptionTestBox[0], description);
        }

        public void CheckCallBackFormPrepopulatedFields(string NameOfPersonToCall, string TelePhNumToCall, string DateOfFollowUpToCall, string TimeOfFollowUpToCall, string EmailForFollowup)
        {

            VerifyIsEquals(comFunc.GetReqFromatDate(DateOfFollowUpToCall,"dd/MM/yyyy") , seleniumFunc.GetAttributeValue(outBoundCustomerContactPage.PrePopulatedDetails[0], "value"), "Check 'Date of follow up call' details on call back form.");
            VerifyIsEquals(TimeOfFollowUpToCall, seleniumFunc.GetAttributeValue(outBoundCustomerContactPage.PrePopulatedDetails[1], "value"), "Check 'Time of follow up call' details on call back form.");
            VerifyIsEquals(NameOfPersonToCall, seleniumFunc.GetAttributeValue(outBoundCustomerContactPage.PrePopulatedDetails[2], "value"), "Check 'Name Of Person To Call' details on call back form.");
            VerifyIsEquals(TelePhNumToCall, seleniumFunc.GetAttributeValue(outBoundCustomerContactPage.PrePopulatedDetails[3], "value"), "Check 'Telephone number to call'  details on call back form.");
            VerifyIsEquals(EmailForFollowup, seleniumFunc.GetAttributeValue(outBoundCustomerContactPage.PrePopulatedDetails[4], "value"), "Check 'Email address' details on call back form.");

        }

        public void FillCallBackForm(bool CallBackRequired, string DateOfFollowUpToCall, string TimeOfFollowUpToCall, string AgentNote)
        {
            if (CallBackRequired)
            {
                seleniumFunc.WaitAndClickOnElement(outBoundCustomerContactPage.OutcomeRadioBtns[1]);
                seleniumFunc.WaitForPageToLoad();
                comFunc.SelectDateFromDatePicker(outBoundCustomerContactPage.DateOfFollowUpToCall[3], DateOfFollowUpToCall);
                seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.TimeOfFollowUpToCallTextbox, TimeOfFollowUpToCall);
                seleniumFunc.WaitAndEnterText(outBoundCustomerContactPage.AgentNotesTextArea, AgentNote + 2);

            }
            else
                seleniumFunc.WaitAndClickOnElement(outBoundCustomerContactPage.OutcomeRadioBtns[0]);


        }
    }
}
