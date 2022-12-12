using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoLab.Drivers;
using SauceDemoLab.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SauceDemoV2.Steps
{
    [Binding]
    public sealed class AddProductsStepDef
    {      
        private readonly ScenarioContext _scenarioContext;
        SauceDemoLoginPage LoginPage;
        ProductsPage productsPage;
        IWebDriver driver;
        YourShoppingCartPage cartPage;


        public AddProductsStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            LoginPage = new SauceDemoLoginPage(driver);
            productsPage = new ProductsPage(driver);
            cartPage = new YourShoppingCartPage(driver);
        }

        [Given(@"I am logged in the application with (.*) and (.*)")]
        public void GivenIAmLoggedInTheApplicationWithAnd(string username, string password)
        {
            LoginPage.Open();
            LoginPage.EnterCredentials(username, password);
            LoginPage.Login();
        }


        [When(@"I am on the product page")]
        public void WhenIAmOnTheProductPage()
        {
            Assert.IsTrue(driver.Url.Contains("inventory"));
        }

        [Then(@"I am able to add the products to the cart")]
        public void ThenIAmAbleToAddTheProductsToTheCart()
        {
            productsPage.AddFirstProductToCart();
        }

        [Then(@"I can see product in my cart")]
        public void ThenICanSeeProductInMyCart()
        {
            Assert.IsTrue(cartPage.getCartItemCount().Equals("1"));
        }


        [Then(@"Logout")]
        public void ThenLogout()
        {
            productsPage.Logout();
        }

    }
}
