using System;

namespace Desaprendiendo.Services.Image
{
    public interface IHelperImage
    {
        public byte[] Resize(int ancho, int alto,byte[] datosImagen);
    }
}