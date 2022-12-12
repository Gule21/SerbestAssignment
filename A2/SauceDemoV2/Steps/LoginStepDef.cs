using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoLab.Drivers;
using SauceDemoLab.Pages;
using System;
using TechTalk.SpecFlow;

namespace SauceDemoLab.Steps
{
    [Binding]
    public sealed class LoginStepDef
    {
        private readonly ScenarioContext _scenarioContext;
        IWebDriver driver;
        SauceDemoLoginPage LoginPage;
        ProductsPage productsPage;

        public LoginStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            LoginPage = new SauceDemoLoginPage(driver);
            productsPage = new ProductsPage(driver);
        }

        [Given(@"I navigate to the application login")]
        public void GivenINavigateToTheApplicationLogin()
        {
            LoginPage.Open();

        }

        [Given(@"I typed the (.*) and (.*)")]
        public void GivenITypedTheAnd(string username, string password)
        {
            LoginPage.EnterCredentials(username, password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {

            LoginPage.Login();
        }

        [Then(@"I should see the Products page")]
        public void ThenIShouldSeeTheProductsPage()
        {
            Assert.IsTrue(driver.Url.Contains("inventory"));
        }

        [When(@"I will logout")]
        public void WhenIWillLogout()
        {
            productsPage.Logout();
        }


        [Then(@"I should see the Error message")]
        public void ThenIShouldSeeTheError()
        {
            int errormsg = driver.FindElements(By.XPath("//h3[@data-test='error']")).Count;
            Assert.That(errormsg.Equals(1));
        }

    }
}
