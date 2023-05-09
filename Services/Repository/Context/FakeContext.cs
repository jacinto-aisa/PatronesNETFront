using Desaprendiendo.Models.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Desaprendiendo.Services.Repository
{
    public partial class FakeContext
    {
        // ReSharper disable once IdentifierTypo
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Lección> Lección { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<SubCategoria> SubCategoria { get; set; }
        private IEnumerable<SubCategoria> GetSubCategoriasPorCatetoria(Categoria categoria)
        {
            var categoriaList = new List<SubCategoria>();
            switch (categoria.Id)
            {
                case 1:
                    {
                        var subcategoria1 =
                            new SubCategoria()
                            {
                                Id = 1,
                                SubCategoria1 = "SubCategoria 1.1",
                                Categoria = categoria.Id,
                                CategoriaNavigation = categoria,
                                ComentarioHtml = "<p>holaaaa</p>"
                            };
                        var subcategoria2 =
                            new SubCategoria()
                            {
                                Id = 2,
                                SubCategoria1 = "SubCategoria 1.2",
                                Categoria = categoria.Id,
                                CategoriaNavigation = categoria,
                                ComentarioHtml = "<p>holaaaa22222</p>"
                            };
                        var subcategoria3 =
                            new SubCategoria()
                            {
                                Id = 3,
                                SubCategoria1 = "SubCategoria 1.3",
                                Categoria = categoria.Id,
                                CategoriaNavigation = categoria,
                                ComentarioHtml = "<p>holaaaa22222sss</p>"
                            };
                        categoriaList.Add(subcategoria1);
                        categoriaList.Add(subcategoria2);

                        break;
                    }
            }
            return categoriaList;

        }



        private IEnumerable<Categoria> GetFakeListOfCategorias()
        {
            var categorias = new List<Categoria>();
            var categoria1 = new Categoria()
            {
                Id = 1,
                Categoria1 = "Fake 01 Categoria",
                ComentarioHtml = "hola html <p> patata </p>",
                Color = "red"
            };
            categorias.Add(categoria1);
            return categorias;
        }
    }

}

