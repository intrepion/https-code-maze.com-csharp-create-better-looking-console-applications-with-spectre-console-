﻿using Bogus;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace HostelStudents.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class HostelAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        var faker = new Faker();
        var aRandomString = faker.Random.String2(10);
        var someRandomString = faker.Random.String2(10);
        await Page.GetByTestId("hostelNavLink").ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Hostel Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Hostel Add");

        await Page.GetByLabel("Name:").FillAsync("aName" + aRandomString);
        // CreatePropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Hostel View");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Edit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Hostel Edit");

        await Page.GetByLabel("Name:").FillAsync("someName" + someRandomString);
        // ModifyPropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Hostel View");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Delete" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Back to Grid" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Hostel Home");
    }

    [SetUp]
    public async Task SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
        if (string.IsNullOrEmpty(baseUrl))
        {
            baseUrl = "http://localhost:5123";
        }
        await Page.GotoAsync(baseUrl);


        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@HostelStudents.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@HostelStudents.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();
    }
}
