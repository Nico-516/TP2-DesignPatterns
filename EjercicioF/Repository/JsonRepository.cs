using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TP2_NicolasSanchez.EjercicioF.Repository
{
    public class JsonRepository<T> : IRepository<T>
    {
        private readonly string _rutaArchivo;
        private readonly JsonSerializerOptions _opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public string RutaArchivo => _rutaArchivo;

        public JsonRepository(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
                throw new ArgumentException("La ruta del archivo no puede estar vacía.", nameof(rutaArchivo));

            _rutaArchivo = rutaArchivo;
            AsegurarDirectorio();
        }

        private void AsegurarDirectorio()
        {
            string? directorio = Path.GetDirectoryName(_rutaArchivo);
            if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        public List<T> ObtenerTodos()
        {
            if (!File.Exists(_rutaArchivo))
                return new List<T>();

            try
            {
                string json = File.ReadAllText(_rutaArchivo);
                if (string.IsNullOrWhiteSpace(json))
                    return new List<T>();

                return JsonSerializer.Deserialize<List<T>>(json, _opciones) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[JsonRepository] Error al leer {_rutaArchivo}: {ex.Message}");
                return new List<T>();
            }
        }

        public void Guardar(T entidad)
        {
            var elementos = ObtenerTodos();
            elementos.Add(entidad);
            GuardarTodos(elementos);
        }

        public void GuardarTodos(IEnumerable<T> entidades)
        {
            AsegurarDirectorio();
            string json = JsonSerializer.Serialize(entidades, _opciones);
            File.WriteAllText(_rutaArchivo, json);
        }

        public void Limpiar()
        {
            GuardarTodos(new List<T>());
        }
    }
}
