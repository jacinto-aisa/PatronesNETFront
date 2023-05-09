﻿using Desaprendiendo.Models.DomainModel;
using System;
using System.Collections.Generic;

namespace Desaprendiendo.Views.ViewComponents.ViewModels.ContentItem
{
    public class ContentItem 
    {
        public String ContenidoHTML { get; set; }
        public string Titulo { get; set; }
        public byte[] Imagen { get; set; }
        public byte[] ImagenMiniatura { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public int? ParametroId { get; set; }

        public ICollection<SubCategoria> SubCategoria { get; set; }
    }
}
