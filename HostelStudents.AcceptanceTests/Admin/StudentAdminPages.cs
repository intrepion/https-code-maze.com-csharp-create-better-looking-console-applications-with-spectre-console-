﻿using Bogus;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace HostelStudents.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class StudentAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByTestId("studentNavLink").ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Student List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Student Creation");

        await Page.GetByTestId("studentAdminEditAge").FillAsync("1");
        await Page.GetByTestId("studentAdminEditFirstName").FillAsync("a student");
        await Page.GetByTestId("studentAdminEditLastName").FillAsync("a student");
        // CreatePropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Student Modification");

        await Page.GetByTestId("studentAdminEditAge").FillAsync("2");
        await Page.GetByTestId("studentAdminEditFirstName").FillAsync("some student");
        await Page.GetByTestId("studentAdminEditLastName").FillAsync("some student");
        // ModifyPropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Student Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Student List");
    }

    [SetUp]
    public async Task SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
        if (string.IsNullOrEmpty(baseUrl))
        {
            baseUrl = "http://localhost:5206";
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
