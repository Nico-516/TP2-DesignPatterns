namespace TP2_NicolasSanchez.EjercicioF.Strategy
{
    public interface ITarifa
    {
        string Nombre { get; }
        decimal Calcular(int minutos);
    }
}
