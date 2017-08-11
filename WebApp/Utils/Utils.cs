using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp.Utils
{
    public static class Utils
    {
        /// <summary>
        /// Convierte un archivo de imagen a un arreglo de bytes.
        /// </summary>
        /// <param name="image">Archivo de imagen</param>
        /// <returns></returns>
        public static byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;

            var reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;
        }

    }
}