using System;

namespace TP2_NicolasSanchez.EjercicioF.Strategy
{
    public class TarifaEstadia : ITarifa
    {
        public string Nombre => "ESTADIA";
        private const decimal PrecioBase = 6000m;
        private const decimal PrecioHoraExtra = 1200m;
        private const int MinutosBase = 720; // 12 horas

        public decimal Calcular(int minutos)
        {
            if (minutos <= MinutosBase)
            {
                return PrecioBase;
            }

            int minutosExtras = minutos - MinutosBase;
            int horasExtras = (int)Math.Ceiling(minutosExtras / 60.0);
            return PrecioBase + (horasExtras * PrecioHoraExtra);
        }
    }
}
