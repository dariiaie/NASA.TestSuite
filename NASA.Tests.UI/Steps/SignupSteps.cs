using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace NASA.Tests.UI.Steps
{
    [Binding]
    public class SignupSteps
    {
        private IPage _page;
        private IBrowser _browser;
        private IBrowserContext _context;
        private string _email;

        [Given(@"I navigate to the NASA Open APIs home page")]
        public async Task GivenINavigateToTheNASAOpenAPIsHomePage()
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50
            });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
            await _page.GotoAsync("https://api.nasa.gov");
        }

        [When(@"I open the sign-up form")]
        public async Task WhenIOpenTheSignUpForm()
        {
            await _page.ClickAsync("text=Get Started");
        }

        [When(@"I fill the registration form with valid details")]
        public async Task WhenIFillTheRegistrationFormWithValidDetails()
        {
            _email = $"test+{Guid.NewGuid():N}@gmail.com";
            await _page.FillAsync("#user_first_name", "Test");
            await _page.FillAsync("#user_last_name", "User");
            await _page.FillAsync("#user_email", _email);
        }

        [When(@"I submit the registration form")]
        public async Task WhenISubmitTheRegistrationForm()
        {
            await _page.ClickAsync("button.btn-primary:has-text('Sign up')");
        }

        [Then(@"I should see a registration confirmation message")]
        public async Task ThenIShouldSeeARegistrationConfirmationMessage()
        {
            var successMessage = _page.Locator($"text=Your API key for {_email} has been e-mailed to you");
            await successMessage.WaitForAsync();
            Assert.IsTrue(await successMessage.IsVisibleAsync());

            // Close browser after test
            await _browser.CloseAsync();
        }
    }
}
