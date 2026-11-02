using System;

namespace TP2_NicolasSanchez.EjercicioF.Strategy
{
    public class TarifaHora : ITarifa
    {
        public string Nombre => "HORA";
        private const decimal PrecioPorHora = 1200m;

        public decimal Calcular(int minutos)
        {
            if (minutos <= 0)
                return 0m;

            int horas = (int)Math.Ceiling(minutos / 60.0);
            return horas * PrecioPorHora;
        }
    }
}
