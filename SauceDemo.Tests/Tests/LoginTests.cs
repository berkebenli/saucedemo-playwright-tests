using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTests : PageTest
{
    private LoginPage _loginPage = null!;

    [SetUp]
    public async Task SetUp()
    {
        _loginPage = new LoginPage(Page);
        await _loginPage.GotoAsync();
    }

    [Test]
    public async Task ValidLogin_OpensProductsPage()
    {
        await _loginPage.LoginAsync("standard_user", "secret_sauce");

        await Expect(Page).ToHaveURLAsync(
            "https://www.saucedemo.com/inventory.html");
        await Expect(Page.Locator(".title")).ToHaveTextAsync("Products");
    }

    [Test]
    public async Task WrongPassword_ShowsError()
    {
        await _loginPage.LoginAsync("standard_user", "wrong_password");

        await Expect(_loginPage.ErrorMessage).ToContainTextAsync(
            "Username and password do not match");
    }

    [Test]
    public async Task LockedOutUser_ShowsError()
    {
        await _loginPage.LoginAsync("locked_out_user", "secret_sauce");

        await Expect(_loginPage.ErrorMessage).ToContainTextAsync(
            "this user has been locked out");
    }
}