using Microsoft.Playwright;

namespace Playwright_Automation
{
    public class PlaywrightHelper
    {
        public async Task ClickButtonAsync(IPage page, string selector)
        {
            await page.ClickAsync(selector);
        }

        public async Task TypeIntoFieldAsync(IPage page, string selector, string text)
        {
            await page.FillAsync(selector, text);
        }

        public async Task<string> GetTextAsync(IPage page, string selector)
        {
            return await page.InnerTextAsync(selector);
        }

        public async Task<bool> DoesElementExistAsync(IPage page, string selector)
        {
            return await page.QuerySelectorAsync(selector) != null;
        }

        public async Task<bool> IsElementVisibleAsync(IPage page, string selector)
        {
            var element = await page.QuerySelectorAsync(selector);
            return element != null && await element.IsVisibleAsync();
        }

        public async Task<string> GetPageTitleAsync(IPage page)
        {
            return await page.TitleAsync();
        }

        public async Task GoToUrlAsync(IPage page, string url)
        {
            await page.GotoAsync(url);
        }

        public async Task HoverElementAsync(IPage page, string selector)
        {
            await page.HoverAsync(selector);
        }

        public async Task<string> GetElementAttributeAsync(IPage page, string selector, string attributeName)
        {
            var element = await page.QuerySelectorAsync(selector);
            return element != null ? await element.GetAttributeAsync(attributeName) : string.Empty;
        }

        public async Task ScrollToElementAsync(IPage page, string selector)
        {
            await page.EvaluateAsync(@"
                (selector) => {
                    const element = document.querySelector(selector);
                    element.scrollIntoView();
                }",
                selector
            );
        }

        public async Task<string> GetCurrentUrlAsync(IPage page)
        {
            return page.Url;
        }

