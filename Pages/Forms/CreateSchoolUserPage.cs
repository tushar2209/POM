using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class CreateSchoolUserPage
    {
        public CreateSchoolUserPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f05c0ff0f4aa46f5a01037d9ce2d4c3405b9170921a54e57beb3ddf2d98103fe_0")]
        public IWebElement UpdateContactRadio { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f05c0ff0f4aa46f5a01037d9ce2d4c3405b9170921a54e57beb3ddf2d98103fe_1")]
        public IWebElement CreateNewContactRadio { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_NextButton")]
        public IWebElement NextBtn { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_BackButton")]
        public IWebElement BackBtn { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e66caf63f4a2dd6437ca489275311a86fa5_REPEAT1")]
        public IWebElement TitleDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e66fce3685ee61748f99481413ed60a0437_REPEAT1")]
        public IWebElement NewContactFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e66d2d04e804a6445bc9dbbc9a1e8e8430c_REPEAT1")]
        public IWebElement NewContactSurname { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e669ca922e0cc6e4663a17e349a8683cda6_REPEAT1")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e669d1b1ad838a044c98bf86fe4e41469b6_REPEAT1")]
        public IWebElement EmailAdd { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e66c1382454b46544b4baa43eecb55cda85_REPEAT1")]
        public IWebElement ConfirmEmailAdd { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e6654657305c8744a0c89cf03e27f0a1a0c_REPEAT1")]
        public IWebElement TelephoneNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='content-container-response']/div[@class='formQuestion']")]
        public IWebElement SubmissionMessage { get; set; }

        /////////////////////Checkbox to Select Portal Contact Role///////////////////////////////////

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e66fbbb877c00c94feba0161b83950571a2_REPEAT1_0")]
        public IWebElement HeadTeacherCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e66fbbb877c00c94feba0161b83950571a2_REPEAT1_1")]
        public IWebElement SuperUserCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_36e1c264a99b460a8285dc3e555f5e66fbbb877c00c94feba0161b83950571a2_REPEAT1_2")]
        public IWebElement NormalUserCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_SubmitButton")]
        public IWebElement FormSubmitBtn { get; set; }
    }
}
