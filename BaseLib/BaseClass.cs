using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using static STA__Automation.BaseLib.Enums;


namespace STA__Automation.BaseLib

{


    public class BaseClass
    {
        #region BaseClass Common Variables
        public static IWebDriver driver;
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public static IWebDriver GetDriver()
        {
            return driver;
        }
        #endregion


        /// <summary>
        /// Function to Launch the browser according to the input browser extension 
        /// </summary>
        /// <param name="browser">Pass the browser</param>
        public static void LaunchBrowser(String browser)
        {
            String selectedBrowse = ConfigurationManager.AppSettings[browser];
            try
            {
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                string DownloadsfilePath = Path.Combine(projectPath, "Resources\\Downloads");

                if (driver == null)
                {

                    if (selectedBrowse == CommonConstants.CHROME)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--incognito");
                        options.AddArguments("disable-infobars");
                        options.AddArguments("--ignore-certificate-errors");
                        options.AddArguments("no-sandbox");
                        options.AddUserProfilePreference("download.default_directory", DownloadsfilePath);
                        options.AddUserProfilePreference("intl.accept_languages", "nl");
                        options.AddUserProfilePreference("disable-popup-blocking", "true");

                        driver = new ChromeDriver(options);
                        log.Info("Chrome browser invoked.");
                    }

                    else if (browser == CommonConstants.IE)
                    {
                        var options = new InternetExplorerOptions
                        {
                            IgnoreZoomLevel = true
                        };
                        driver = new InternetExplorerDriver(options);
                        log.Info("Internet Explorer browser invoked.");
                    }
                    else if (browser == CommonConstants.FIREFOX)
                    {

                        System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", "@C:\\Selenium\\geckodriver.exe");
                        driver = new FirefoxDriver();
                        log.Info("Firefox browser invoked.");

                    }
                    else
                    {
                        log.Info("The given browser is not supported.");
                    }
                    SetDriverMangerProperties();
                }
                
            }
            catch (Exception e) {
                log.Error(e.Message);
            }
        }


        /// <summary>
        /// Function to set the browser driver wait properties  
        /// </summary>

        private static void SetDriverMangerProperties()
        {
            driver.Manage().Window.Maximize();
            // driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CommonConstants.IMPLICITE_WAIT);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(CommonConstants.PAGE_LOAD_WAIT);
            driver.Manage().Timeouts().AsynchronousJavaScript=TimeSpan.FromSeconds(CommonConstants.LARGE_WAIT);
        }

        
        

    }

}
