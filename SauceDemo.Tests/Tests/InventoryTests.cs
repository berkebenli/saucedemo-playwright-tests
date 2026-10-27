using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class InventoryTests : PageTest
{
    private InventoryPage _inventoryPage = null!;

    [SetUp]
    public async Task SetUp()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.GotoAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        _inventoryPage = new InventoryPage(Page);
    }

    [Test]
    public async Task AddToCart_UpdatesCartBadge()
    {
        await _inventoryPage.AddToCartAsync("sauce-labs-backpack");
        await _inventoryPage.AddToCartAsync("sauce-labs-bike-light");

        await Expect(_inventoryPage.CartBadge).ToHaveTextAsync("2");
    }

    [Test]
    public async Task SortByPriceLowToHigh_SortsPricesAscending()
    {
        await _inventoryPage.SortByAsync("lohi");

        var prices = await _inventoryPage.GetPricesAsync();

        Assert.That(prices, Is.Ordered.Ascending);
    }
}