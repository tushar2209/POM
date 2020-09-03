using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class CreateMarkerPage
    {

        public CreateMarkerPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Employee Code')]/../input")]
        public IWebElement EmployeeCode { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Gender')]/../input")]

        public IWebElement Gender { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Title')]/../input")]

        public IWebElement TitlePersonal { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'ForeName')]/../input")]

        public IWebElement ForeName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'SurName')]/../input")]

        public IWebElement SurName { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Adderess Line1')]/../input")]
        public IWebElement AdderessLine1 { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Address Line2')]/../input")]
        public IWebElement AdderessLine2 { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Address Line3')]/../input")]

        public IWebElement AdderessLine3 { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Address Line4')]/../input")]
        public IWebElement AdderessLine4 { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'PostCode')]/../input")]
        public IWebElement PostCode { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Country')]/../input")]
        public IWebElement Country { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Material Status')]/../input")]
        public IWebElement MaterialStatus { get; set; }

        [FindsBy(How = How.XPath,  Using ="//select[@class='w66 datedropdown form-control css-date daydropdown']")]
        public IWebElement DayDatePicker { get; set; }

        [FindsBy(How = How.XPath, Using ="//select[@class='w150 datedropdown form-control css-month monthdropdown']")]
        public IWebElement MonthDatePicker { get; set; }

        [FindsBy(How = How.XPath, Using ="//select[@class='w100  datedropdown form-control css-year yeardropdown']")]
        public IWebElement YearDatePicker { get; set; }

        [FindsBy(How = How.XPath, Using="input[id='MainContent_NextButton']")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Marker family name')]/../input")]

        public IWebElement Markerfamilyname { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Marker other name')]/../input")]

        public IWebElement Markerothername { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'School ID')]/../input")]

        public IWebElement SchoolID { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Mobile number')]/../input")]
        public IWebElement Mobilenumber { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Landline number')]/../input")]

        public IWebElement Landlinenumber { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Email address')]/../input")]

        public IWebElement Emailaddress { get; set; }

      
      



       


   

       

[FindsBy(How = How.XPath, Using ="//label[contains(text(),'Contract State Change Date')]/../div[1]/input[1]")]

        public IWebElement Contractstatechangedate { get; set; }



        [FindsBy(How = How.XPath, Using ="//label[text()='Title']/span/../../select")]

        public IWebElement Title { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Marker role']/span/../../select")]

        public IWebElement MarkerRole { get; set; }


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Preferred method of contact']/../../select")]

        public IWebElement preferdmodeofconatct { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Marker subject']/span/../../select")]

        public IWebElement MarkerSubject { get; set; }

        //label[text()='TPT marking?']/span/../../span/span/input[@type='radio']



        [FindsBy(How = How.XPath, Using = "//label[text()='TPT marking?']/span/../../span/span/input[@type='radio' and @value='Yes']")]

        public IWebElement TPTMarkingyes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='TPT marking?']/span/../../span/span/input[@type='radio' and @value='No']")]

        public IWebElement TPTMarkingNo { get; set; }



        [FindsBy(How = How.XPath, Using = "//label[text()='New marker?']/span/../../span/span/input[@type='radio'and @value='Yes']")]

        public IWebElement NewMarkeryes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='New marker?']/span/../../span/span/input[@type='radio'and @value='No']")]

        public IWebElement NewMarkerNo { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Previous role']/../select")]

        public IWebElement PreviosRole { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Capita role']/../select")]

        public IWebElement Capitarole { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Capita subject']/../select")]

        public IWebElement Capitasubject { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Contract state']/../select")]

        public IWebElement ContarctState { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[contains(text(), 'Employment Status')]/../input")]
        public IWebElement Employmentstatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Leaver')]/../input")]
        public IWebElement Leaver { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Branch')]/../input")]
        public IWebElement Branch { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'CostCenter')]/../input")]

        public IWebElement CostCenter { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Department')]/../input")]

        public IWebElement Department { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'RunGroup')]/../input")]
        public IWebElement RunGroup { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Default Cost Split')]/../input")]
        public IWebElement DefaultCostSplit { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'NI Number')]/../input")]
        public IWebElement NINumber { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'NI Letter')]/../input")]
        public IWebElement NILetter { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Frequency')]/../input")]
        public IWebElement Frequency { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Pay Method')]/../input")]
        public IWebElement PayMethod { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Bank Account No')]/../input")]
        public IWebElement BankAccountNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Bank Account Name')]/../input")]
        public IWebElement BankAccountName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Sort Code')]/../input")]
        public IWebElement SortCode { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Bank Name')]/../input")]
        public IWebElement BankName { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Bank Branch Name')]/../input")]
        public IWebElement BankBranchName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Building Society Reference')]/../input")]
        public IWebElement BuildingSocietyReference { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Autopay Reference')]/../input")]
        public IWebElement AutopayReference { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Paasport Number')]/../input")]
        public IWebElement PaasportNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Starting Declaration')]/../input")]
        public IWebElement StartingDeclaration { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Irregular Payment')]/../input")]
        public IWebElement IrregularPayment { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Omit From RTI')]/../input")]

        public IWebElement OmitFromRTI { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Payment to Non Indivisual')]/../input")]

        public IWebElement PaymenttoNonIndivisual { get; set; }

    }
}
