using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace STA__Automation.Pages.Portal
{
   public class MyActivityPage 
    {
        #region MyActivityPage Constructor
        public MyActivityPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Page Objects
        [FindsBy(How = How.Id, Using = "headingOne")]
        public IWebElement OutstandingActivity { get; set; }

        [FindsBy(How = How.Id, Using = "headingThree")]
        public IWebElement CompletedActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='headingFour']")]
        public IWebElement AvailableActivity { get; set; }

        [FindsBy(How = How.PartialLinkText, Using ="Special consideration application")]
        public IWebElement SpecialConsideration_lnk { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='headingFour']//span[@class='badge']")]
        public IWebElement BadgeAvailableActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(),'Key stage 2 test paper')]//following::div[@class='calendar'])[last()]")]
        public IWebElement OutstandingFormCreateDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Key stage 2 test order confirmation')]//following::div[@class='calendar']")]
        public IWebElement CompletedFormCreateDate { get; set; }

        

        [FindsBy(How = How.PartialLinkText, Using = "Key stage 2 test paper")]
        public IWebElement KS2FormLink { get; set; }

        [FindsBy(How = How.Id, Using = "edit_link")]
        public IList<IWebElement> AllLinks { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='×']")]
        public IList<IWebElement> CloseTabs { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='activityDescText']")]
        public IWebElement testing { get; set; }

     
        [FindsBy(How = How.LinkText, Using = "KS2 modified test materials order")]
        public IWebElement ModifiedKS2 { get; set; }

        // Notification Scribe Transcript From Link
        [FindsBy(How = How.PartialLinkText, Using = "Scribe/transcript or other aid notification")]
        public IWebElement NotificationScribeTranscriptFromLink { get; set; }

        // TimeTable variation Application Link
        [FindsBy(How = How.LinkText, Using = "Timetable variation application")]
        public IWebElement TimeTableVariationAppLink { get; set; }

        // Early Opening Application Link
        [FindsBy(How = How.LinkText, Using = "Early opening application")]
        public IWebElement EarlyOpeningAppLink { get; set; }

        // Confirm holiday dates Application Link
        [FindsBy(How = How.PartialLinkText, Using = "Confirm holiday dates")]
        public IWebElement ConfirmHolidayDatesAppLink { get; set; }

        // Application for additional time Application Link
        [FindsBy(How = How.PartialLinkText, Using = "Additional time application")]
        public IWebElement ApplicationForAdditionalTimeLink { get; set; }

        //  Application for special consideration Link  // Dev test= Application for special consideration and QA =Special consideration application
        [FindsBy(How = How.PartialLinkText, Using = "Special consideration application")]
        public IWebElement ApplicationForSpecialConsiderationLink { get; set; }


        //  Notification of pupil cheating Link
        [FindsBy(How = How.PartialLinkText, Using = "Notification of pupil cheating")]
        public IWebElement NotificationOfPupilCheatingLink { get; set; }


        // Key stage 1 test paper order Link
        [FindsBy(How = How.PartialLinkText, Using = "KS1 test paper order")]
        public IWebElement KS1TestOrderLink { get; set; }

        
        // Modifyed Key stage 1 test paper order Link
        [FindsBy(How = How.PartialLinkText, Using = "KS1 modified test materials order")]
        public IWebElement ModifyedKS1TestOrderLink { get; set; }

        // Key stage 2 test paper order Link
        [FindsBy(How = How.PartialLinkText, Using = "KS2 test paper order")]
        public IWebElement KS2TestPaperOrderLink;

        // Key stage 1 test paper order Link
        [FindsBy(How = How.PartialLinkText, Using = "Maintain school organisation details")]
        public IWebElement ChangeOrgDetailsLink { get; set; }

        

        // Key stage 1 test paper order Link
        [FindsBy(How = How.PartialLinkText, Using = "Maintaining local authority selection")]
        public IWebElement MantainLASelection { get; set; }

       // Application for compensatory marks for spelling
        [FindsBy(How = How.PartialLinkText, Using = "Compensatory marks application")]
        public IWebElement CompencentoryMarksLink { get; set; }

        //Phonics zero order form
        [FindsBy(How = How.PartialLinkText, Using = "Phonics zero order form")]
        public IWebElement PhonicsZeroOrderFormLink { get; set; }

        //Manage Pupil Registration form
        [FindsBy(How = How.PartialLinkText, Using = "Manage pupil registration")]
        public IWebElement ManagePupilRegistrationFormLink { get; set; }


        [FindsBy(How = How.PartialLinkText, Using = "Complaint lodgement")]
        public IWebElement ComplaintLodgement { get; set; }


        [FindsBy(How = How.PartialLinkText, Using = "Scanning exception")]
        public IWebElement Scanningexception  { get; set; }



        [FindsBy(How = How.PartialLinkText, Using = "Scanning resolution")]
        public IWebElement ScanningResolution { get; set; }


        public string editLinks = "//*[contains(text(),'$$')]/../../..//a[@id='edit_link']";
        #endregion
                       

        //School portal contacts management form
        [FindsBy(How = How.PartialLinkText, Using = "School portal contacts management")]
        public IWebElement SchoolPortlContactMangFromLink { get; set; }

        //View KS1 test material form
        [FindsBy(How = How.PartialLinkText, Using = "View KS1 test material")]
        public IWebElement ViewKS1TestMaterialFromLink{ get; set; }

        //View KS2 test material form
        [FindsBy(How = How.PartialLinkText, Using = "View KS2 test material")]
        public IWebElement ViewKS2TestMaterialFromLink { get; set; }

        //View Phonic test material form
        [FindsBy(How = How.PartialLinkText, Using = "View Phonics test material")]
        public IWebElement ViewPhonicsTestMaterialFromLink { get; set; }
        //Marker Traning Confirmation form 
        [FindsBy(How = How.PartialLinkText, Using = "Training confirmation")]
        public IWebElement MarkerTraningConfirmationFormLink { get; set; }

        //SQAPortalContactFormLink form 
        [FindsBy(How = How.PartialLinkText, Using = "")]
        public IWebElement SQAPortalContactFormLink { get; set; }




        //View KS2 headteacher's declaration  form
        [FindsBy(How = How.PartialLinkText, Using = "KS2 headteacher's declaration form")]
        public IWebElement KS2headteacherdeclarationform { get; set; }

        //View teacher assessment test material form
        [FindsBy(How = How.PartialLinkText, Using = "View teacher assessment test material")]
        public IWebElement ViewTeacherAssessmentTestMaterial { get; set; }



    }
}
