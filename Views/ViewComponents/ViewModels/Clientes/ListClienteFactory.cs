using Desaprendiendo.Models;
using Desaprendiendo.Models.DomainModel;
using Desaprendiendo.Models.Interfaces;
using Desaprendiendo.Services.Repository;
using Desaprendiendo.Views.ViewComponents.ViewModels.Base;
using System.Collections.Generic;

namespace Desaprendiendo.Views.ViewComponents.ViewModels.Clientes
{
    public class ListClienteFactory : BaseComponentFactory, IListClienteFactory
    {
        public ListClienteFactory(ICategoriaRepository categoriaRepository, ISubCategoriaRepository subCategoriaRepository, ICursoRepository cursoRepository, IModuloRepository moduloRepository,ILeccionRepository leccionRepository,IClienteRepository clienteRepository,IBannerRepository bannerRepository):
            base(categoriaRepository,subCategoriaRepository,cursoRepository,moduloRepository,leccionRepository,clienteRepository,bannerRepository)
        {
        }
        private Categoria DameCategoria(int id)
        {
            return _categoriaRepository.GetById(id);
        }
        private SubCategoria DameSubCategoria(int id)
        {
            return _subCategoriaRepository.GetById(id);
        }
        private Curso DameCurso(int id)
        {
            return _cursoRepository.GetById(id);
        }
        public List<Cliente> GetAll(IEntity entidad)
        {
            var tipoEntidad = entidad.GetType().Name;

            var _viewModelCliente = new List<Cliente>();
            if (tipoEntidad == "Cliente")
            {
                foreach (var item in base._clienteRepository.GetAll())
                {
                    _viewModelCliente.Add(item);
                }
            }
           
            return _viewModelCliente;
        }
    }
}
