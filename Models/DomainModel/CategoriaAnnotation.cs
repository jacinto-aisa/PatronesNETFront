using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Desaprendiendo.Models.Interfaces;
using Desaprendiendo.Services.Repository;

namespace Desaprendiendo.Models.DomainModel
{
    public class CategoriaAnnotation 
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Descripción de la categoría")]
        [Required]
        public string Categoria1 { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string ComentarioHtml { get; set; }

        public string Color { get; set; }
    }

    [ModelMetadataType(typeof(CategoriaAnnotation))]
    public partial class Categoria : IEntity
    {

    }
}
