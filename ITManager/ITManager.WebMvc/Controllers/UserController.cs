using ITManager.Application.Services;
using ITManager.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITManager.WebMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var model = new ListUserViewModel();
            model.Users = userService.List();
            return View(model);
        }
        //Criação da Entidade
        //Criação do repositório
        //Criação do serviço
        //Criação do Controller
    }
}
