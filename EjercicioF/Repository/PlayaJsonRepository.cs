using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TP2_NicolasSanchez.EjercicioF.Observer;

namespace TP2_NicolasSanchez.EjercicioF.Repository
{
    public class PlayaJsonRepository : IPlayaRepository
    {
        private readonly JsonRepository<MovimientoVehiculo> _jsonRepo;

        public string RutaArchivo => _jsonRepo.RutaArchivo;

        public PlayaJsonRepository(string? rutaArchivo = null)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                // Determina la carpeta Datos dentro de EjercicioF
                string dirActual = Directory.GetCurrentDirectory();
                string carpetaDatos = Path.Combine(dirActual, "EjercicioF", "Datos");

                if (!Directory.Exists(carpetaDatos))
                {
                    // Alternativa: buscar desde el AppDomain BaseDirectory
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string altPath = Path.Combine(basePath, "EjercicioF", "Datos");
                    carpetaDatos = Directory.Exists(altPath) ? altPath : carpetaDatos;
                }

                rutaArchivo = Path.Combine(carpetaDatos, "movimientos_playa.json");
            }

            _jsonRepo = new JsonRepository<MovimientoVehiculo>(rutaArchivo);
        }

        public void RegistrarMovimiento(MovimientoVehiculo movimiento)
        {
            _jsonRepo.Guardar(movimiento);
        }

        public List<MovimientoVehiculo> ObtenerMovimientos()
        {
            return _jsonRepo.ObtenerTodos();
        }

        public decimal ObtenerTotalRecaudado()
        {
            return _jsonRepo.ObtenerTodos()
                .Where(m => m.Tipo == TipoEvento.Egreso)
                .Sum(m => m.Importe);
        }

        public void LimpiarHistorial()
        {
            _jsonRepo.Limpiar();
        }
    }
}
