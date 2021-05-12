using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Utils;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.User
{
    public class UserMutations
    {
        public async Task<UserModel> Register(UserModel userModel, string password, [Service] UserManager<UserModel> userManager)
        {

            //userModel.Password = Hasher.GetHash(userModel.Password);
            //await context.Users.AddAsync(userModel);
            //await context.SaveChangesAsync();
            //await userManager.CreateAsync(userModel, password);
            await userManager.CreateAsync(userModel, password);
            return userModel;
        }

        public async Task<string> Logout([Service] IHttpContextAccessor httpContextAccessor)
        {
            await httpContextAccessor.HttpContext.SignOutAsync();
            return httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }

        public async Task<UserModel> Login(string password, string userName, [Service] UserManager<UserModel> userManager,[Service] SignInManager<UserModel> signInManager)
        {
            UserModel user = await userManager.FindByNameAsync(userName);
            var res = await signInManager.PasswordSignInAsync(user, password, true, false);

            //UserModel userModel = await context.Users.Where(x=>x.Username==userName).Include(x=>x.Role).FirstOrDefaultAsync();
            //string hashedPassword = Hasher.GetHash(password);
            //if (!userModel.Password.Equals(hashedPassword) && userModel != null) return null;

            //var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, userName),
            //        new Claim(ClaimTypes.Role, userModel.Role.Name)
            //    };

            //var claimsIdentity = new ClaimsIdentity(
            //    claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //var authProperties = new AuthenticationProperties
            //{
            //    //AllowRefresh = <bool>,
            //    // Refreshing the authentication session should be allowed.

            //    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            //    // The time at which the authentication ticket expires. A 
            //    // value set here overrides the ExpireTimeSpan option of 
            //    // CookieAuthenticationOptions set with AddCookie.

            //    //IsPersistent = true,
            //    // Whether the authentication session is persisted across 
            //    // multiple requests. When used with cookies, controls
            //    // whether the cookie's lifetime is absolute (matching the
            //    // lifetime of the authentication ticket) or session-based.

            //    //IssuedUtc = <DateTimeOffset>,
            //    // The time at which the authentication ticket was issued.

            //    //RedirectUri = <string>
            //    // The full path or absolute URI to be used as an http 
            //    // redirect response value.

            //};

            //await httpContextAccessor.HttpContext.SignInAsync(
            //    CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity),
            //    authProperties);

            return user;
        }
        public async Task<UserModel> DeleteUser(int id, [ScopedService] LibraryDbContext context)
        {
            UserModel userModel = await context.Users.FindAsync(id);
            context.Users.Remove(userModel);
            await context.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel> UpdateUser(UserModel userModel, [ScopedService] LibraryDbContext context)
        {
            //userModel.Password = Hasher.GetHash(userModel.Password);
            //context.Users.Update(userModel);
            //await context.SaveChangesAsync();
            return userModel;
        }
    }
}
