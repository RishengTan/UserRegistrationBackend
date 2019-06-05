using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> ur;
        private SignInManager<User> si;

        public UserController(UserManager<User> u, SignInManager<User> s)
        {
            ur = u;
            si = s;
        }
        [EnableCors]
        [HttpPost]
        [Route("R")]
        public async Task<Object> Post(UserModel m)
        {
            var a = new User()
            {
                UserName = m.UserName,
                Email = m.Email


            };
            try
            {
                var r = await ur.CreateAsync(a, m.Password);
                async Task Execute()
                {
                    var apiKey = "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";
                    var client = new SendGridClient(apiKey);
                    var from = new EmailAddress("rtan2@montefiore.org", "Example User");
                    var subject = "Sending with SendGrid is Fun";
                    var to = new EmailAddress(a.Email, "Example User");
                    var plainTextContent = "and easy to do anywhere, even with C#";
                    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                    var response = await client.SendEmailAsync(msg);
                }
                Execute().Wait();
                return Ok(r);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [EnableCors]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var user = await ur.FindByNameAsync(login.UserName);
            if (user != null && await ur.CheckPasswordAsync(user, login.Password))
            {
                var key = Encoding.ASCII.GetBytes("f9a32479-4549-4cf2-ba47-daa00c3f2afe");
                var K = new SymmetricSecurityKey(key);
                var tokenDesriptior = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserID", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    SigningCredentials = new SigningCredentials(K, SecurityAlgorithms.HmacSha256)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDesriptior);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
             }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
        }
    }
}