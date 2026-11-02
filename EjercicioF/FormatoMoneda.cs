using System.Globalization;

namespace TP2_NicolasSanchez.EjercicioF
{
    public static class FormatoMoneda
    {
        public static readonly CultureInfo Cultura = new CultureInfo("es-AR")
        {
            NumberFormat =
            {
                NumberGroupSeparator = ".",
                NumberDecimalSeparator = ","
            }
        };

        public static string Formatear(decimal monto)
        {
            return monto.ToString("#,##0", Cultura);
        }
    }
}
