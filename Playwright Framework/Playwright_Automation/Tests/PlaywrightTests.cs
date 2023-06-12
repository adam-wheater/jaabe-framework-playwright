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
            await helper.GoToUrlAsync(Page, "https://www.jaabe.co.uk/contact");
            await helper.IsElementVisibleAsync(Page, ".art-menu-bar-header");
        }

        [Test]
        public async Task TestTypeIntoField()
        {
            await helper.GoToUrlAsync(Page, "https://www.jaabe.co.uk/contact");
            await helper.TypeIntoFieldAsync(Page, "input[type='text']", "Hello");
        }

        [Test]
        public async Task TestGetText()
        {
            await helper.GoToUrlAsync(Page, "https://www.jaabe.co.uk");
            var text = await helper.GetTextAsync(Page, "h1");
            Assert.AreEqual("Building Solutions\nFor Your Problems.", text);
        }

        [Test]
        public async Task TestDoesElementExist()
        {
            await helper.GoToUrlAsync(Page, "https://www.jaabe.co.uk");
            var exists = await helper.DoesElementExistAsync(Page, ".art-menu-bar-header");
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task TestIsElementVisible()
        {
            await helper.GoToUrlAsync(Page, "https://www.jaabe.co.uk");
            var isVisible = await helper.IsElementVisibleAsync(Page, ".art-menu-bar-header");
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
