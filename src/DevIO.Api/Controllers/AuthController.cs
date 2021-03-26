using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/conta")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotificador notificador,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager) : base(notificador)
        {
            _signinManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUserViewModel)
        {
            return CustomResponse(registerUserViewModel);
        }
    }
}
