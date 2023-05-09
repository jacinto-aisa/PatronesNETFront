using Desaprendiendo.Services.Repository;

namespace Desaprendiendo.Views.ViewComponents.ViewModels.Base
{

    public class BaseComponentFactory
    {
        protected ICategoriaRepository _categoriaRepository;
        protected ISubCategoriaRepository _subCategoriaRepository;
        protected ICursoRepository _cursoRepository;
        protected IModuloRepository _moduloRepository;
        protected ILeccionRepository _leccionRepository;
        protected IClienteRepository _clienteRepository;
        protected IBannerRepository _bannerRepository;
        public BaseComponentFactory(ICategoriaRepository categoriaRepository, ISubCategoriaRepository subCategoriaRepository, ICursoRepository cursoRepository, IModuloRepository moduloRepository, ILeccionRepository leccionRepository,IClienteRepository clienteRepository,IBannerRepository bannerRepository)
        {
            _clienteRepository = clienteRepository;
            _categoriaRepository = categoriaRepository;
            _subCategoriaRepository = subCategoriaRepository;
            _moduloRepository = moduloRepository;
            _cursoRepository = cursoRepository;
            _leccionRepository = leccionRepository;
            _bannerRepository = bannerRepository;
        }
    }
}
