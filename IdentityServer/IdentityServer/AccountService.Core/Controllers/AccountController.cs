using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AccountService.Core.Infrasructure;
using AccountService.Core.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;

namespace AccountService.Core.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly AccountDataContext _accountDataContext;
        public AccountController(IIdentityServerInteractionService interactionService, AccountDataContext accountDataContext)
        {
            _interactionService = interactionService;
            _accountDataContext = accountDataContext;
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            var context = await _interactionService.GetAuthorizationContextAsync(returnUrl);
            if (!string.IsNullOrEmpty(context.Parameters["code"]))
            {
                await HttpContext.SignInAsync(Guid.NewGuid().ToString(), "external@ex.com",
                    new AuthenticationProperties());

                return  Redirect(returnUrl);
            }

            return View(new LoginInputModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [Route("/Account/LoginHandle", Name = "loginHandle")]
        public async Task<IActionResult> Login(LoginInputModel loginModel)
        {
            if (_interactionService.IsValidReturnUrl(loginModel.ReturnUrl))
            {
                var user = (from u in _accountDataContext.Users
                            where u.EMAIL_ADDRESS == loginModel.UserName && u.USER_PASSWORD == loginModel.Password
                            select u).FirstOrDefault();
                if (user != null)
                {
                    var context = await _interactionService.GetAuthorizationContextAsync(loginModel.ReturnUrl);
                    var authProps = new AuthenticationProperties();
                    await HttpContext.SignInAsync(Guid.NewGuid().ToString(), user.EMAIL_ADDRESS, authProps);

                    return Redirect(loginModel.ReturnUrl);
                }
            }

            return View(loginModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var context = await _interactionService.GetLogoutContextAsync(logoutId);
            await HttpContext.SignOutAsync();
            return View(new LogoutInputModel { LogoutRedirectUrl = "http://localhost:3000" });
        }

        [HttpGet]
        public async Task<IActionResult> ExternalOAuth(string code, string state, string provider)
        {
            return Redirect(
                $"/connect/authorize?nonce=abc&code={code}&state={state}&provider={provider}&client_id=portal-external-sso&scope=openid&response_type=id_token token&redirect_uri=http://localhost:3000/");
        }
    }
}