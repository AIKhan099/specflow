using TechTalk.SpecFlow;
//using Allure.Commons;
using BoDi;
using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using ERM.StepDefinitions;

namespace ERM
{
    [Binding]
    //[TestFixture]
    //[AllureNUnit]
    public sealed class Hooks1
    {
        // taking files in
        loginPageObjects loginObjects = new loginPageObjects();
        // taken
        //static readonly IWebDriver driver ;
        private readonly IObjectContainer _container;
        //private readonly IWebDriver driver;
        public Hooks1(IObjectContainer container)
        {
            _container = container;
             //driver = _driver;
        }

        //private readonly IWebDriver driver;
        //public Hooks1(IWebDriver driver)
        //{
        //    driver = driver;
        //}

        [AfterScenario("@tag1", Order = 0)]
        public void BeforeScenarioWithTag1()
        {
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping
            Console.WriteLine("This is the after scenario tag");
        }


        [BeforeScenario(Order = 0)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--enable-javascript");

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver(options);
            _container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Window.Maximize();
            


        }




        
       




        [AfterScenario(Order = 2)]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                Console.WriteLine("Quit the browser");
                driver.Quit();
            }

        }
    }
}