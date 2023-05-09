using Desaprendiendo.Models.DomainModel;
using Desaprendiendo.Models.Interfaces;
using Desaprendiendo.Services.Repository;
using Desaprendiendo.Views.ViewComponents.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace Desaprendiendo.Views.ViewComponents.ViewModels.ContentItem
{
    public class ListContentFactory : BaseComponentFactory, ILListContentFactory
    {
        public ListContentFactory(ICategoriaRepository categoriaRepository,
                                  ISubCategoriaRepository subCategoriaRepository,
                                  ICursoRepository cursoRepository,
                                  IModuloRepository moduloRepository,
                                  ILeccionRepository leccionRepository,
                                  IClienteRepository clienteRepository,
                                  IBannerRepository bannerRepository) :
            base(categoriaRepository, subCategoriaRepository, cursoRepository, moduloRepository, leccionRepository,clienteRepository,bannerRepository)
        {
        }

        public List<ContentItem> GetAll(IEntity entidad)
        {
            var tipoEntidad = entidad.GetType().Name;

            var _viewModelContenido = new List<ContentItem>();
            
            if (tipoEntidad == "Cliente")
            {
                foreach (var item in _clienteRepository.GetAll())
                {
                    _viewModelContenido.Add(ContentItemFactory.CreateInstance(item));
                }
            }
            if (tipoEntidad == "Banner")
            {
                foreach(var item in _bannerRepository.GetAll())
                {
                    _viewModelContenido.Add(ContentItemFactory.CreateInstance(item));
                }
            }
            if (tipoEntidad == "Categoria")
            {
                foreach (var item in _categoriaRepository.GetAll())
                {
                    var _subCate = _subCategoriaRepository.GetAll().Where(p=>p.Categoria == (item.Id));
                    
                    _viewModelContenido.Add(ContentItemFactory.CreateInstanceCategoria(item,_subCate));
                }
            }
            if (tipoEntidad == "SubCategoria")
            {
                foreach (var item in _subCategoriaRepository.GetAll().Where(p => p.Categoria == ((SubCategoria)entidad).Categoria))
                {
                    _viewModelContenido.Add(ContentItemFactory.CreateInstance(item));
                }
            }
            if (tipoEntidad == "Curso")
            {
                foreach (var item in _cursoRepository.GetAll().Where(p => p.SubCategoria == ((Curso)entidad).SubCategoria))
                {
                    _viewModelContenido.Add(ContentItemFactory.CreateInstance(item));
                }
            }
            return _viewModelContenido;
        }
    }
}
