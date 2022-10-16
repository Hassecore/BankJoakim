using Microsoft.Extensions.Configuration;
using PuppeteerSharp;
using System.Linq;
using System.Threading.Tasks;

namespace BankJoakim.Models.Accounts.RandomIbanRetriever
{
    public class RandomIbanRetriever : IRandomIbanRetriever
    {
        private string urlString;
        private IBrowser _browser;

        public RandomIbanRetriever(IConfiguration configuration)
        {
            urlString = "http://randomiban.com/?country=Netherlands";

            var chromeLocation = configuration["AppSettings:ChromeLocation"];
            var options = new LaunchOptions()
            {
                Headless = true,
                ExecutablePath = chromeLocation
            };

            _browser = Puppeteer.LaunchAsync(options).Result;
        }

        public async Task<string> Retrieve()
        {
            var page = await _browser.NewPageAsync();
            await page.GoToAsync(urlString);

            var elements = await page .EvaluateExpressionAsync($"Array.from(document.querySelectorAll('p')).map(e => e.innerHTML);");
            var iban = elements.Values<string>().First();

            return iban;
        }
    }
}
