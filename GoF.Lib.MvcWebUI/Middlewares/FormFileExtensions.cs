using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GoF.Lib.MvcWebUI.Middlewares
{
    public static class FormFileExtensions
    {
        public static byte[] GetBytes(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                 formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
