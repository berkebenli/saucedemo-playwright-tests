using Microsoft.Playwright;

namespace SauceDemo.Tests.Pages;

public class CheckoutPage
{
    private readonly IPage _page;

    public CheckoutPage(IPage page)
    {
        _page = page;
    }

    public ILocator CompleteHeader => _page.Locator(".complete-header");

    public async Task StartCheckoutAsync()
    {
        await _page.Locator("#checkout").ClickAsync();
    }

    public async Task FillInformationAsync(
        string firstName,
        string lastName,
        string postalCode)
    {
        await _page.Locator("#first-name").FillAsync(firstName);
        await _page.Locator("#last-name").FillAsync(lastName);
        await _page.Locator("#postal-code").FillAsync(postalCode);
        await _page.Locator("#continue").ClickAsync();
    }

    public async Task FinishAsync()
    {
        await _page.Locator("#finish").ClickAsync();
    }
}