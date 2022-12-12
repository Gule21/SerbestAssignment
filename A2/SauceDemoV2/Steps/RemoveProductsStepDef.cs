using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoLab.Drivers;
using SauceDemoLab.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SauceDemoV2.Steps
{
    [Binding]
    public sealed class RemoveProductsStepDef
    {
        private readonly ScenarioContext _scenarioContext;
        SauceDemoLoginPage LoginPage;
        ProductsPage productsPage;
        IWebDriver driver;
        YourShoppingCartPage cartPage;
        public RemoveProductsStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            LoginPage = new SauceDemoLoginPage(driver);
            productsPage = new ProductsPage(driver);
            cartPage = new YourShoppingCartPage(driver);

        }

        [Given(@"I am logging in with (.*) and (.*)")]
        public void GivenIAmLoggedInWithAnd(string username, string password)
        {
            LoginPage.Open();
            LoginPage.EnterCredentials(username, password);
            LoginPage.Login();
        }

        [When(@"I am on the products page")]
        public void WhenIAmOnTheProductsPage()
        {
            Assert.IsTrue(driver.Url.Contains("inventory"));
        }

        [Then(@"I am able to remove the products from the cart")]
        public void ThenIAmAbleToRemoveTheProductsFromTheCart()
        {
            productsPage.AddFirstProductToCart();
            Assert.IsTrue(cartPage.getCartItemCount().Equals("1"));
            cartPage.Open();
            cartPage.removeItem();
        }

        [Then(@"I can see no product in my cart")]
        public void ThenICanSeeNoProductInMyCart()
        {
            productsPage.Open();
            Assert.IsTrue(cartPage.getCartItemCount().Equals("0"));
        }

        [Then(@"Log out")]
        public void ThenLogOut()
        {
            productsPage.Logout();
        }




    }
}
