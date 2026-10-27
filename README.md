# SauceDemo Playwright Tests (C#)

![Tests](https://github.com/berkebenli/saucedemo-playwright-tests/actions/workflows/tests.yml/badge.svg)

End-to-end UI test suite for [SauceDemo](https://www.saucedemo.com), built with **Playwright for .NET**, **C#**, and **NUnit**, using the **Page Object Model**. Tests run automatically on every push with **GitHub Actions**.

## Test coverage

| Area | Test |
|---|---|
| Login | Valid login opens the products page |
| Login | Wrong password shows an error message |
| Login | Locked-out user shows an error message |
| Cart | Adding two products updates the cart badge |
| Sorting | "Price (low to high)" sorts prices in ascending order |
| Checkout | Full purchase flow: login, cart, checkout, order confirmation |

## Project structure

- `SauceDemo.Tests/Pages/`: Page Objects (LoginPage, InventoryPage, CheckoutPage)
- `SauceDemo.Tests/Tests/`: Test classes (LoginTests, InventoryTests, CheckoutTests)

## Run locally

    cd SauceDemo.Tests
    dotnet build
    pwsh bin/Debug/net10.0/playwright.ps1 install
    dotnet test
