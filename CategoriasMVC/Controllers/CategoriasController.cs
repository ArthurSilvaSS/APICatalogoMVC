using CategoriasMVC.Models;
using CategoriasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoriasMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaServices _categoriaServices;

        public CategoriasController(ICategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }

        public async Task<ActionResult<IEnumerable<CategoriaViwerModel>>> Index()
        {
            var result = await _categoriaServices.GetCategorias();

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        public IActionResult CriarNovaCategoria()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaViwerModel>>
            CriarNovaCategoria(CategoriaViwerModel categoriaVM)
       {
            if (ModelState.IsValid)
            {
                var result = await _categoriaServices.CriaCategoria(categoriaVM);

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Erro ao criar Categoria";
            return View(categoriaVM);
        }
    }

}
