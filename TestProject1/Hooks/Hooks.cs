using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestProject1.Utilities;
using BoDi;
using System.IO;
using TechTalk.SpecFlow.Infrastructure;

namespace TestProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private IObjectContainer _IObjectContainer;
        private Browser _browser;        
        public static string ScreenshotPath;
        public IWebDriver driver { get; set; }
        private static ScenarioContext _scenarioContext;
        public static string reportPath = CommonFuntions.GetProjectPathOfFolder("TestReports");
        public static string SubFolderName;

        private ISpecFlowOutputHelper _specFlowOutputHelper;


        public Hooks(IObjectContainer objectContainer, Browser browser, ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _IObjectContainer = objectContainer;
            _browser = browser;
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;

        }



        [BeforeTestRun]
        public static void InitializeReport()
        {

            SubFolderName = "AutomationResults" + DateTime.Today.ToString("ddMMyyyy") + "_" + DateTime.Now.ToShortTimeString().Replace(':', '_').Replace(" ", "_");
            Directory.CreateDirectory(reportPath + @"\" + SubFolderName + @"\");
            Directory.CreateDirectory(reportPath + @"\" + SubFolderName + @"\" + @"\" + "ScreenShots" + @"\");
            ScreenshotPath = reportPath + @"\" + SubFolderName + @"\" + @"\" + "ScreenShots" + @"\";
        }

      


       
        
        [AfterStep]
        public void InsertReportingSteps()
        {
            if (_scenarioContext.TestError != null)
            {
                #region Error Message 
                string Failmsg = "<br><b>Message:</b> " + _scenarioContext.TestError.Message +
                                "<br><b>Inner Exception:</b> " + _scenarioContext.TestError.InnerException +
                                 "<br><b>Stack Trace: </b> " + _scenarioContext.TestError.StackTrace;
                #endregion

                #region ScreenShot

                Random rad = new Random();
                string Imgname = "image" + rad.Next(0, 1000000);

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(ScreenshotPath + Imgname);

                string f = @"./Screenshots/" + Imgname;
                _specFlowOutputHelper.WriteLine(Failmsg);
                _specFlowOutputHelper.AddAttachment(f);
                #endregion

            }

           




        }



        [BeforeScenario]
        public void BeforeScenario()
        {
            if (driver == null)
            {
                driver = _browser.GetBrowser();

            }

            _IObjectContainer.RegisterInstanceAs(driver);

        }

        [AfterScenario]
        public void AfterScenario()
        {

            driver.Close(); driver.Quit();
            _browser.driver = null;
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //Random rad = new Random();
            //string Filename = "Report_" + rad.Next(0, 10000);
            //var batFile = CommonFuntions.GetProjectPathOfFolder("BatchFiles") + "RunPgm.bat";
            //var p1 = AppContext.BaseDirectory;
            //var p2 = Assembly.GetExecutingAssembly().GetName().Name + ".dll";
            //var p3 = reportPath + @"\" + SubFolderName + @"\" + Filename + ".html";

            //var process = new Process();
            //var startinfo = new ProcessStartInfo(batFile);
            //startinfo.Arguments = string.Format("{0} {1} {2}", p1, p2, p3);
            //startinfo.UseShellExecute = false;
            //process.StartInfo = startinfo;
            //process.Start();

        }


    }
}

