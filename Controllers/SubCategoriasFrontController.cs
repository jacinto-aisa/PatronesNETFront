using Desaprendiendo.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Desaprendiendo.Controllers
{
    public class SubCategoriasFrontController : Controller
    {
        private readonly ISubCategoriaRepository _subCategoriaRepository;

        public SubCategoriasFrontController(ISubCategoriaRepository subCategoriaRepository)
        {
            this._subCategoriaRepository = subCategoriaRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewData["Menu"] = "Cursos";
            var subcategorias = await _subCategoriaRepository.GetAll().Where(p => p.Categoria == id).ToListAsync();
            if (subcategorias != null)
            {
                return View(subcategorias);
            }
            else
            {
                return RedirectToAction("Index", "CategoriaFront");
            }
        }
    }
}