using OpenQA.Selenium;

namespace MagentoTestCases.PageObjects;

public class LoginPageObject
{
    private readonly  string _email = "testing26@gmail.com";
    private readonly  string _password = "testing123#";
    private readonly IWebDriver _webDriver;

    public LoginPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }
    
    private IWebElement AuthLink => _webDriver.FindElement(By.ClassName("authorization-link"));
    private IWebElement EmailField => _webDriver.FindElement(By.Id("email"));
    private IWebElement PasswordField => _webDriver.FindElement(By.Id("pass"));
    private IWebElement SubmitButton =>_webDriver.FindElement(By.Id("send2"));

    public void ClickAuthLink()
    {
        AuthLink.Click();
    }

    public void EnterEmailField()
    {
        EmailField.SendKeys(_email);
    }

    public void EnterPasswordField()
    {
        PasswordField.SendKeys(_password);
    }

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }
    
}