using OpenQA.Selenium;

namespace MagentoTestCases.PageObjects;

public class ProductPageObject
{
    private readonly IWebDriver _webDriver;
    
    private readonly  String[] _jackets = { "Proteus Fitness Jackshirt", "Montana Wind Jacket" };
    private readonly  String _pant = "Cronus Yoga Pant";

    public ProductPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private IWebElement MenLink => _webDriver.FindElement(By.LinkText("Men"));
    private IWebElement JacketsLink => _webDriver.FindElement(By.LinkText("Jackets"));
    private IWebElement PantsLink => _webDriver.FindElement(By.LinkText("Pants"));
    private IWebElement JacketSize => _webDriver.FindElement(By.CssSelector("#option-label-size-143-item-166"));
    private IWebElement PantSize => _webDriver.FindElement(By.CssSelector("#option-label-size-143-item-175"));
    private IWebElement Colour => _webDriver.FindElement(By.CssSelector("#option-label-color-93-item-49"));
    private IWebElement AddToCart => _webDriver.FindElement(By.Id("product-addtocart-button"));

    public void AddMenJackets()
    {
        for (int i = 0; i < 2; i++)
        {
            MenLink.Click();
            JacketsLink.Click();
            _webDriver.FindElement(By.LinkText(_jackets[i])).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            JacketSize.Click();
            Colour.Click();
            AddToCart.Click();
            Thread.Sleep(3000);
        }
    }

    public void AddMenPant()
    {
        MenLink.Click();
        PantsLink.Click();
        _webDriver.FindElement(By.LinkText(_pant)).Click();
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        PantSize.Click();
        Colour.Click();
        AddToCart.Click();
        Thread.Sleep(3000);
    }
}