using ApprovalApp.API.Contracts.Responses;
using ApprovalApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
            
            
        }

        /// <summary>
        /// Логин форма
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task GetPersonsAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            // html-форма для ввода логина/пароля
            string loginForm = @"<!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <title>METANIT.COM</title>
                </head>
                <body>
                    <h2>Login Form</h2>
                    <form method='post'>
                        <p>
                            <label>Email</label><br />
                            <input name='email' />
                        </p>
                        <p>
                            <label>Password</label><br />
                            <input type='password' name='password' />
                        </p>
                        <input type='submit' value='Login' />
                    </form>
                </body>
                </html>";
            await context.Response.WriteAsync(loginForm);
        }
    }
}
