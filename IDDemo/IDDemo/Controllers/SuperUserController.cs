using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IDDemo.Models;
using IDDemo.Models.AccountViewModels;
using IDDemo.Services;
using IDDemo.Data;
namespace IDDemo.Controllers
{
    public class SuperUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public SuperUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Role()
        {
            
            var roles = _applicationDbContext.Roles.ToList();
            return View(roles);
        }

        public IActionResult CreateRole(string roleName)
        {
            if (roleName != null)
            {
                var newRole = new IdentityRole(roleName);
                _roleManager.CreateAsync(newRole);
                return Redirect("Role");
            }
            return View();
        }

        
    }
}