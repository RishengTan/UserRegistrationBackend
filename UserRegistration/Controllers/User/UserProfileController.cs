using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<User> ur;
        private SignInManager<User> si;
        private readonly UserContext context;

        public UserProfileController(UserManager<User> u, SignInManager<User> s, UserContext Usercontext)
        {
            ur = u;
            si = s;
            context = Usercontext;
        }
        [EnableCors]
        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string UserId = User.Claims.First(C => C.Type == "UserID").Value;
            var user = await ur.FindByIdAsync(UserId);
            return new
            {
                user.UserName,
                user.Email
            };
        }
        [EnableCors]
        [HttpPost]
        [Route("Passwordchange")]
        [Authorize]
        public async Task<Object> ChangePassword(passwordchange change)
        {
            string UserId = User.Claims.First(C => C.Type == "UserID").Value;
            var user = await ur.FindByIdAsync(UserId);
            var x = await ur.ChangePasswordAsync(user, change.currentpass, change.newpass);
            return Ok(x);
        }

        
    }
}