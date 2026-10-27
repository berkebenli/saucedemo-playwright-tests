using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CheckoutTests : PageTest
{
    [Test]
    public async Task CompletePurchase_ShowsConfirmation()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);
        var checkoutPage = new CheckoutPage(Page);

        await loginPage.GotoAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await inventoryPage.AddToCartAsync("sauce-labs-backpack");
        await inventoryPage.OpenCartAsync();

        await checkoutPage.StartCheckoutAsync();
        await checkoutPage.FillInformationAsync("Berke", "Benli", "35000");
        await checkoutPage.FinishAsync();

        await Expect(checkoutPage.CompleteHeader).ToHaveTextAsync(
            "Thank you for your order!");
    }
}