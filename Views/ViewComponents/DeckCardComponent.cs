using System.Threading.Tasks;
using Desaprendiendo.Models.Interfaces;
using Desaprendiendo.Services.Repository;
using Desaprendiendo.Views.ViewComponents.ViewModels.ContentItem;
using Microsoft.AspNetCore.Mvc;

namespace Desaprendiendo.Views.ViewComponents
{
    public class DeckCardComponent : BaseComponent<ContentItem>
    {
        private readonly ILListContentFactory miFabrica;

        public DeckCardComponent(ICategoriaRepository categoriaRepository,
            ISubCategoriaRepository subCategoriaRepository,
            ICursoRepository cursoRepository,
            IModuloRepository moduloRepository,
            ILeccionRepository leccionRepository,
            IClienteRepository clienteRepository,
            IBannerRepository bannerRepository) :
            base()

        {
            miFabrica = new ListContentFactory(categoriaRepository, subCategoriaRepository, cursoRepository,
                moduloRepository, leccionRepository,clienteRepository,bannerRepository);
            base.MyFactory = miFabrica;
        }

    }
}
