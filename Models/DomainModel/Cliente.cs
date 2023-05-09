using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desaprendiendo.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string ComentarioHtml { get; set; }
        public byte[] ImagenGrande { get; set; }
        public byte[] ImagenMiniatura { get; set; }
    }
}
