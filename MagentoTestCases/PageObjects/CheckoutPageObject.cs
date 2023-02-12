using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MagentoTestCases.PageObjects;

public class CheckoutPageObject
{
    private readonly IWebDriver _webDriver;

    private readonly  String[] _productNamesToCheckout = { "Proteus Fitness Jackshirt", "Montana Wind Jacket" , "Cronus Yoga Pant"};
    private readonly  String[] _productPricesToCheckout = { "$45.00", "$49.00", "$48.00" };
    public CheckoutPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }
    private WebDriverWait Wait => new (_webDriver, TimeSpan.FromSeconds(20));
    private IWebElement CartIcon => _webDriver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/a"));
    private IWebElement ProceedToCheckout => _webDriver.FindElement(By.Id("top-cart-btn-checkout"));
    private IWebElement OrderSummary => _webDriver.FindElement(By.ClassName("opc-block-summary"));
    private IWebElement ExpandOrderSummary => _webDriver.FindElement(By.CssSelector("#opc-sidebar > div.opc-block-summary > div > div.title > strong > span:nth-child(2)"));
    private IWebElement SelectedShippingAddress => _webDriver.FindElement(By.CssSelector("div[class='shipping-address-item selected-item']"));
    private IWebElement SelectTableRate => _webDriver.FindElement(By.XPath("//*[@id='label_method_bestway_tablerate']"));
    private IWebElement NextButton => _webDriver.FindElement(By.XPath("//*[@id='shipping-method-buttons-container']/div/button"));
    private IWebElement OrderNumber => _webDriver.FindElement(By.CssSelector("a[class='order-number']"));
    public void NavigateToCheckout()
    {
        CartIcon.Click();
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        ProceedToCheckout.Click();
    }
    
    public void VerifyOrderSummary()
    {
        var productItems = _webDriver.FindElements(By.ClassName("product-item-name"));
        var productPrices = _webDriver.FindElements(By.ClassName("cart-price"));

        int counter = 0;
        Assert.True(OrderSummary.Displayed);
        Wait.Until(drv => drv.FindElement(By.CssSelector("#opc-sidebar > div.opc-block-summary > div > div.title > strong > span:nth-child(2)")).Displayed);
        WebElement webElement1 = (WebElement)ExpandOrderSummary;
        ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", webElement1);
        
        foreach(WebElement we in productItems)
        {
            var productName=we.GetDomProperty("innerText");
            Assert.True(productName.Equals(_productNamesToCheckout[counter++]));
        }
        counter = 0;

        foreach (WebElement we in productPrices)
        {
            var productPrice = we.GetDomProperty("innerText");
            Assert.True(productPrice.Equals(_productPricesToCheckout[counter++]));
        }
    }
    
    public void SelectValidAddress()
    {
        Assert.True(SelectedShippingAddress.Displayed);
    }
    
    public void SelectDeliveryMethod()
    {
        SelectTableRate.Click();
    }
    
    public void NavigateToPaymentReview()
    {
        NextButton.Click();
        Wait.Until(drv => drv.FindElement(By.Id("checkout-payment-method-load")));
    }
    
    public void PlaceOrder()
    {
        Wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Place Order']")));
        WebElement webElement = (WebElement)_webDriver.FindElement(By.CssSelector("button[class='action primary checkout']"));
        ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", webElement);

        Wait.Until(drv => drv.FindElement(By.CssSelector("h1[class='page-title']")));
    }
    
    public String GetOrderNumber()
    {
        var submittedOrderNumber = OrderNumber.GetDomProperty("innerText");
        return submittedOrderNumber;
    }
    
}