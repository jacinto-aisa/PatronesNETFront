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
    public class ClienteAnnotation
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Razón Social")]
        [Required]
        public string RazonSocial { get; set; }

        [DataType(DataType.MultilineText)]
        public string ComentarioHtml { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Subir Imagen en Miniatura")]
        [FileExtensions(Extensions = "jpg")]
        public byte[] ImagenGrande { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Subir Imagen en Miniatura")]
        [FileExtensions(Extensions = "jpg")]
        public byte[] ImagenMiniatura { get; set; }
    }

    [ModelMetadataType(typeof(ClienteAnnotation))]
    public partial class Cliente : IEntity { }

}


