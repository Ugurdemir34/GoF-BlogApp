using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoF.Lib.Business.Abstract;
using GoF.Lib.MvcWebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GoF.Core.Utilities.Security.Hashing;
using GoF.Lib.Entities.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GoF.Lib.MvcWebUI.Controllers
{
    public class LoginController : Controller
    {
        private IAdminService _adminService;
        private IAuthService _authService;
        private IHttpContextAccessor _httpContextAccessor;
        public LoginController(IAdminService adminService,IHttpContextAccessor httpContextAccessor,IAuthService authService)
        {
            _adminService = adminService;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var loginModel = new AdminForLoginDto
            {
                Email = model.Email,
                Password = model.Password
            };
          
            var result = _authService.Login(loginModel);
            if(result.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,model.Email)
                };              
                var userIdentity = new ClaimsIdentity(claims,"login");
             
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                _httpContextAccessor.HttpContext.Session.SetString("username", result.Data.Username );
                _httpContextAccessor.HttpContext.Session.SetString("mail", result.Data.Email );
                _httpContextAccessor.HttpContext.Session.SetInt32("Id", result.Data.Id);
               
                await HttpContext.SignInAsync(principal);
                ViewData["mesaj"] = "";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewData["mesaj"] = "Kullanıcı Adı veya Parola Hatalı !";
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        public bool LoginCheck(string userName, string password)
        {
            var model = _adminService.GetAdmin(userName, password);
            if(model !=null)
            {
                return true;
            }
            return false;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AdministratorViewModel adminView)
        {
          
         
            var result = new Core.Entities.Concrete.Admin()
            {
                About = adminView.About,
                Email = adminView.Email,
                Lastname = adminView.LastName,
                Name = adminView.FirstName,
                Username = adminView.Username,
               Password = adminView.Password
            };
             _adminService.Add(result);
            return View();
        }
    }
}