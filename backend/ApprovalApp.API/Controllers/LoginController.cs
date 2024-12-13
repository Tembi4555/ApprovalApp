using ApprovalApp.API.Contracts.Responses;
using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(string? returnUrl, HttpContext context)
        //{
        //    return LocalRedirect(Url.GetLocalUrl(returnUrl));
        //}
    }
}
