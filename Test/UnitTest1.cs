using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace CineTix.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
		await Page.GotoAsync("https://localhost:7084/");

		await Page.GetByRole(AriaRole.Heading, new() { Name = "Hello, welcome to CineTix!" }).ClickAsync();

		await Page.GetByRole(AriaRole.Link, new() { Name = "Movies" }).ClickAsync();

		await Page.GetByRole(AriaRole.Link, new() { Name = "Angry Birds" }).ClickAsync();

		await Expect(Page).ToHaveURLAsync(new Regex(".*details*"));

		await Page.GetByRole(AriaRole.Combobox).SelectOptionAsync(new[] { "sat" });

		await Page.GetByText("19:10").ClickAsync();

		await Page.GetByText("3A").ClickAsync();

		await Page.GetByPlaceholder("Enter your name").ClickAsync();

		await Page.GetByPlaceholder("Enter your name").FillAsync("Ange Nicole");

		await Page.GetByRole(AriaRole.Button, new() { Name = "Book your ticket" }).ClickAsync();

		await Page.GetByRole(AriaRole.Heading, new() { Name = "Tickets" }).ClickAsync();

	}
}