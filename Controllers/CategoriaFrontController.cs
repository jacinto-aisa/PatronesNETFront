using System.Linq;
using Desaprendiendo.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Desaprendiendo.Controllers
{
    public class CategoriaFrontController : Controller
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaFrontController(ICategoriaRepository categoriaRepository,
            IClienteRepository clienteRepository)
        {
            this._categoriaRepository = categoriaRepository;
        }

        // GET: CategoriaFront
        public async Task<IActionResult> Index()
        {
            var categorias 
                = await _categoriaRepository.GetAll().ToArrayAsync();
            ViewData["Menu"] = "Cursos";
            if (categorias is null)
                return RedirectToAction("Home");
            else
            {
                return View(categorias);
            }
        }

        public async Task<IActionResult> Home()
        {
            ViewData["Menu"] = "Home";
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Tripartita()
        {
            ViewData["Menu"] = "Tripartita";
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Nosotros()
        {
            ViewData["Menu"] = "Nosotros";
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Metodologia()
        {
            ViewData["Menu"] = "Metodologia";
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Privacy()
        {
            //coimentaddasassa
            ViewData["Menu"] = "Privacy";
            return await Task.Run(() => View());
        }

        
    }
}