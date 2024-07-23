using System.Security.Claims;
using BlogApp.Data;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers{

    public class UsersController : Controller{

        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public IActionResult Login(){
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index","Posts");
            }
            return View();
        }
        public async Task<IActionResult> Logout(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model){

            if(ModelState.IsValid){

                var isUser =await _userRepository.Users.FirstOrDefaultAsync(x=> x.Email == model.Email && x.Password == model.Password);

                if(isUser != null){
                    var userClaims = new List<Claim>();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.UserId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Name ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));

                    if(isUser.Email == "info@ahmetkaya.com"){
                        userClaims.Add(new Claim(ClaimTypes.Role,"admin"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var autProperties = new AuthenticationProperties{IsPersistent=true};
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),autProperties
                    );
                    return RedirectToAction("Index","Posts");
                }else{
                ModelState.AddModelError("","Kullanıcı adı veya parola hatalı");
            }
            }
            
            return View(model);
        }
    }
}