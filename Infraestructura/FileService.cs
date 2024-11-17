using System;
using System.IO;
using System.Collections.Generic;

namespace Infraestructura
{
    public class FileService
    {
        private readonly string filePath = "Infraestructura/entidades.txt";

        public IEnumerable<string> GetEntidades()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"El archivo no fue encontrado en la ruta: {filePath}");
                }
                return File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Relanzamos la excepción para que el controlador la maneje.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw; // Relanzamos cualquier otra excepción inesperada.
            }
        }
    }
}