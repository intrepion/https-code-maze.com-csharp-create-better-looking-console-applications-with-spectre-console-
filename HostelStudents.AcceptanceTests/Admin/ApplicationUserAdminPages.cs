using Bogus;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ApplicationNamePlaceholder.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class ApplicationUserAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        var faker = new Faker();
        string aRandomString = faker.Random.String2(10);
        string someRandomString = faker.Random.String2(10);
        await Page.GetByRole(AriaRole.Link, new() { Name = "Application Users" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User Creation");
        await Page.GetByTestId("applicationUserAdminEditEmail").FillAsync("aEmail" + aRandomString);
        await Page.GetByTestId("applicationUserAdminEditPhoneNumber").FillAsync("aPhoneNumber" + aRandomString);
        await Page.GetByTestId("applicationUserAdminEditUserName").FillAsync("aUserName + aRandomString");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User Modification");
        await Page.GetByTestId("applicationUserAdminEditEmail").FillAsync("someEmail" + someRandomString);
        await Page.GetByTestId("applicationUserAdminEditPhoneNumber").FillAsync("somePhoneNumber" + someRandomString);
        await Page.GetByTestId("applicationUserAdminEditUserName").FillAsync("someUserName" + someRandomString);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User List");
    }

    [SetUp]
    public async Task SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
        if (string.IsNullOrEmpty(baseUrl))
        {
            baseUrl = "ClientUriPlaceholder";
        }
        await Page.GotoAsync(baseUrl);
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();
    }
}
