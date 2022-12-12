using System.Collections.Generic;
using System.Reflection;
using System.Data.Common;
using OpenQA.Selenium;
using SauceDemoLab.Utils;

namespace SauceDemoLab.Pages
{
    public class SauceDemoLoginPage : BasePage
    {
        public SauceDemoLoginPage(IWebDriver driver) : base(driver)
        {
        }

        private By _loginButtonLocator = By.Id("login-button");
        public bool IsLoaded => new Wait(_driver, _loginButtonLocator).IsVisible();
        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(_loginButtonLocator);
        private readonly By _usernameLocator = By.Id("user-name");
        public IWebElement UsernameField => _driver.FindElement(_usernameLocator);

        public SauceDemoLoginPage Open()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            return this;
        }

        public void EnterCredentials(string username, string password)
        {
            var usernameField = Wait.UntilIsVisible(_usernameLocator);
            usernameField.SendKeys(username);
            PasswordField.SendKeys(password);
        }

        public void Login()
        {
            LoginButton.Click();
        }
        public ProductsPage CheckProductPage()
        {
            return new ProductsPage(_driver);
        }
    }
}