namespace TP2_NicolasSanchez.EjercicioF.Strategy
{
    public class TarifaNocturna : ITarifa
    {
        public string Nombre => "NOCHE";
        private const decimal PrecioFijo = 4500m;

        public decimal Calcular(int minutos)
        {
            return PrecioFijo;
        }
    }
}
