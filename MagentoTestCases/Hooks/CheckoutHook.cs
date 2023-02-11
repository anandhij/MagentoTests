using MagentoTestCases.Drivers;
using OpenQA.Selenium;

namespace MagentoTestCases.Hooks;

[Binding]
public sealed class CheckoutHook
{
    private readonly ScenarioContext _scenarioContext;

    public CheckoutHook(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
        _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("Selenium webdriver quit");
        _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
    }
}