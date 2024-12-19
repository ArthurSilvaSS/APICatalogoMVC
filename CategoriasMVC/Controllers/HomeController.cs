using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using CategoriasMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CategoriasMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
