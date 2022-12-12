using OpenQA.Selenium;
using SauceDemoLab.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        private readonly ScenarioContext _scenarioContext;

        public HookInit(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Quit browser");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}
