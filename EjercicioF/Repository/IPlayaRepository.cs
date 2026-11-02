using System.Collections.Generic;

namespace TP2_NicolasSanchez.EjercicioF.Repository
{
    public interface IPlayaRepository
    {
        string RutaArchivo { get; }
        void RegistrarMovimiento(MovimientoVehiculo movimiento);
        List<MovimientoVehiculo> ObtenerMovimientos();
        decimal ObtenerTotalRecaudado();
        void LimpiarHistorial();
    }
}
