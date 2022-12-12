using OpenQA.Selenium;

namespace SauceDemoLab.Pages
{
    internal class CheckoutInformationPage : BasePage
    {
        public CheckoutInformationPage(IWebDriver driver) : base(driver)
        {
        }

        private By CartCheckoutButtonLocator => By.Id("continue");

        public CheckoutOverviewPage FillOutPersonalInformation()
        {
            Wait.UntilIsVisibleById("first-name").SendKeys("firstName");
            _driver.FindElement(By.Id("last-name")).SendKeys("lastName");
            _driver.FindElement(By.Id("postal-code")).SendKeys("zip");
            _driver.FindElement(CartCheckoutButtonLocator).Click();
            return new CheckoutOverviewPage(_driver);
        }
    }
}