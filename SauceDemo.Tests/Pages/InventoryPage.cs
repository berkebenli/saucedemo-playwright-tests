using System.Globalization;
using Microsoft.Playwright;

namespace SauceDemo.Tests.Pages;

public class InventoryPage
{
    private readonly IPage _page;

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    public ILocator Title => _page.Locator(".title");
    public ILocator CartBadge => _page.Locator(".shopping_cart_badge");
    public ILocator CartLink => _page.Locator(".shopping_cart_link");
    public ILocator SortDropdown => _page.Locator(".product_sort_container");
    public ILocator ItemPrices => _page.Locator(".inventory_item_price");

    public async Task AddToCartAsync(string productId)
    {
        await _page.Locator($"#add-to-cart-{productId}").ClickAsync();
    }

    public async Task SortByAsync(string option)
    {
        await SortDropdown.SelectOptionAsync(option);
    }

    public async Task<List<decimal>> GetPricesAsync()
    {
        var texts = await ItemPrices.AllInnerTextsAsync();

        return texts
            .Select(t => decimal.Parse(
                t.Replace("$", ""),
                CultureInfo.InvariantCulture))
            .ToList();
    }

    public async Task OpenCartAsync()
    {
        await CartLink.ClickAsync();
    }
}