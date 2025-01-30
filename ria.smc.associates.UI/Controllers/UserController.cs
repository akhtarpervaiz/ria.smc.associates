using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.UI.Utilities.Attributes;
using ria.smc.associates.UI.Utilities;
using System.Security.Claims;
using ria.smc.associates.UI.Models.Login;
using ria.smc.associates.DL.UIDataLayers.Users;

namespace ria.smc.associates.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            this._logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            //if (HttpContext.User.Identity.IsAuthenticated && this.User.GetUserId() > 0)
            //{
            //    return RedirectToAction(AppConstants.ACTION_INDEX_CONTROLLER_HOME, AppConstants.CONTROLLER_HOME);
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] LoginRequest requestLogin)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(requestLogin.UserName)  && !string.IsNullOrEmpty(requestLogin.Password))
                {
                    LoginResponse responseLogin = new LoginResponse();
                    responseLogin = UsersDL.Login(requestLogin);
                    if (responseLogin != null)
                    {
                        SetClaimsCookieAuthentication(responseLogin);
                        return RedirectToAction(AppConstants.ACTION_INDEX_CONTROLLER_HOME, AppConstants.CONTROLLER_HOME);
                    }
                    ViewData["ErrorAlertMessge"] = AlertMessages.Invalid_Login_Credentials;
                    return View(requestLogin);
                }
                else
                {
                    ViewData["ErrorAlertMessge"] = AlertMessages.Invalid_Login_Credentials;
                    return View(requestLogin);
                }
            }
            ViewData["ErrorAlertMessge"] = AlertMessages.Something_Went_Wrong;
            return View(requestLogin);
        }


        public void SetClaimsCookieAuthentication(LoginResponse responseLoginDto)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, responseLoginDto.UserName),
                new Claim(AppConstants.AUTH_USERNAME, responseLoginDto.UserName),
                new Claim(AppConstants.Auth_UserID, Convert.ToString(responseLoginDto.UserId))
            };


            //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity
            var principal = new ClaimsPrincipal(identity);

            //SignInAsync is a Extension method for Sign in a principal for the specified scheme.
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = AppConstants.URL_Loginin_Index,
                IsPersistent = responseLoginDto.ValidLogin
            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal, authProperties);

            _logger.LogInformation(LogInformationMessages.Login_User, responseLoginDto.UserName, DateTime.UtcNow);
        }
    }
}
