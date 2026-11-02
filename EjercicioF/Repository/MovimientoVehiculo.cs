using System;
using TP2_NicolasSanchez.EjercicioF.Observer;

namespace TP2_NicolasSanchez.EjercicioF.Repository
{
    public class MovimientoVehiculo
    {
        public string Patente { get; set; } = string.Empty;
        public TipoEvento Tipo { get; set; }
        public string TarifaCodigo { get; set; } = string.Empty;
        public int Minutos { get; set; }
        public decimal Importe { get; set; }
        public int LugaresLibres { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
    }
}
