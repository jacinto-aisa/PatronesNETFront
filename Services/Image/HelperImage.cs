using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Desaprendiendo.Services.Image
{
    public class HelperImage : IHelperImage
    {


        public byte[] Resize(int ancho, int alto, byte[] datosImagen)
        {
            System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(datosImagen);
            System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
            System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(ancho, alto, null, IntPtr.Zero);
            System.IO.MemoryStream myResult = new System.IO.MemoryStream();
            newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);  //Or whatever format you want.
            return myResult.ToArray();  //Returns a new byte array.

        }
    }
}
