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
    public sealed class Checkout
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        SauceDemoLoginPage LoginPage;
        ProductsPage productsPage;
        IWebDriver driver;
        YourShoppingCartPage cartPage;
        CheckoutOverviewPage checkoutOverviewPage;
        CheckoutInformationPage checkoutInformationPage;
        CheckoutCompletePage checkoutCompletePage;
        OrderConfirmationPage orderConfirmationPage;


        public Checkout(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            LoginPage = new SauceDemoLoginPage(driver);
            productsPage = new ProductsPage(driver);
            cartPage = new YourShoppingCartPage(driver);
            checkoutOverviewPage = new CheckoutOverviewPage(driver);
            checkoutInformationPage = new CheckoutInformationPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);
            orderConfirmationPage = new OrderConfirmationPage(driver);
        }

        [Given(@"I am logged in with (.*) and (.*)")]
        public void GivenIAmLoggedIn(string username, string password)
        {
            LoginPage.Open();
            LoginPage.EnterCredentials(username, password);
            LoginPage.Login();

        }

        [Given(@"I am adding the products in cart")]
        public void GivenIAmAddingTheProductsInCart()
        {
            productsPage.Open();
            productsPage.AddFirstProductToCart();
        }

        [When(@"my cart has items")]
        public void WhenMyCartHasItems()
        {
            Assert.IsTrue(cartPage.getCartItemCount().Equals("1"));
            cartPage.Open();
        }

        [Then(@"should be able to checkout")]
        public void ThenShouldBeAbleToCheckout()
        {
            checkoutOverviewPage.FinishCheckout();

        }

        [Then(@"fill in my information")]
        public void ThenFillInMyInformation()
        {
            checkoutInformationPage.FillOutPersonalInformation();
        }

        [Then(@"click on finish")]
        public void ThenClickOnFinish()
        {
            checkoutOverviewPage.CompleteCheckout();

        }

        [Then(@"Verify the message")]
        public void ThenVerifyTheMessage()
        {
            Assert.IsTrue(checkoutCompletePage.IsCheckedOut);
            Assert.IsTrue(orderConfirmationPage.IsCheckoutComplete);
        }

    }
}
