using Desaprendiendo.Services.Repository;
using Desaprendiendo.Views.ViewComponents.ViewModels.BreadCum;
using Desaprendiendo.Views.ViewComponents.ViewModels.Clientes;

namespace Desaprendiendo.Views.ViewComponents
{

    //ViewComponent que muestra el breadcum para Subcategorias, Cursos y Modulos
    public class BreadBreadCumComponent : BaseComponent<Bread>
    {

        private readonly ILListBreadFactory miFabrica;
        public BreadBreadCumComponent (ICategoriaRepository categoriaRepository,
                                  ISubCategoriaRepository subCategoriaRepository,
                                  ICursoRepository cursoRepository,
                                  IModuloRepository moduloRepository,
                                  ILeccionRepository leccionRepository,
                                  IClienteRepository clienteRepository,
                                  IBannerRepository bannerRepository):
                            base()
        {
           miFabrica = new ListBreadFactory(categoriaRepository, subCategoriaRepository, cursoRepository, moduloRepository, leccionRepository,clienteRepository,bannerRepository);
           MyFactory =  miFabrica;
        }
    }
}
