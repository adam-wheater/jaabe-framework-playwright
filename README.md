# Playwright Automation

This solution contains automated tests using Playwright for web application testing.

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.

## Prerequisites

- .NET 7.0 SDK
- Playwright

## Configuration

The project uses test run parameters to configure the web application URL and Playwright settings. You can provide these parameters in the test run configuration.

Open the `.runsettings` file in the solution root and modify the following parameters:

- **WebAppUrl**: Set the URL of your web application.
- **Headless**: Set the Headless mode for Playwright (default: `false`).
- **BrowserName**: Set the browser name (default: `chromium`).
- **Channel**: Set the Playwright browser channel (default: `chrome`).
- **Timeout**: Set the timeout value in milliseconds (default: `100000`).

## Tests

The `PlaywrightTests.cs` file contains a collection of test methods that demonstrate how to use the `PlaywrightHelper` class to perform various actions on web elements. The test methods include:

- `TestClickMenu`: Clicks a menu item and verifies its visibility.
- `TestTypeIntoField`: Types text into an input field.
- `TestGetText`: Retrieves the text content of an element and verifies it.
- `TestDoesElementExist`: Checks if an element exists on the page.
- `TestIsElementVisible`: Checks if an element is visible on the page.
- `TestGetPageTitle`: Retrieves the page title and verifies it.

Feel free to modify these test methods or add your own tests using the provided helper methods in the `PlaywrightHelper.cs` file.

## Running the Tests

To run the tests:

1. Open the Test Explorer in Visual Studio.
2. Select the desired test methods or the entire test class.
3. Click the "Run" button or use the keyboard shortcut (Ctrl+R, T).

The tests will launch a browser instance, navigate to the specified URL, and perform the defined actions/assertions.

## Additional Helper Methods

The `PlaywrightHelper.cs` file contains a set of helper methods that encapsulate common actions performed during web application testing. These methods include:

- `ClickButtonAsync`: Clicks a button or element.
- `TypeIntoFieldAsync`: Types text into an input field.
- `GetTextAsync`: Retrieves the text content of an element.
- `DoesElementExistAsync`: Checks if an element exists on the page.
- `IsElementVisibleAsync`: Checks if an element is visible on the page.
- `GetPageTitleAsync`: Retrieves the page title.
- `HoverElementAsync`: Performs a hover action on an element.
- `GetElementAttributeAsync`: Retrieves the value of an element's attribute.
- `ScrollToElementAsync`: Scrolls to a specific element on the page.
- `GetCurrentUrlAsync`: Retrieves the current URL of the page.
- `ScreenshotAsync`: Takes a screenshot of the page.
- `UploadFileAsync`: Uploads a file to an input field.
- `WaitForNavigationAsync`: Waits for a page navigation to complete.
- `CountElementsAsync`: Counts the number of elements matching a selector.
- `ScrollToBottomAsync`: Scrolls to the bottom of the page.
- `DragAndDropAsync`: Performs a drag-and-drop action between elements.
- `IsCheckedAsync`: Checks if a checkbox or radio button is checked.
- `SelectOptionAsync`: Selects an option from a dropdown.
- `ClearInputAsync`: Clears the value of an input field.
- `PageContainsTextAsync`: Checks if the page contains a specific text.
- `ExecuteScriptAsync`: Executes custom JavaScript code on the page.
- `WaitForRequestAsync`: Waits for a network request that matches a URL substring.
- `WaitForResponseAsync`: Waits for a network response that matches a URL substring.
- `BringToFrontAsync`: Brings the browser window to the front.
- `EmulateViewportAndUserAgentAsync`: Emulates the viewport size and user agent of the browser.
- `PressKeyAsync`: Simulates pressing a key on the page.
- `ReloadPageAsync`: Reloads the current page.
- `IsElementFocusedAsync`: Checks if an element is currently focused.
- `WaitForFunctionAsync`: Waits for a JavaScript function on the page to evaluate to true.
- `DoubleClickAsync`: Performs a double-click action on an element.
- `CheckCookieValueAsync`: Retrieves the value of a cookie.
- `SetCookieAsync`: Sets a cookie on the page.
- `DeleteCookieAsync`: Deletes a cookie from the page.
- `SetViewportSizeAsync`: Sets the viewport size of the page.
- `GetInnerHtmlAsync`: Retrieves the inner HTML of an element.
- `GetOuterHtmlAsync`: Retrieves the outer HTML of an element.
- `GetElementPropertyValueAsync`: Retrieves the value of a property from an element.

These helper methods provide a wide range of capabilities for interacting with web elements and performing actions on the page. Feel free to utilize them in your tests or customize them further to meet your specific needs.

## PlaywrightTestBase

The `PlaywrightTestBase.cs` file provides a base test fixture for Playwright tests. It sets up the Playwright instance, launches the browser, and provides a clean browser instance for each test method.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

Please note that this README file is a template and should be customized to fit your specific project. Update the sections, instructions, and license information according to your requirements.

Feel free to reach out if you have any questions or need further assistance!

Happy testing with Playwright!

---

You can use this README file as a starting point for your project. Customize it further based on your specific needs, such as adding installation instructions or providing more detailed usage examples.

Let me know if there's anything else I can help you with!
