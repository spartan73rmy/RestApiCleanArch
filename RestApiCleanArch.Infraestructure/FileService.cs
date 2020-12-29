using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Common;
using RestApiCleanArch.Infraestructure.Options;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace RestApiCleanArch.Infraestructure
{
    public class FileService : IFileService
    {
        private readonly IRandomGenerator random;
        private readonly FileServiceOptions settings;

        public FileService(IRandomGenerator random, IOptions<FileServiceOptions> options)
        {
            this.random = random;
            this.settings = options.Value;
        }

        public Stream GetStreamFile(string hash)
        {
            string filePath = GetFileName(hash);
            return File.OpenRead(filePath);
        }

        public async Task<string> SaveFile(Stream stream)
        {
            stream.Position = 0;
            string hash = random.Guid();
            string filePath = GetFileName(hash);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            using (Stream file = File.Create(filePath))
            {
                await CopyStream(stream, file);
            }
            return hash;
        }

        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        private static async Task CopyStream(Stream input, Stream output)
        {
            // 8Mb
            byte[] buffer = new byte[8 * 1024 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                await output.WriteAsync(buffer, 0, len);
            }
        }

        private string GetFileName(string hash)
        {
            string path = settings.UserFiles;
            string filePath = Path.Combine(path, hash);
            return filePath;
        }
    }
}
