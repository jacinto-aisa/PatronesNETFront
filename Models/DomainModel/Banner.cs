using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desaprendiendo.Models
{
    public partial class Banner
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Url { get; set; }
        public byte[] ImagenGrande { get; set; }
        public byte[] ImagenMiniatura { get; set; }
    }
}
