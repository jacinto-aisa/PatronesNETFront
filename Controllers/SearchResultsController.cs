using Desaprendiendo.Services.Repository;
using Desaprendiendo.Services.SearchService;
using Desaprendiendo.Services.SearchService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Desaprendiendo.Controllers
{
    public class SearchResultsController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchResultsController(ICursoRepository repositorioCursos, IModuloRepository repositorioModulos, ICategoriaRepository categoriaRepository)
        {
            _searchService = new SearchService(repositorioCursos);
        }

        // GET: SearchResults
        public async Task<IActionResult> Index(SearchInput textSearched)
        {
            if (ViewData["Menu"] is null)
                ViewData["Menu"] = "SearchResult";
            return View(await _searchService.Search(textSearched.SearchedText));
        }

    }
}
