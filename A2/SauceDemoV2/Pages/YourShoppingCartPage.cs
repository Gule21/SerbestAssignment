using OpenQA.Selenium;
using SauceDemoLab.Elements;

namespace SauceDemoLab.Pages
{
    internal class YourShoppingCartPage : BasePage
    {
        public YourShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public CartComponent Cart => new CartComponent(_driver);

        internal CheckoutInformationPage Checkout()
        {
            Wait.UntilIsVisibleByCss("a[class='btn_action checkout_button']").Click();
            return new CheckoutInformationPage(_driver);
        }

        internal YourShoppingCartPage Open()
        {
            _driver.Navigate().GoToUrl($"{BaseUrl}/cart.html");
            return this;
        }

        public string getCartItemCount()
        {
            string itemCount;
            if (_driver.FindElements(By.XPath("//span[@class='shopping_cart_badge']")).Count > 0)
            {
                itemCount = _driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']")).Text;
            }
            else
                itemCount = "0";

            return itemCount;
        }

        public void removeItem()
        {
            _driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();
        }

        public void continueShopping()
        {
            _driver.FindElement(By.Id("continue-shopping")).Click();
        }
    }
}