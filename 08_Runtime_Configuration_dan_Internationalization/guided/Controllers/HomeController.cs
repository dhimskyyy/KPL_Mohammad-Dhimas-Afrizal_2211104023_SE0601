using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using localizationnnn.Models;
using localizationnnn.Services;
using Microsoft.AspNetCore.Localization;

namespace localizationnnn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localizationnnn;
        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _localizationnnn = localization;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = _localizationnnn.Getkey("str_welcome_message").Value;
            //get culture information
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return View();
        }
        #region Localization
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });

            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
