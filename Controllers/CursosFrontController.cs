using Desaprendiendo.Models.DomainModel;
using Desaprendiendo.Services.Mail;
using Desaprendiendo.Services.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Desaprendiendo.Controllers
{
    public class CursosFrontController : Controller
    {
        private int _idCurso;
        private readonly ICursoRepository _repositorioCursos;
        public ISubCategoriaRepository RepositorioSubCategoria { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public IEMail EmailSender { get; }

        public CursosFrontController(ICursoRepository repositorioCursos, ISubCategoriaRepository repositorioSubCategoria,
                                     IWebHostEnvironment webHostEnvironment,
                                     IEMail emailSender)
        {
            _repositorioCursos = repositorioCursos;
            RepositorioSubCategoria = repositorioSubCategoria;
            WebHostEnvironment = webHostEnvironment;
            EmailSender = emailSender;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewData["Menu"] = "Cursos";
            return View(await _repositorioCursos.GetAll().Where(p => p.SubCategoria == id).ToListAsync());
        }
        public async Task<IActionResult> Information(int id)
        {
            var _Curso = _repositorioCursos.GetById(id);
            _idCurso = _Curso.Id;
            MailConfiguration _configuracion = new()
            {
                Body = $"Quisiera más información sobre el curso: {_Curso.Curso1}"
            };
            return await Task.Run(() => View(_configuracion));
        }
        [HttpPost]
        public async Task <IActionResult> Information(MailConfiguration envio)
        {
            var cuerpo = $"El cliente con correo: {envio.CcEmail} /n ha realizado la siguiente consulta: {envio.Body}";
            await EmailSender.SendEmailAsync(cuerpo);
            return RedirectToAction("index", "ModulosFront", _idCurso);
        }
    }

}
