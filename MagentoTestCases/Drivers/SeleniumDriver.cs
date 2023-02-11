using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MagentoTestCases.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://magento.softwaretestingboard.com/";
            
            //Set the driver
            _scenarioContext.Set(_driver, "WebDriver");
            
            _driver.Manage().Window.Maximize();

            return _driver;
        }

    }
}
