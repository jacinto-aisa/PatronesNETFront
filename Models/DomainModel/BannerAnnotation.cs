using Desaprendiendo.Models.Interfaces;
using Desaprendiendo.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desaprendiendo.Models
{
    public class BannerAnnotation
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required]
        public string Titulo { get; set; }

        [Display(Name ="Subtítulo")]
        [Required]
        public string Subtitulo { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Url del Curso")]
        public string Url { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Subir Imagen en Miniatura")]
        [FileExtensions(Extensions = "jpg")]
        public byte[] ImagenGrande { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Subir Imagen en Miniatura")]
        [FileExtensions(Extensions = "jpg")]
        public byte[] ImagenMiniatura { get; set; }
    }

    [ModelMetadataType(typeof(BannerAnnotation))]
    public partial class Banner :  IEntity { }

}


