using Microsoft.Playwright;
using NUnit.Framework;

namespace Playwright_Automation.Tests
{
    [TestFixture]
    public class PlaywrightTests : PlaywrightTestBase
    {
        private PlaywrightHelper helper;

        [SetUp]
        public void Setup()
        {
            helper = new PlaywrightHelper();
        }

        [Test]
        public async Task TestClickMenu()
        {
            await helper.GoToUrlAsync(Page, "https://jaabeblazor.com");
            await helper.IsElementVisibleAsync(Page, ".jaabe-hamburger > button");
        }

        [Test]
        public async Task TestTypeIntoField()
        {
            await helper.GoToUrlAsync(Page, "https://jaabeblazor.com");
            await helper.TypeIntoFieldAsync(Page, "input[type='text']", "Hello");
        }

        [Test]
        public async Task TestGetText()
        {
            await helper.GoToUrlAsync(Page, "https://jaabeblazor.com");
            var text = await helper.GetTextAsync(Page, "h1");
            Assert.AreEqual("JAABEBLAZOR", text);
        }

        [Test]
        public async Task TestDoesElementExist()
        {
            await helper.GoToUrlAsync(Page, "https://jaabeblazor.com");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var exists = await helper.DoesElementExistAsync(Page, "#getting-started");
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task TestIsElementVisible()
        {
            await helper.GoToUrlAsync(Page, "https://jaabeblazor.com");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var isVisible = await helper.IsElementVisibleAsync(Page, "#getting-started");
            Assert.IsTrue(isVisible);
        }

        [Test]
        public async Task TestGetPageTitle()
        {
            await helper.GoToUrlAsync(Page, "https://www.jaabe.co.uk");
            var title = await helper.GetPageTitleAsync(Page);
            Assert.AreEqual("Building Solutions for your Problems. - Jaabe Solutions", title);
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
        }
    }
}
