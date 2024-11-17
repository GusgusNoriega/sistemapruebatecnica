using System.IO;
using System.Collections.Generic;

namespace Infraestructura
{
    public class FileService
    {
        private readonly string filePath = "Infraestructura/entidades.txt";

        public IEnumerable<string> GetEntidades()
        {
            if (!File.Exists(filePath)) return new List<string>();
            return File.ReadAllLines(filePath);
        }
    }
}