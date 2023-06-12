using Microsoft.Playwright;
using NUnit.Framework;
using System.Reflection;
using System.Threading.Channels;
using System.Xml;

namespace Playwright_Automation
{
    [TestFixture]
    public abstract class PlaywrightTestBase
    {
        protected static string WebAppUrl;
        protected static bool Headless;
        protected static string BrowserName;
        protected static string Channel;
        protected static int Timeout;
        protected static IPlaywright Playwright;
        protected IBrowser Browser;
        protected IPage Page;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            WebAppUrl = TestContext.Parameters["WebAppUrl"]
                ?? throw new Exception("WebAppUrl is not configured as a parameter.");

            var headless = TestContext.Parameters["Headless"];
            Headless = string.IsNullOrEmpty(headless) ? false : bool.Parse(headless);

            var browserName = TestContext.Parameters["BrowserName"];
            BrowserName = string.IsNullOrEmpty(browserName) ? "chromium" : browserName;

            var channel = TestContext.Parameters["Channel"];
            Channel = string.IsNullOrEmpty(channel) ? "chrome" : channel;

            var timeout = TestContext.Parameters["Timeout"];
            Timeout = string.IsNullOrEmpty(timeout) ? 100000 : int.Parse(timeout);

            // Create Playwright instance
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        }


        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
        }


        [SetUp]
        public async Task SetUp()
        {
            // Launch new browser for each test
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Headless });
            var context = await Browser.NewContextAsync();
            Page = await context.NewPageAsync();

            // Navigate to web app
            await Page.GotoAsync(WebAppUrl);
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.DisposeAsync();
        }
    }
}
