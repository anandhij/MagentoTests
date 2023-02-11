using MagentoTestCases.Drivers;
using MagentoTestCases.PageObjects;
using NUnit.Framework;

namespace MagentoTestCases.Steps;

[Binding]
public class CheckoutSteps
{
    private readonly LoginPageObject _loginPageObject;

    private readonly ProductPageObject _productPageObject;
    
    private readonly CheckoutPageObject _checkoutPageObject;
    
    private readonly MyOrderPageObject _myOrderPageObject;

    private String _submittedOrderNumber;

    private String _tableOrderNumber;

    public CheckoutSteps(ScenarioContext scenarioContext)
    {
        var driver = scenarioContext.Get<SeleniumDriver>("SeleniumDriver").SetUp();
        _loginPageObject = new LoginPageObject(driver);
        _productPageObject = new ProductPageObject(driver);
        _checkoutPageObject = new CheckoutPageObject(driver);
        _myOrderPageObject = new MyOrderPageObject(driver);
    }
    
    /// <summary>
    /// //New code
    /// </summary>

    [Given(@"the registered user logins")]
    public void GivenTheRegisteredUserLogins()
    {
        _loginPageObject.ClickAuthLink();
        _loginPageObject.EnterEmailField();
        _loginPageObject.EnterPasswordField();
        _loginPageObject.ClickSubmit();
    }

    [When(@"the user adds two Men jackets and one Men pant to the cart")]
    public void WhenTheUserAddsTwoMenJacketsAndOneMenPantToTheCart()
    {
        _productPageObject.AddMenJackets();
        _productPageObject.AddMenPant();
    }

    [When(@"proceeds to the checkout")]
    public void WhenProceedsToTheCheckout()
    {
        _checkoutPageObject.NavigateToCheckout();
    }
    
    [Then(@"verify the product and price in the checkout page")]
    public void ThenVerifyTheProductAndPriceInTheCheckoutPage()
    {
        _checkoutPageObject.VerifyOrderSummary();
    }

    [Then(@"the user provides valid address")]
    public void ThenTheUserProvidesValidAddress()
    {
        _checkoutPageObject.SelectValidAddress();
    }

    [Then(@"select the delivery method")]
    public void ThenSelectTheDeliveryMethod()
    {
        _checkoutPageObject.SelectDeliveryMethod();
        _checkoutPageObject.NavigateToPaymentReview();
    }

    [Then(@"place the order")]
    public void ThenPlaceTheOrder()
    {
        _checkoutPageObject.PlaceOrder();
        _submittedOrderNumber = _checkoutPageObject.GetOrderNumber();
    }

    [When(@"the user navigates to My Orders")]
    public void WhenTheUserNavigatesToMyOrders()
    {
        _myOrderPageObject.NavigateToMyOrders();
    }

    [Then(@"Verify the submitted order under My Orders")]
    public void ThenVerifyTheSubmittedOrderUnderMyOrders()
    {
        _tableOrderNumber = _myOrderPageObject.GetTableOrderNumber();
        Assert.True(_submittedOrderNumber.Equals(_tableOrderNumber));
    }
}