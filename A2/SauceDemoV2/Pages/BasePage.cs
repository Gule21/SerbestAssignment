using OpenQA.Selenium;
using SauceDemoLab.Utils;

namespace SauceDemoLab.Pages
{
    public class BasePage
    {
        public readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public Wait Wait => new Wait(_driver);
        public string BaseUrl => _baseUrl;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _baseUrl = "https://www.saucedemo.com";
        }
    }
}