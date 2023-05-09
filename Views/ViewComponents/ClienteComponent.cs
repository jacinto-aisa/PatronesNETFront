using Desaprendiendo.Models;
using Desaprendiendo.Services.Repository;
using Desaprendiendo.Views.ViewComponents.ViewModels.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desaprendiendo.Views.ViewComponents
{
    public class ClienteComponent : BaseComponent<Cliente>
    {
        private readonly IListClienteFactory miFabrica;
        public ClienteComponent(ICategoriaRepository categoriaRepository,
                                 ISubCategoriaRepository subCategoriaRepository,
                                 ICursoRepository cursoRepository,
                                 IModuloRepository moduloRepository,
                                 ILeccionRepository leccionRepository,
                                 IClienteRepository clienteRepository,
                                 IBannerRepository bannerRepository) :
                           base()
        {
            miFabrica = new ListClienteFactory(categoriaRepository, subCategoriaRepository, cursoRepository, moduloRepository, leccionRepository, clienteRepository, bannerRepository);
            MyFactory = miFabrica;
        }
    }
}
