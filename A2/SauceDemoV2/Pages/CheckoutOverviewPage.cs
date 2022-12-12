using OpenQA.Selenium;
using SauceDemoLab.Elements;

namespace SauceDemoLab.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        public CheckoutOverviewPage(IWebDriver driver) : base(driver)
        {
        }
        public CartComponent Cart => new CartComponent(_driver);

        public OrderConfirmationPage FinishCheckout()
        {
            Wait.UntilIsVisibleByCss("[class='shopping_cart_link']").Click();
            _driver.FindElement(By.Id("checkout")).Click();
            return new OrderConfirmationPage(_driver);
        }

        internal CheckoutOverviewPage Open()
        {
            //TODO duplication here with the URL. Also happening in YourShoppingCartPage
            _driver.Navigate().GoToUrl($"{BaseUrl}/checkout-step-two.html");
            return this;
        }

        public OrderConfirmationPage CompleteCheckout()
        {
            _driver.FindElement(By.Id("finish")).Click();
            return new OrderConfirmationPage(_driver);
        }
    }
}