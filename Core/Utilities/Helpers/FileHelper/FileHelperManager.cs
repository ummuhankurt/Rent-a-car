using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        public string Update(IFormFile file, string imagePath, string root)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath); // Eski dosyayı siliyoruz.
            }

            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuildHelper.CreateGuild();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}
