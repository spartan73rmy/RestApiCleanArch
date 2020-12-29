using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Enums;
using RestApiCleanArch.Infraestructure.Options;
using RestApiCleanArch.Infraestructure.Resources;
using Microsoft.Extensions.Options;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace RestApiCleanArch.Infraestructure
{
    public class AvatarService : IAvatarService
    {
        private readonly AvatarServiceOptions options;

        public AvatarService(IOptions<AvatarServiceOptions> options)
        {
            this.options = options.Value;
        }
        public bool Exists(string nombre, MySize size)
        {
            string file = Path.Combine(options.Ruta, GetName(nombre, size));
            return File.Exists(file);
        }

        public void Genera(Stream pngStream, string nombre, MySize size)
        {
            int width;
            int height;

            switch (size)
            {
                case MySize.Small:
                    width = options.SizeSmall.Width;
                    height = options.SizeSmall.Height;
                    break;

                case MySize.Medium:
                    width = options.SizeMedium.Width;
                    height = options.SizeMedium.Height;
                    break;

                case MySize.Large:
                    width = options.SizeLarge.Width;
                    height = options.SizeLarge.Height;
                    break;
                default:
                    throw new ArgumentException("El tamano no es valido");
            }

            using (var image = new Bitmap(pngStream))
            {
                var resized = new Bitmap(width, height);
                using (var graphics = Graphics.FromImage(resized))
                {
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(image, 0, 0, width, height);

                    if (!Directory.Exists(options.Ruta))
                    {
                        Directory.CreateDirectory(options.Ruta);
                    }
                    resized.Save(Path.Combine(options.Ruta, GetName(nombre, size)), ImageFormat.Jpeg);
                }
            }
        }

        public Stream Get(string nombre, MySize size)
        {
            string filePath = Path.Combine(options.Ruta, GetName(nombre, size));
            return File.OpenRead(filePath);
        }

        private string GetName(string name, MySize size)
        {
            return $"{name}-{size}.jpg";
        }

        public Stream DefaultAvatar(MySize size)
        {
            switch (size)
            {
                case MySize.Small:
                    return new MemoryStream(Images.avatar_small);
                case MySize.Medium:
                    return new MemoryStream(Images.avatar_medium);
                case MySize.Large:
                    return new MemoryStream(Images.avatar_large);
                default:
                    throw new Exception("No se ha encontrado la imagen");
            }
        }
    }
}
