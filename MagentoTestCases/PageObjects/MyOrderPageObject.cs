using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MagentoTestCases.PageObjects;

public class MyOrderPageObject
{
    private readonly IWebDriver _webDriver;
    
    public MyOrderPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private IWebElement CustomerToggleMenu =>
        _webDriver.FindElement(By.CssSelector("button[data-action='customer-menu-toggle']"));

    private IWebElement MyAccountLink => _webDriver.FindElement(By.LinkText("My Account"));
    private IWebElement MyOrdersLink => _webDriver.FindElement(By.LinkText("My Orders"));
    private IWebElement FirstOrderInTable => _webDriver.FindElement(By.CssSelector("td[class='col id']"));
    
    public void NavigateToMyOrders()
    {
        var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
        CustomerToggleMenu.Click();
        MyAccountLink.Click();
        wait.Until(drv => drv.FindElement(By.CssSelector("h1[class='page-title']")));
        MyOrdersLink.Click();
        wait.Until(drv => drv.FindElement(By.Id("my-orders-table")));
        
    }
    
    public String GetTableOrderNumber()
    {
        var tableOrderNumber = FirstOrderInTable.GetDomProperty("innerText");
        return tableOrderNumber;
    }
}