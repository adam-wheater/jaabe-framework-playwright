using Microsoft.Playwright;
using NUnit.Framework;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

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
        private Dictionary<string, string> browserstackOptions;

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
            browserstackOptions = new Dictionary<string, string>();
            browserstackOptions.Add("name", "Playwright first sample test");
            browserstackOptions.Add("build", "playwright-dotnet-1");
            browserstackOptions.Add("os", "osx");
            browserstackOptions.Add("os_version", "catalina");
            browserstackOptions.Add("browser", BrowserName);
            browserstackOptions.Add("browserstack.username", "BROWSERSTACK_USERNAME");
            browserstackOptions.Add("browserstack.accessKey", "BROWSERSTACK_ACCESS_KEY");

            string capsJson = JsonConvert.SerializeObject(browserstackOptions);
            string cdpUrl = "wss://cdp.browserstack.com/playwright?caps=" + Uri.EscapeDataString(capsJson);

            Browser = await Playwright.Chromium.ConnectAsync(cdpUrl);
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

        public static async Task MarkTestStatus(string status, string reason, IPage page)
        {
            await page.EvaluateAsync("_ => {}", "browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"" + status + "\", \"reason\": \"" + reason + "\"}}");
        }
    }
}
