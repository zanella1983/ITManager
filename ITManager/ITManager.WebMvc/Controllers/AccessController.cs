using ITManager.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITManager.WebMvc.Controllers
{
    public class AccessController : Controller
    {
        private readonly IUserService userService;

        public AccessController(IUserService userService)
        {
            this.userService = userService;
        }

        //TODO Criar tela de login
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate(string email, string password)
        {
            var auth = userService.Authenticate(email, password);
            if (auth)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index");
        }
    }
}
