using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PostAppConfiguration.Models;
using System.Diagnostics;

namespace PostAppConfiguration.Controllers
{
    public class HomeController : Controller
    {
        private readonly WelcomeSettings _welcomeOptions;

        public HomeController( IOptionsSnapshot<WelcomeSettings> welcomeOptions)
        {
            _welcomeOptions = welcomeOptions.Value;
        }

        public IActionResult Index()
        {
            return View(_welcomeOptions);
        }
    }
}
