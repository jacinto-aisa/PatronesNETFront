﻿using Desaprendiendo.Services.Repository;
using Desaprendiendo.Views.ViewComponents.ViewModels.ContentItem;
using Desaprendiendo.Views.ViewComponents.ViewModels.ModuloComp;

namespace Desaprendiendo.Views.ViewComponents
{
    public class CardModulosComponent : BaseComponent <ModuloComp>
    {

        private readonly IListModuloCompFactory miFabrica;
        public CardModulosComponent(ICategoriaRepository categoriaRepository,
                                          ISubCategoriaRepository subCategoriaRepository,
                                          ICursoRepository cursoRepository,
                                          IModuloRepository moduloRepository,
                                          ILeccionRepository leccionRepository,
                                          IClienteRepository clienteRepository,
                                          IBannerRepository bannerRepository) :
                                    base()
        {
            miFabrica = new ListModuloCompFactory(categoriaRepository,subCategoriaRepository
                                                 ,cursoRepository, moduloRepository, leccionRepository,clienteRepository
                                                 ,bannerRepository);
            MyFactory = miFabrica;
        }
    }
}