        public async Task ScreenshotAsync(IPage page, string path)
        {
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = path });
        }

        public async Task UploadFileAsync(IPage page, string selector, string filePath)
        {
            var fileInput = await page.QuerySelectorAsync(selector);
            if (fileInput != null)
            {
                await fileInput.SetInputFilesAsync(filePath);
            }
        }

        public async Task WaitForNavigationAsync(IPage page)
        {
            await page.WaitForNavigationAsync();
        }

        public async Task<int> CountElementsAsync(IPage page, string selector)
        {
            var elements = await page.QuerySelectorAllAsync(selector);
            return elements.Count;
        }

        public async Task ScrollToBottomAsync(IPage page)
        {
            await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
        }

        public async Task DragAndDropAsync(IPage page, string sourceSelector, string targetSelector)
        {
            var sourceElement = await page.QuerySelectorAsync(sourceSelector);
            var targetElement = await page.QuerySelectorAsync(targetSelector);

            if (sourceElement != null && targetElement != null)
            {
                var sourceBox = await sourceElement.BoundingBoxAsync();
                var targetBox = await targetElement.BoundingBoxAsync();

                if (sourceBox != null && targetBox != null)
                {
                    await page.Mouse.MoveAsync(sourceBox.X + sourceBox.Width / 2, sourceBox.Y + sourceBox.Height / 2);
                    await page.Mouse.DownAsync();
                    await page.Mouse.MoveAsync(targetBox.X + targetBox.Width / 2, targetBox.Y + targetBox.Height / 2);
                    await page.Mouse.UpAsync();
                }
            }
        }

        public async Task<bool> IsCheckedAsync(IPage page, string selector)
        {
            return await page.IsCheckedAsync(selector);
        }

        public async Task SelectOptionAsync(IPage page, string selector, string value)
        {
            await page.SelectOptionAsync(selector, value);
        }

        public async Task ClearInputAsync(IPage page, string selector)
        {
            await page.FillAsync(selector, "");
        }

        public async Task<bool> PageContainsTextAsync(IPage page, string text)
        {
            var content = await page.ContentAsync();
            return content.Contains(text);
        }

        public async Task<object> ExecuteScriptAsync(IPage page, string script, params object[] args)
        {
            return await page.EvaluateAsync(script, args);
        }

        public async Task WaitForRequestAsync(IPage page, string urlSubstring)
        {
            await page.WaitForRequestAsync(request => request.Url.Contains(urlSubstring));
        }

        public async Task WaitForResponseAsync(IPage page, string urlSubstring)
        {
            await page.WaitForResponseAsync(response => response.Url.Contains(urlSubstring));
        }

        public async Task BringToFrontAsync(IPage page)
        {
            await page.BringToFrontAsync();
        }

        public async Task<IBrowserContext> EmulateViewportAndUserAgentAsync(IBrowser browser, int width, int height, string userAgent)
        {
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = width, Height = height },
                UserAgent = userAgent
            });
            return context;
        }

        public async Task PressKeyAsync(IPage page, string key)
        {
            await page.PressAsync("body", key);
        }

        public async Task ReloadPageAsync(IPage page)
        {
            await page.ReloadAsync();
        }

        public async Task<bool> IsElementFocusedAsync(IPage page, string selector)
        {
            var activeElement = await page.EvaluateHandleAsync("document.activeElement");
            var element = await page.QuerySelectorAsync(selector);
            return activeElement == element;
        }

        public async Task WaitForFunctionAsync(IPage page, string script, params object[] args)
        {
            await page.WaitForFunctionAsync(script, args);
        }

        public async Task DoubleClickAsync(IPage page, string selector)
        {
            await page.DblClickAsync(selector);
        }

        public async Task<string> CheckCookieValueAsync(IPage page, string cookieName)
        {
            var cookies = await page.Context.CookiesAsync();
            var cookie = cookies.FirstOrDefault(c => c.Name == cookieName);
            return cookie?.Value;
        }

        public async Task SetCookieAsync(IPage page, string cookieName, string cookieValue)
        {
            var cookie = new Cookie { Name = cookieName, Value = cookieValue, Url = page.Url };
            await page.Context.AddCookiesAsync(new[] { cookie });
        }

        public async Task DeleteCookieAsync(IPage page, string cookieName)
        {
            await page.Context.ClearCookiesAsync();
        }

        public async Task SetViewportSizeAsync(IPage page, int width, int height)
        {
            await page.SetViewportSizeAsync(width, height);
        }

        public async Task<string> GetInnerHtmlAsync(IPage page, string selector)
        {
            var handle = await page.QuerySelectorAsync(selector);
            return handle != null ? await page.EvaluateAsync<string>("e => e.innerHTML", handle) : string.Empty;
        }

        public async Task<string> GetOuterHtmlAsync(IPage page, string selector)
        {
            var handle = await page.QuerySelectorAsync(selector);
            return handle != null ? await page.EvaluateAsync<string>("e => e.outerHTML", handle) : string.Empty;
        }

        public async Task<string> GetElementPropertyValueAsync(IPage page, string selector, string propertyName)
        {
            var handle = await page.QuerySelectorAsync(selector);
            if (handle != null)
            {
                var script = @"(element, property) => element[property]";
                var arguments = new Dictionary<string, object>
                {
                    { "element", handle },
                    { "property", propertyName }
                };
                var propertyValue = await page.EvaluateAsync<string>(script, arguments);
                return propertyValue ?? string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task WaitForNetworkIdleAsync(IPage page, int timeoutMillis = 500, int maxInflightRequests = 0)
        {
            var inflightRequests = new HashSet<IRequest>();
            var idleTaskSource = new TaskCompletionSource<bool>();
            var timeoutTaskSource = new TaskCompletionSource<bool>();

            var timeoutToken = new CancellationTokenSource(timeoutMillis).Token;

            timeoutToken.Register(() => timeoutTaskSource.TrySetResult(true), useSynchronizationContext: false);

            page.Request += (sender, e) =>
            {
                inflightRequests.Add(e);
                CheckIdleState();
            };

            page.RequestFinished += (sender, e) =>
            {
                inflightRequests.Remove(e);
                CheckIdleState();
            };

            page.RequestFailed += (sender, e) =>
            {
                inflightRequests.Remove(e);
                CheckIdleState();
            };

            void CheckIdleState()
            {
                if (inflightRequests.Count <= maxInflightRequests)
                {
                    idleTaskSource.TrySetResult(true);
                }
            }

            try
            {
                await Task.WhenAny(idleTaskSource.Task, timeoutTaskSource.Task);
            }
            finally
            {
                // Cleanup
                page.Request -= (sender, e) => inflightRequests.Add(e);
                page.RequestFinished -= (sender, e) => inflightRequests.Remove(e);
                page.RequestFailed -= (sender, e) => inflightRequests.Remove(e);
            }
        }


    }
}
