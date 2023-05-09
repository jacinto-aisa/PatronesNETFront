﻿using Desaprendiendo.Services.Repository;
using Desaprendiendo.Views.ViewComponents.ViewModels.ContentItem;

namespace Desaprendiendo.Views.ViewComponents
{
    public class ContentComponent : BaseComponent<ContentItem>
    {
        private readonly ILListContentFactory miFabrica;
        public ContentComponent(ICategoriaRepository categoriaRepository,
                                  ISubCategoriaRepository subCategoriaRepository,
                                  ICursoRepository cursoRepository,
                                  IModuloRepository moduloRepository,
                                  ILeccionRepository leccionRepository,
                                  IClienteRepository clienteRepository,
                                  IBannerRepository bannerRepository):
                                  base()
                                  
        {
            miFabrica = new ListContentFactory(categoriaRepository, subCategoriaRepository, cursoRepository, moduloRepository, leccionRepository,clienteRepository,bannerRepository);
            base.MyFactory = miFabrica;
        }

    }
}

