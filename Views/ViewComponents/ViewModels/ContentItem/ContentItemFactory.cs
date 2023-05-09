using Desaprendiendo.Models;
using Desaprendiendo.Models.DomainModel;
using Desaprendiendo.Models.Interfaces;
using Desaprendiendo.Services.Image;
using System.Collections.Generic;
using System.Linq;

namespace Desaprendiendo.Views.ViewComponents.ViewModels.ContentItem
{
    public static class ContentItemFactory
    {
        private static readonly IHelperImage helperImage = new HelperImage();
        public static ContentItem CreateInstanceCategoria(Categoria entidad, IQueryable<SubCategoria> subCategorias)
        {
            var elemento = new ContentItem
            {
                Accion = "index"
            };
            elemento.Titulo = entidad.Categoria1;
            elemento.ContenidoHTML = entidad.ComentarioHtml;
            elemento.ParametroId = entidad.Id;
            elemento.Controlador = "SubCategoriasFront";

            var sub = from x in subCategorias
                      select x;
            elemento.SubCategoria = sub.ToArray<SubCategoria>();
            return elemento;
        }
        public static ContentItem CreateInstance(IEntity entidad)
        {
            var tipoEntidad = entidad.GetType().Name;
            var elemento = new ContentItem
            {
                Accion = "index"
            };

            if (tipoEntidad == "Cliente")
            {
                elemento.Titulo = ((Cliente)entidad).RazonSocial;
                elemento.ContenidoHTML = ((Cliente)entidad).ComentarioHtml;
                elemento.ParametroId = ((Cliente)entidad).Id;
                elemento.ImagenMiniatura = ((Cliente)entidad).ImagenGrande;
            }
            if (tipoEntidad == "Banner")
            {
                elemento.Titulo = ((Banner)entidad).Titulo;
                elemento.ContenidoHTML = ((Banner)entidad).SubTitulo;
                elemento.ParametroId = ((Banner)entidad).Id;
                elemento.ImagenMiniatura = ((Banner)entidad).ImagenGrande;
                elemento.Controlador = ((Banner)entidad).Url;
            }
            if (tipoEntidad == "Categoria")
            {
                elemento.Titulo = ((Categoria)entidad).Categoria1;
                elemento.ContenidoHTML = ((Categoria)entidad).ComentarioHtml;
                elemento.ParametroId = ((Categoria)entidad).Id;
                elemento.Controlador = "SubCategoriasFront";
                elemento.SubCategoria = ((Categoria)entidad).SubCategoria;

            }
            if (tipoEntidad == "SubCategoria")
            {
                elemento.Titulo = ((SubCategoria)entidad).SubCategoria1;
                elemento.ContenidoHTML = ((SubCategoria)entidad).ComentarioHtml;
                elemento.ParametroId = ((SubCategoria)entidad).Id;
                elemento.Controlador = "CursosFront";
            }
            if (tipoEntidad == "Curso")
            {
                elemento.Titulo = ((Curso)entidad).Curso1;
                elemento.ContenidoHTML = ((Curso)entidad).ComentarioHtml;
                elemento.ParametroId = ((Curso)entidad).Id;
                elemento.Controlador = "ModulosFront";
            }
            return elemento;
        }
    }
}
